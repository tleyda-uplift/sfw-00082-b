#include "unity/unity.h"
#include "stubs.h"
#include "../command_handler.h"

void setUp(void)    { resetStubs(); }
void tearDown(void) {}

/* --- Report ignored --- */

static void test_ignores_report_with_wrong_report_id(void)
{
    uint8_t report[32] = {0};
    report[0] = 0x00; /* wrong report ID */
    report[2] = PACKET_ID_OUTPUT;

    uint8_t result = processReport(report, 32);

    TEST_ASSERT_EQUAL_UINT8(0, result);
    TEST_ASSERT_EQUAL_UINT8(0, stub_setOutputs_called);
    TEST_ASSERT_EQUAL_UINT8(0, stub_configureInputs_called);
}

static void test_ignores_report_shorter_than_3_bytes(void)
{
    uint8_t report[2] = {REPORT_ID_COMMAND, 0x00};

    uint8_t result = processReport(report, 2);

    TEST_ASSERT_EQUAL_UINT8(0, result);
    TEST_ASSERT_EQUAL_UINT8(0, stub_setOutputs_called);
}

static void test_ignores_unknown_packet_id(void)
{
    uint8_t report[32] = {0};
    report[0] = REPORT_ID_COMMAND;
    report[2] = 0xFF; /* unknown packet ID */

    uint8_t result = processReport(report, 32);

    TEST_ASSERT_EQUAL_UINT8(0, result);
    TEST_ASSERT_EQUAL_UINT8(0, stub_setOutputs_called);
    TEST_ASSERT_EQUAL_UINT8(0, stub_configureInputs_called);
}

/* --- Output command (0x37) --- */

static void test_output_report_calls_setOutputs(void)
{
    uint8_t report[32] = {0};
    report[0] = REPORT_ID_COMMAND;
    report[2] = PACKET_ID_OUTPUT;

    processReport(report, 32);

    TEST_ASSERT_EQUAL_UINT8(1, stub_setOutputs_called);
}

static void test_output_report_passes_data_from_byte2(void)
{
    uint8_t report[32] = {0};
    report[0] = REPORT_ID_COMMAND;
    report[2] = PACKET_ID_OUTPUT;
    report[3] = 0x02; /* port */
    report[4] = 0x80; /* output 0 control byte */
    report[5] = 0x64; /* output 0 duty cycle */

    processReport(report, 32);

    /* setOutputs receives report + 2, so its data[0] == report[2] */
    TEST_ASSERT_EQUAL_UINT8(PACKET_ID_OUTPUT, stub_setOutputs_data[0]);
    TEST_ASSERT_EQUAL_UINT8(0x02,             stub_setOutputs_data[1]);
    TEST_ASSERT_EQUAL_UINT8(0x80,             stub_setOutputs_data[2]);
    TEST_ASSERT_EQUAL_UINT8(0x64,             stub_setOutputs_data[3]);
}

static void test_output_report_does_not_call_configureInputs(void)
{
    uint8_t report[32] = {0};
    report[0] = REPORT_ID_COMMAND;
    report[2] = PACKET_ID_OUTPUT;

    processReport(report, 32);

    TEST_ASSERT_EQUAL_UINT8(0, stub_configureInputs_called);
}

static void test_output_report_returns_0(void)
{
    uint8_t report[32] = {0};
    report[0] = REPORT_ID_COMMAND;
    report[2] = PACKET_ID_OUTPUT;

    uint8_t result = processReport(report, 32);

    TEST_ASSERT_EQUAL_UINT8(0, result);
}

/* --- Input config command (0x38) --- */

static void test_input_config_report_calls_configureInputs(void)
{
    uint8_t report[32] = {0};
    report[0] = REPORT_ID_COMMAND;
    report[2] = PACKET_ID_INPUT_CFG;

    processReport(report, 32);

    TEST_ASSERT_EQUAL_UINT8(1, stub_configureInputs_called);
}

static void test_input_config_report_passes_data_from_byte2(void)
{
    uint8_t report[32] = {0};
    report[0] = REPORT_ID_COMMAND;
    report[2] = PACKET_ID_INPUT_CFG;
    report[3] = 0x01; /* port */
    report[4] = 0x81; /* input 0: enabled, pull-up */

    processReport(report, 32);

    TEST_ASSERT_EQUAL_UINT8(PACKET_ID_INPUT_CFG, stub_configureInputs_data[0]);
    TEST_ASSERT_EQUAL_UINT8(0x01,                stub_configureInputs_data[1]);
    TEST_ASSERT_EQUAL_UINT8(0x81,                stub_configureInputs_data[2]);
}

static void test_input_config_report_does_not_call_setOutputs(void)
{
    uint8_t report[32] = {0};
    report[0] = REPORT_ID_COMMAND;
    report[2] = PACKET_ID_INPUT_CFG;

    processReport(report, 32);

    TEST_ASSERT_EQUAL_UINT8(0, stub_setOutputs_called);
}

static void test_input_config_report_returns_1(void)
{
    uint8_t report[32] = {0};
    report[0] = REPORT_ID_COMMAND;
    report[2] = PACKET_ID_INPUT_CFG;

    uint8_t result = processReport(report, 32);

    TEST_ASSERT_EQUAL_UINT8(1, result);
}

/* --- main --- */

int main(void)
{
    UNITY_BEGIN();

    RUN_TEST(test_ignores_report_with_wrong_report_id);
    RUN_TEST(test_ignores_report_shorter_than_3_bytes);
    RUN_TEST(test_ignores_unknown_packet_id);

    RUN_TEST(test_output_report_calls_setOutputs);
    RUN_TEST(test_output_report_passes_data_from_byte2);
    RUN_TEST(test_output_report_does_not_call_configureInputs);
    RUN_TEST(test_output_report_returns_0);

    RUN_TEST(test_input_config_report_calls_configureInputs);
    RUN_TEST(test_input_config_report_passes_data_from_byte2);
    RUN_TEST(test_input_config_report_does_not_call_setOutputs);
    RUN_TEST(test_input_config_report_returns_1);

    return UNITY_END();
}
