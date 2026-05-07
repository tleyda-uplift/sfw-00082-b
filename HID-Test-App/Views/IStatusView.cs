using System;
using System.Collections.Generic;
using System.Text;

namespace HID_Test_App.Views
{
    public interface IStatusView
    {
        string RawStatus { get; set; }
        event EventHandler RequestClicked;
    }
}
