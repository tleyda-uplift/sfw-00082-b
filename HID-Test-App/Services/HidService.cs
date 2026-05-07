using HidSharp;
using HidSharp.Reports;
using System.Diagnostics;

namespace HID_Test_App.Services
{
    public interface IHidService
    {
        bool Connected { get; }

        bool Connect(int vendorId, int productId);
        void Disconnect();
        void Write(byte reportId, byte[] data);
        byte[] GetReport(byte reportId);

        event EventHandler<bool> ConnectionChanged;
    }

    public class HidService : IHidService
    {
        private HidDevice? _hidDevice;

        public event EventHandler<bool>? ConnectionChanged;

        public bool Connected => _hidDevice != null;

        public bool Connect(int vendorId, int productId)
        {
            var list = DeviceList.Local;

            _hidDevice = list.GetHidDevices(vendorId, productId).FirstOrDefault();

            ConnectionChanged?.Invoke(this, _hidDevice != null);

            return _hidDevice != null;
        }

        public void Disconnect()
        {
            if (_hidDevice != null)
            {
                _hidDevice = null;
                ConnectionChanged?.Invoke(this, false);
            }

        }

        public void Write(byte reportId, byte[] data)
        {
            if (_hidDevice != null && _hidDevice.TryOpen(out HidStream stream))
            {
                using (stream)
                {
                    stream.ReadTimeout = 1000;
                    byte[] outputReport = new byte[_hidDevice.GetMaxOutputReportLength()];

                    data.CopyTo(outputReport, 1);
                    outputReport[0] = reportId;
                    stream.Write(outputReport);
                }

            }
        }

        public byte[] GetReport(byte reportId)
        {
            Write(0x40, []);
            if (_hidDevice != null && _hidDevice.TryOpen(out HidStream stream))
            {
                var reportDescriptor = _hidDevice.GetReportDescriptor();
                Console.WriteLine(reportDescriptor.InputReports);
                using (stream)
                {
                    int inputLength = _hidDevice.GetMaxInputReportLength();
                    byte[] inReport = new byte[inputLength];
                    stream.Read(inReport, 0, inputLength);
                    return inReport;
                }
             }
            return [];
        }
    }
}
