/************************************************************************
 *  FMW-00060: Firmware for ELA-00572 GPIO controller					*
 *  																	*
 *  Description: 														*
 *  Firmware for the ELA-00572 GPIO controller, specialized for			*
 *  use with BBS-00430/BBS-00431 and the requirements for indication	*
 *  therein.  Drives nine PWM channels comprising three tri-color		*
 *  LEDs and allows PC-based control of these LEDs from a generic		*
 *  USB HID interface.													*
 *  																	*
 *  main.h: Support definitions and function prototypes for main.c		*
 *																		*								*
 ************************************************************************/

#ifndef MAIN_H_
#define MAIN_H_

// Physical definition for onboard diagnostic LED.
#define OBDLED_OUT P5OUT
#define OBDLED_PIN BIT7
#define OBDLED_DIR P5DIR
#define OBDLED_SEL P5SEL
#define OBDLED_CCR TB0CCR1

#endif /* MAIN_H_ */
