/* usb_gcc_sections.ld — USB hardware buffer placement for msp430-elf-gcc.
 *
 * The MSP430F5529 USB controller uses fixed hardware addresses for its
 * endpoint descriptor blocks and FIFO buffers.  The TI cl430 compiler
 * relies on the CCS linker command file to place these; IAR uses
 * #pragma location.  This script provides the equivalent for GCC.
 *
 * Included in the link via -T usb_gcc_sections.ld alongside the main
 * -T $(SUPPORT_FILE_DIR)/msp430f5529.ld script.
 *
 * All sections are marked NOLOAD: the USB controller owns these regions
 * directly and they must not be touched by the C startup routine.
 */

SECTIONS
{
    /* Endpoint 0 descriptor block — USB hardware register area */
    .usb_edb0   0x0920 (NOLOAD) : { KEEP(*(.usb_edb0))  }

    /* EP0 FIFO buffers */
    .usb_oep0   0x2370 (NOLOAD) : { KEEP(*(.usb_oep0))  }
    .usb_iep0   0x2378 (NOLOAD) : { KEEP(*(.usb_iep0))  }

    /* Setup packet buffer and endpoint descriptor tables */
    .usb_setup  0x2380 (NOLOAD) : { KEEP(*(.usb_setup)) }
    .usb_oedb   0x2388 (NOLOAD) : { KEEP(*(.usb_oedb))  }
    .usb_iedb   0x23C8 (NOLOAD) : { KEEP(*(.usb_iedb))  }

    /* Endpoint 1 FIFO buffers (USB RAM: 0x1C00–0x1FFF) */
    .usb_ep1ox  0x1C00 (NOLOAD) : { KEEP(*(.usb_ep1ox)) }
    .usb_ep1oy  0x1C40 (NOLOAD) : { KEEP(*(.usb_ep1oy)) }
    .usb_ep1ix  0x1C80 (NOLOAD) : { KEEP(*(.usb_ep1ix)) }
    .usb_ep1iy  0x1CC0 (NOLOAD) : { KEEP(*(.usb_ep1iy)) }

    /* Endpoint 2 */
    .usb_ep2ox  0x1D00 (NOLOAD) : { KEEP(*(.usb_ep2ox)) }
    .usb_ep2oy  0x1D40 (NOLOAD) : { KEEP(*(.usb_ep2oy)) }
    .usb_ep2ix  0x1D80 (NOLOAD) : { KEEP(*(.usb_ep2ix)) }
    .usb_ep2iy  0x1DC0 (NOLOAD) : { KEEP(*(.usb_ep2iy)) }

    /* Endpoint 3 */
    .usb_ep3ox  0x1E00 (NOLOAD) : { KEEP(*(.usb_ep3ox)) }
    .usb_ep3oy  0x1E40 (NOLOAD) : { KEEP(*(.usb_ep3oy)) }
    .usb_ep3ix  0x1E80 (NOLOAD) : { KEEP(*(.usb_ep3ix)) }
    .usb_ep3iy  0x1EC0 (NOLOAD) : { KEEP(*(.usb_ep3iy)) }

    /* Endpoint 4 */
    .usb_ep4ox  0x1F00 (NOLOAD) : { KEEP(*(.usb_ep4ox)) }
    .usb_ep4oy  0x1F40 (NOLOAD) : { KEEP(*(.usb_ep4oy)) }
    .usb_ep4ix  0x1F80 (NOLOAD) : { KEEP(*(.usb_ep4ix)) }
    .usb_ep4iy  0x1FC0 (NOLOAD) : { KEEP(*(.usb_ep4iy)) }

    /* Endpoint 5 */
    .usb_ep5ox  0x2000 (NOLOAD) : { KEEP(*(.usb_ep5ox)) }
    .usb_ep5oy  0x2040 (NOLOAD) : { KEEP(*(.usb_ep5oy)) }
    .usb_ep5ix  0x2080 (NOLOAD) : { KEEP(*(.usb_ep5ix)) }
    .usb_ep5iy  0x20C0 (NOLOAD) : { KEEP(*(.usb_ep5iy)) }
}
