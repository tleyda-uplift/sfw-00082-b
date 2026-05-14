using System;
using System.Collections.Generic;
using System.Text;

namespace HID_Test_App.Views
{
    public interface ILedTestView
    {
        string StatusText { get; set; }
        bool PrevEnabled { get; set; }
        bool RunPauseEnabled { get; set; }
        bool NextEnabled { get; set; }
        bool ResetEnabled { get; set; }
        string LedColor1 { get; set; }
        string LedColor2 { get; set; }
        string LedColor3 { get; set; }
        string RunPauseText { set; }

        event EventHandler PrevClicked;
        event EventHandler RunPauseClicked;
        event EventHandler NextClicked;
        event EventHandler ResetClicked;

        void StartTimer();
        void StopTimer();
    }
}
