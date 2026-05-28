#include "input_hal_stub.h"
#include "../input_hal.h"

GpioCfgCall gpio_cfg_calls[GPIO_CFG_MAX];
int         gpio_cfg_call_count = 0;
bool        hal_pin_states[24];
int         hal_timer_init_count = 0;
int         hal_pin_read_count = 0;

void resetInputHalStub(void)
{
    int i;
    gpio_cfg_call_count = 0;
    hal_timer_init_count = 0;
    hal_pin_read_count = 0;
    for (i = 0; i < 24; i++)
        hal_pin_states[i] = false;
}

void hal_initializeTimer(void)
{
    hal_timer_init_count++;
}

void hal_configureGpio(int index, bool enabled, bool pullUp)
{
    gpio_cfg_calls[gpio_cfg_call_count].index   = index;
    gpio_cfg_calls[gpio_cfg_call_count].enabled = enabled;
    gpio_cfg_calls[gpio_cfg_call_count].pullUp  = pullUp;
    gpio_cfg_call_count++;
}

bool hal_readGpioPin(int index)
{
    hal_pin_read_count++;
    return hal_pin_states[index];
}
