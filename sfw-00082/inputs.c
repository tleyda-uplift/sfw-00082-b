#include "gpio.h"
#include "rtc_a.h"

#include "inputs.h"
#include "main.h"

typedef struct {
    bool enabled;
    bool pullUp;
    uint8_t lastState;
    uint8_t currentState;
    uint8_t count;
    bool state;
} InputState;

static InputState inputStates[24];

static const uint8_t MAX_INPUT_DEBOUNCE_COUNT = 5;

extern uint8_t sendReportFlag;

void initializeInputs(){
    int idx = 0;

    for (; idx < 24; ++idx) {
        inputStates[idx].enabled = false;
        inputStates[idx].pullUp = false;
        inputStates[idx].state = false;
        inputStates[idx].lastState = GPIO_INPUT_PIN_LOW;
        inputStates[idx].currentState = GPIO_INPUT_PIN_LOW;
        inputStates[idx].count = 0;
    }

    RTC_A_initCounter(RTC_A_BASE,
                      RTC_A_CLOCKSELECT_ACLK,
                      RTC_A_COUNTERSIZE_8BIT);
    RTC_A_setCounterValue(RTC_A_BASE, 1);
    RTC_A_enableInterrupt(RTC_A_BASE,
                          RTC_A_TIME_EVENT_INTERRUPT);
    RTC_A_startClock(RTC_A_BASE);
}

uint8_t getGpioPort(BYTE inputPort) {
    switch (inputPort) {
    case 2:
        return GPIO_PORT_P6;
    case 1:
        return GPIO_PORT_P4;
    default:
        return GPIO_PORT_P3;
    }
}

void configureGpio(int index) {
    uint8_t port = index / 8;
    uint8_t gpioPort = getGpioPort(port);
    uint8_t pin = 0x01 << (index % 8);

    if (inputStates[index].enabled) {
        if (inputStates[index].pullUp) {
            GPIO_setAsInputPinWithPullUpResistor(gpioPort, pin);
        } else {
            GPIO_setAsInputPinWithPullDownResistor(gpioPort, pin);
        }
    } else {
        GPIO_setAsInputPin(gpioPort, pin);
    }
}

void configureInput(int index, BYTE configData) {
    inputStates[index].enabled = (configData & 0x80) > 0;
    inputStates[index].pullUp = (configData & 0x01) > 0;
    inputStates[index].state = false;
    inputStates[index].lastState = GPIO_INPUT_PIN_LOW;
    inputStates[index].currentState = GPIO_INPUT_PIN_LOW;
    inputStates[index].count = 0;

    configureGpio(index);
}

void configureInputs(BYTE *configData) {
    BYTE port = configData[1] - 1;

    int stateIndex = port * 8;
    int idx = 0;

    for (; idx < 8; ++idx) {
        configureInput(stateIndex + idx, *(configData + 3 + idx));
    }
}

void getInputsReport(BYTE *reportBuffer) {
    uint8_t idx;
    reportBuffer[0] = 0x40;

    for (idx =  0; idx < 24; ++idx) {
        uint8_t bufferIndex = (idx / 2) + 1;
        uint8_t bitShift = ((idx % 2) == 0) ? 4 : 0;
        uint8_t data = 0;
        if (inputStates[idx].enabled) {
            data |= 0x08;
        }
        if (inputStates[idx].pullUp) {
            data |= 0x04;
        }
        if (inputStates[idx].state) {
            data |= 0x01;
        }
        reportBuffer[bufferIndex] |= data << bitShift;    
    }
}

void readInputs() {
    uint8_t idx;
    for (idx = 0; idx < 24; ++idx) {
        if (inputStates[idx].enabled) {
            uint8_t port = idx / 8;
            uint8_t gpioPort = getGpioPort(port);
            uint8_t pin = 0x01 << (idx % 8);

            inputStates[idx].currentState = GPIO_getInputPinValue(gpioPort, pin);

            if (inputStates[idx].currentState == inputStates[idx].lastState) {
                if (inputStates[idx].count < MAX_INPUT_DEBOUNCE_COUNT) {
                    inputStates[idx].count++;
                    if (inputStates[idx].count == MAX_INPUT_DEBOUNCE_COUNT) {
                        inputStates[idx].state = inputStates[idx].currentState == GPIO_INPUT_PIN_HIGH;
                        sendReportFlag = 1;
                    }
                }
            } else {
                inputStates[idx].count = 0;
            }

            inputStates[idx].lastState = inputStates[idx].currentState;
        }
    }
}

#pragma vector=RTC_VECTOR
__interrupt void RTC_A_ISR(void)
{
    switch(__even_in_range(RTCIV,16))
    {
        case 0: break;  // No interrupts
        case 2:         // RTCIFG
            // Toggle LED or set flag
            break;
        case 4:         // RTCCNTIFG (Counter interrupt)
            // Handle timer interrupt
            readInputs();
            break;
        default: break;
    }
    __bic_SR_register_on_exit(LPM3_bits);
    __no_operation();
}
