using HID_Test_App.Commands;
using HID_Test_App.Models;
using HID_Test_App.Services;
using HID_Test_App.Views;

namespace HID_Test_App.Presenters
{
    public class LedTestPresenter
    {
        enum TestState
        {
            Reset,
            Manual,
            Running
        }
        private TestState _testState;
        private readonly ILedTestView _ledTestView;
        private readonly IHidService _hidService;
        private System.Windows.Forms.Timer _testTimer;
        private int _testCount;
        private bool _hidConnected;
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
            _testCount = 9;
            _testState = TestState.Reset;
            _hidConnected = false;

            _ledTestView.RunPauseClicked += LedTestView_StartClicked;
            _ledTestView.PrevClicked += LedTestView_PrevClicked;
            _ledTestView.NextClicked += LedTestView_NextClicked;
            _ledTestView.ResetClicked += LedTestView_ResetClicked;

            _ledTestView.StatusText = "N/A";
            SetLedColors();
            SetButtonStates();

            _testTimer = new System.Windows.Forms.Timer();
            _testTimer.Interval = 2000;
            _testTimer.Tick += TimerHandler;

            _hidService.ConnectionChanged += HidService_ConnectionChanged;
        }

        private void LedTestView_ResetClicked(object? sender, EventArgs e)
        {
            _testCount = 9;
            _testState = TestState.Reset;
            _ledTestView.StatusText = "N/A";
            SetButtonStates();
            SetLedColors();
        }

        private void LedTestView_NextClicked(object? sender, EventArgs e)
        {
            if (_testState == TestState.Reset)
            {
                _testCount = 0;
            }
            else
            {
                _testCount++;
            }
            _testState = TestState.Manual;
            _ledTestView.StatusText = TestDisplay[_testCount];
            SetButtonStates();
            SetLedColors();
            SendCurrentCommand();
        }

        private void LedTestView_PrevClicked(object? sender, EventArgs e)
        {
            _testCount--;
            _testState = TestState.Manual;
            _ledTestView.StatusText = TestDisplay[_testCount];
            SetButtonStates();
            SetLedColors();
            SendCurrentCommand();
        }

        private void SetButtonStates()
        {
            if (_hidConnected)
            {
                switch (_testState) 
                {
                    case TestState.Reset:
                        _ledTestView.RunPauseText = "Run";
                        _ledTestView.RunPauseEnabled = true;
                        _ledTestView.PrevEnabled = false;
                        _ledTestView.NextEnabled = true;
                        _ledTestView.ResetEnabled = false;
                        break;
                    case TestState.Manual:
                        _ledTestView.RunPauseText = "Run";
                        _ledTestView.RunPauseEnabled = true;
                        _ledTestView.PrevEnabled = _testCount > 0;
                        _ledTestView.NextEnabled = _testCount < 8;
                        _ledTestView.ResetEnabled = true;
                        break;
                    case TestState.Running:
                        _ledTestView.RunPauseText = "Pause";
                        _ledTestView.RunPauseEnabled = true;
                        _ledTestView.PrevEnabled = false;
                        _ledTestView.NextEnabled = false;
                        _ledTestView.ResetEnabled = false;
                        break;
                } 
            }
            else
            {
                _ledTestView.RunPauseEnabled = false;
                _ledTestView.PrevEnabled = false;
                _ledTestView.NextEnabled = false;
                _ledTestView.ResetEnabled = false;
            }
        }

        private void HidService_ConnectionChanged(object? sender, bool connected)
        {
            _hidConnected = connected;
            SetButtonStates();
        }

        private void LedTestView_StartClicked(object? sender, EventArgs e)
        {
            if (_testState == TestState.Reset)
            {
                _testCount = 0;
                _testState = TestState.Running;
                _ledTestView.StatusText = TestDisplay[_testCount];
                SetLedColors();
                SetButtonStates();
                SendCurrentCommand();
                _testTimer.Start();
            }
            else if (_testState == TestState.Manual)
            {
                _testState = TestState.Running;
                SetButtonStates();
                _testTimer.Start();
            }
            else
            {
                _testTimer.Stop();
                _testState = TestState.Manual;
                SetButtonStates();
            }
        }

        private void TimerHandler(object? sender, EventArgs e)
        {
            if (_testCount < 9)
            {
                _testCount++;
                _ledTestView.StatusText = TestDisplay[_testCount];
                SetLedColors();
                SendCurrentCommand();
            }

            if (_testCount >= 9) 
            {
                _testTimer.Stop();
                _testState = TestState.Reset;
                SetButtonStates();
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
        }
    }
}
