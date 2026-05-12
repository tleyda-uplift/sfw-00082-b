using HID_Test_App.Presenters;
using HID_Test_App.Services;
using System.ComponentModel;

namespace HID_Test_App.Views
{
    public partial class MainForm : Form, IMainForm
    {
        private readonly MainPresenter _presenter;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string VendorId { get => texboxVendorId.Text; set => texboxVendorId.Text = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ProductId { get => textBoxProductId.Text; set => textBoxProductId.Text = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ConnectEnabled { get => btnConnect.Enabled; set => btnConnect.Enabled = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DisconnectEnabled { get => btnDisconnect.Enabled; set => btnDisconnect.Enabled = value; }

        public MainForm(IHidService hidService)
        {
            InitializeComponent();

            _presenter = new MainPresenter(this, hidService);

            outputCommandView.Initialize(hidService);
            inputConfiigView.Initialize(hidService);
            statusView.Initialize(hidService);
            ledTestView.Initialize(hidService);

            tabControlApp.SelectedIndexChanged += TabControlApp_SelectedIndexChanged;
        }

        private void TabControlApp_SelectedIndexChanged(object? sender, EventArgs e)
        {
            TabPage currentTab = tabControlApp.SelectedTab;
            statusView.StatusTabSelected = currentTab.Controls[0] is IStatusView activeView;
        }

        public event EventHandler? ConnectClicked;
        public event EventHandler? DisconnectClicked;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectClicked?.Invoke(this, EventArgs.Empty);
        }

        private void comboBoxPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
