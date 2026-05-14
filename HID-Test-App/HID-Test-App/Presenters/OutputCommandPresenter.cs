using HID_Test_App.Commands;
using HID_Test_App.Models;
using HID_Test_App.Services;
using HID_Test_App.Views;

namespace HID_Test_App.Presenters
{
    public class OutputCommandPresenter
    {
        private readonly IOutputCommandView _outputCommandView;
        private readonly OutputCommandBuilder outputCommandBuilder;
        private readonly IHidService _hidService;

        public OutputCommandPresenter(IOutputCommandView outputCommandView, IHidService hidService)
        {
            _outputCommandView = outputCommandView;
            _hidService = hidService;

            _outputCommandView.SendEnabled = false;
            _outputCommandView.SentLabelVisible = false;
            _outputCommandView.OutputPort = 0;
            ResetInputs();

            _outputCommandView.SendClicked += OutputCommandView_SendClicked;
            _outputCommandView.PortChanged += OutputCommandView_PortChanged;
            _hidService.ConnectionChanged += HidService_ConnectionChanged;

            outputCommandBuilder = new OutputCommandBuilder();
        }

        public void SendTimerExpired()
        {
            _outputCommandView.StopSendTimer();
            _outputCommandView.SendEnabled = _hidService.Connected;
            _outputCommandView.SentLabelVisible = false;
        }

        private void HidService_ConnectionChanged(object? sender, bool e)
        {
            _outputCommandView.SendEnabled = e;
        }

        private void OutputCommandView_PortChanged(object? sender, EventArgs e)
        {
            ResetInputs();
        }

        void ResetInputs()
        {
            _outputCommandView.ChangeEnabled0 = false;
            _outputCommandView.ChangeEnabled1 = false;
            _outputCommandView.ChangeEnabled2 = false;
            _outputCommandView.ChangeEnabled3 = false;
            _outputCommandView.ChangeEnabled4 = false;
            _outputCommandView.ChangeEnabled5 = false;
            _outputCommandView.ChangeEnabled6 = false;
            _outputCommandView.ChangeEnabled7 = false;
            _outputCommandView.OutputOff0 = true;
            _outputCommandView.OutputOff1 = true;
            _outputCommandView.OutputOff2 = true;
            _outputCommandView.OutputOff3 = true;
            _outputCommandView.OutputOff4 = true;
            _outputCommandView.OutputOff5 = true;
            _outputCommandView.OutputOff6 = true;
            _outputCommandView.OutputOff7 = true;
            _outputCommandView.OutputDutyCycle0 = 0;
            _outputCommandView.OutputDutyCycle1 = 0;
            _outputCommandView.OutputDutyCycle2 = 0;
            _outputCommandView.OutputDutyCycle3 = 0;
            _outputCommandView.OutputDutyCycle4 = 0;
            _outputCommandView.OutputDutyCycle5 = 0;
            _outputCommandView.OutputDutyCycle6 = 0;
            _outputCommandView.OutputDutyCycle7 = 0;

        }

        private void OutputCommandView_SendClicked(object? sender, EventArgs e)
        {
            _outputCommandView.SendEnabled = false;
            _outputCommandView.SentLabelVisible = true;
            _outputCommandView.StartSendTimer();
            byte[] usbData = outputCommandBuilder
                .WithPort(_outputCommandView.OutputPort)
                .WithOutput(0, _outputCommandView.ChangeEnabled0, GetOutputState(_outputCommandView.OutputOn0, _outputCommandView.OutputPwm0), (int)_outputCommandView.OutputDutyCycle0)
                .WithOutput(1, _outputCommandView.ChangeEnabled1, GetOutputState(_outputCommandView.OutputOn1, _outputCommandView.OutputPwm1), (int)_outputCommandView.OutputDutyCycle1)
                .WithOutput(2, _outputCommandView.ChangeEnabled2, GetOutputState(_outputCommandView.OutputOn2, _outputCommandView.OutputPwm2), (int)_outputCommandView.OutputDutyCycle2)
                .WithOutput(3, _outputCommandView.ChangeEnabled3, GetOutputState(_outputCommandView.OutputOn3, _outputCommandView.OutputPwm3), (int)_outputCommandView.OutputDutyCycle3)
                .WithOutput(4, _outputCommandView.ChangeEnabled4, GetOutputState(_outputCommandView.OutputOn4, _outputCommandView.OutputPwm4), (int)_outputCommandView.OutputDutyCycle4)
                .WithOutput(5, _outputCommandView.ChangeEnabled5, GetOutputState(_outputCommandView.OutputOn5, _outputCommandView.OutputPwm5), (int)_outputCommandView.OutputDutyCycle5)
                .WithOutput(6, _outputCommandView.ChangeEnabled6, GetOutputState(_outputCommandView.OutputOn6, _outputCommandView.OutputPwm6), (int)_outputCommandView.OutputDutyCycle6)
                .WithOutput(7, _outputCommandView.ChangeEnabled7, GetOutputState(_outputCommandView.OutputOn7, _outputCommandView.OutputPwm7), (int)_outputCommandView.OutputDutyCycle7)
                .BuildCommandData();

            string[] commandDisplay = [.. usbData.Select(x => Convert.ToHexString([x]))];
            _outputCommandView.CommandData = string.Join(',', commandDisplay);

            _hidService.WriteConfigurationReport(usbData);
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
