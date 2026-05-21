# Makefile for sfw-00082 — MSP430F5529 firmware
# Toolchain: msp430-elf-gcc (TI MSP430-GCC, https://www.ti.com/tool/MSP430-GCC-OPENSOURCE)
#
# Requires two downloads from TI:
#   1. MSP430-GCC compiler      → provides msp430-elf-gcc / msp430-elf-objcopy
#   2. MSP430-GCC Support Files → provides device headers and linker scripts
#
# Usage (from the project root):
#   make -C gcc SUPPORT_FILE_DIR=/path/to/msp430-gcc-support-files/include
#
# SUPPORT_FILE_DIR can also be exported as an environment variable so it
# does not need to be passed on every invocation.
#
# The CCS project files (.project / .cproject) are unaffected by this
# Makefile and continue to work normally in Code Composer Studio.

PROJECT  = sfw-00082
MCU      = msp430f5529
BUILD    = gcc-build

CC       = msp430-elf-gcc
OBJCOPY  = msp430-elf-objcopy

# Path to the MSP430-GCC Support File Package (device headers + linker scripts).
# Override on the command line or via the environment variable.
SUPPORT_FILE_DIR ?= $(HOME)/msp430-gcc-support-files/include

# Source files live in the project root (one level up).
# Use pattern-specific vpath so only .c lookups search the parent directory;
# build outputs (.o, .elf, .hex) are never accidentally found there.
vpath %.c ..

# -----------------------------------------------------------------------------
# Compiler flags
# -----------------------------------------------------------------------------
CFLAGS  = -mmcu=$(MCU)
CFLAGS += -msmall              # restricted (small) data model — matches CCS setting
CFLAGS += -mhwmult=f5series   # F5-series hardware multiplier — matches CCS setting
CFLAGS += -Os                 # optimise for size (release build)
CFLAGS += -Wall
CFLAGS += -Wno-unknown-pragmas # suppress harmless #pragma vector= warnings

# Preprocessor defines — mirrors the CCS project definitions
CFLAGS += -D__MSP430F5529__
CFLAGS += -DDEPRECATED

# Include paths — mirrors the CCS project include paths
CFLAGS += -I./compat-include          # must be first: wrapper headers override TI headers
CFLAGS += -I$(SUPPORT_FILE_DIR)       # device headers (msp430f5529.h etc.)
CFLAGS += -I..                        # project root
CFLAGS += -I../driverlib/MSP430F5xx_6xx
CFLAGS += -I../USB_config

# Inject the GCC compatibility shim into every translation unit
CFLAGS += -include gcc_compat.h

# -----------------------------------------------------------------------------
# Linker flags
# -----------------------------------------------------------------------------
LDFLAGS  = -mmcu=$(MCU)
LDFLAGS += -msmall
LDFLAGS += -mhwmult=f5series
LDFLAGS += -L $(SUPPORT_FILE_DIR)             # linker script search path (for INCLUDE directives)
LDFLAGS += -T $(SUPPORT_FILE_DIR)/$(MCU).ld   # GCC linker script from support files
LDFLAGS += -T usb_gcc_sections.ld             # USB hardware buffer placement
LDFLAGS += -Wl,--gc-sections                  # dead-strip unused sections
LDFLAGS += -Wl,-Map,$(BUILD)/$(PROJECT).map

# -----------------------------------------------------------------------------
# Source files
# Only the driverlib modules that are transitively included by application code
# are listed here. --gc-sections will eliminate any unused functions at link time.
# -----------------------------------------------------------------------------

APP_SRCS = \
    main.c \
    command_handler.c \
    inputs.c \
    input_hal.c \
    outputs.c \
    output_hal.c

USB_CONFIG_SRCS = \
    USB_config/descriptors.c \
    USB_config/UsbIsr.c

USB_APP_SRCS = \
    USB_app/usbConstructs.c \
    USB_app/usbEventHandling.c

USB_API_SRCS = \
    USB_API/USB_Common/usb.c \
    USB_API/USB_Common/usbdma.c \
    USB_API/USB_HID_API/UsbHid.c \
    USB_API/USB_HID_API/UsbHidReq.c \
    USB_API/USB_CDC_API/UsbCdc.c \
    USB_API/USB_MSC_API/UsbMscReq.c \
    USB_API/USB_MSC_API/UsbMscScsi.c \
    USB_API/USB_MSC_API/UsbMscStateMachine.c \
    USB_API/USB_PHDC_API/UsbPHDC.c

# Driverlib modules used by the application and USB stack
DRIVERLIB_SRCS = \
    driverlib/MSP430F5xx_6xx/gpio.c \
    driverlib/MSP430F5xx_6xx/wdt_a.c \
    driverlib/MSP430F5xx_6xx/ucs.c \
    driverlib/MSP430F5xx_6xx/pmm.c \
    driverlib/MSP430F5xx_6xx/sfr.c \
    driverlib/MSP430F5xx_6xx/timer_a.c \
    driverlib/MSP430F5xx_6xx/rtc_a.c \
    driverlib/MSP430F5xx_6xx/tlv.c \
    driverlib/MSP430F5xx_6xx/dma.c

SRCS = $(APP_SRCS) $(USB_CONFIG_SRCS) $(USB_APP_SRCS) $(USB_API_SRCS) $(DRIVERLIB_SRCS)
OBJS = $(SRCS:%.c=$(BUILD)/%.o)

# -----------------------------------------------------------------------------
# Targets
# -----------------------------------------------------------------------------
.PHONY: all clean

all: $(BUILD)/$(PROJECT).elf $(BUILD)/$(PROJECT).hex

# Link
$(BUILD)/$(PROJECT).elf: $(OBJS)
	$(CC) $(LDFLAGS) -o $@ $^

# Intel HEX (for flash programmers)
$(BUILD)/$(PROJECT).hex: $(BUILD)/$(PROJECT).elf
	$(OBJCOPY) -O ihex $< $@

# Compile — create subdirectories as needed
$(BUILD)/%.o: %.c
	@mkdir -p $(dir $@)
	$(CC) $(CFLAGS) -c -o $@ $<

clean:
	rm -rf $(BUILD)
