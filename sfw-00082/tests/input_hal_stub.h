#ifndef INPUT_HAL_STUB_H_
#define INPUT_HAL_STUB_H_

#include <stdbool.h>

typedef struct {
    int  index;
    bool enabled;
    bool pullUp;
} GpioCfgCall;

#define GPIO_CFG_MAX 64

extern GpioCfgCall gpio_cfg_calls[GPIO_CFG_MAX];
extern int         gpio_cfg_call_count;
extern bool        hal_pin_states[24];
extern int         hal_timer_init_count;
extern int         hal_pin_read_count;

void resetInputHalStub(void);

#endif /* INPUT_HAL_STUB_H_ */
