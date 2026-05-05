using HID_Test_App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HID_Test_App.Commands
{
    public class InputConfigBuilder
    {
        private const byte ReportId = 0x3F;
        private const byte PacketId = 0x38;
        private int port;
        private InputConfig[] inputConfigs;

        public InputConfigBuilder() 
        {
            port = 0;
            inputConfigs = [.. Enumerable.Range(0,8).Select(_ =>  new InputConfig())];
        }

        public InputConfigBuilder WithPort(int port) { this.port = port; return this; }

        public InputConfigBuilder WithInput(int index, bool enabled, InputResistor inputResistor)
        {
            inputConfigs[index].Enabled = enabled;
            inputConfigs[index].InputResistor = inputResistor;

            return this;
        }

        public byte[] BuildConfigData()
        {
            byte[] data = new byte[31];

            data[0] = ReportId;
            data[1] = PacketId;
            data[2] = (byte)(port + 1);

            data[4] |= (byte)(inputConfigs[0].Enabled ? 0x80 : 0);
            data[4] |= GetResistorBitMask(inputConfigs[0].InputResistor);
            data[5] |= (byte)(inputConfigs[1].Enabled ? 0x80 : 0);
            data[5] |= GetResistorBitMask(inputConfigs[1].InputResistor);
            data[6] |= (byte)(inputConfigs[2].Enabled ? 0x80 : 0);
            data[6] |= GetResistorBitMask(inputConfigs[2].InputResistor);
            data[7] |= (byte)(inputConfigs[3].Enabled ? 0x80 : 0);
            data[7] |= GetResistorBitMask(inputConfigs[3].InputResistor);
            data[8] |= (byte)(inputConfigs[4].Enabled ? 0x80 : 0);
            data[9] |= GetResistorBitMask(inputConfigs[4].InputResistor);
            data[9] |= (byte)(inputConfigs[5].Enabled ? 0x80 : 0);
            data[9] |= GetResistorBitMask(inputConfigs[5].InputResistor);
            data[10] |= (byte)(inputConfigs[6].Enabled ? 0x80 : 0);
            data[10] |= GetResistorBitMask(inputConfigs[6].InputResistor);
            data[11] |= (byte)(inputConfigs[7].Enabled ? 0x80 : 0);
            data[11] |= GetResistorBitMask(inputConfigs[7].InputResistor);

            return data;
        }

        public static byte GetResistorBitMask(InputResistor inputResistor)
        {
            if (inputResistor == InputResistor.PullUp)
            {
                return 0x01;
            }
            return 0;
        }
    }
}
