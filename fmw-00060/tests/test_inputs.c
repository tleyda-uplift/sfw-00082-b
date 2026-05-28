#include "unity/unity.h"
#include "input_hal_stub.h"
#include "../inputs.h"

uint8_t sendReportFlag = 0;

void setUp(void)
{
    resetInputHalStub();
    sendReportFlag = 0;
    initializeInputs();
}

void tearDown(void) {}

/* Helpers ----------------------------------------------------------------- */

/* Builds a configureInputs buffer.
 * port:       1–3
 * configData: array of 8 config bytes (bit7=enabled, bit0=pullUp)
 */
static void makeInputCmd(uint8_t *buf, int buf_len, uint8_t port,
                         const uint8_t *cfgBytes)
{
    int i;
    for (i = 0; i < buf_len; i++) buf[i] = 0;
    buf[0] = 0x38;   /* packet ID */
    buf[1] = port;
    for (i = 0; i < 8; i++)
        buf[3 + i] = cfgBytes[i];
}

/* Drive a pin to a stable debounced state.
 * First call resets the debounce counter (pin changed); 5 further calls
 * increment the counter to MAX and latch the state.
 */
static void stabilizePin(int index, bool high)
{
    int i;
    hal_pin_states[index] = high;
    readInputs();                        /* lastState changes, count resets */
    for (i = 0; i < 5; i++)
        readInputs();                    /* count 1→5: state latches on 5th */
}

/* --- initializeInputs ---------------------------------------------------- */

static void test_initialize_callsTimerInit(void)
{
    /* setUp already called initializeInputs */
    TEST_ASSERT_EQUAL_INT(1, hal_timer_init_count);
}

/* --- configureInputs: config byte interpretation ------------------------- */

static void test_configureInput_enabledBit_setsEnabled(void)
{
    uint8_t cfg[8] = {0x80, 0, 0, 0, 0, 0, 0, 0};
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 1, cfg);

    configureInputs(cmd);

    TEST_ASSERT_TRUE(gpio_cfg_calls[0].enabled);
}

static void test_configureInput_enabledBitClear_notEnabled(void)
{
    uint8_t cfg[8] = {0x00, 0, 0, 0, 0, 0, 0, 0};
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 1, cfg);

    configureInputs(cmd);

    TEST_ASSERT_FALSE(gpio_cfg_calls[0].enabled);
}

static void test_configureInput_pullUpBit_setsPullUp(void)
{
    uint8_t cfg[8] = {0x81, 0, 0, 0, 0, 0, 0, 0};
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 1, cfg);

    configureInputs(cmd);

    TEST_ASSERT_TRUE(gpio_cfg_calls[0].pullUp);
}

static void test_configureInput_pullUpBitClear_notPullUp(void)
{
    uint8_t cfg[8] = {0x80, 0, 0, 0, 0, 0, 0, 0};
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 1, cfg);

    configureInputs(cmd);

    TEST_ASSERT_FALSE(gpio_cfg_calls[0].pullUp);
}

/* --- configureInputs: port-to-index mapping ------------------------------ */

static void test_configureInputs_port1_mapsToIndices0to7(void)
{
    uint8_t cfg[8] = {0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80};
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 1, cfg);

    configureInputs(cmd);

    TEST_ASSERT_EQUAL_INT(8, gpio_cfg_call_count);
    TEST_ASSERT_EQUAL_INT(0, gpio_cfg_calls[0].index);
    TEST_ASSERT_EQUAL_INT(7, gpio_cfg_calls[7].index);
}

static void test_configureInputs_port2_mapsToIndices8to15(void)
{
    uint8_t cfg[8] = {0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80};
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 2, cfg);

    configureInputs(cmd);

    TEST_ASSERT_EQUAL_INT(8,  gpio_cfg_call_count);
    TEST_ASSERT_EQUAL_INT(8,  gpio_cfg_calls[0].index);
    TEST_ASSERT_EQUAL_INT(15, gpio_cfg_calls[7].index);
}

static void test_configureInputs_port3_mapsToIndices16to23(void)
{
    uint8_t cfg[8] = {0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80};
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 3, cfg);

    configureInputs(cmd);

    TEST_ASSERT_EQUAL_INT(8,  gpio_cfg_call_count);
    TEST_ASSERT_EQUAL_INT(16, gpio_cfg_calls[0].index);
    TEST_ASSERT_EQUAL_INT(23, gpio_cfg_calls[7].index);
}

/* --- readInputs: debounce logic ------------------------------------------ */

static void test_readInputs_disabledInput_notPolled(void)
{
    /* input 0 not configured, so hal_readGpioPin should never be called */
    readInputs();
    TEST_ASSERT_EQUAL_INT(0, hal_pin_read_count);
}

static void test_readInputs_pinStableHigh_stateSettlesTrue(void)
{
    uint8_t cfg[8] = {0x80, 0, 0, 0, 0, 0, 0, 0}; /* enable pin 0 */
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 1, cfg);
    configureInputs(cmd);

    stabilizePin(0, true);

    uint8_t report[13] = {0};
    getInputsReport(report);
    /* pin 0 is even → high nibble of report[1]; state bit is bit 0 */
    TEST_ASSERT_TRUE((report[1] >> 4) & 0x01);
}

static void test_readInputs_pinStableLow_stateSettlesFalse(void)
{
    uint8_t cfg[8] = {0x80, 0, 0, 0, 0, 0, 0, 0};
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 1, cfg);
    configureInputs(cmd);

    /* pin stays low (default) – drive to high then back to low */
    stabilizePin(0, true);
    stabilizePin(0, false);

    uint8_t report[13] = {0};
    getInputsReport(report);
    TEST_ASSERT_FALSE((report[1] >> 4) & 0x01);
}

static void test_readInputs_pinBounce_doesNotSetState(void)
{
    int i;
    uint8_t cfg[8] = {0x80, 0, 0, 0, 0, 0, 0, 0};
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 1, cfg);
    configureInputs(cmd);

    /* alternating reads: pin flips each time, count never reaches 5 */
    for (i = 0; i < 10; i++) {
        hal_pin_states[0] = (i % 2 == 0);
        readInputs();
    }

    uint8_t report[13] = {0};
    getInputsReport(report);
    TEST_ASSERT_FALSE((report[1] >> 4) & 0x01);
}

/* --- getInputsReport ----------------------------------------------------- */

static void test_report_headerByte(void)
{
    uint8_t report[13] = {0};
    getInputsReport(report);
    TEST_ASSERT_EQUAL_HEX8(0x40, report[0]);
}

static void test_report_enabledBit(void)
{
    uint8_t cfg[8] = {0x80, 0, 0, 0, 0, 0, 0, 0}; /* enable pin 0 */
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 1, cfg);
    configureInputs(cmd);

    uint8_t report[13] = {0};
    getInputsReport(report);
    /* pin 0: even → high nibble of report[1]; enabled = bit 3 */
    TEST_ASSERT_TRUE((report[1] >> 4) & 0x08);
}

static void test_report_pullUpBit(void)
{
    uint8_t cfg[8] = {0x81, 0, 0, 0, 0, 0, 0, 0}; /* enable + pullUp */
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 1, cfg);
    configureInputs(cmd);

    uint8_t report[13] = {0};
    getInputsReport(report);
    /* pullUp = bit 2 of nibble */
    TEST_ASSERT_TRUE((report[1] >> 4) & 0x04);
}

static void test_report_stateBit_afterDebounce(void)
{
    uint8_t cfg[8] = {0x80, 0, 0, 0, 0, 0, 0, 0};
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 1, cfg);
    configureInputs(cmd);

    stabilizePin(0, true);

    uint8_t report[13] = {0};
    getInputsReport(report);
    /* state = bit 0 of nibble */
    TEST_ASSERT_TRUE((report[1] >> 4) & 0x01);
}

static void test_report_evenInputInHighNibble_oddInLowNibble(void)
{
    /* enable pin 0 (even → high nibble) and pin 1 (odd → low nibble) */
    uint8_t cfg[8] = {0x80, 0x80, 0, 0, 0, 0, 0, 0};
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 1, cfg);
    configureInputs(cmd);

    uint8_t report[13] = {0};
    getInputsReport(report);

    /* both enabled; pin 0 in high nibble, pin 1 in low nibble of report[1] */
    TEST_ASSERT_TRUE((report[1] >> 4) & 0x08);  /* pin 0 enabled bit */
    TEST_ASSERT_TRUE(report[1]        & 0x08);  /* pin 1 enabled bit */
}

static void test_report_port2_inBytes5to8(void)
{
    /* enable pin 8 (port 2, slot 0) → even → high nibble of report[5] */
    uint8_t cfg[8] = {0x80, 0, 0, 0, 0, 0, 0, 0};
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 2, cfg);
    configureInputs(cmd);

    uint8_t report[13] = {0};
    getInputsReport(report);
    /* index 8: bufferIndex = 8/2+1 = 5, bitShift=4 (even) */
    TEST_ASSERT_TRUE((report[5] >> 4) & 0x08);
}

/* --- inputs_onRtcTick: divider and flag ---------------------------------- */

static void test_onRtcTick_firstTick_doesNotReadOrSetFlag(void)
{
    uint8_t cfg[8] = {0x80, 0, 0, 0, 0, 0, 0, 0};
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 1, cfg);
    configureInputs(cmd);
    hal_pin_read_count = 0;

    inputs_onRtcTick();

    TEST_ASSERT_EQUAL_INT(0, hal_pin_read_count);
    TEST_ASSERT_EQUAL_INT(0, sendReportFlag);
}

static void test_onRtcTick_secondTick_readsAndSetsFlag(void)
{
    uint8_t cfg[8] = {0x80, 0, 0, 0, 0, 0, 0, 0};
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 1, cfg);
    configureInputs(cmd);
    hal_pin_read_count = 0;

    inputs_onRtcTick();
    inputs_onRtcTick();

    TEST_ASSERT_EQUAL_INT(1, hal_pin_read_count);
    TEST_ASSERT_EQUAL_INT(1, sendReportFlag);
}

static void test_onRtcTick_thirdTick_doesNotReadAgain(void)
{
    uint8_t cfg[8] = {0x80, 0, 0, 0, 0, 0, 0, 0};
    uint8_t cmd[12];
    makeInputCmd(cmd, 12, 1, cfg);
    configureInputs(cmd);
    hal_pin_read_count = 0;

    inputs_onRtcTick();
    inputs_onRtcTick();
    sendReportFlag = 0;
    inputs_onRtcTick();

    TEST_ASSERT_EQUAL_INT(1, hal_pin_read_count);
    TEST_ASSERT_EQUAL_INT(0, sendReportFlag);
}

/* --- main ---------------------------------------------------------------- */

int main(void)
{
    UNITY_BEGIN();

    RUN_TEST(test_initialize_callsTimerInit);

    RUN_TEST(test_configureInput_enabledBit_setsEnabled);
    RUN_TEST(test_configureInput_enabledBitClear_notEnabled);
    RUN_TEST(test_configureInput_pullUpBit_setsPullUp);
    RUN_TEST(test_configureInput_pullUpBitClear_notPullUp);

    RUN_TEST(test_configureInputs_port1_mapsToIndices0to7);
    RUN_TEST(test_configureInputs_port2_mapsToIndices8to15);
    RUN_TEST(test_configureInputs_port3_mapsToIndices16to23);

    RUN_TEST(test_readInputs_disabledInput_notPolled);
    RUN_TEST(test_readInputs_pinStableHigh_stateSettlesTrue);
    RUN_TEST(test_readInputs_pinStableLow_stateSettlesFalse);
    RUN_TEST(test_readInputs_pinBounce_doesNotSetState);

    RUN_TEST(test_report_headerByte);
    RUN_TEST(test_report_enabledBit);
    RUN_TEST(test_report_pullUpBit);
    RUN_TEST(test_report_stateBit_afterDebounce);
    RUN_TEST(test_report_evenInputInHighNibble_oddInLowNibble);
    RUN_TEST(test_report_port2_inBytes5to8);

    RUN_TEST(test_onRtcTick_firstTick_doesNotReadOrSetFlag);
    RUN_TEST(test_onRtcTick_secondTick_readsAndSetsFlag);
    RUN_TEST(test_onRtcTick_thirdTick_doesNotReadAgain);

    return UNITY_END();
}
