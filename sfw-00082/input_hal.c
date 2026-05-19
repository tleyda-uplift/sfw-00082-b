#include <msp430.h>

#include "gpio.h"
#include "rtc_a.h"

#include "input_hal.h"
#include "inputs.h"

static uint8_t getGpioPort(int port)
{
    switch (port) {
    case 2:  return GPIO_PORT_P6;
    case 1:  return GPIO_PORT_P4;
    default: return GPIO_PORT_P3;
    }
}

void hal_initializeTimer(void)
{
    RTC_A_initCounter(RTC_A_BASE,
                      RTC_A_CLOCKSELECT_ACLK,
                      RTC_A_COUNTERSIZE_8BIT);
    RTC_A_setCounterValue(RTC_A_BASE, 2);
    RTC_A_enableInterrupt(RTC_A_BASE,
                          RTC_A_TIME_EVENT_INTERRUPT);
    RTC_A_startClock(RTC_A_BASE);
}

void hal_configureGpio(int index, bool enabled, bool pullUp)
{
    uint8_t gpioPort = getGpioPort(index / 8);
    uint8_t pin      = (uint8_t)(0x01 << (index % 8));

    if (enabled) {
        if (pullUp) {
            GPIO_setAsInputPinWithPullUpResistor(gpioPort, pin);
        } else {
            GPIO_setAsInputPinWithPullDownResistor(gpioPort, pin);
        }
    } else {
        GPIO_setAsInputPin(gpioPort, pin);
    }
}

bool hal_readGpioPin(int index)
{
    uint8_t gpioPort = getGpioPort(index / 8);
    uint8_t pin      = (uint8_t)(0x01 << (index % 8));
    return GPIO_getInputPinValue(gpioPort, pin) == GPIO_INPUT_PIN_HIGH;
}

#pragma vector=RTC_VECTOR
__interrupt void RTC_A_ISR(void)
{
    switch (__even_in_range(RTCIV, 16))
    {
        case 0: break;  /* No interrupts */
        case 2: break;  /* RTCIFG */
        case 4:         /* RTCCNTIFG */
            inputs_onRtcTick();
            break;
        default: break;
    }
    __bic_SR_register_on_exit(LPM3_bits);
    __no_operation();
}
