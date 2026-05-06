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
                "LED 1 - Red",
                "LED 1 - Green",
                "LED 1 - Blue",
                "LED 2 - Red",
                "LED 2 - Green",
                "LED 2 - Blue",
                "LED 3 - Red",
                "LED 3 - Green",
                "LED 3 - Blue",
                "Test Complete"
            ];
        private readonly string[] LedColors =
            [
                "Red",
                "Lime",
                "CornflowerBlue"
            ];

        public LedTestPresenter(ILedTestView ledTestView, IHidService hidService)
        {
            _ledTestView = ledTestView;
            _hidService = hidService;
            _testCount = 10;

            _ledTestView.StartClicked += LedTestView_StartClicked;
            _ledTestView.StartEnabled = false;
            _ledTestView.StatusText = "N/A";
            SetLedColors();

            _testTimer = new System.Windows.Forms.Timer();
            _testTimer.Interval = 2000;
            _testTimer.Tick += TimerHandler;

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
            _ledTestView.StatusText = TestDisplay[_testCount];
            SetLedColors();
            SendCurrentCommand();
            _testTimer.Start();
        }

        private void TimerHandler(object? sender, EventArgs e)
        {
            _ledTestView.StatusText = TestDisplay[_testCount];
            SetLedColors();
            SendCurrentCommand();

            if (_testCount > 9) 
            {
                _testTimer.Stop();
                _ledTestView.StartEnabled = true;
            }
        }

        private void SetLedColors()
        {
            if (_testCount < 3)
            {
                _ledTestView.LedColor1 = LedColors[_testCount % 3];
                _ledTestView.LedColor2 = "Gray";
                _ledTestView.LedColor3 = "Gray";
            }
            else if (_testCount < 6)
            {
                _ledTestView.LedColor1 = "Gray";
                _ledTestView.LedColor2 = LedColors[_testCount % 3];
                _ledTestView.LedColor3 = "Gray";
            }
            else if (_testCount < 9)
            {
                _ledTestView.LedColor1 = "Gray";
                _ledTestView.LedColor2 = "Gray";
                _ledTestView.LedColor3 = LedColors[_testCount % 3];
            }
            else
            {
                _ledTestView.LedColor1 = "Gray";
                _ledTestView.LedColor2 = "Gray";
                _ledTestView.LedColor3 = "Gray";
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
