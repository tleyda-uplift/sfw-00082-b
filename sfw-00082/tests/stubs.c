#include "stubs.h"

uint8_t stub_setOutputs_called = 0;
uint8_t stub_setOutputs_data[32];

uint8_t stub_configureInputs_called = 0;
uint8_t stub_configureInputs_data[32];

void resetStubs(void)
{
    stub_setOutputs_called = 0;
    stub_configureInputs_called = 0;
}

/* Stub implementations replacing outputs.c and inputs.c */

void setOutputs(uint8_t *cmdData)
{
    uint8_t i;
    stub_setOutputs_called = 1;
    for (i = 0; i < 32; i++)
        stub_setOutputs_data[i] = cmdData[i];
}

void configureInputs(uint8_t *configData)
{
    uint8_t i;
    stub_configureInputs_called = 1;
    for (i = 0; i < 32; i++)
        stub_configureInputs_data[i] = configData[i];
}

/* Unused functions required by inputs.h */
void initializeInputs(void) {}
void getInputsReport(uint8_t *reportBuffer) { (void)reportBuffer; }

/* Unused function required by outputs.h */
void initializeOutputs(void) {}
