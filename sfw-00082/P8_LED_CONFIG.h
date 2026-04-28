/************************************************************************
 *  SFW-00082: Firmware for ELA-00572 GPIO controller, P-8A specialized	*
 *  Author: Mike Steffen												*
 *  																	*
 *  Description: 														*
 *  Firmware for the ELA-00572 GPIO controller, specialized for			*
 *  use with BBS-00430/BBS-00431 and the requirements for indication	*
 *  therein.  Drives nine PWM channels comprising three tri-color		*
 *  LEDs and allows PC-based control of these LEDs from a generic		*
 *  USB HID interface.													*
 *  																	*
 *  P8_LED_CONFIG.h: Port configuration for P-8A indicator outputs		*
 *																		*
 *  Revision History:													*
 *  A : 11/14/2013 MAS : Original release								*
 ************************************************************************/

#ifndef P8_LED_CONFIG_H_
#define P8_LED_CONFIG_H_

#define STS1RED_OUT P1OUT
#define STS1GRN_OUT P1OUT
#define STS1BLU_OUT P1OUT
#define STS1RED_PIN BIT2
#define STS1GRN_PIN BIT3
#define STS1BLU_PIN BIT4
#define STS1RED_DIR P1DIR
#define STS1GRN_DIR P1DIR
#define STS1BLU_DIR P1DIR
#define STS1RED_SEL P1SEL
#define STS1GRN_SEL P1SEL
#define STS1BLU_SEL P1SEL
#define STS1RED_CCR TA0CCR1
#define STS1GRN_CCR TA0CCR2
#define STS1BLU_CCR TA0CCR3

#define STS2RED_OUT P1OUT
#define STS2GRN_OUT P2OUT
#define STS2BLU_OUT P2OUT
#define STS2RED_PIN BIT5
#define STS2GRN_PIN BIT0
#define STS2BLU_PIN BIT1
#define STS2RED_DIR P1DIR
#define STS2GRN_DIR P2DIR
#define STS2BLU_DIR P2DIR
#define STS2RED_SEL P1SEL
#define STS2GRN_SEL P2SEL
#define STS2BLU_SEL P2SEL
#define STS2RED_CCR TA0CCR4
#define STS2GRN_CCR TA1CCR1
#define STS2BLU_CCR TA1CCR2

#define STS3RED_OUT P7OUT
#define STS3GRN_OUT P7OUT
#define STS3BLU_OUT P7OUT
#define STS3RED_PIN BIT4
#define STS3GRN_PIN BIT5
#define STS3BLU_PIN BIT6
#define STS3RED_DIR P7DIR
#define STS3GRN_DIR P7DIR
#define STS3BLU_DIR P7DIR
#define STS3RED_SEL P7SEL
#define STS3GRN_SEL P7SEL
#define STS3BLU_SEL P7SEL
#define STS3RED_CCR TB0CCR2
#define STS3GRN_CCR TB0CCR3
#define STS3BLU_CCR TB0CCR4

#endif /* P8_LED_CONFIG_H_ */
