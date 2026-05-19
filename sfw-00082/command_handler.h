#ifndef COMMAND_HANDLER_H_
#define COMMAND_HANDLER_H_

#include <stdint.h>

#define REPORT_ID_COMMAND   0x3F
#define PACKET_ID_OUTPUT    0x37
#define PACKET_ID_INPUT_CFG 0x38

/*
 * Process a received HID report.
 *
 * report : pointer to the full received report buffer
 * len    : length of the buffer
 *
 * Returns 1 if a status report should be sent to the host, 0 otherwise.
 */
uint8_t processReport(const uint8_t *report, uint8_t len);

#endif /* COMMAND_HANDLER_H_ */
