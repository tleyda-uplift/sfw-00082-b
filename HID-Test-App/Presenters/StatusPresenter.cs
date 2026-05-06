using HID_Test_App.Services;
using HID_Test_App.Views;

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
            var report = _hidService.GetReport(0x40);
            Console.WriteLine(report);
        }
    }
}
