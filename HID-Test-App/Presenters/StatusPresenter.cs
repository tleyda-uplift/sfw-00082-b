using HID_Test_App.Services;
using HID_Test_App.Views;
using System.Diagnostics;

namespace HID_Test_App.Presenters
{
    public class StatusPresenter
    {
        private readonly IStatusView _statusView;
        private readonly IHidService _hidService;

        public StatusPresenter(IStatusView statusView, IHidService hidService)
        {
            _statusView = statusView;
            _hidService = hidService;

            _statusView.RequestClicked += StatusView_RequestClicked;
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
                }
                else
                {
                    _statusView.RawStatus = "Failed to retrieve status";
                }
            } catch {
                _statusView.RawStatus = "Failed to retrieve status";
            }
        }
    }
}
