#ifndef OUTPUT_HAL_STUB_H_
#define OUTPUT_HAL_STUB_H_

#include <stdbool.h>

typedef enum {
    HAL_SET_PWM,
    HAL_GPIO_HIGH,
    HAL_GPIO_LOW,
} HalCallType;

typedef struct {
    HalCallType type;
    int         index;
    unsigned int value; /* only meaningful for HAL_SET_PWM */
} HalCall;

#define HAL_CALL_MAX 64

extern HalCall  hal_calls[HAL_CALL_MAX];
extern int      hal_call_count;
extern bool     hal_pwm_capable[24];

void resetHalStub(void);

#endif /* OUTPUT_HAL_STUB_H_ */
