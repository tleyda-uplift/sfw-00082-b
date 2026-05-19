CC      = gcc
CFLAGS  = -Wall -Wextra -I.. -I.
TARGET  = test_command_handler

SRCS    = test_command_handler.c \
          stubs.c \
          ../command_handler.c \
          unity/unity.c

$(TARGET): $(SRCS)
	$(CC) $(CFLAGS) -o $(TARGET) $(SRCS)

.PHONY: test clean
test: $(TARGET)
	./$(TARGET)

clean:
	rm -f $(TARGET)
