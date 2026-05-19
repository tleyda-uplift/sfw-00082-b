using FluentAssertions;
using HID_Test_App.Models;
using HID_Test_App.Presenters;
using HID_Test_App.Views;
using Hid_Test_App_Tests.Fakes;
using System.ComponentModel;

namespace Hid_Test_App_Tests.Presenters
{
    internal class TestStatusView : IStatusView
    {
        string _rawStatus = "";
        BindingList<InputStatus>? _statusList1;
        BindingList<InputStatus>? _statusList2;
        BindingList<InputStatus>? _statusList3;

        public string RawStatus { get => _rawStatus; set => _rawStatus = value; }
        public bool StatusTabSelected { set { } }

        public BindingList<InputStatus>? StatusList1 => _statusList1;
        public BindingList<InputStatus>? StatusList2 => _statusList2;
        public BindingList<InputStatus>? StatusList3 => _statusList3;

        public void SetInputStatusDataSource(
            BindingList<InputStatus> statusList1,
            BindingList<InputStatus> statusList2,
            BindingList<InputStatus> statusList3)
        {
            _statusList1 = statusList1;
            _statusList2 = statusList2;
            _statusList3 = statusList3;
        }
    }

    public class TestStatusPresenter
    {
        private readonly TestStatusView _testView;
        private readonly FakeHidService _hidService;
        private readonly StatusPresenter _presenter;

        // Report layout: byte 0 = report ID, bytes 1–12 = status data (3 ports × 4 bytes).
        // Each byte encodes two inputs: upper nibble = even input, lower nibble = odd input.
        // Within each nibble: bit 3 = Enabled, bit 2 = Resistor (1=PullUp), bit 0 = State.
        private static byte[] BuildReport(byte[] portData)
        {
            byte[] report = new byte[13];
            report[0] = 0x40;
            portData.CopyTo(report, 1);
            return report;
        }

        private static byte Nibble(bool enabled, bool pullUp, bool state)
            => (byte)((enabled ? 0x08 : 0) | (pullUp ? 0x04 : 0) | (state ? 0x01 : 0));

        private static byte PackByte(bool evenEnabled, bool evenPullUp, bool evenState,
                                     bool oddEnabled,  bool oddPullUp,  bool oddState)
            => (byte)((Nibble(evenEnabled, evenPullUp, evenState) << 4)
                    |  Nibble(oddEnabled,  oddPullUp,  oddState));

        public TestStatusPresenter()
        {
            _testView = new TestStatusView();
            _hidService = new FakeHidService();
            _presenter = new StatusPresenter(_testView, _hidService);
        }

        [Fact]
        public void StatusPresenter_SetsDataSourceOnConstruction()
        {
            _testView.StatusList1.Should().NotBeNull();
            _testView.StatusList2.Should().NotBeNull();
            _testView.StatusList3.Should().NotBeNull();
        }

        [Fact]
        public void StatusPresenter_DataSourceHasEightInputsPerPort()
        {
            _testView.StatusList1!.Count.Should().Be(8);
            _testView.StatusList2!.Count.Should().Be(8);
            _testView.StatusList3!.Count.Should().Be(8);
        }

        [Fact]
        public void StatusPresenter_DefaultsAllInputsDisabled()
        {
            _testView.StatusList1!.Should().AllSatisfy(s => s.Enabled.Should().BeFalse());
            _testView.StatusList2!.Should().AllSatisfy(s => s.Enabled.Should().BeFalse());
            _testView.StatusList3!.Should().AllSatisfy(s => s.Enabled.Should().BeFalse());
        }

        [Fact]
        public void StatusPresenter_DefaultsAllInputStateLow()
        {
            _testView.StatusList1!.Should().AllSatisfy(s => s.State.Should().BeFalse());
            _testView.StatusList2!.Should().AllSatisfy(s => s.State.Should().BeFalse());
            _testView.StatusList3!.Should().AllSatisfy(s => s.State.Should().BeFalse());
        }

        [Fact]
        public void StatusPresenter_DefaultsAllResistorsToPullDown()
        {
            _testView.StatusList1!.Should().AllSatisfy(s => s.Resistor.Should().Be(InputResistor.PullDown));
            _testView.StatusList2!.Should().AllSatisfy(s => s.Resistor.Should().Be(InputResistor.PullDown));
            _testView.StatusList3!.Should().AllSatisfy(s => s.Resistor.Should().Be(InputResistor.PullDown));
        }

        [Fact]
        public void StatusPresenter_ParsesEnabledFlagForPort1()
        {
            // inputs 0,1 enabled; inputs 2,3,4,5,6,7 disabled
            byte[] portData = new byte[12];
            portData[0] = PackByte(true,  false, false,
                                   true,  false, false);

            _hidService.StatusReportData = BuildReport(portData);
            _presenter.TimerHandler();

            _testView.StatusList1![0].Enabled.Should().BeTrue();
            _testView.StatusList1![1].Enabled.Should().BeTrue();
            _testView.StatusList1![2].Enabled.Should().BeFalse();
        }

        [Fact]
        public void StatusPresenter_ParsesResistorForPort1()
        {
            // input 0: PullUp, input 1: PullDown
            byte[] portData = new byte[12];
            portData[0] = PackByte(true, true,  false,
                                   true, false, false);

            _hidService.StatusReportData = BuildReport(portData);
            _presenter.TimerHandler();

            _testView.StatusList1![0].Resistor.Should().Be(InputResistor.PullUp);
            _testView.StatusList1![1].Resistor.Should().Be(InputResistor.PullDown);
        }

        [Fact]
        public void StatusPresenter_ParsesStateForPort1()
        {
            // input 0: High, input 1: Low
            byte[] portData = new byte[12];
            portData[0] = PackByte(true, false, true,
                                   true, false, false);

            _hidService.StatusReportData = BuildReport(portData);
            _presenter.TimerHandler();

            _testView.StatusList1![0].State.Should().BeTrue();
            _testView.StatusList1![1].State.Should().BeFalse();
        }

        [Fact]
        public void StatusPresenter_ParsesAllEightInputsForPort1()
        {
            // Each pair of inputs gets a distinct enabled/resistor/state pattern
            byte[] portData = new byte[12];
            portData[0] = PackByte(true,  true,  true,
                                   false, false, false);
            portData[1] = PackByte(true,  false, true,
                                   true,  true,  false);
            portData[2] = PackByte(false, false, false,
                                   true,  true,  true);
            portData[3] = PackByte(true,  true,  false,
                                   false, false, true);

            _hidService.StatusReportData = BuildReport(portData);
            _presenter.TimerHandler();

            var s = _testView.StatusList1!;
            s[0].Enabled.Should().BeTrue();  s[0].Resistor.Should().Be(InputResistor.PullUp);   s[0].State.Should().BeTrue();
            s[1].Enabled.Should().BeFalse(); s[1].Resistor.Should().Be(InputResistor.PullDown); s[1].State.Should().BeFalse();
            s[2].Enabled.Should().BeTrue();  s[2].Resistor.Should().Be(InputResistor.PullDown); s[2].State.Should().BeTrue();
            s[3].Enabled.Should().BeTrue();  s[3].Resistor.Should().Be(InputResistor.PullUp);   s[3].State.Should().BeFalse();
            s[4].Enabled.Should().BeFalse(); s[4].Resistor.Should().Be(InputResistor.PullDown); s[4].State.Should().BeFalse();
            s[5].Enabled.Should().BeTrue();  s[5].Resistor.Should().Be(InputResistor.PullUp);   s[5].State.Should().BeTrue();
            s[6].Enabled.Should().BeTrue();  s[6].Resistor.Should().Be(InputResistor.PullUp);   s[6].State.Should().BeFalse();
            s[7].Enabled.Should().BeFalse(); s[7].Resistor.Should().Be(InputResistor.PullDown); s[7].State.Should().BeTrue();
        }

        [Fact]
        public void StatusPresenter_ParsesPort2AtCorrectByteOffset()
        {
            byte[] portData = new byte[12];
            portData[4] = PackByte(true, true, true,
                                   true, true, true);

            _hidService.StatusReportData = BuildReport(portData);
            _presenter.TimerHandler();

            _testView.StatusList1![0].Enabled.Should().BeFalse();
            _testView.StatusList2![0].Enabled.Should().BeTrue();
            _testView.StatusList2![0].Resistor.Should().Be(InputResistor.PullUp);
            _testView.StatusList2![0].State.Should().BeTrue();
            _testView.StatusList2![1].Enabled.Should().BeTrue();
        }

        [Fact]
        public void StatusPresenter_ParsesPort3AtCorrectByteOffset()
        {
            byte[] portData = new byte[12];
            portData[8] = PackByte(true,  false, true,
                                   false, false, false);

            _hidService.StatusReportData = BuildReport(portData);
            _presenter.TimerHandler();

            _testView.StatusList1![0].Enabled.Should().BeFalse();
            _testView.StatusList2![0].Enabled.Should().BeFalse();
            _testView.StatusList3![0].Enabled.Should().BeTrue();
            _testView.StatusList3![0].State.Should().BeTrue();
            _testView.StatusList3![1].Enabled.Should().BeFalse();
        }

        [Fact]
        public void StatusPresenter_UpdatesRawStatusDisplay()
        {
            _hidService.StatusReportData = BuildReport(new byte[12]);
            _presenter.TimerHandler();

            _testView.RawStatus.Should().NotBeEmpty();
            _testView.RawStatus.Should().NotBe("Failed to retrieve status");
        }

        [Fact]
        public void StatusPresenter_ShowsFailureMessageWhenReportIsEmpty()
        {
            _hidService.StatusReportData = [];
            _presenter.TimerHandler();

            _testView.RawStatus.Should().Be("Failed to retrieve status");
        }
    }
}
