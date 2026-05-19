using FluentAssertions;
using HID_Test_App.Commands;
using HID_Test_App.Models;

namespace Hid_Test_App_Tests.Commands
{
    // Output byte layout (both BuildCommandData and BuildLegacyCommandData):
    //   output N control byte: bit 7 = ChangeEnabled, bit 5 = PWM, bit 4 = On
    //   output N duty cycle byte: raw value 0–255
    //
    // BuildCommandData offsets (8 outputs):
    //   output 0: [4],[5]  output 1: [7],[8]   output 2: [10],[11]  output 3: [13],[14]
    //   output 4: [16],[17] output 5: [19],[20] output 6: [22],[23]  output 7: [25],[26]
    //
    // BuildLegacyCommandData offsets (9 outputs, same as above plus):
    //   output 8: [28],[29]  — and byte [2] is not set (no port)
    public class TestOutputCommandBuilder
    {
        // --- BuildCommandData ---

        [Fact]
        public void OutputCommandBuilder_ReportIdAtByte0()
        {
            var data = new OutputCommandBuilder().BuildCommandData();

            data[0].Should().Be(0x3F);
        }

        [Fact]
        public void OutputCommandBuilder_PacketIdAtByte1()
        {
            var data = new OutputCommandBuilder().BuildCommandData();

            data[1].Should().Be(0x37);
        }

        [Fact]
        public void OutputCommandBuilder_PortEncodedAsOneBased()
        {
            var data = new OutputCommandBuilder().WithPort(2).BuildCommandData();

            data[2].Should().Be(3);
        }

        [Fact]
        public void OutputCommandBuilder_DefaultPortIsZero()
        {
            var data = new OutputCommandBuilder().BuildCommandData();

            data[2].Should().Be(1);
        }

        [Fact]
        public void OutputCommandBuilder_ReportIs31Bytes()
        {
            var data = new OutputCommandBuilder().BuildCommandData();

            data.Length.Should().Be(31);
        }

        [Fact]
        public void OutputCommandBuilder_DefaultControlBytesAreZero()
        {
            var data = new OutputCommandBuilder().BuildCommandData();

            int[] controlOffsets = [4, 7, 10, 13, 16, 19, 22, 25];
            foreach (var offset in controlOffsets)
                data[offset].Should().Be(0, $"control byte at [{offset}] should default to 0");
        }

        [Fact]
        public void OutputCommandBuilder_ChangeEnabledSetsBit7OnControlByte()
        {
            var data = new OutputCommandBuilder()
                .WithOutput(0, true, OutputState.Off, 0)
                .BuildCommandData();

            (data[4] & 0x80).Should().Be(0x80);
        }

        [Fact]
        public void OutputCommandBuilder_OutputOnSetsBit4OnControlByte()
        {
            var data = new OutputCommandBuilder()
                .WithOutput(0, false, OutputState.On, 0)
                .BuildCommandData();

            (data[4] & 0x10).Should().Be(0x10);
        }

        [Fact]
        public void OutputCommandBuilder_OutputPwmSetsBit5OnControlByte()
        {
            var data = new OutputCommandBuilder()
                .WithOutput(0, false, OutputState.PWM, 0)
                .BuildCommandData();

            (data[4] & 0x20).Should().Be(0x20);
        }

        [Fact]
        public void OutputCommandBuilder_OutputOffClearsStateBits()
        {
            var data = new OutputCommandBuilder()
                .WithOutput(0, false, OutputState.Off, 0)
                .BuildCommandData();

            (data[4] & 0x30).Should().Be(0);
        }

        [Fact]
        public void OutputCommandBuilder_OnAndPwmBitsAreMutuallyExclusive()
        {
            var onData  = new OutputCommandBuilder().WithOutput(0, false, OutputState.On,  0).BuildCommandData();
            var pwmData = new OutputCommandBuilder().WithOutput(0, false, OutputState.PWM, 0).BuildCommandData();

            (onData[4]  & 0x30).Should().Be(0x10);
            (pwmData[4] & 0x30).Should().Be(0x20);
        }

        [Fact]
        public void OutputCommandBuilder_DutyCycleWrittenToByteAfterControlByte()
        {
            var data = new OutputCommandBuilder()
                .WithOutput(0, false, OutputState.PWM, 200)
                .BuildCommandData();

            data[5].Should().Be(200);
        }

        [Fact]
        public void OutputCommandBuilder_EachOutputMapsToItsOwnControlAndDutyBytes()
        {
            int[] controlOffsets = [4, 7, 10, 13, 16, 19, 22, 25];
            int[] dutyOffsets    = [5, 8, 11, 14, 17, 20, 23, 26];

            for (int i = 0; i < 8; i++)
            {
                var data = new OutputCommandBuilder()
                    .WithOutput(i, true, OutputState.On, 128)
                    .BuildCommandData();

                (data[controlOffsets[i]] & 0x80).Should().Be(0x80, $"output {i} ChangeEnabled at [{controlOffsets[i]}]");
                (data[controlOffsets[i]] & 0x10).Should().Be(0x10, $"output {i} On bit at [{controlOffsets[i]}]");
                data[dutyOffsets[i]].Should().Be(128, $"output {i} duty cycle at [{dutyOffsets[i]}]");
            }
        }

        [Fact]
        public void OutputCommandBuilder_OutputsDoNotCrossContaminateBytes()
        {
            var data = new OutputCommandBuilder()
                .WithOutput(3, true, OutputState.On, 99)
                .BuildCommandData();

            data[4].Should().Be(0);
            data[7].Should().Be(0);
            data[10].Should().Be(0);
            (data[13] & 0x90).Should().Be(0x90);
            data[14].Should().Be(99);
            data[16].Should().Be(0);
        }

        // --- BuildLegacyCommandData ---

        [Fact]
        public void OutputCommandBuilder_Legacy_ReportIdAtByte0()
        {
            var data = new OutputCommandBuilder().BuildLegacyCommandData();

            data[0].Should().Be(0x3F);
        }

        [Fact]
        public void OutputCommandBuilder_Legacy_PacketIdAtByte1()
        {
            var data = new OutputCommandBuilder().BuildLegacyCommandData();

            data[1].Should().Be(0x37);
        }

        [Fact]
        public void OutputCommandBuilder_Legacy_NoPortByte()
        {
            var data = new OutputCommandBuilder().WithPort(2).BuildLegacyCommandData();

            data[2].Should().Be(0);
        }

        [Fact]
        public void OutputCommandBuilder_Legacy_SupportsNinthOutput()
        {
            var data = new OutputCommandBuilder()
                .WithOutput(8, true, OutputState.On, 77)
                .BuildLegacyCommandData();

            (data[28] & 0x90).Should().Be(0x90);
            data[29].Should().Be(77);
        }

        [Fact]
        public void OutputCommandBuilder_Legacy_NinthOutputDoesNotAffectOthers()
        {
            var data = new OutputCommandBuilder()
                .WithOutput(8, true, OutputState.On, 0)
                .BuildLegacyCommandData();

            int[] controlOffsets = [4, 7, 10, 13, 16, 19, 22, 25];
            foreach (var offset in controlOffsets)
                data[offset].Should().Be(0, $"control byte at [{offset}] should be unaffected");
        }
    }
}
