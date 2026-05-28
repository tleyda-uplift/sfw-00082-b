/* GCC compatibility wrapper for <msp430.h>.
 *
 * Problem: in430.h (pulled in by the real msp430.h) defines __no_init as
 * __attribute__((noinit)).  When this expands before a typedef name in a
 * variable declaration the GCC parser treats it as an attribute on the
 * *type* rather than the *declarator*, silently discarding the variable.
 *
 * Fix: include the real header first, then redefine __no_init as empty so
 * the TI USB-stack declarations parse correctly under GCC.
 *
 * __data16 is also cleared here — it is a low-address-space hint for the TI
 * compiler that has no meaning in MSP430-GCC (all RAM is already in range).
 */
#include_next <msp430.h>

#undef  __no_init
#define __no_init

#undef  __data16
#define __data16
