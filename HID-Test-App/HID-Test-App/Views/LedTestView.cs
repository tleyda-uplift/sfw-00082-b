using HID_Test_App.Presenters;
using HID_Test_App.Services;
using System.ComponentModel;

namespace HID_Test_App.Views
{
    public partial class LedTestView : UserControl, ILedTestView
    {
        private LedTestPresenter? presenter;
        private System.Windows.Forms.Timer _testTimer;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RunPauseEnabled { get => btnLedTestStart.Enabled; set => btnLedTestStart.Enabled = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LedColor1 { get => panelLedDisplay1.BackColor.ToString(); set => panelLedDisplay1.BackColor = Color.FromName(value); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LedColor2 { get => panelLedDisplay2.BackColor.ToString(); set => panelLedDisplay2.BackColor = Color.FromName(value); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LedColor3 { get => panelLedDisplay3.BackColor.ToString(); set => panelLedDisplay3.BackColor = Color.FromName(value); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string StatusText { get => labelStatus.Text; set => labelStatus.Text = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool PrevEnabled { get => btnLedTestPrev.Enabled; set => btnLedTestPrev.Enabled = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NextEnabled { get => btnLedTestNext.Enabled; set => btnLedTestNext.Enabled = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ResetEnabled { get => btnLedTestReset.Enabled; set => btnLedTestReset.Enabled = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RunPauseText { set => btnLedTestStart.Text = value; }

        public LedTestView()
        {
            InitializeComponent();

            _testTimer = new System.Windows.Forms.Timer();
            _testTimer.Interval = 2000;
            _testTimer.Tick += TestTimer_Tick;
        }

        private void TestTimer_Tick(object? sender, EventArgs e)
        {
            presenter?.TimerHandler();
        }

        public void Initialize(IHidService hidService)
        {
            presenter = new LedTestPresenter(this, hidService);
        }

        public event EventHandler? RunPauseClicked;
        public event EventHandler? PrevClicked;
        public event EventHandler? NextClicked;
        public event EventHandler? ResetClicked;

        private void btnLedTestStart_Click(object sender, EventArgs e)
        {
            RunPauseClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnLedTestPrev_Click(object sender, EventArgs e)
        {
            PrevClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnLedTestNext_Click(object sender, EventArgs e)
        {
            NextClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnLedTestReset_Click(object sender, EventArgs e)
        {
            ResetClicked?.Invoke(this, EventArgs.Empty);
        }

        public void StartTimer()
        {
            _testTimer.Start();
        }

        public void StopTimer()
        {
            _testTimer.Stop();
        }
    }
}
