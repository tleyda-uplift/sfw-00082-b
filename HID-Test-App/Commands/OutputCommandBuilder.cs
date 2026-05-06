using HID_Test_App.Models;

namespace HID_Test_App.Commands
{
    public class OutputCommandBuilder
    {
        private const byte ReportId = 0x3F;
        private const byte PacketId = 0x37;
        private const byte OutputOnBitMask = 0x10;
        private const byte OutputPwmBitMask = 0x20;
        private int port;
        private OutputParams[] outputParams;

        public OutputCommandBuilder()
        {
            port = 0;
            outputParams = [.. Enumerable.Range(0, 9).Select(_ => new OutputParams())];
        }

        public OutputCommandBuilder WithPort(int port) { this.port = port; return this;}
        public OutputCommandBuilder WithOutput(int index, bool changeEnabled, OutputState outputState, int dutyCycle)
        {
            outputParams[index].ChangeEnabled = changeEnabled;
            outputParams[index].State = outputState;
            outputParams[index].DutyCycle = dutyCycle;

            return this;
        }

        public byte[] BuildLegacyCommandData()
        {
            byte[] data = new byte[31];

            data[0] = ReportId;
            data[1] = PacketId;

            data[4] |= (byte)(outputParams[0].ChangeEnabled ? 0x80 : 0);
            data[4] |= GetControlFunctionBitMask(outputParams[0].State);
            data[5] = (byte)(outputParams[0].DutyCycle);
            data[7] |= (byte)(outputParams[1].ChangeEnabled ? 0x80 : 0);
            data[7] |= GetControlFunctionBitMask(outputParams[1].State);
            data[8] = (byte)(outputParams[1].DutyCycle);
            data[10] |= (byte)(outputParams[2].ChangeEnabled ? 0x80 : 0);
            data[10] |= GetControlFunctionBitMask(outputParams[2].State);
            data[11] = (byte)(outputParams[2].DutyCycle);
            data[13] |= (byte)(outputParams[3].ChangeEnabled ? 0x80 : 0);
            data[13] |= GetControlFunctionBitMask(outputParams[3].State);
            data[14] = (byte)(outputParams[3].DutyCycle);
            data[16] |= (byte)(outputParams[4].ChangeEnabled ? 0x80 : 0);
            data[16] |= GetControlFunctionBitMask(outputParams[4].State);
            data[17] = (byte)(outputParams[4].DutyCycle);
            data[19] |= (byte)(outputParams[5].ChangeEnabled ? 0x80 : 0);
            data[19] |= GetControlFunctionBitMask(outputParams[5].State);
            data[20] = (byte)(outputParams[5].DutyCycle);
            data[22] |= (byte)(outputParams[6].ChangeEnabled ? 0x80 : 0);
            data[22] |= GetControlFunctionBitMask(outputParams[6].State);
            data[23] = (byte)(outputParams[6].DutyCycle);
            data[25] |= (byte)(outputParams[7].ChangeEnabled ? 0x80 : 0);
            data[25] |= GetControlFunctionBitMask(outputParams[7].State);
            data[26] = (byte)(outputParams[7].DutyCycle);
            data[27] |= (byte)(outputParams[8].ChangeEnabled ? 0x80 : 0);
            data[27] |= GetControlFunctionBitMask(outputParams[8].State);
            data[28] = (byte)(outputParams[8].DutyCycle);

            return data;
        }

        public byte[] BuildCommandData()
        {
            byte[] data = new byte[31];

            data[0] = ReportId;
            data[1] = PacketId;
            data[2] = (byte)(port + 1);

            data[4] |= (byte)(outputParams[0].ChangeEnabled ? 0x80 : 0);
            data[4] |= GetControlFunctionBitMask(outputParams[0].State);
            data[5] = (byte)(outputParams[0].DutyCycle);
            data[7] |= (byte)(outputParams[1].ChangeEnabled ? 0x80 : 0);
            data[7] |= GetControlFunctionBitMask(outputParams[1].State);
            data[8] = (byte)(outputParams[1].DutyCycle);
            data[10] |= (byte)(outputParams[2].ChangeEnabled ? 0x80 : 0);
            data[10] |= GetControlFunctionBitMask(outputParams[2].State);
            data[11] = (byte)(outputParams[2].DutyCycle);
            data[13] |= (byte)(outputParams[3].ChangeEnabled ? 0x80 : 0);
            data[13] |= GetControlFunctionBitMask(outputParams[3].State);
            data[14] = (byte)(outputParams[3].DutyCycle);
            data[16] |= (byte)(outputParams[4].ChangeEnabled ? 0x80 : 0);
            data[16] |= GetControlFunctionBitMask(outputParams[4].State);
            data[17] = (byte)(outputParams[4].DutyCycle);
            data[19] |= (byte)(outputParams[5].ChangeEnabled ? 0x80 : 0);
            data[19] |= GetControlFunctionBitMask(outputParams[5].State);
            data[20] = (byte)(outputParams[5].DutyCycle);
            data[22] |= (byte)(outputParams[6].ChangeEnabled ? 0x80 : 0);
            data[22] |= GetControlFunctionBitMask(outputParams[6].State);
            data[23] = (byte)(outputParams[6].DutyCycle);
            data[25] |= (byte)(outputParams[7].ChangeEnabled ? 0x80 : 0);
            data[25] |= GetControlFunctionBitMask(outputParams[7].State);
            data[26] = (byte)(outputParams[7].DutyCycle);

            return data;
        }

        private static byte GetControlFunctionBitMask(OutputState outputState)
        {
            if (outputState == OutputState.PWM)
            {
                return OutputPwmBitMask;
            }
            if (outputState == OutputState.On)
            {
                return OutputOnBitMask;
            }

            return (byte)0;
        }
    }
}
