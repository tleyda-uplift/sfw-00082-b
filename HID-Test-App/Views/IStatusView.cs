using System;
using System.Collections.Generic;
using System.Text;

namespace HID_Test_App.Views
{
    public interface IStatusView
    {
        event EventHandler RequestClicked;
    }
}
