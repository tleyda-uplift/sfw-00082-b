#ifndef INPUT_HAL_H_
#define INPUT_HAL_H_

#include <stdbool.h>

void hal_initializeTimer(void);
void hal_configureGpio(int index, bool enabled, bool pullUp);
bool hal_readGpioPin(int index);

#endif /* INPUT_HAL_H_ */
