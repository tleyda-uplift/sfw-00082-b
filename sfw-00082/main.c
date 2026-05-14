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
 *  Parts of this source are derived from Texas Instruments libraries.	*
 *  See following block for TI license details.							*
 *  																	*
 *  main.c: Main runtime code											*
 *																		*
 *  Revision History:													*
 *  A : 11/14/2013 MAS : Original release								*
 ************************************************************************/

/* --COPYRIGHT--,BSD
 * Copyright (c) 2013, Texas Instruments Incorporated
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 *
 * *  Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 *
 * *  Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 *
 * *  Neither the name of Texas Instruments Incorporated nor the names of
 *    its contributors may be used to endorse or promote products derived
 *    from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO,
 * THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
 * PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
 * EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
 * PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS;
 * OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
 * OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE,
 * EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * --/COPYRIGHT--*/

#include "inc/hw_memmap.h"
#include "gpio.h"
#include "wdt_a.h"
#include "ucs.h"
#include "pmm.h"
#include "sfr.h"
#include "timer_a.h"

#include "USB_config/descriptors.h"
#include "USB_API/USB_Common/device.h"
#include "USB_API/USB_Common/types.h"               // Basic Type declarations
#include "USB_API/USB_Common/usb.h"                 // USB-specific functions
#include "USB_API/USB_HID_API/UsbHid.h"
#include "USB_app/usbConstructs.h"

#include "inputs.h"
#include "outputs.h"
#include "P8_LED_CONFIG.h"
#include "main.h"

#define GPIO_ALL	GPIO_PIN0|GPIO_PIN1|GPIO_PIN2|GPIO_PIN3| \
					GPIO_PIN4|GPIO_PIN5|GPIO_PIN6|GPIO_PIN7

#define PWM_MAX_COUNT 255

// Function declarations
void initPorts(void);
void initClocks(DWORD mclkFreq);

// Global flags set by events
volatile BYTE bHIDDataReceived_event = FALSE; // Indicates data has been rx'ed
                                              // without an open rx operation

#define MAX_STR_LENGTH 32
char wholeString[MAX_STR_LENGTH] = "";
BYTE reportBuffer[MAX_STR_LENGTH];

uint8_t sendReportFlag = 0;

void resetReportBuffer() {
    uint8_t idx;

    for (idx = 0; idx < MAX_STR_LENGTH; ++idx) {
        reportBuffer[idx] = 0;
    }
}


/*  
 * ======== main ========
 */
VOID main (VOID)
{
    WDT_A_hold(WDT_A_BASE); // Stop watchdog timer

    // Minimum Vcore setting required for the USB API is PMM_CORE_LEVEL_2 .
    PMM_setVCore(PMM_CORE_LEVEL_2);

    initPorts();           // Config GPIOS for low-power (output low)
    initClocks(8000000);   // Config clocks. MCLK=SMCLK=FLL=8MHz; ACLK=REFO=32kHz
    USB_setup(TRUE, TRUE); // Init USB & events; if a host is present, connect

	initializeOutputs();   // Initialize Outputs functionality
    initializeInputs();    // Initialize Inputs functionality 

    resetReportBuffer();

    __enable_interrupt();  // Enable interrupts globally

    OBDLED_OUT |= OBDLED_PIN; // Turn on Onboard Diagnostic LED
    
    while (1)
    {
        BYTE i;
        
        // Check the USB state and directly main loop accordingly
        switch (USB_connectionState())
        {
            case ST_ENUM_ACTIVE:
            
                // Enter LPM0 (can't do LPM3 when active)
                if (!bHIDDataReceived_event && !sendReportFlag) {
                    __bis_SR_register(LPM0_bits + GIE);
                    _NOP(); 
                }
                // Exit LPM on USB receive and perform a receive operation
                
                // If true, some data is in the buffer; begin receiving a cmd
                if (bHIDDataReceived_event){
 
                    // Store contents of USB buffer
                    // hidReceiveDataInBuffer((BYTE*)wholeString, MAX_STR_LENGTH, HID0_INTFNUM);
                    USBHID_receiveReport((BYTE*)wholeString, HID0_INTFNUM);

                    if (wholeString[0] == 0x3F) {
                        // Command/Configure Report
                        if(wholeString[2] == 0x37)
                        {
                            // Output command report
                            setOutputs((BYTE*)(wholeString + 2));
                        } else if (wholeString[2] == 0x38) {
                            // Input configure report
                            configureInputs((BYTE*)(wholeString + 2));
                            // Input configuration change, send inputs report
                            sendReportFlag = 1;
                        }
                    }
                    
                    // Reset buffers and flags
                    for (i = 0; i < MAX_STR_LENGTH; i++){
                            wholeString[i] = 0x00;
                    }
                    bHIDDataReceived_event = FALSE;
                }
                if (sendReportFlag) {
                    // Send inputs report
                    uint8_t idx;
                    resetReportBuffer();
                    getInputsReport(reportBuffer);

                    for (idx = 0; idx < 10; ++idx) {
                        // Send report, retry 9 times if needed
                        if(USBHID_sendReport(reportBuffer, HID0_INTFNUM) == kUSBHID_sendComplete) {
                            sendReportFlag = false;
                            break;
                        }
                    }               
                }
                break;

            case ST_PHYS_DISCONNECTED:
            case ST_ENUM_SUSPENDED:
            case ST_PHYS_CONNECTED_NOENUM_SUSP:
                __bis_SR_register(LPM3_bits + GIE);
                _NOP();
                break;

            case ST_ENUM_IN_PROGRESS:
            default:;
        }

    }  //while(1)
} //main()

// Set all ports to Output: Low for power savings, then configure peripherals.
void initPorts(void)
{
#ifdef __MSP430_HAS_PORT5_R__
    GPIO_setOutputLowOnPin(GPIO_PORT_P5, GPIO_ALL);
    GPIO_setAsOutputPin(GPIO_PORT_P5, GPIO_ALL);
#endif

#ifdef __MSP430_HAS_PORT8_R__
    GPIO_setOutputLowOnPin(GPIO_PORT_P8, GPIO_ALL);
    GPIO_setAsOutputPin(GPIO_PORT_P8, GPIO_ALL);
#endif

#ifdef __MSP430_HAS_PORT9_R__
    GPIO_setOutputLowOnPin(GPIO_PORT_P9, GPIO_ALL);
    GPIO_setAsOutputPin(GPIO_PORT_P9, GPIO_ALL);
#endif

#ifdef __MSP430_HAS_PORTJ_R__
    GPIO_setOutputLowOnPin(GPIO_PORT_PJ, GPIO_ALL);
    GPIO_setAsOutputPin(GPIO_PORT_PJ, GPIO_ALL);
#endif

    // CONFIGURE PWM OUTPUT CHANNELS
    OBDLED_OUT &= ~OBDLED_PIN;
    OBDLED_DIR |= OBDLED_PIN;
    OBDLED_SEL &= ~OBDLED_PIN;
}

// Set up clocks.  MCLK=SMCLK=DCO/FLL=mclkFreq; ACLK=FLLref=REFO=32kHz
void initClocks(DWORD mclkFreq)
{
	UCS_initClockSignal(
	   UCS_FLLREF,
	   UCS_REFOCLK_SELECT,
	   UCS_CLOCK_DIVIDER_1);

	UCS_initClockSignal(
	   UCS_ACLK,
	   UCS_REFOCLK_SELECT,
	   UCS_CLOCK_DIVIDER_1);

    UCS_initFLLSettle(
        mclkFreq/1000,
        mclkFreq/32768);
}

/*  
 * ======== UNMI_ISR ========
 */
#pragma vector = UNMI_VECTOR
__interrupt VOID UNMI_ISR (VOID)
{
    switch (__even_in_range(SYSUNIV, SYSUNIV_BUSIFG))
    {
        case SYSUNIV_NONE:
            __no_operation();
            break;
        case SYSUNIV_NMIIFG:
            __no_operation();
            break;
        case SYSUNIV_OFIFG:
            UCS_clearFaultFlag(UCS_XT2OFFG);
            UCS_clearFaultFlag(UCS_DCOFFG);
            SFR_clearInterrupt(SFR_OSCILLATOR_FAULT_INTERRUPT);
            break;
        case SYSUNIV_ACCVIFG:
            __no_operation();
            break;
        case SYSUNIV_BUSIFG:
            SYSBERRIV = 0; //clear bus error flag
            USB_disable(); //Disable
    }
}
