using HID_Test_App.Commands;
using HID_Test_App.Models;
using HID_Test_App.Services;
using HID_Test_App.Views;

namespace HID_Test_App.Presenters
{
    public class InputConfigPresenter
    {
        private readonly IInputConfigView _inputConfigView;
        private readonly IHidService _hidService;

        public InputConfigPresenter(IInputConfigView inputConfigView, IHidService hidService) 
        {
            _inputConfigView = inputConfigView;
            _hidService = hidService;

            _inputConfigView.SendEnabled = false;
            _inputConfigView.InputPort = 0;
            ResetInputs();

            _inputConfigView.SendClicked += InputConfigView_SendClicked;
            _inputConfigView.PortChanged += InputConfigView_PortChanged;
            _hidService.ConnectionChanged += HidService_ConnectionChanged;
        }

        private void HidService_ConnectionChanged(object? sender, bool e)
        {
            _inputConfigView.SendEnabled = e;
        }

        private void InputConfigView_PortChanged(object? sender, EventArgs e)
        {
            ResetInputs();
        }

        private void ResetInputs()
        {
            _inputConfigView.InputEnable0 = false;
            _inputConfigView.InputEnable1 = false;
            _inputConfigView.InputEnable2 = false;
            _inputConfigView.InputEnable3 = false;
            _inputConfigView.InputEnable4 = false;
            _inputConfigView.InputEnable5 = false;
            _inputConfigView.InputEnable6 = false;
            _inputConfigView.InputEnable7 = false;
            _inputConfigView.PullResistor0 = 0;
            _inputConfigView.PullResistor1 = 0;
            _inputConfigView.PullResistor2 = 0;
            _inputConfigView.PullResistor3 = 0;
            _inputConfigView.PullResistor4 = 0;
            _inputConfigView.PullResistor5 = 0;
            _inputConfigView.PullResistor6 = 0;
            _inputConfigView.PullResistor7 = 0;

        }

        private void InputConfigView_SendClicked(object? sender, EventArgs e)
        {
            var builder = new InputConfigBuilder();
            byte[] usbData = builder
                .WithPort(_inputConfigView.InputPort)
                .WithInput(0, _inputConfigView.InputEnable0, (InputResistor)_inputConfigView.PullResistor0)
                .WithInput(1, _inputConfigView.InputEnable1, (InputResistor)_inputConfigView.PullResistor1)
                .WithInput(2, _inputConfigView.InputEnable2, (InputResistor)_inputConfigView.PullResistor2)
                .WithInput(3, _inputConfigView.InputEnable3, (InputResistor)_inputConfigView.PullResistor3)
                .WithInput(4, _inputConfigView.InputEnable4, (InputResistor)_inputConfigView.PullResistor4)
                .WithInput(5, _inputConfigView.InputEnable5, (InputResistor)_inputConfigView.PullResistor5)
                .WithInput(6, _inputConfigView.InputEnable6, (InputResistor)_inputConfigView.PullResistor6)
                .WithInput(7, _inputConfigView.InputEnable7, (InputResistor)_inputConfigView.PullResistor7)
                .BuildConfigData();

            _hidService.WriteConfigurationReport(usbData);
        }
    }
}
