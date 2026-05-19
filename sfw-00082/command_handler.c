#include "command_handler.h"
#include "outputs.h"
#include "inputs.h"

uint8_t processReport(const uint8_t *report, uint8_t len)
{
    if (len < 3)
        return 0;

    if (report[0] != REPORT_ID_COMMAND)
        return 0;

    if (report[2] == PACKET_ID_OUTPUT)
    {
        setOutputs((uint8_t *)(report + 2));
        return 0;
    }

    if (report[2] == PACKET_ID_INPUT_CFG)
    {
        configureInputs((uint8_t *)(report + 2));
        return 1;
    }

    return 0;
}
