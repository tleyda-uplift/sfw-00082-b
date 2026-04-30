using System;
using System.Collections.Generic;
using System.Text;

namespace HID_Test_App.Views
{
    public interface IMainForm
    {
        string VendorId { get; set; }
        string ProductId { get; set; }
        bool ConnectEnabled { get; set; }
        bool DisconnectEnabled { get; set; }
 
        event EventHandler ConnectClicked;
        event EventHandler DisconnectClicked;
    }
}
