using System;
using System.Collections.Generic;
using System.Text;

namespace HID_Test_App.Views
{
    public interface ILedTestView
    {
        string LabelTemp { get; set; }
        bool StartEnabled { get; set; }

        event EventHandler StartClicked;
    }
}
