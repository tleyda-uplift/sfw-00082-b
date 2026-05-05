#ifndef INPUTS_H_
#define INPUTS_H_

#include "USB_API/USB_Common/types.h"               // Basic Type declarations

void initializeInputs();
void configureInputs(BYTE *configData);
void getInputsReport(BYTE *reportBuffer);

#endif // INPUTS_H_
