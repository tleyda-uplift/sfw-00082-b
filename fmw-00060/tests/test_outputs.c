#include "unity/unity.h"
#include "output_hal_stub.h"
#include "../outputs.h"

void setUp(void)    { resetHalStub(); }
void tearDown(void) {}

/* Helpers ----------------------------------------------------------------- */

/* Builds a port-format cmdData buffer.
 * output_index: which of the 8 per-port slots (0–7) to configure
 * control:      control byte (bit 7=changeEnabled, bits 6:4=function)
 * duty:         PWM duty cycle byte
 * port:         1–3; port 0 triggers original (legacy) format
 */
static void makePortCmd(uint8_t *buf, int buf_len,
                        int output_slot, uint8_t control, uint8_t duty,
                        uint8_t port)
{
    int i;
    for (i = 0; i < buf_len; i++) buf[i] = 0;
    buf[0] = 0x37;   /* packet ID */
    buf[1] = port;
    buf[3 + output_slot * 3]     = control;
    buf[3 + output_slot * 3 + 1] = duty;
}

/* --- change-enable bit --------------------------------------------------- */

static void test_changeDisabled_noHalCalls(void)
{
    uint8_t cmd[32];
    makePortCmd(cmd, 32, 0, 0x00 /* changeEnabled=0, Off */, 0, 1);

    setOutputs(cmd);

    TEST_ASSERT_EQUAL_INT(0, hal_call_count);
}

/* --- OutputOff ----------------------------------------------------------- */

static void test_off_pwmCapable_callsSetPwm0(void)
{
    uint8_t cmd[32];
    hal_pwm_capable[0] = true;
    makePortCmd(cmd, 32, 0, 0x80 /* changeEnabled, Off */, 0, 1);

    setOutputs(cmd);

    TEST_ASSERT_EQUAL_INT(1, hal_call_count);
    TEST_ASSERT_EQUAL_INT(HAL_SET_PWM, hal_calls[0].type);
    TEST_ASSERT_EQUAL_INT(0,           hal_calls[0].index);
    TEST_ASSERT_EQUAL_UINT(0,          hal_calls[0].value);
}

static void test_off_notPwmCapable_callsGpioLow(void)
{
    uint8_t cmd[32];
    hal_pwm_capable[0] = false;
    makePortCmd(cmd, 32, 0, 0x80, 0, 1);

    setOutputs(cmd);

    TEST_ASSERT_EQUAL_INT(1,            hal_call_count);
    TEST_ASSERT_EQUAL_INT(HAL_GPIO_LOW, hal_calls[0].type);
    TEST_ASSERT_EQUAL_INT(0,            hal_calls[0].index);
}

/* --- OutputOn ------------------------------------------------------------ */

static void test_on_pwmCapable_callsSetPwmMax(void)
{
    uint8_t cmd[32];
    hal_pwm_capable[0] = true;
    makePortCmd(cmd, 32, 0, 0x90 /* changeEnabled | BIT4 */, 0, 1);

    setOutputs(cmd);

    TEST_ASSERT_EQUAL_INT(1,           hal_call_count);
    TEST_ASSERT_EQUAL_INT(HAL_SET_PWM, hal_calls[0].type);
    TEST_ASSERT_EQUAL_INT(0,           hal_calls[0].index);
    TEST_ASSERT_EQUAL_UINT(255,        hal_calls[0].value);
}

static void test_on_notPwmCapable_callsGpioHigh(void)
{
    uint8_t cmd[32];
    hal_pwm_capable[0] = false;
    makePortCmd(cmd, 32, 0, 0x90, 0, 1);

    setOutputs(cmd);

    TEST_ASSERT_EQUAL_INT(1,             hal_call_count);
    TEST_ASSERT_EQUAL_INT(HAL_GPIO_HIGH, hal_calls[0].type);
    TEST_ASSERT_EQUAL_INT(0,             hal_calls[0].index);
}

/* --- OutputPWM ----------------------------------------------------------- */

static void test_pwm_pwmCapable_callsSetPwmWithDutyCycle(void)
{
    uint8_t cmd[32];
    hal_pwm_capable[0] = true;
    makePortCmd(cmd, 32, 0, 0xA0 /* changeEnabled | BIT5 */, 128, 1);

    setOutputs(cmd);

    TEST_ASSERT_EQUAL_INT(1,           hal_call_count);
    TEST_ASSERT_EQUAL_INT(HAL_SET_PWM, hal_calls[0].type);
    TEST_ASSERT_EQUAL_INT(0,           hal_calls[0].index);
    TEST_ASSERT_EQUAL_UINT(128,        hal_calls[0].value);
}

static void test_pwm_notPwmCapable_nonZeroDuty_callsGpioHigh(void)
{
    uint8_t cmd[32];
    hal_pwm_capable[0] = false;
    makePortCmd(cmd, 32, 0, 0xA0, 64, 1);

    setOutputs(cmd);

    TEST_ASSERT_EQUAL_INT(1,             hal_call_count);
    TEST_ASSERT_EQUAL_INT(HAL_GPIO_HIGH, hal_calls[0].type);
}

static void test_pwm_notPwmCapable_zeroDuty_callsGpioLow(void)
{
    uint8_t cmd[32];
    hal_pwm_capable[0] = false;
    makePortCmd(cmd, 32, 0, 0xA0, 0, 1);

    setOutputs(cmd);

    TEST_ASSERT_EQUAL_INT(1,            hal_call_count);
    TEST_ASSERT_EQUAL_INT(HAL_GPIO_LOW, hal_calls[0].type);
}

/* --- OutputNoOp ---------------------------------------------------------- */

static void test_noOp_doesNotCallHal(void)
{
    uint8_t cmd[32];
    hal_pwm_capable[0] = true;
    /* changeEnabled=1, func bits 5 and 4 both set → NoOp */
    makePortCmd(cmd, 32, 0, 0xB0, 0, 1);

    setOutputs(cmd);

    TEST_ASSERT_EQUAL_INT(0, hal_call_count);
}

/* --- Port format index mapping ------------------------------------------- */

static void test_portFormat_port1_mapsToStartIndex0(void)
{
    uint8_t cmd[32];
    makePortCmd(cmd, 32, 0, 0x80, 0, 1); /* port 1, slot 0 → logical index 0 */

    setOutputs(cmd);

    TEST_ASSERT_EQUAL_INT(0, hal_calls[0].index);
}

static void test_portFormat_port2_mapsToStartIndex8(void)
{
    uint8_t cmd[32];
    makePortCmd(cmd, 32, 0, 0x80, 0, 2); /* port 2, slot 0 → logical index 8 */

    setOutputs(cmd);

    TEST_ASSERT_EQUAL_INT(8, hal_calls[0].index);
}

static void test_portFormat_port3_mapsToStartIndex16(void)
{
    uint8_t cmd[32];
    makePortCmd(cmd, 32, 0, 0x80, 0, 3); /* port 3, slot 0 → logical index 16 */

    setOutputs(cmd);

    TEST_ASSERT_EQUAL_INT(16, hal_calls[0].index);
}

static void test_portFormat_setsAllEightOutputsInPort(void)
{
    int i;
    uint8_t cmd[32] = {0};
    cmd[0] = 0x37;
    cmd[1] = 1; /* port 1 */
    /* set changeEnabled for all 8 output slots */
    for (i = 0; i < 8; i++)
        cmd[3 + i * 3] = 0x80;

    setOutputs(cmd);

    TEST_ASSERT_EQUAL_INT(8, hal_call_count);
    for (i = 0; i < 8; i++)
        TEST_ASSERT_EQUAL_INT(i, hal_calls[i].index);
}

/* --- Original (legacy) format index mapping ------------------------------ */

static void test_originalFormat_mapsToLegacyLedIndices(void)
{
    /* Expected logical indices for the 9 LED outputs in original format */
    const int expected[] = {2, 3, 4, 5, 8, 9, 20, 21, 22};
    int i;
    uint8_t cmd[32] = {0};
    cmd[0] = 0x37;
    cmd[1] = 0; /* port == 0 → original format */
    /* set changeEnabled for all 9 slots (at byte offsets 3,6,9,...,27) */
    for (i = 0; i < 9; i++)
        cmd[3 + i * 3] = 0x80;

    setOutputs(cmd);

    TEST_ASSERT_EQUAL_INT(9, hal_call_count);
    for (i = 0; i < 9; i++)
        TEST_ASSERT_EQUAL_INT(expected[i], hal_calls[i].index);
}

/* --- main ---------------------------------------------------------------- */

int main(void)
{
    UNITY_BEGIN();

    RUN_TEST(test_changeDisabled_noHalCalls);

    RUN_TEST(test_off_pwmCapable_callsSetPwm0);
    RUN_TEST(test_off_notPwmCapable_callsGpioLow);

    RUN_TEST(test_on_pwmCapable_callsSetPwmMax);
    RUN_TEST(test_on_notPwmCapable_callsGpioHigh);

    RUN_TEST(test_pwm_pwmCapable_callsSetPwmWithDutyCycle);
    RUN_TEST(test_pwm_notPwmCapable_nonZeroDuty_callsGpioHigh);
    RUN_TEST(test_pwm_notPwmCapable_zeroDuty_callsGpioLow);

    RUN_TEST(test_noOp_doesNotCallHal);

    RUN_TEST(test_portFormat_port1_mapsToStartIndex0);
    RUN_TEST(test_portFormat_port2_mapsToStartIndex8);
    RUN_TEST(test_portFormat_port3_mapsToStartIndex16);
    RUN_TEST(test_portFormat_setsAllEightOutputsInPort);

    RUN_TEST(test_originalFormat_mapsToLegacyLedIndices);

    return UNITY_END();
}
