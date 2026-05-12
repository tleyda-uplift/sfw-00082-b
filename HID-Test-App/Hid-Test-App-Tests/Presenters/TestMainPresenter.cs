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
        [Fact]
        public void MainPresenter_DefaultsVendorAndProductIds()
        {
            var form = new TestMainForm();
            var presenter = new MainPresenter(form, new FakeHidService());

            form.VendorId.Should().Be("2047");
            form.ProductId.Should().Be("3737");
        }
    }
}
