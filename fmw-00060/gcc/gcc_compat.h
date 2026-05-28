/* gcc_compat.h
 * Compatibility shim for building with msp430-elf-gcc.
 * Included automatically by the GCC Makefile via -include gcc_compat.h.
 * Has no effect when building with the TI cl430 compiler.
 */

#ifndef GCC_COMPAT_H
#define GCC_COMPAT_H

#ifdef __GNUC__

/* __no_init, __even_in_range, and _NOP are already defined by the MSP430-GCC
 * support headers (in430.h, pulled in via <msp430.h>).  Only __data16 needs
 * a stub here — it places a variable in the lower 64 KB address space, which
 * is where all MSP430 RAM lives anyway, so the qualifier is a no-op for GCC. */
#ifndef __data16
#define __data16
#endif

#endif /* __GNUC__ */

#endif /* GCC_COMPAT_H */
