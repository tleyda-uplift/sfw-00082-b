using FluentAssertions;
using HID_Test_App.Commands;
using HID_Test_App.Models;

namespace Hid_Test_App_Tests.Commands
{
    public class TestInputConfigBuilder
    {
        [Fact]
        public void InputConfigBuilder_ReportIdAtByte0()
        {
            var data = new InputConfigBuilder().BuildConfigData();

            data[0].Should().Be(0x3F);
        }

        [Fact]
        public void InputConfigBuilder_PacketIdAtByte1()
        {
            var data = new InputConfigBuilder().BuildConfigData();

            data[1].Should().Be(0x38);
        }

        [Fact]
        public void InputConfigBuilder_PortEncodedAsOneBased()
        {
            var data = new InputConfigBuilder().WithPort(2).BuildConfigData();

            data[2].Should().Be(3);
        }

        [Fact]
        public void InputConfigBuilder_DefaultPortIsZero()
        {
            var data = new InputConfigBuilder().BuildConfigData();

            data[2].Should().Be(1);
        }

        [Fact]
        public void InputConfigBuilder_DefaultDataBytesAreZero()
        {
            var data = new InputConfigBuilder().BuildConfigData();

            data[4..12].Should().AllBeEquivalentTo((byte)0);
        }

        [Fact]
        public void InputConfigBuilder_EnabledSetsBit7OnInputByte()
        {
            var data = new InputConfigBuilder()
                .WithInput(0, true, InputResistor.PullDown)
                .BuildConfigData();

            (data[4] & 0x80).Should().Be(0x80);
        }

        [Fact]
        public void InputConfigBuilder_DisabledClearsBit7OnInputByte()
        {
            var data = new InputConfigBuilder()
                .WithInput(0, false, InputResistor.PullDown)
                .BuildConfigData();

            (data[4] & 0x80).Should().Be(0);
        }

        [Fact]
        public void InputConfigBuilder_PullUpSetsBit0OnInputByte()
        {
            var data = new InputConfigBuilder()
                .WithInput(0, false, InputResistor.PullUp)
                .BuildConfigData();

            (data[4] & 0x01).Should().Be(0x01);
        }

        [Fact]
        public void InputConfigBuilder_PullDownClearsBit0OnInputByte()
        {
            var data = new InputConfigBuilder()
                .WithInput(0, false, InputResistor.PullDown)
                .BuildConfigData();

            (data[4] & 0x01).Should().Be(0);
        }

        [Fact]
        public void InputConfigBuilder_EachInputMapsToItsOwnByte()
        {
            var data = new InputConfigBuilder()
                .WithInput(0, true, InputResistor.PullDown)
                .WithInput(1, true, InputResistor.PullDown)
                .WithInput(2, true, InputResistor.PullDown)
                .WithInput(3, true, InputResistor.PullDown)
                .WithInput(4, true, InputResistor.PullDown)
                .WithInput(5, true, InputResistor.PullDown)
                .WithInput(6, true, InputResistor.PullDown)
                .WithInput(7, true, InputResistor.PullDown)
                .BuildConfigData();

            for (int i = 0; i < 8; i++)
            {
                (data[4 + i] & 0x80).Should().Be(0x80, $"input {i} enabled bit should be set at byte {4 + i}");
            }
        }

        [Fact]
        public void InputConfigBuilder_InputsDoNotCrossContaminateBytes()
        {
            var data = new InputConfigBuilder()
                .WithInput(3, true, InputResistor.PullUp)
                .BuildConfigData();

            data[4].Should().Be(0);
            data[5].Should().Be(0);
            data[6].Should().Be(0);
            data[7].Should().Be(0x81);
            data[8].Should().Be(0);
        }

        [Fact]
        public void InputConfigBuilder_ReportIs31Bytes()
        {
            var data = new InputConfigBuilder().BuildConfigData();

            data.Length.Should().Be(31);
        }
    }
}
