#ifndef OUTPUT_HAL_H_
#define OUTPUT_HAL_H_

#include <stdbool.h>

void hal_initializeHardware(void);

bool hal_isPwmCapable(int index);
void hal_setPwmValue(int index, unsigned int value);
void hal_setGpioHigh(int index);
void hal_setGpioLow(int index);

#endif /* OUTPUT_HAL_H_ */
