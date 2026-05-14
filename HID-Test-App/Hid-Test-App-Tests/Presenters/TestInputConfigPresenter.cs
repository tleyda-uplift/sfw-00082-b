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
    internal class TestView : IInputConfigView
    {
        int _port;
        bool[] _inputEnable;
        int[] _inputResistor;
        bool _sendEnabled;
        string _rawData;
        bool _sendTimerStarted;
        bool _sentLabelVisible;

        public TestView()
        {
            _port = 0;
            _inputEnable = [.. Enumerable.Range(0, 8).Select(_ => false)];
            _inputResistor = [.. Enumerable.Range(0, 8).Select(_ => 0)];
            _sendEnabled = false;
            _rawData = "";
            _sendTimerStarted = false;
            _sentLabelVisible = false;
        }

        public bool SendTimerStarted { get => _sendTimerStarted; }

        public int InputPort { get => _port; set => _port = value; }
        public bool InputEnable0 { get => _inputEnable[0]; set => _inputEnable[0] = value; }
        public bool InputEnable1 { get => _inputEnable[1]; set => _inputEnable[1] = value; }
        public bool InputEnable2 { get => _inputEnable[2]; set => _inputEnable[2] = value; }
        public bool InputEnable3 { get => _inputEnable[3]; set => _inputEnable[3] = value; }
        public bool InputEnable4 { get => _inputEnable[4]; set => _inputEnable[4] = value; }
        public bool InputEnable5 { get => _inputEnable[5]; set => _inputEnable[5] = value; }
        public bool InputEnable6 { get => _inputEnable[6]; set => _inputEnable[6] = value; }
        public bool InputEnable7 { get => _inputEnable[7]; set => _inputEnable[7] = value; }
        public int PullResistor0 { get => _inputResistor[0]; set => _inputResistor[0] = value; }
        public int PullResistor1 { get => _inputResistor[1]; set => _inputResistor[1] = value; }
        public int PullResistor2 { get => _inputResistor[2]; set => _inputResistor[2] = value; }
        public int PullResistor3 { get => _inputResistor[3]; set => _inputResistor[3] = value; }
        public int PullResistor4 { get => _inputResistor[4]; set => _inputResistor[4] = value; }
        public int PullResistor5 { get => _inputResistor[5]; set => _inputResistor[5] = value; }
        public int PullResistor6 { get => _inputResistor[6]; set => _inputResistor[6] = value; }
        public int PullResistor7 { get => _inputResistor[7]; set => _inputResistor[7] = value; }
        public bool SendEnabled { get => _sendEnabled; set => _sendEnabled = value; }
        public string ConfigData { get => _rawData; set => _rawData = value; }
        public bool SentLabelVisible { get => _sentLabelVisible; set => _sentLabelVisible = value; }

        public event EventHandler? SendClicked;
        public event EventHandler? PortChanged;

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

    public class TestInputConfigPresenter
    {
        private readonly TestView _testView;
        private readonly FakeHidService _hidService;
        private readonly InputConfigPresenter _presenter;

        public TestInputConfigPresenter()
        {
            _testView = new TestView();
            _hidService = new FakeHidService();
            _presenter = new InputConfigPresenter(_testView, _hidService);
        }

        [Fact]
        public void InputConfigPresenter_DefaultsInputs()
        {
            _testView.InputEnable0.Should().BeFalse();
            _testView.InputEnable1.Should().BeFalse();
            _testView.InputEnable2.Should().BeFalse();
            _testView.InputEnable3.Should().BeFalse();
            _testView.InputEnable4.Should().BeFalse();
            _testView.InputEnable5.Should().BeFalse();
            _testView.InputEnable6.Should().BeFalse();
            _testView.InputEnable7.Should().BeFalse();
            _testView.PullResistor0.Should().Be(0);
            _testView.PullResistor1.Should().Be(0);
            _testView.PullResistor2.Should().Be(0);
            _testView.PullResistor3.Should().Be(0);
            _testView.PullResistor4.Should().Be(0);
            _testView.PullResistor5.Should().Be(0);
            _testView.PullResistor6.Should().Be(0);
            _testView.PullResistor7.Should().Be(0);
            _testView.SendEnabled.Should().BeFalse();
        }

        [Fact]
        public void InputConfigPresenter_EnabledSendOnConnect()
        {
            _hidService.Connect(0, 0);

            _testView.SendEnabled.Should().BeTrue();
        }

        [Fact]
        public void InputConfigPresenter_ResetsInputsOnPortChange()
        {
            _testView.InputEnable0 = true;
            _testView.InputEnable7 = true;
            _testView.PullResistor4 = 1;
            _testView.PullResistor6 = 1;

            _testView.ChangePort();

            _testView.InputEnable0.Should().BeFalse();
            _testView.InputEnable1.Should().BeFalse();
            _testView.InputEnable2.Should().BeFalse();
            _testView.InputEnable3.Should().BeFalse();
            _testView.InputEnable4.Should().BeFalse();
            _testView.InputEnable5.Should().BeFalse();
            _testView.InputEnable6.Should().BeFalse();
            _testView.InputEnable7.Should().BeFalse();
            _testView.PullResistor0.Should().Be(0);
            _testView.PullResistor1.Should().Be(0);
            _testView.PullResistor2.Should().Be(0);
            _testView.PullResistor3.Should().Be(0);
            _testView.PullResistor4.Should().Be(0);
            _testView.PullResistor5.Should().Be(0);
            _testView.PullResistor6.Should().Be(0);
            _testView.PullResistor7.Should().Be(0);
        }

        [Fact]
        public void InputConfigPresenter_WritesReportOnSend()
        {
            _testView.InputPort = 1;
            _testView.InputEnable0 = true;
            _testView.InputEnable4 = true;
            _testView.InputEnable6 = true;
            _testView.InputEnable7 = true;
            _testView.PullResistor4 = 1;
            _testView.PullResistor6 = 1;

            _hidService.Connect(0, 0);
            _testView.ClickSend();

            var expectedData = new InputConfigBuilder()
                .WithPort(1)
                .WithInput(0, true, InputResistor.PullDown)
                .WithInput(4, true, InputResistor.PullUp)
                .WithInput(6, true, InputResistor.PullUp)
                .WithInput(7, true, InputResistor.PullDown)
                .BuildConfigData();

            _hidService.WriteReportId.Should().Be(_hidService.ConfigurationReportId);
            _hidService.WriteReportData.Should().BeEqualTo(expectedData);
        }

        [Fact]
        public void InputConfigPresenter_UpdatesRawUsbDataOnSend()
        {
            _testView.InputPort = 1;
            _testView.InputEnable0 = true;
            _testView.InputEnable4 = true;
            _testView.InputEnable6 = true;
            _testView.InputEnable7 = true;
            _testView.PullResistor4 = 1;
            _testView.PullResistor6 = 1;

            _hidService.Connect(0, 0);
            _testView.ClickSend();

            var usbData = new InputConfigBuilder()
                .WithPort(1)
                .WithInput(0, true, InputResistor.PullDown)
                .WithInput(4, true, InputResistor.PullUp)
                .WithInput(6, true, InputResistor.PullUp)
                .WithInput(7, true, InputResistor.PullDown)
                .BuildConfigData();
            var expectedText = string.Join(",", [.. usbData.Select(x => Convert.ToHexString([x]))]);

            _testView.ConfigData.Should().Be(expectedText);
        }

        [Fact]
        public void InputConfigPresenter_TemporarilyDisablesSendButtonOnSend()
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
        public void InputConfigPresenter_TemporarilyShowsNotificationOnSend()
        {
            _hidService.Connect(0, 0);
            _testView.ClickSend();

            _testView.SentLabelVisible.Should().BeTrue();

            _presenter.SendTimerExpired();

            _testView.SentLabelVisible.Should().BeFalse();
        }
    }
}
