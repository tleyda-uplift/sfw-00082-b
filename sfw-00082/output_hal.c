#include <msp430.h>
#include <stdbool.h>

#include "gpio.h"
#include "P8_LED_CONFIG.h"
#include "output_hal.h"

#define PWM_MAX_COUNT 255

#define GPIO_ALL GPIO_PIN0|GPIO_PIN1|GPIO_PIN2|GPIO_PIN3| \
                 GPIO_PIN4|GPIO_PIN5|GPIO_PIN6|GPIO_PIN7

static volatile unsigned int*  outputCaptureRegisters[24];
static volatile unsigned char* outputRegisters[24];

static void initializeOutputMaps(void)
{
    outputRegisters[0]  = &P1OUT;
    outputRegisters[1]  = &P1OUT;
    outputRegisters[2]  = 0;
    outputRegisters[3]  = 0;
    outputRegisters[4]  = 0;
    outputRegisters[5]  = 0;
    outputRegisters[6]  = &P1OUT;
    outputRegisters[7]  = &P1OUT;
    outputRegisters[8]  = 0;
    outputRegisters[9]  = 0;
    outputRegisters[10] = &P2OUT;
    outputRegisters[11] = &P2OUT;
    outputRegisters[12] = 0;
    outputRegisters[13] = 0;
    outputRegisters[14] = &P2OUT;
    outputRegisters[15] = &P2OUT;
    outputRegisters[16] = &P7OUT;
    outputRegisters[17] = &P7OUT;
    outputRegisters[18] = &P7OUT;
    outputRegisters[19] = &P7OUT;
    outputRegisters[20] = 0;
    outputRegisters[21] = 0;
    outputRegisters[22] = 0;
    outputRegisters[23] = &P7OUT;

    outputCaptureRegisters[0]  = 0;
    outputCaptureRegisters[1]  = 0;
    outputCaptureRegisters[2]  = &TA0CCR1;
    outputCaptureRegisters[3]  = &TA0CCR2;
    outputCaptureRegisters[4]  = &TA0CCR3;
    outputCaptureRegisters[5]  = &TA0CCR4;
    outputCaptureRegisters[6]  = 0;
    outputCaptureRegisters[7]  = 0;
    outputCaptureRegisters[8]  = &TA1CCR1;
    outputCaptureRegisters[9]  = &TA1CCR2;
    outputCaptureRegisters[10] = 0;
    outputCaptureRegisters[11] = 0;
    outputCaptureRegisters[12] = &TA2CCR1;
    outputCaptureRegisters[13] = &TA2CCR2;
    outputCaptureRegisters[14] = 0;
    outputCaptureRegisters[15] = 0;
    outputCaptureRegisters[16] = 0;
    outputCaptureRegisters[17] = 0;
    outputCaptureRegisters[18] = 0;
    outputCaptureRegisters[19] = 0;
    outputCaptureRegisters[20] = &TB0CCR2;
    outputCaptureRegisters[21] = &TB0CCR3;
    outputCaptureRegisters[22] = &TB0CCR4;
    outputCaptureRegisters[23] = 0;
}

void hal_initializeHardware(void)
{
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

    P1OUT = 0;
    P1DIR = BIT7|BIT6|BIT5|BIT4|BIT3|BIT2|BIT1|BIT0;
    P1SEL = 0;
    P1SEL |= BIT5|BIT4|BIT3|BIT2;

    P2OUT = 0;
    P2DIR = BIT7|BIT6|BIT5|BIT4|BIT3|BIT2|BIT1|BIT0;
    P2SEL = 0;
    P2SEL |= BIT5|BIT4|BIT1|BIT0;

    P7OUT = 0;
    P7DIR = BIT7|BIT6|BIT5|BIT4|BIT3|BIT2|BIT1|BIT0;
    P7SEL = 0;
    P7SEL |= BIT6|BIT5|BIT4;

    TA0CCR0  = PWM_MAX_COUNT;
    TA0CCTL1 = OUTMOD_7;
    TA0CCTL2 = OUTMOD_7;
    TA0CCTL3 = OUTMOD_7;
    TA0CCTL4 = OUTMOD_7;
    TA0CCR1  = 0;
    TA0CCR2  = 0;
    TA0CCR3  = 0;
    TA0CCR4  = 0;
    TA0CTL   = TASSEL_2 + MC_1;

    TA1CCR0  = PWM_MAX_COUNT;
    TA1CCTL1 = OUTMOD_7;
    TA1CCTL2 = OUTMOD_7;
    TA1CCR1  = 0;
    TA1CCR2  = 0;
    TA1CTL   = TASSEL_2 + MC_1;

    TA2CCR0  = PWM_MAX_COUNT;
    TA2CCTL1 = OUTMOD_7;
    TA2CCTL2 = OUTMOD_7;
    TA2CCR1  = 0;
    TA2CCR2  = 0;
    TA2CTL   = TASSEL_2 + MC_1;

    TB0CCR0  = PWM_MAX_COUNT;
    TB0CCTL2 = OUTMOD_7;
    TB0CCTL3 = OUTMOD_7;
    TB0CCTL4 = OUTMOD_7;
    TB0CCR2  = 0;
    TB0CCR3  = 0;
    TB0CCR4  = 0;
    TB0CTL   = TBSSEL_2 + MC_1;

    initializeOutputMaps();
}

bool hal_isPwmCapable(int index)
{
    return outputCaptureRegisters[index] != 0;
}

void hal_setPwmValue(int index, unsigned int value)
{
    *outputCaptureRegisters[index] = value;
}

void hal_setGpioHigh(int index)
{
    *outputRegisters[index] |= (unsigned char)(0x01 << (index % 8));
}

void hal_setGpioLow(int index)
{
    *outputRegisters[index] &= ~(unsigned char)(0x01 << (index % 8));
}
