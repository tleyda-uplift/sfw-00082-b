using HID_Test_App.Models;
using HID_Test_App.Services;
using HID_Test_App.Views;
using System.ComponentModel;

namespace HID_Test_App.Presenters
{
    public class StatusPresenter
    {
        private const int INPUT_ENABLE_BITMASK = 0x08;
        private const int INPUT_RESISTOR_BITMASK = 0x04;
        private const int INPUT_STATE_BITMASK = 0x01;
        private const int BYTES_PER_PORT = 4;
        private const int INPUT_NIBBLE_SHIFT = BYTES_PER_PORT;
        private const int INPUT_NIBBLE_MASK = 0x0F;
        private readonly IStatusView _statusView;
        private readonly IHidService _hidService;
        private BindingList<InputStatus> _inputStatuses1;
        private BindingList<InputStatus> _inputStatuses2;
        private BindingList<InputStatus> _inputStatuses3;
        private System.Windows.Forms.Timer _statusTimer;

        public StatusPresenter(IStatusView statusView, IHidService hidService)
        {
            _statusView = statusView;
            _hidService = hidService;

            _inputStatuses1 = [..Enumerable.Range(0, 8).Select(idx => new InputStatus(1, (idx % 8) + 1))];
            _inputStatuses2 = [..Enumerable.Range(0, 8).Select(idx => new InputStatus(2, (idx % 8) + 1))];
            _inputStatuses3 = [..Enumerable.Range(0, 8).Select(idx => new InputStatus(3, (idx % 8) + 1))];

            _statusView.SetInputStatusDataSource(_inputStatuses1, _inputStatuses2, _inputStatuses3);

            _statusTimer = new System.Windows.Forms.Timer();
            _statusTimer.Interval = 500;
            _statusTimer.Tick += TimerHandler;

            _hidService.ConnectionChanged += HidService_ConnectionChanged;
        }

        private void HidService_ConnectionChanged(object? sender, bool connected)
        {
            if (connected)
            {
                _statusTimer.Start();
            }
            else
            {
                _statusTimer.Stop();
            }
        }

        private void TimerHandler(object? sender, EventArgs e)
        {
            try
            {
                var report = _hidService.GetStatusReport();
                if (report.Length > 0)
                {
                    string[] statusDisplay = [.. report.Select(x => Convert.ToHexString([x]))];
                    _statusView.RawStatus = string.Join(',', statusDisplay);
                    ParseStatusData(report[1..13]);
                }
                else
                {
                    _statusView.RawStatus = "Failed to retrieve status";
                }
            }
            catch
            {
                _statusView.RawStatus = "Failed to retrieve status";
            }
        }

        private void ParseStatusData(byte[] statusData)
        {
            for (int i = 0; i < BYTES_PER_PORT; i++)
            {
                int input = i * 2;
                byte status = (byte)(statusData[i] >> INPUT_NIBBLE_SHIFT);
                _inputStatuses1[input].Enabled = (status & INPUT_ENABLE_BITMASK) > 0;
                _inputStatuses1[input].Resistor = (status & INPUT_RESISTOR_BITMASK) > 0 ? InputResistor.PullUp : InputResistor.PullDown;
                _inputStatuses1[input].State = (status & INPUT_STATE_BITMASK) > 0;

                input++;
                status = (byte)(statusData[i] & INPUT_NIBBLE_MASK);
                _inputStatuses1[input].Enabled = (status & INPUT_ENABLE_BITMASK) > 0;
                _inputStatuses1[input].Resistor = (status & INPUT_RESISTOR_BITMASK) > 0 ? InputResistor.PullUp : InputResistor.PullDown;
                _inputStatuses1[input].State = (status & INPUT_STATE_BITMASK) > 0;
            }
            for (int i = 0; i < BYTES_PER_PORT; i++)
            {
                int input = i * 2;
                int portOffset = BYTES_PER_PORT;
                byte status = (byte)(statusData[i + portOffset] >> INPUT_NIBBLE_SHIFT);
                _inputStatuses2[input].Enabled = (status & INPUT_ENABLE_BITMASK) > 0;
                _inputStatuses2[input].Resistor = (status & INPUT_RESISTOR_BITMASK) > 0 ? InputResistor.PullUp : InputResistor.PullDown;
                _inputStatuses2[input].State = (status & INPUT_STATE_BITMASK) > 0;

                input++;
                status = (byte)(statusData[i + portOffset] & INPUT_NIBBLE_MASK);
                _inputStatuses2[input].Enabled = (status & INPUT_ENABLE_BITMASK) > 0;
                _inputStatuses2[input].Resistor = (status & INPUT_RESISTOR_BITMASK) > 0 ? InputResistor.PullUp : InputResistor.PullDown;
                _inputStatuses2[input].State = (status & INPUT_STATE_BITMASK) > 0;
            }
            for (int i = 0; i < BYTES_PER_PORT; i++)
            {
                int input = i * 2;
                int portOffset = BYTES_PER_PORT * 2;
                byte status = (byte)(statusData[i + portOffset] >> INPUT_NIBBLE_SHIFT);
                _inputStatuses3[input].Enabled = (status & INPUT_ENABLE_BITMASK) > 0;
                _inputStatuses3[input].Resistor = (status & INPUT_RESISTOR_BITMASK) > 0 ? InputResistor.PullUp : InputResistor.PullDown;
                _inputStatuses3[input].State = (status & INPUT_STATE_BITMASK) > 0;

                input++;
                status = (byte)(statusData[i + portOffset] & INPUT_NIBBLE_MASK);
                _inputStatuses3[input].Enabled = (status & INPUT_ENABLE_BITMASK) > 0;
                _inputStatuses3[input].Resistor = (status & INPUT_RESISTOR_BITMASK) > 0 ? InputResistor.PullUp : InputResistor.PullDown;
                _inputStatuses3[input].State = (status & INPUT_STATE_BITMASK) > 0;
            }
        }
    }
}
