using HID_Test_App.Commands;
using HID_Test_App.Models;
using HID_Test_App.Services;
using HID_Test_App.Views;

namespace HID_Test_App.Presenters
{
    public class LedTestPresenter
    {
        private readonly ILedTestView _ledTestView;
        private readonly IHidService _hidService;
        private System.Windows.Forms.Timer _testTimer;
        private int _testCount;
        private readonly string[] TestDisplay = 
            [
                "Red 1",
                "Green 1",
                "Blue 1",
                "Red 2",
                "Green 2",
                "Blue 2",
                "Red 3",
                "Green 3",
                "Blue 3",
                "N/A"
            ];

        public LedTestPresenter(ILedTestView ledTestView, IHidService hidService)
        {
            _ledTestView = ledTestView;
            _hidService = hidService;

            _ledTestView.StartClicked += LedTestView_StartClicked;
            _ledTestView.StartEnabled = false;

            _testTimer = new System.Windows.Forms.Timer();
            _testTimer.Interval = 2000;
            _testTimer.Tick += TimerHandler;
            _testCount = 0;

            _hidService.ConnectionChanged += HidService_ConnectionChanged;
        }

        private void HidService_ConnectionChanged(object? sender, bool connected)
        {
            _ledTestView.StartEnabled = connected;
        }

        private void LedTestView_StartClicked(object? sender, EventArgs e)
        {
            _ledTestView.StartEnabled = false;
            _testCount = 0;
            _ledTestView.LabelTemp = TestDisplay[_testCount];
            SendCurrentCommand();
            _testTimer.Start();
        }

        private void TimerHandler(object? sender, EventArgs e)
        {
            _ledTestView.LabelTemp = TestDisplay[_testCount];

            SendCurrentCommand();

            if (_testCount > 9) 
            {
                _testTimer.Stop();
                _ledTestView.StartEnabled = true;
            }
        }

        private void SendCurrentCommand()
        {
            var builder = new OutputCommandBuilder();
            builder = builder
                .WithOutput(0, true, OutputState.Off, 0)
                .WithOutput(1, true, OutputState.Off, 0)
                .WithOutput(2, true, OutputState.Off, 0)
                .WithOutput(3, true, OutputState.Off, 0)
                .WithOutput(4, true, OutputState.Off, 0)
                .WithOutput(5, true, OutputState.Off, 0)
                .WithOutput(6, true, OutputState.Off, 0)
                .WithOutput(7, true, OutputState.Off, 0)
                .WithOutput(8, true, OutputState.Off, 0);
            if (_testCount < 9)
            {
                builder = builder.WithOutput(_testCount, true, OutputState.On, 0);
            }
            var usbData = builder.BuildLegacyCommandData();
            _hidService.Write(0x3F, usbData);
            _testCount++;
        }
    }
}
