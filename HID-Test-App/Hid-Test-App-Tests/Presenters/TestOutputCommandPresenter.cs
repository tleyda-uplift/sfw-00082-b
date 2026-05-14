using FluentAssertions;
using HID_Test_App.Commands;
using HID_Test_App.Models;
using HID_Test_App.Presenters;
using HID_Test_App.Views;
using Hid_Test_App_Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hid_Test_App_Tests.Presenters
{
    internal class TestOutputCommandView : IOutputCommandView
    {
        int _port;
        bool[] _changeEnable = [.. Enumerable.Range(0, 8).Select(_ => false)];
        bool[] _outputOff = [.. Enumerable.Range(0, 8).Select(_ => false)];
        bool[] _outputOn = [.. Enumerable.Range(0, 8).Select(_ => false)];
        bool[] _outputPwm = [.. Enumerable.Range(0, 8).Select(_ => false)];
        OutputState[] _outputState = [.. Enumerable.Range(0, 8).Select(_ => OutputState.Off)];
        decimal[] _dutyCycle = new decimal[8];
        bool _sendEnabled = false;
        string _rawData = "";
        bool _sendTimerStarted = false;
        bool _sentLabelVisible = false;

        public bool SendTimerStarted { get => _sendTimerStarted; }

        public string CommandData { get => _rawData; set => _rawData = value; }
        public int OutputPort { get => _port; set => _port = value; }
        public bool ChangeEnabled0 { get => _changeEnable[0]; set => _changeEnable[0] = value; }
        public bool ChangeEnabled1 { get => _changeEnable[1]; set => _changeEnable[1] = value; }
        public bool ChangeEnabled2 { get => _changeEnable[2]; set => _changeEnable[2] = value; }
        public bool ChangeEnabled3 { get => _changeEnable[3]; set => _changeEnable[3] = value; }
        public bool ChangeEnabled4 { get => _changeEnable[4]; set => _changeEnable[4] = value; }
        public bool ChangeEnabled5 { get => _changeEnable[5]; set => _changeEnable[5] = value; }
        public bool ChangeEnabled6 { get => _changeEnable[6]; set => _changeEnable[6] = value; }
        public bool ChangeEnabled7 { get => _changeEnable[7]; set => _changeEnable[7] = value; }
        public bool OutputOff0 { get => _outputState[0] == OutputState.Off; set => _outputState[0] = value ? OutputState.Off : _outputState[0]; }
        public bool OutputOff1 { get => _outputState[1] == OutputState.Off; set => _outputState[1] = value ? OutputState.Off : _outputState[1]; }
        public bool OutputOff2 { get => _outputState[2] == OutputState.Off; set => _outputState[2] = value ? OutputState.Off : _outputState[2]; }
        public bool OutputOff3 { get => _outputState[3] == OutputState.Off; set => _outputState[3] = value ? OutputState.Off : _outputState[3]; }
        public bool OutputOff4 { get => _outputState[4] == OutputState.Off; set => _outputState[4] = value ? OutputState.Off : _outputState[4]; }
        public bool OutputOff5 { get => _outputState[5] == OutputState.Off; set => _outputState[5] = value ? OutputState.Off : _outputState[5]; }
        public bool OutputOff6 { get => _outputState[6] == OutputState.Off; set => _outputState[6] = value ? OutputState.Off : _outputState[6]; }
        public bool OutputOff7 { get => _outputState[7] == OutputState.Off; set => _outputState[7] = value ? OutputState.Off : _outputState[7]; }
        public bool OutputOn0 { get => _outputState[0] == OutputState.On; set => _outputState[0] = value ? OutputState.On : _outputState[0]; }
        public bool OutputOn1 { get => _outputState[1] == OutputState.On; set => _outputState[1] = value ? OutputState.On : _outputState[1]; }
        public bool OutputOn2 { get => _outputState[2] == OutputState.On; set => _outputState[2] = value ? OutputState.On : _outputState[2]; }
        public bool OutputOn3 { get => _outputState[3] == OutputState.On; set => _outputState[3] = value ? OutputState.On : _outputState[3]; }
        public bool OutputOn4 { get => _outputState[4] == OutputState.On; set => _outputState[4] = value ? OutputState.On : _outputState[4]; }
        public bool OutputOn5 { get => _outputState[5] == OutputState.On; set => _outputState[5] = value ? OutputState.On : _outputState[5]; }
        public bool OutputOn6 { get => _outputState[6] == OutputState.On; set => _outputState[6] = value ? OutputState.On : _outputState[6]; }
        public bool OutputOn7 { get => _outputState[7] == OutputState.On; set => _outputState[7] = value ? OutputState.On : _outputState[7]; }
        public bool OutputPwm0 { get => _outputState[0] == OutputState.PWM; set => _outputState[0] = value ? OutputState.PWM : _outputState[0]; }
        public bool OutputPwm1 { get => _outputState[1] == OutputState.PWM; set => _outputState[1] = value ? OutputState.PWM : _outputState[1]; }
        public bool OutputPwm2 { get => _outputState[2] == OutputState.PWM; set => _outputState[2] = value ? OutputState.PWM : _outputState[2]; }
        public bool OutputPwm3 { get => _outputState[3] == OutputState.PWM; set => _outputState[3] = value ? OutputState.PWM : _outputState[3]; }
        public bool OutputPwm4 { get => _outputState[4] == OutputState.PWM; set => _outputState[4] = value ? OutputState.PWM : _outputState[4]; }
        public bool OutputPwm5 { get => _outputState[5] == OutputState.PWM; set => _outputState[5] = value ? OutputState.PWM : _outputState[5]; }
        public bool OutputPwm6 { get => _outputState[6] == OutputState.PWM; set => _outputState[6] = value ? OutputState.PWM : _outputState[6]; }
        public bool OutputPwm7 { get => _outputState[7] == OutputState.PWM; set => _outputState[7] = value ? OutputState.PWM : _outputState[7]; }
        public decimal OutputDutyCycle0 { get => _dutyCycle[0]; set => _dutyCycle[0] = value; }
        public decimal OutputDutyCycle1 { get => _dutyCycle[1]; set => _dutyCycle[1] = value; }
        public decimal OutputDutyCycle2 { get => _dutyCycle[2]; set => _dutyCycle[2] = value; }
        public decimal OutputDutyCycle3 { get => _dutyCycle[3]; set => _dutyCycle[3] = value; }
        public decimal OutputDutyCycle4 { get => _dutyCycle[4]; set => _dutyCycle[4] = value; }
        public decimal OutputDutyCycle5 { get => _dutyCycle[5]; set => _dutyCycle[5] = value; }
        public decimal OutputDutyCycle6 { get => _dutyCycle[6]; set => _dutyCycle[6] = value; }
        public decimal OutputDutyCycle7 { get => _dutyCycle[7]; set => _dutyCycle[7] = value; }
        public bool SendEnabled { get => _sendEnabled; set => _sendEnabled = value; }
        public bool SentLabelVisible { get => _sentLabelVisible; set => _sentLabelVisible = value; }

        public event EventHandler SendClicked = delegate { };
        public event EventHandler PortChanged = delegate { };

        public void ClickSend()
        {
            SendClicked?.Invoke(this, EventArgs.Empty);
        }

        public void ChangePort()
        {
            PortChanged?.Invoke(this, EventArgs.Empty);
        }

        public void StartSendTimer()
        {
            _sendTimerStarted = true;
        }

        public void StopSendTimer()
        {
            _sendTimerStarted = false;
        }
    }

    public class TestOutputCommandPresenter
    {
        private readonly TestOutputCommandView _testView;
        private readonly FakeHidService _hidService;
        private readonly OutputCommandPresenter _presenter;

        public TestOutputCommandPresenter()
        {
            _testView = new TestOutputCommandView();
            _hidService = new FakeHidService();
            _presenter = new OutputCommandPresenter(_testView, _hidService);
        }

        [Fact]
        public void OutputCommandPresenter_DefaultsInputs()
        {
            _testView.ChangeEnabled0.Should().BeFalse();
            _testView.ChangeEnabled1.Should().BeFalse();
            _testView.ChangeEnabled2.Should().BeFalse();
            _testView.ChangeEnabled3.Should().BeFalse();
            _testView.ChangeEnabled4.Should().BeFalse();
            _testView.ChangeEnabled5.Should().BeFalse();
            _testView.ChangeEnabled6.Should().BeFalse();
            _testView.ChangeEnabled7.Should().BeFalse();

            _testView.OutputOff0.Should().BeTrue();
            _testView.OutputOff1.Should().BeTrue();
            _testView.OutputOff2.Should().BeTrue();
            _testView.OutputOff3.Should().BeTrue();
            _testView.OutputOff4.Should().BeTrue();
            _testView.OutputOff5.Should().BeTrue();
            _testView.OutputOff6.Should().BeTrue();
            _testView.OutputOff7.Should().BeTrue();

            _testView.OutputOn0.Should().BeFalse();
            _testView.OutputOn1.Should().BeFalse();
            _testView.OutputOn2.Should().BeFalse();
            _testView.OutputOn3.Should().BeFalse();
            _testView.OutputOn4.Should().BeFalse();
            _testView.OutputOn5.Should().BeFalse();
            _testView.OutputOn6.Should().BeFalse();
            _testView.OutputOn7.Should().BeFalse();

            _testView.OutputPwm0.Should().BeFalse();
            _testView.OutputPwm1.Should().BeFalse();
            _testView.OutputPwm2.Should().BeFalse();
            _testView.OutputPwm3.Should().BeFalse();
            _testView.OutputPwm4.Should().BeFalse();
            _testView.OutputPwm5.Should().BeFalse();
            _testView.OutputPwm6.Should().BeFalse();
            _testView.OutputPwm7.Should().BeFalse();

            _testView.OutputDutyCycle0.Should().Be(0);
            _testView.OutputDutyCycle1.Should().Be(0);
            _testView.OutputDutyCycle2.Should().Be(0);
            _testView.OutputDutyCycle3.Should().Be(0);
            _testView.OutputDutyCycle4.Should().Be(0);
            _testView.OutputDutyCycle5.Should().Be(0);
            _testView.OutputDutyCycle6.Should().Be(0);
            _testView.OutputDutyCycle7.Should().Be(0);

            _testView.SendEnabled.Should().BeFalse();
            _testView.SentLabelVisible.Should().BeFalse();
        }

        [Fact]
        public void OutputCommandPresenter_EnabledSendOnConnect()
        {
            _hidService.Connect(0, 0);

            _testView.SendEnabled.Should().BeTrue();
        }

        [Fact]
        public void OutputCommandPresenter_ResetsInputsOnPortChange()
        {
            _testView.ChangeEnabled0 = true;
            _testView.OutputOn1 = true;
            _testView.OutputPwm2 = true;
            _testView.OutputDutyCycle3 = 20;

            _testView.ChangePort();

            _testView.ChangeEnabled0.Should().BeFalse();

            _testView.OutputOff1.Should().BeTrue();
            _testView.OutputOn1.Should().BeFalse();

            _testView.OutputOff2.Should().BeTrue();
            _testView.OutputPwm2.Should().BeFalse();

            _testView.OutputDutyCycle3.Should().Be(0);
        }

        [Fact]
        public void OutputCommandPresenter_TemporarilyDisablesSendButtonOnSend()
        {
            _hidService.Connect(0, 0);
            _testView.ClickSend();

            _testView.SendTimerStarted.Should().BeTrue();
            _testView.SendEnabled.Should().BeFalse();

            _presenter.SendTimerExpired();

            _testView.SendEnabled.Should().BeTrue();
            _testView.SendTimerStarted.Should().BeFalse();
        }

        [Fact]
        public void OutputCommandPresenter_TemporarilyShowsNotificationOnSend()
        {
            _hidService.Connect(0, 0);
            _testView.ClickSend();

            _testView.SentLabelVisible.Should().BeTrue();

            _presenter.SendTimerExpired();

            _testView.SentLabelVisible.Should().BeFalse();
        }

        [Fact]
        public void OutputCommandPresenter_WritesReportOnSend()
        {
            _testView.OutputPort = 2;
            _testView.ChangeEnabled0 = true;
            _testView.OutputOn0 = true;
            _testView.ChangeEnabled7 = true;
            _testView.OutputPwm7 = true;
            _testView.OutputDutyCycle7 = 128;

            _hidService.Connect(0, 0);
            _testView.ClickSend();

            var expectedData = new OutputCommandBuilder()
                .WithPort(2)
                .WithOutput(0, true, OutputState.On, 0)
                .WithOutput(7, true, OutputState.PWM, 128)
                .BuildCommandData();

            _hidService.WriteReportId.Should().Be(_hidService.ConfigurationReportId);
            _hidService.WriteReportData.Should().BeEqualTo(expectedData);
        }

        [Fact]
        public void OutputCommandPresenter_UpdatesRawUsbDataOnSend()
        {
            _testView.OutputPort = 2;
            _testView.ChangeEnabled0 = true;
            _testView.OutputOn0 = true;
            _testView.ChangeEnabled7 = true;
            _testView.OutputPwm7 = true;
            _testView.OutputDutyCycle7 = 128;

            _hidService.Connect(0, 0);
            _testView.ClickSend();

            var usbData = new OutputCommandBuilder()
                .WithPort(2)
                .WithOutput(0, true, OutputState.On, 0)
                .WithOutput(7, true, OutputState.PWM, 128)
                .BuildCommandData();
            var expectedText = string.Join(",", [.. usbData.Select(x => Convert.ToHexString([x]))]);

            _testView.CommandData.Should().Be(expectedText);
        }
    }
}
