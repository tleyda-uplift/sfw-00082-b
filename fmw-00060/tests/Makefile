CC     = gcc
CFLAGS = -Wall -Wextra -I.. -I.

ALL_TESTS = test_command_handler test_outputs test_inputs

all: $(ALL_TESTS)

test_command_handler: test_command_handler.c stubs.c ../command_handler.c unity/unity.c
	$(CC) $(CFLAGS) -o $@ $^

test_outputs: test_outputs.c output_hal_stub.c ../outputs.c unity/unity.c
	$(CC) $(CFLAGS) -o $@ $^

test_inputs: test_inputs.c input_hal_stub.c ../inputs.c unity/unity.c
	$(CC) $(CFLAGS) -o $@ $^

.PHONY: test clean
test: $(ALL_TESTS)
	./test_command_handler
	./test_outputs
	./test_inputs

clean:
	rm -f $(ALL_TESTS)
