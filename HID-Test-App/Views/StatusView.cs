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

        public StatusView()
        {
            InitializeComponent();
        }

        public void Initialize(IHidService hidService)
        {
            _presenter = new StatusPresenter(this, hidService);
        }

        public event EventHandler? RequestClicked;

        private void btnRequestStatus_Click(object sender, EventArgs e)
        {
            RequestClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
