using FluentAssertions;
using HID_Test_App.Presenters;
using HID_Test_App.Views;
using Hid_Test_App_Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hid_Test_App_Tests.Presenters
{
    internal class TestMainForm : IMainForm
    {
        string _vendorId;
        string _productId;
        bool _connectEnabled;
        bool _disconnectEnabled;

        public string VendorId { get => _vendorId; set => _vendorId = value; }
        public string ProductId { get => _productId; set => _productId = value; }
        public bool ConnectEnabled { get => _connectEnabled; set => _connectEnabled = value; }
        public bool DisconnectEnabled { get => _disconnectEnabled; set => _disconnectEnabled = value; }

        public event EventHandler ConnectClicked;
        public event EventHandler DisconnectClicked;

        public void ClickConnect()
        {
            ConnectClicked?.Invoke(this, EventArgs.Empty);
        }

        public void ClickDisconnect()
        {
            DisconnectClicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class TestMainPresenter
    {
        private TestMainForm _mainForm;
        private FakeHidService _hidService;
        private MainPresenter _presenter;

        public TestMainPresenter()
        {
            _mainForm = new TestMainForm();
            _hidService = new FakeHidService();
            _presenter = new MainPresenter(_mainForm, _hidService);
        }

        [Fact]
        public void MainPresenter_DefaultsVendorAndProductIds()
        {
            _mainForm.VendorId.Should().Be("2047");
            _mainForm.ProductId.Should().Be("3737");
        }

        [Fact]
        public void MainPresenter_CorrectlyDefaultsButtonStates()
        {
            _mainForm.ConnectEnabled.Should().BeTrue();
            _mainForm.DisconnectEnabled.Should().BeFalse();
        }

        [Fact]
        public void MainPresenter_ConnectsToDevice()
        {
            _mainForm.ClickConnect();

            _hidService.Connected.Should().BeTrue();
            _mainForm.ConnectEnabled.Should().BeFalse();
            _mainForm.DisconnectEnabled.Should().BeTrue();
        }

        [Fact]
        public void MainPresenter_DisConnectsFromDevice()
        {
            _mainForm.ClickConnect();
            _mainForm.ClickDisconnect();

            _hidService.Connected.Should().BeFalse();
            _mainForm.ConnectEnabled.Should().BeTrue();
            _mainForm.DisconnectEnabled.Should().BeFalse();
        }
    }
}
