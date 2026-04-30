using HID_Test_App.Commands;
using HID_Test_App.Models;
using HID_Test_App.Views;
using HidSharp;

namespace HID_Test_App.Presenters
{
    public class MainPresenter
    {
        private readonly IMainForm mainForm;
        private HidDevice? hidDevice;
        private readonly OutputCommandBuilder outputCommandBuilder;

        public MainPresenter(IMainForm mainForm)
        {
            this.mainForm = mainForm;

            this.mainForm.VendorId = "2047";
            this.mainForm.ProductId = "3737";
            this.mainForm.ConnectEnabled = true;
            this.mainForm.DisconnectEnabled = false;
            this.mainForm.OutputPort = 0;
            this.mainForm.ChangeEnabled0 = false;
            this.mainForm.ChangeEnabled1 = false;
            this.mainForm.ChangeEnabled2 = false;
            this.mainForm.ChangeEnabled3 = false;
            this.mainForm.ChangeEnabled4 = false;
            this.mainForm.ChangeEnabled5 = false;
            this.mainForm.ChangeEnabled6 = false;
            this.mainForm.ChangeEnabled7 = false;
            this.mainForm.OutputOff0 = true;
            this.mainForm.OutputOff1 = true;
            this.mainForm.OutputOff2 = true;
            this.mainForm.OutputOff3 = true;
            this.mainForm.OutputOff4 = true;
            this.mainForm.OutputOff5 = true;
            this.mainForm.OutputOff6 = true;
            this.mainForm.OutputOff7 = true;
            this.mainForm.OutputDutyCycle0 = 0;
            this.mainForm.OutputDutyCycle1 = 0;
            this.mainForm.OutputDutyCycle2 = 0;
            this.mainForm.OutputDutyCycle3 = 0;
            this.mainForm.OutputDutyCycle4 = 0;
            this.mainForm.OutputDutyCycle5 = 0;
            this.mainForm.OutputDutyCycle6 = 0;
            this.mainForm.OutputDutyCycle7 = 0;

            this.mainForm.ConnectClicked += MainForm_ConnectClicked;
            this.mainForm.DisconnectClicked += MainForm_DisconnectClicked;
            this.mainForm.SendClicked += MainForm_SendClicked;

            outputCommandBuilder = new OutputCommandBuilder();
        }

        private void MainForm_SendClicked(object? sender, EventArgs e)
        {
            byte[] usbData = outputCommandBuilder
                .WithPort(this.mainForm.OutputPort)
                .WithOutput(0, mainForm.ChangeEnabled0, GetOutputState(mainForm.OutputOn0, mainForm.OutputPwm0), (int)mainForm.OutputDutyCycle0)
                .WithOutput(1, mainForm.ChangeEnabled1, GetOutputState(mainForm.OutputOn1, mainForm.OutputPwm1), (int)mainForm.OutputDutyCycle1)
                .WithOutput(2, mainForm.ChangeEnabled2, GetOutputState(mainForm.OutputOn2, mainForm.OutputPwm2), (int)mainForm.OutputDutyCycle2)
                .WithOutput(3, mainForm.ChangeEnabled3, GetOutputState(mainForm.OutputOn3, mainForm.OutputPwm3), (int)mainForm.OutputDutyCycle3)
                .WithOutput(4, mainForm.ChangeEnabled4, GetOutputState(mainForm.OutputOn4, mainForm.OutputPwm4), (int)mainForm.OutputDutyCycle4)
                .WithOutput(5, mainForm.ChangeEnabled5, GetOutputState(mainForm.OutputOn5, mainForm.OutputPwm5), (int)mainForm.OutputDutyCycle5)
                .WithOutput(6, mainForm.ChangeEnabled6, GetOutputState(mainForm.OutputOn6, mainForm.OutputPwm6), (int)mainForm.OutputDutyCycle6)
                .WithOutput(7, mainForm.ChangeEnabled7, GetOutputState(mainForm.OutputOn7, mainForm.OutputPwm7), (int)mainForm.OutputDutyCycle7)
                .BuildCommandData();
            if (hidDevice != null && hidDevice.TryOpen(out DeviceStream stream))
            {
                using (stream)
                {
                    stream.ReadTimeout = 1000;
                    byte[] outputReport = new byte[hidDevice.GetMaxOutputReportLength()];

                    usbData.CopyTo(outputReport, 1);
                    outputReport[0] = 0x3F;
                    stream.Write(outputReport);
                }

            }

            string[] commandDisplay = [.. usbData.Select(x => Convert.ToHexString([x]))];
            mainForm.CommandData = string.Join(',', commandDisplay);
        }

        private void MainForm_DisconnectClicked(object? sender, EventArgs e)
        {
            hidDevice = null;
            mainForm.ConnectEnabled = true;
            mainForm.DisconnectEnabled = false;
        }

        private void MainForm_ConnectClicked(object? sender, EventArgs e)
        {
            Console.WriteLine("Connect Clicked");

            var vendorId = Convert.ToInt32(mainForm.VendorId, 16);
            var productId = Convert.ToInt32(mainForm.ProductId, 16);

            var list = DeviceList.Local;

            hidDevice = list.GetHidDevices(vendorId, productId).FirstOrDefault();

            if (hidDevice != null) 
            {
                mainForm.ConnectEnabled = false;
                mainForm.DisconnectEnabled = true;
            }
        }

        private static OutputState GetOutputState(bool outputOn, bool outputPwm)
        {
            if (outputOn)
            {
                return OutputState.On;
            }
            if (outputPwm)
            {
                return OutputState.PWM;
            }
            return OutputState.Off;
        }
    }
}
