using HID_Test_App.Presenters;
using HID_Test_App.Services;
using System.ComponentModel;

namespace HID_Test_App.Views
{
    public partial class LedTestView : UserControl, ILedTestView
    {
        private LedTestPresenter? presenter;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool StartEnabled { get => btnLedTestStart.Enabled; set => btnLedTestStart.Enabled = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LedColor1 { get => panelLedDisplay1.BackColor.ToString(); set => panelLedDisplay1.BackColor = Color.FromName(value); }
         [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LedColor2 { get => panelLedDisplay2.BackColor.ToString(); set => panelLedDisplay2.BackColor = Color.FromName(value); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LedColor3 { get => panelLedDisplay3.BackColor.ToString(); set => panelLedDisplay3.BackColor = Color.FromName(value); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string StatusText { get => labelStatus.Text; set => labelStatus.Text = value; }

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
