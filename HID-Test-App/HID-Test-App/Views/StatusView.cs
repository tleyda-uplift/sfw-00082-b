using HID_Test_App.Models;
using HID_Test_App.Presenters;
using HID_Test_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HID_Test_App.Views
{
    public partial class StatusView : UserControl, IStatusView
    {
        private StatusPresenter? _presenter;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RawStatus { get => textBoxRawStatus.Text; set => textBoxRawStatus.Text = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool StatusTabSelected { set => _presenter?.StatusTabActive = value; }

        public StatusView()
        {
            InitializeComponent();
        }

        public void Initialize(IHidService hidService)
        {
            _presenter = new StatusPresenter(this, hidService);
        }

        public void SetInputStatusDataSource(BindingList<InputStatus> statusList1, BindingList<InputStatus> statusList2, BindingList<InputStatus> statusList3)
        {
            listBoxInputStatus1.DataSource = statusList1;
            listBoxInputStatus2.DataSource = statusList2;
            listBoxInputStatus3.DataSource = statusList3;
        }
    }
}
