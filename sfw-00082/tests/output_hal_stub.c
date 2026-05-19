#include "output_hal_stub.h"
#include "../output_hal.h"

HalCall  hal_calls[HAL_CALL_MAX];
int      hal_call_count = 0;
bool     hal_pwm_capable[24];

void resetHalStub(void)
{
    int i;
    hal_call_count = 0;
    for (i = 0; i < 24; i++)
        hal_pwm_capable[i] = false;
}

void hal_initializeHardware(void) {}

bool hal_isPwmCapable(int index)
{
    return hal_pwm_capable[index];
}

void hal_setPwmValue(int index, unsigned int value)
{
    hal_calls[hal_call_count].type  = HAL_SET_PWM;
    hal_calls[hal_call_count].index = index;
    hal_calls[hal_call_count].value = value;
    hal_call_count++;
}

void hal_setGpioHigh(int index)
{
    hal_calls[hal_call_count].type  = HAL_GPIO_HIGH;
    hal_calls[hal_call_count].index = index;
    hal_calls[hal_call_count].value = 0;
    hal_call_count++;
}

void hal_setGpioLow(int index)
{
    hal_calls[hal_call_count].type  = HAL_GPIO_LOW;
    hal_calls[hal_call_count].index = index;
    hal_calls[hal_call_count].value = 0;
    hal_call_count++;
}
