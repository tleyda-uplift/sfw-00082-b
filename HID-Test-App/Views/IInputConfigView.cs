using System;
using System.Collections.Generic;
using System.Text;

namespace HID_Test_App.Views
{
    public interface IInputConfigView
    {
        int InputPort { get; set; }
        bool InputEnable0 { get; set; }
        bool InputEnable1 { get; set; }
        bool InputEnable2 { get; set; }
        bool InputEnable3 { get; set; }
        bool InputEnable4 { get; set; }
        bool InputEnable5 { get; set; }
        bool InputEnable6 { get; set; }
        bool InputEnable7 { get; set; }
        int PullResistor0 { get; set; }
        int PullResistor1 { get; set; }
        int PullResistor2 { get; set; }
        int PullResistor3 { get; set; }
        int PullResistor4 { get; set; }
        int PullResistor5 { get; set; }
        int PullResistor6 { get; set; }
        int PullResistor7 { get; set; }

        event EventHandler SendClicked;
    }
}
