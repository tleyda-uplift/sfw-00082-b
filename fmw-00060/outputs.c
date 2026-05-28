#include <stdint.h>
#include <stdbool.h>

#include "output_hal.h"
#include "outputs.h"

#define PWM_MAX_COUNT 255

typedef enum {
    OutputOff,
    OutputOn,
    OutputPWM,
    OutputNoOp,
} OutputCommand;

void initializeOutputs(void)
{
    hal_initializeHardware();
}

static OutputCommand getCommand(uint8_t cmdByte)
{
    uint8_t func = cmdByte & 0x70; /* bits 6:4 */
    if (func == 0x20) return OutputPWM;
    if (func == 0x10) return OutputOn;
    if (func == 0x00) return OutputOff;
    return OutputNoOp;
}

static void setOutput(int index, uint8_t *cmdData)
{
    if (!(cmdData[0] & 0x80)) /* change-enable bit 7 */
        return;

    switch (getCommand(cmdData[0]))
    {
        case OutputOff:
            if (hal_isPwmCapable(index))
                hal_setPwmValue(index, 0);
            else
                hal_setGpioLow(index);
            break;

        case OutputOn:
            if (hal_isPwmCapable(index))
                hal_setPwmValue(index, PWM_MAX_COUNT);
            else
                hal_setGpioHigh(index);
            break;

        case OutputPWM:
            if (hal_isPwmCapable(index))
                hal_setPwmValue(index, cmdData[1]);
            else if (cmdData[1] > 0)
                hal_setGpioHigh(index);
            else
                hal_setGpioLow(index);
            break;

        default:
            break;
    }
}

static bool isOriginalMessageFormat(uint8_t *cmdData)
{
    return cmdData[1] == 0;
}

static void setOutputsOriginalFormat(uint8_t *cmdData)
{
    setOutput(2,  cmdData + 3);
    setOutput(3,  cmdData + 6);
    setOutput(4,  cmdData + 9);
    setOutput(5,  cmdData + 12);
    setOutput(8,  cmdData + 15);
    setOutput(9,  cmdData + 18);
    setOutput(20, cmdData + 21);
    setOutput(21, cmdData + 24);
    setOutput(22, cmdData + 27);
}

static void setOutputsPortFormat(uint8_t *cmdData)
{
    int startIndex = (cmdData[1] - 1) * 8;

    setOutput(startIndex++, cmdData + 3);
    setOutput(startIndex++, cmdData + 6);
    setOutput(startIndex++, cmdData + 9);
    setOutput(startIndex++, cmdData + 12);
    setOutput(startIndex++, cmdData + 15);
    setOutput(startIndex++, cmdData + 18);
    setOutput(startIndex++, cmdData + 21);
    setOutput(startIndex++, cmdData + 24);
}

void setOutputs(uint8_t *cmdData)
{
    if (isOriginalMessageFormat(cmdData))
        setOutputsOriginalFormat(cmdData);
    else
        setOutputsPortFormat(cmdData);
}
