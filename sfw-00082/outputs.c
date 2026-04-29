#include <msp430.h>
#include <stdbool.h>

#include "gpio.h"
#include "USB_API/USB_Common/types.h"

#include "P8_LED_CONFIG.h"
#include "outputs.h"

#define PWM_MAX_COUNT 255

#define GPIO_ALL	GPIO_PIN0|GPIO_PIN1|GPIO_PIN2|GPIO_PIN3| \
					GPIO_PIN4|GPIO_PIN5|GPIO_PIN6|GPIO_PIN7

typedef struct {
    volatile unsigned int *captureRegister;
    int dataIndex;
} OutputParameters;

typedef enum {
    OutputOff,
    OutputOn,
    OutputPWM,
    OutputNoOp,
} OutputCommand;

static volatile unsigned int* outputCaptureRegisters[9];

void initializeOutputs() {
#ifdef __MSP430_HAS_PORT1_R__
    GPIO_setOutputLowOnPin(GPIO_PORT_P1, GPIO_ALL);
    GPIO_setAsOutputPin(GPIO_PORT_P1, GPIO_ALL);
#endif

#ifdef __MSP430_HAS_PORT2_R__
    GPIO_setOutputLowOnPin(GPIO_PORT_P2, GPIO_ALL);
    GPIO_setAsOutputPin(GPIO_PORT_P2, GPIO_ALL);
#endif

#ifdef __MSP430_HAS_PORT7_R__
    GPIO_setOutputLowOnPin(GPIO_PORT_P7, GPIO_ALL);
    GPIO_setAsOutputPin(GPIO_PORT_P7, GPIO_ALL);
#endif

    // Port 1
    P1OUT = 0;
    P1DIR = BIT7|BIT6|BIT5|BIT4|BIT3|BIT2|BIT1|BIT0;
    P1SEL = 0;
    P1SEL |= BIT5|BIT4|BIT3|BIT2;

    // Port 2
    P2OUT = 0;
    P2DIR = BIT7|BIT6|BIT5|BIT4|BIT3|BIT2|BIT1|BIT0;
    P2SEL = 0;
    P2SEL |= BIT5|BIT4|BIT1|BIT0;

    // Port 7
    P7OUT = 0;
    P7DIR = BIT7|BIT6|BIT5|BIT4|BIT3|BIT2|BIT1|BIT0;
    P7SEL = 0;
    P7SEL |= BIT6|BIT5|BIT4;
    
    // Configure TimerA0
    TA0CCR0 = PWM_MAX_COUNT;							// Top val for PWM
    TA0CCTL1 = OUTMOD_7;								// PWM Reset-Set mode
    TA0CCTL2 = OUTMOD_7;								// PWM Reset-Set mode
	TA0CCTL3 = OUTMOD_7;								// PWM Reset-Set mode
	TA0CCTL4 = OUTMOD_7;								// PWM Reset-Set mode
    TA0CCR1 = 0;
    TA0CCR2 = 0;
    TA0CCR3 = 0;
    TA0CCR4 = 0;
    TA0CTL = TASSEL_2 + MC_1;							// PWM clock src=ACLK, count up

    // Configure TimerA1
    TA1CCR0 = PWM_MAX_COUNT;							// Top val for PWM
    TA1CCTL1 = OUTMOD_7;								// PWM Reset-Set mode
    TA1CCTL2 = OUTMOD_7;								// PWM Reset-Set mode
    TA1CCR1 = 0;
    TA1CCR2 = 0;
    TA1CTL = TASSEL_2 + MC_1;							// PWM clock src=ACLK, count up

    // Configure TimerA2
    TA2CCR0 = PWM_MAX_COUNT;							// Top val for PWM
    TA2CCTL1 = OUTMOD_7;								// PWM Reset-Set mode
    TA2CCTL2 = OUTMOD_7;								// PWM Reset-Set mode
    TA2CCR1 = 0;
    TA2CCR2 = 0;
    TA2CTL = TASSEL_2 + MC_1;							// PWM clock src=ACLK, count up

    // Configure TimerB0
    TB0CCR0 = PWM_MAX_COUNT;							// Top val for PWM
    TB0CCTL2 = OUTMOD_7;								// PWM Reset-Set mode
	TB0CCTL3 = OUTMOD_7;								// PWM Reset-Set mode
	TB0CCTL4 = OUTMOD_7;								// PWM Reset-Set mode
    TB0CCR2 = 0;
    TB0CCR3 = 0;
    TB0CCR4 = 0;
    TB0CTL = TBSSEL_2 + MC_1;							// PWM clock src=ACLK, count up

    outputCaptureRegisters[0] = &TA0CCR1;
    outputCaptureRegisters[1] = &TA0CCR2;
    outputCaptureRegisters[2] = &TA0CCR3;
    outputCaptureRegisters[3] = &TA0CCR4;
    outputCaptureRegisters[4] = &TA1CCR1;
    outputCaptureRegisters[5] = &TA1CCR2;
    outputCaptureRegisters[6] = &TB0CCR2;
    outputCaptureRegisters[7] = &TB0CCR3;
    outputCaptureRegisters[8] = &TB0CCR4;
}

OutputCommand getCommand(BYTE cmdData) {
    BYTE command = cmdData & (BIT6 | BIT5 | BIT4);
    if (command == BIT5) {
        return OutputPWM;
    }
    if (command == BIT4) {
        return OutputOn;
    }
    if (command == 0) {
        return OutputOff;
    }
    return OutputNoOp;
}

void setOutput(int index, BYTE* cmdData) {
    bool changeEnabled = (cmdData[0] & BIT7) > 0;

    if(changeEnabled) //change enabled
    {
        switch(getCommand(cmdData[0])) // Function select
        {
            case OutputOff:
                *outputCaptureRegisters[index] = 0; // Off
                break;
            case OutputOn:
                *outputCaptureRegisters[index] = PWM_MAX_COUNT; // Full
                break;
            case OutputPWM:
                *outputCaptureRegisters[index] = cmdData[1]; // PWM, duty cycle per input
                break;
            default:
                break;
        }
    }
}

void setOutputsOriginalFormat(BYTE* cmdData) {
    //Byte 3,6,9,12,15,18,21,24,27 are Control packets.
    //7: statechg, 6-4: func, 3-0: reserved
    // func: 0: off, 1: on, 2: pwmval by next byte, 3-7 reserved

    // STATUS 1 RED
    setOutput(0, cmdData + 3);
    // STATUS 1 GREEN
    setOutput(1, cmdData + 6);
    // STATUS 1 BLUE
    setOutput(2, cmdData + 9);
    // STATUS 2 RED
    setOutput(3, cmdData + 12);
    // STATUS 2 GREEN
    setOutput(4, cmdData + 15);
    // STATUS 2 BLUE
    setOutput(5, cmdData + 18);
    // STATUS 3 RED
    setOutput(6, cmdData + 21);
    // STATUS 3 GREEN
    setOutput(7, cmdData + 24);
    // STATUS 3 BLUE
    setOutput(8, cmdData + 27);
}

bool isOriginalMessageFormat(BYTE* cmdData) {
    return cmdData[1] == 0;
}

void setOutputs(BYTE* cmdData) {
    if(isOriginalMessageFormat(cmdData)) {
        setOutputsOriginalFormat(cmdData);
    }
}
