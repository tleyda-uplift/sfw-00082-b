using HID_Test_App.Presenters;
using HID_Test_App.Services;
using System.ComponentModel;

namespace HID_Test_App.Views
{
    public partial class LedTestView : UserControl, ILedTestView
    {
        private LedTestPresenter? presenter;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LabelTemp { get => labelTemp.Text; set => labelTemp.Text = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool StartEnabled { get => btnLedTestStart.Enabled; set => btnLedTestStart.Enabled = value; }

        public LedTestView()
        {
            InitializeComponent();
        }

        public void Initialize(IHidService hidService)
        {
            presenter = new LedTestPresenter(this, hidService);
        }

        public event EventHandler? StartClicked;

        private void btnLedTestStart_Click(object sender, EventArgs e)
        {
            StartClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
