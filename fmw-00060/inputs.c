#include <stdint.h>
#include <stdbool.h>

#include "inputs.h"
#include "input_hal.h"

typedef struct {
    bool    enabled;
    bool    pullUp;
    bool    lastState;
    uint8_t count;
    bool    state;
} InputState;

static InputState inputStates[24];

static const uint8_t MAX_INPUT_DEBOUNCE_COUNT = 5;
static uint8_t rtcDivider = 0;

extern uint8_t sendReportFlag;

void initializeInputs(void)
{
    int idx;
    rtcDivider = 0;
    for (idx = 0; idx < 24; ++idx) {
        inputStates[idx].enabled   = false;
        inputStates[idx].pullUp    = false;
        inputStates[idx].state     = false;
        inputStates[idx].lastState = false;
        inputStates[idx].count     = 0;
    }
    hal_initializeTimer();
}

static void configureInput(int index, uint8_t configData)
{
    inputStates[index].enabled   = (configData & 0x80) != 0;
    inputStates[index].pullUp    = (configData & 0x01) != 0;
    inputStates[index].state     = false;
    inputStates[index].lastState = false;
    inputStates[index].count     = 0;
    hal_configureGpio(index,
                      inputStates[index].enabled,
                      inputStates[index].pullUp);
}

void configureInputs(uint8_t *configData)
{
    uint8_t port = configData[1] - 1;
    int stateIndex = port * 8;
    int idx;
    for (idx = 0; idx < 8; ++idx) {
        configureInput(stateIndex + idx, configData[3 + idx]);
    }
}

void getInputsReport(uint8_t *reportBuffer)
{
    uint8_t idx;
    reportBuffer[0] = 0x40;
    for (idx = 0; idx < 24; ++idx) {
        uint8_t bufferIndex = (idx / 2) + 1;
        uint8_t bitShift    = ((idx % 2) == 0) ? 4 : 0;
        uint8_t data        = 0;
        if (inputStates[idx].enabled) data |= 0x08;
        if (inputStates[idx].pullUp)  data |= 0x04;
        if (inputStates[idx].state)   data |= 0x01;
        reportBuffer[bufferIndex] |= (uint8_t)(data << bitShift);
    }
}

void readInputs(void)
{
    uint8_t idx;
    for (idx = 0; idx < 24; ++idx) {
        if (inputStates[idx].enabled) {
            bool pinHigh = hal_readGpioPin(idx);
            if (pinHigh == inputStates[idx].lastState) {
                if (inputStates[idx].count < MAX_INPUT_DEBOUNCE_COUNT) {
                    inputStates[idx].count++;
                    if (inputStates[idx].count == MAX_INPUT_DEBOUNCE_COUNT) {
                        inputStates[idx].state = pinHigh;
                    }
                }
            } else {
                inputStates[idx].count = 0;
            }
            inputStates[idx].lastState = pinHigh;
        }
    }
}

void inputs_onRtcTick(void)
{
    if ((++rtcDivider % 2) == 0) {
        readInputs();
        sendReportFlag = 1;
    }
}
