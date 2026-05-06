using System;
using System.Collections.Generic;
using System.Text;

namespace HID_Test_App.Views
{
    public interface ILedTestView
    {
        string StatusText { get; set; }
        bool StartEnabled { get; set; }
        string LedColor1 { get; set; }
        string LedColor2 { get; set; }
        string LedColor3 { get; set; }

        event EventHandler StartClicked;
    }
}
