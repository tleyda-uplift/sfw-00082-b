using HID_Test_App.Models;
using HID_Test_App.Services;
using HID_Test_App.Views;
using System.ComponentModel;

namespace HID_Test_App.Presenters
{
    public class StatusPresenter
    {
        private readonly IStatusView _statusView;
        private readonly IHidService _hidService;
        private BindingList<InputStatus> _inputStatuses;
        private System.Windows.Forms.Timer _statusTimer;

        public StatusPresenter(IStatusView statusView, IHidService hidService)
        {
            _statusView = statusView;
            _hidService = hidService;

            _statusView.RequestClicked += StatusView_RequestClicked;

            _inputStatuses = [..Enumerable.Range(0, 24).Select(idx => new InputStatus((idx / 8) + 1, (idx % 8) + 1))];

            _statusView.SetInputStatusDataSource(_inputStatuses);

            _statusTimer = new System.Windows.Forms.Timer();
            _statusTimer.Interval = 1000;
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
                var report = _hidService.GetReport(0x40);
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

        private void StatusView_RequestClicked(object? sender, EventArgs e)
        {
            try
            {
                var report = _hidService.GetReport(0x40);
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
            } catch {
                _statusView.RawStatus = "Failed to retrieve status";
            }
        }

        private void ParseStatusData(byte[] statusData)
        {
            for (int i = 0; i < statusData.Length; i++)
            {
                int input = i * 2;
                byte status = (byte)(statusData[i] >> 4);
                _inputStatuses[input].Enabled = (status & 0x08) > 0;
                _inputStatuses[input].Resistor = (status & 0x04) > 0 ? InputResistor.PullUp : InputResistor.PullDown;
                _inputStatuses[input].State = (status & 0x01) > 0;

                input++;
                status = (byte)(statusData[i] & 0x0F);
                _inputStatuses[input].Enabled = (status & 0x08) > 0;
                _inputStatuses[input].Resistor = (status & 0x04) > 0 ? InputResistor.PullUp : InputResistor.PullDown;
                _inputStatuses[input].State = (status & 0x01) > 0;
            }
        }
    }
}
