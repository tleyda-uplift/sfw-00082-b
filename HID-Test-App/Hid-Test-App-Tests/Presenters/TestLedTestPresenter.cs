using FluentAssertions;
using HID_Test_App.Commands;
using HID_Test_App.Models;
using HID_Test_App.Presenters;
using HID_Test_App.Views;
using Hid_Test_App_Tests.Fakes;

namespace Hid_Test_App_Tests.Presenters
{
    internal class TestLedTestView : ILedTestView
    {
        bool _prevEnabled;
        bool _runPauseEnabled;
        bool _nextEnabled;
        bool _resetEnabled;
        string _statusText = "";
        string _ledColor1 = "";
        string _ledColor2 = "";
        string _ledColor3 = "";
        string _runPauseText = "";
        bool _timerRunning = false;

        public bool PrevEnabled { get => _prevEnabled; set => _prevEnabled = value; }
        public bool RunPauseEnabled { get => _runPauseEnabled; set => _runPauseEnabled = value; }
        public bool NextEnabled { get => _nextEnabled; set => _nextEnabled = value; }
        public bool ResetEnabled { get => _resetEnabled; set => _resetEnabled = value; }
        public string StatusText { get => _statusText; set => _statusText = value; }
        public string LedColor1 { get => _ledColor1; set => _ledColor1 = value; }
        public string LedColor2 { get => _ledColor2; set => _ledColor2 = value; }
        public string LedColor3 { get => _ledColor3; set => _ledColor3 = value; }
        public string RunPauseText { set => _runPauseText = value; }
        public string RunPauseTextValue { get => _runPauseText; }
        public bool TimerRunning { get => _timerRunning; }

        public event EventHandler PrevClicked = delegate { };
        public event EventHandler RunPauseClicked = delegate { };
        public event EventHandler NextClicked = delegate { };
        public event EventHandler ResetClicked = delegate { };

        public void ClickPrev() => PrevClicked?.Invoke(this, EventArgs.Empty);
        public void ClickNext() => NextClicked?.Invoke(this, EventArgs.Empty);
        public void ClickRunPause() => RunPauseClicked?.Invoke(this, EventArgs.Empty);
        public void ClickReset() => ResetClicked?.Invoke(this, EventArgs.Empty);

        public void StartTimer() => _timerRunning = true;
        public void StopTimer() => _timerRunning = false;
    }

    public class TestLedTestPresenter
    {
        private readonly TestLedTestView _testView;
        private readonly FakeHidService _hidService;
        private readonly LedTestPresenter _presenter;

        public TestLedTestPresenter()
        {
            _testView = new TestLedTestView();
            _hidService = new FakeHidService();
            _presenter = new LedTestPresenter(_testView, _hidService);
        }

        [Fact]
        public void LedTestPresenter_DefaultsButtonsDisabled()
        {
            _testView.RunPauseEnabled.Should().BeFalse();
            _testView.PrevEnabled.Should().BeFalse();
            _testView.NextEnabled.Should().BeFalse();
            _testView.ResetEnabled.Should().BeFalse();
        }

        [Fact]
        public void LedTestPresenter_DefaultsStatusText()
        {
            _testView.StatusText.Should().Be("N/A");
        }

        [Fact]
        public void LedTestPresenter_DefaultsLedColorsGray()
        {
            _testView.LedColor1.Should().Be("Gray");
            _testView.LedColor2.Should().Be("Gray");
            _testView.LedColor3.Should().Be("Gray");
        }

        [Fact]
        public void LedTestPresenter_EnablesNavigationButtonsOnConnect()
        {
            _hidService.Connect(0, 0);

            _testView.RunPauseEnabled.Should().BeTrue();
            _testView.PrevEnabled.Should().BeTrue();
            _testView.NextEnabled.Should().BeTrue();
        }

        [Fact]
        public void LedTestPresenter_ResetButtonDisabledInResetState()
        {
            _hidService.Connect(0, 0);

            _testView.ResetEnabled.Should().BeFalse();
        }

        [Fact]
        public void LedTestPresenter_DisablesButtonsOnDisconnect()
        {
            _hidService.Connect(0, 0);
            _hidService.Disconnect();

            _testView.RunPauseEnabled.Should().BeFalse();
            _testView.PrevEnabled.Should().BeFalse();
            _testView.NextEnabled.Should().BeFalse();
            _testView.ResetEnabled.Should().BeFalse();
        }

        [Fact]
        public void LedTestPresenter_NextFromResetGoesToFirstStep()
        {
            _testView.ClickNext();

            _testView.StatusText.Should().Be("LED 1 - Red");
            _testView.LedColor1.Should().Be("Red");
            _testView.LedColor2.Should().Be("Gray");
            _testView.LedColor3.Should().Be("Gray");
        }

        [Fact]
        public void LedTestPresenter_NextWrapsFromLastStepToFirst()
        {
            for (int i = 0; i < 10; i++)
                _testView.ClickNext();

            _testView.StatusText.Should().Be("LED 1 - Red");
        }

        [Fact]
        public void LedTestPresenter_PrevFromResetGoesToLastStep()
        {
            _testView.ClickPrev();

            _testView.StatusText.Should().Be("LED 3 - Blue");
            _testView.LedColor1.Should().Be("Gray");
            _testView.LedColor2.Should().Be("Gray");
            _testView.LedColor3.Should().Be("CornflowerBlue");
        }

        [Fact]
        public void LedTestPresenter_PrevFromFirstStepWrapsToLast()
        {
            _testView.ClickNext();
            _testView.ClickPrev();

            _testView.StatusText.Should().Be("LED 3 - Blue");
        }

        [Fact]
        public void LedTestPresenter_ResetButtonEnabledAfterManualNavigation()
        {
            _hidService.Connect(0, 0);
            _testView.ClickNext();

            _testView.ResetEnabled.Should().BeTrue();
        }

        [Fact]
        public void LedTestPresenter_ResetButtonReturnsToInitialState()
        {
            _testView.ClickNext();
            _testView.ClickNext();
            _testView.ClickReset();

            _testView.StatusText.Should().Be("N/A");
            _testView.LedColor1.Should().Be("Gray");
            _testView.LedColor2.Should().Be("Gray");
            _testView.LedColor3.Should().Be("Gray");
        }

        [Fact]
        public void LedTestPresenter_ResetDisablesResetButtonWhenConnected()
        {
            _hidService.Connect(0, 0);
            _testView.ClickNext();
            _testView.ClickReset();

            _testView.ResetEnabled.Should().BeFalse();
        }

        [Fact]
        public void LedTestPresenter_RunFromResetStartsTimerAtFirstStep()
        {
            _hidService.Connect(0, 0);
            _testView.ClickRunPause();

            _testView.TimerRunning.Should().BeTrue();
            _testView.StatusText.Should().Be("LED 1 - Red");
        }

        [Fact]
        public void LedTestPresenter_RunFromResetSetsRunPauseTextToPause()
        {
            _hidService.Connect(0, 0);
            _testView.ClickRunPause();

            _testView.RunPauseTextValue.Should().Be("Pause");
        }

        [Fact]
        public void LedTestPresenter_RunFromResetDisablesNavButtons()
        {
            _hidService.Connect(0, 0);
            _testView.ClickRunPause();

            _testView.PrevEnabled.Should().BeFalse();
            _testView.NextEnabled.Should().BeFalse();
            _testView.ResetEnabled.Should().BeFalse();
        }

        [Fact]
        public void LedTestPresenter_RunFromManualContinuesFromCurrentStep()
        {
            _hidService.Connect(0, 0);
            _testView.ClickNext();
            _testView.ClickNext();
            _testView.ClickRunPause();

            _testView.TimerRunning.Should().BeTrue();
            _testView.StatusText.Should().Be("LED 1 - Green");
        }

        [Fact]
        public void LedTestPresenter_PauseFromRunningStopsTimer()
        {
            _hidService.Connect(0, 0);
            _testView.ClickRunPause();
            _testView.ClickRunPause();

            _testView.TimerRunning.Should().BeFalse();
        }

        [Fact]
        public void LedTestPresenter_PauseTransitionsToManualState()
        {
            _hidService.Connect(0, 0);
            _testView.ClickRunPause();
            _testView.ClickRunPause();

            _testView.RunPauseTextValue.Should().Be("Run");
            _testView.PrevEnabled.Should().BeTrue();
            _testView.NextEnabled.Should().BeTrue();
            _testView.ResetEnabled.Should().BeTrue();
        }

        [Fact]
        public void LedTestPresenter_TimerHandlerAdvancesToNextStep()
        {
            _hidService.Connect(0, 0);
            _testView.ClickRunPause();

            _presenter.TimerHandler();

            _testView.StatusText.Should().Be("LED 1 - Green");
            _testView.LedColor1.Should().Be("Lime");
        }

        [Fact]
        public void LedTestPresenter_TimerHandlerStopsTimerAtEnd()
        {
            _hidService.Connect(0, 0);
            _testView.ClickRunPause();

            for (int i = 0; i < 9; i++)
                _presenter.TimerHandler();

            _testView.TimerRunning.Should().BeFalse();
            _testView.StatusText.Should().Be("Test Complete");
        }

        [Fact]
        public void LedTestPresenter_TimerHandlerResetsButtonStatesAtEnd()
        {
            _hidService.Connect(0, 0);
            _testView.ClickRunPause();

            for (int i = 0; i < 9; i++)
                _presenter.TimerHandler();

            _testView.RunPauseTextValue.Should().Be("Run");
            _testView.PrevEnabled.Should().BeTrue();
            _testView.NextEnabled.Should().BeTrue();
            _testView.ResetEnabled.Should().BeFalse();
        }

        [Fact]
        public void LedTestPresenter_LedColorsCorrectForLed2Steps()
        {
            _testView.ClickNext();
            _testView.ClickNext();
            _testView.ClickNext();
            _testView.ClickNext();

            _testView.StatusText.Should().Be("LED 2 - Red");
            _testView.LedColor1.Should().Be("Gray");
            _testView.LedColor2.Should().Be("Red");
            _testView.LedColor3.Should().Be("Gray");
        }

        [Fact]
        public void LedTestPresenter_LedColorsCorrectForLed3Steps()
        {
            for (int i = 0; i < 7; i++)
                _testView.ClickNext();

            _testView.StatusText.Should().Be("LED 3 - Red");
            _testView.LedColor1.Should().Be("Gray");
            _testView.LedColor2.Should().Be("Gray");
            _testView.LedColor3.Should().Be("Red");
        }

        [Fact]
        public void LedTestPresenter_SendsLegacyCommandOnNext()
        {
            _hidService.Connect(0, 0);
            _testView.ClickNext();

            var expectedData = new OutputCommandBuilder()
                .WithOutput(0, true, OutputState.Off, 0)
                .WithOutput(1, true, OutputState.Off, 0)
                .WithOutput(2, true, OutputState.Off, 0)
                .WithOutput(3, true, OutputState.Off, 0)
                .WithOutput(4, true, OutputState.Off, 0)
                .WithOutput(5, true, OutputState.Off, 0)
                .WithOutput(6, true, OutputState.Off, 0)
                .WithOutput(7, true, OutputState.Off, 0)
                .WithOutput(8, true, OutputState.Off, 0)
                .WithOutput(0, true, OutputState.On, 0)
                .BuildLegacyCommandData();

            _hidService.WriteReportId.Should().Be(_hidService.ConfigurationReportId);
            _hidService.WriteReportData.Should().BeEqualTo(expectedData);
        }

        [Fact]
        public void LedTestPresenter_SendsAllOffCommandOnReset()
        {
            _hidService.Connect(0, 0);
            _testView.ClickNext();
            _testView.ClickReset();

            var expectedData = new OutputCommandBuilder()
                .WithOutput(0, true, OutputState.Off, 0)
                .WithOutput(1, true, OutputState.Off, 0)
                .WithOutput(2, true, OutputState.Off, 0)
                .WithOutput(3, true, OutputState.Off, 0)
                .WithOutput(4, true, OutputState.Off, 0)
                .WithOutput(5, true, OutputState.Off, 0)
                .WithOutput(6, true, OutputState.Off, 0)
                .WithOutput(7, true, OutputState.Off, 0)
                .WithOutput(8, true, OutputState.Off, 0)
                .BuildLegacyCommandData();

            _hidService.WriteReportData.Should().BeEqualTo(expectedData);
        }
    }
}
