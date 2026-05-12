using HID_Test_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HID_Test_App.Views
{
    public interface IStatusView
    {
        string RawStatus { get; set; }
        bool StatusTabSelected { set; }

        void SetInputStatusDataSource(
            BindingList<InputStatus> statusList1,
            BindingList<InputStatus> statusList2,
            BindingList<InputStatus> statusList3
        );
    }
}
