using HidSharp;

namespace HID_Test_App.Services
{
    public interface IHidService
    {
        bool Connected { get; }

        bool Connect(int vendorId, int productId);
        void Disconnect();
        void Write(byte reportId, byte[] data);
    }

    public class HidService : IHidService
    {
        private HidDevice? _hidDevice;

        public bool Connected => _hidDevice != null;

        public bool Connect(int vendorId, int productId)
        {
            var list = DeviceList.Local;

            _hidDevice = list.GetHidDevices(vendorId, productId).FirstOrDefault();

            return _hidDevice != null;
        }

        public void Disconnect()
        {
            if (_hidDevice != null)
            {
                _hidDevice = null;
            }
            
        }

        public void Write(byte reportId, byte[] data)
        {
            if (_hidDevice != null && _hidDevice.TryOpen(out DeviceStream stream))
            {
                using (stream)
                {
                    stream.ReadTimeout = 1000;
                    byte[] outputReport = new byte[_hidDevice.GetMaxOutputReportLength()];

                    data.CopyTo(outputReport, 1);
                    outputReport[0] = 0x3F;
                    stream.Write(outputReport);
                }

            }
        }
    }
}
