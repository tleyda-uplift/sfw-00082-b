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
        string CommandData { get; set; }
        int OutputPort { get; set; }
        bool ChangeEnabled0 { get; set; }
        bool ChangeEnabled1 { get; set; }
        bool ChangeEnabled2 { get; set; }
        bool ChangeEnabled3 { get; set; }
        bool ChangeEnabled4 { get; set; }
        bool ChangeEnabled5 { get; set; }
        bool ChangeEnabled6 { get; set; }
        bool ChangeEnabled7 { get; set; }
        bool OutputOff0 { get; set; }
        bool OutputOff1 { get; set; }
        bool OutputOff2 { get; set; }
        bool OutputOff3 { get; set; }
        bool OutputOff4 { get; set; }
        bool OutputOff5 { get; set; }
        bool OutputOff6 { get; set; }
        bool OutputOff7 { get; set; }
        bool OutputOn0 { get; set; }
        bool OutputOn1 { get; set; }
        bool OutputOn2 { get; set; }
        bool OutputOn3 { get; set; }
        bool OutputOn4 { get; set; }
        bool OutputOn5 { get; set; }
        bool OutputOn6 { get; set; }
        bool OutputOn7 { get; set; }
        bool OutputPwm0 { get; set; }
        bool OutputPwm1 { get; set; }
        bool OutputPwm2 { get; set; }
        bool OutputPwm3 { get; set; }
        bool OutputPwm4 { get; set; }
        bool OutputPwm5 { get; set; }
        bool OutputPwm6 { get; set; }
        bool OutputPwm7 { get; set; }
        decimal OutputDutyCycle0 { get; set; }
        decimal OutputDutyCycle1 { get; set; }
        decimal OutputDutyCycle2 { get; set; }
        decimal OutputDutyCycle3 { get; set; }
        decimal OutputDutyCycle4 { get; set; }
        decimal OutputDutyCycle5 { get; set; }
        decimal OutputDutyCycle6 { get; set; }
        decimal OutputDutyCycle7 { get; set; }

        event EventHandler ConnectClicked;
        event EventHandler DisconnectClicked;
        event EventHandler SendClicked;
    }
}
