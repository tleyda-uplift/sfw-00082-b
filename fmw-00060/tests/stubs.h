#ifndef STUBS_H_
#define STUBS_H_

#include <stdint.h>

extern uint8_t stub_setOutputs_called;
extern uint8_t stub_setOutputs_data[32];

extern uint8_t stub_configureInputs_called;
extern uint8_t stub_configureInputs_data[32];

void resetStubs(void);

#endif /* STUBS_H_ */
