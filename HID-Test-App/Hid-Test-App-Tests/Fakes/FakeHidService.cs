using HID_Test_App.Services;
using HidSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hid_Test_App_Tests.Fakes
{
    public class FakeHidService : IHidService
    {
        bool _connected = false;

        public bool Connected => _connected;

        public event EventHandler<bool> ConnectionChanged;

        public bool Connect(int vendorId, int productId)
        {
            _connected = true;
            ConnectionChanged?.Invoke(this, _connected);
            return true;
        }

        public void Disconnect()
        {
            _connected = false;
            ConnectionChanged?.Invoke(this, _connected);
        }

        public byte[] GetReport(byte reportId)
        {
            return [];
        }

        public byte[] GetStatusReport()
        {
            return [];
        }

        public void Write(byte reportId, byte[] data)
        {
            
        }

        public void WriteConfigurationReport(byte[] data)
        {
            
        }
    }
}
