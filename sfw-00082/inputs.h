#ifndef INPUTS_H_
#define INPUTS_H_

#include <stdint.h>

void initializeInputs(void);
void configureInputs(uint8_t *configData);
void getInputsReport(uint8_t *reportBuffer);
void readInputs(void);
void inputs_onRtcTick(void);

#endif /* INPUTS_H_ */
