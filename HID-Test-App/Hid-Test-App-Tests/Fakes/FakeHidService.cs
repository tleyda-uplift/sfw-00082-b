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
        byte[] _writeReportData;
        byte _writeReportId;
        byte _configurationReportId = 0x3F;

        public FakeHidService() 
        {
            _writeReportData = [];
        }

        public byte[] WriteReportData { get => _writeReportData; }
        public byte WriteReportId { get => _writeReportId; }
        public byte ConfigurationReportId { get => _configurationReportId; set => _configurationReportId = value;  }

        public bool Connected => _connected;

        public event EventHandler<bool>? ConnectionChanged;

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
            _writeReportId = reportId;
            _writeReportData = new byte[data.Length];
            data.CopyTo(_writeReportData);
        }

        public void WriteConfigurationReport(byte[] data)
        {
            Write(_configurationReportId, data);
        }
    }
}
