using HID_Test_App.Presenters;
using HID_Test_App.Services;
using System.ComponentModel;

namespace HID_Test_App.Views
{
    public partial class OutputCommandView : UserControl, IOutputCommandView
    {
        private OutputCommandPresenter? _presenter;
        private readonly System.Windows.Forms.Timer _timer;

        public OutputCommandView()
        {
            InitializeComponent();
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 3000;
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            _presenter?.SendTimerExpired();
        }

        public void Initialize(IHidService hidService)
        {
            _presenter = new OutputCommandPresenter(this, hidService);
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int OutputPort { get => comboBoxPort.SelectedIndex; set => comboBoxPort.SelectedIndex = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ChangeEnabled0 { get => checkBoxEnableChange0.Checked; set => checkBoxEnableChange0.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ChangeEnabled1 { get => checkBoxEnableChange1.Checked; set => checkBoxEnableChange1.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ChangeEnabled2 { get => checkBoxEnableChange2.Checked; set => checkBoxEnableChange2.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ChangeEnabled3 { get => checkBoxEnableChange3.Checked; set => checkBoxEnableChange3.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ChangeEnabled4 { get => checkBoxEnableChange4.Checked; set => checkBoxEnableChange4.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ChangeEnabled5 { get => checkBoxEnableChange5.Checked; set => checkBoxEnableChange5.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ChangeEnabled6 { get => checkBoxEnableChange6.Checked; set => checkBoxEnableChange6.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ChangeEnabled7 { get => checkBoxEnableChange7.Checked; set => checkBoxEnableChange7.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOff0 { get => radioBtnOff0.Checked; set => radioBtnOff0.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOff1 { get => radioBtnOff1.Checked; set => radioBtnOff1.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOff2 { get => radioBtnOff2.Checked; set => radioBtnOff2.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOff3 { get => radioBtnOff3.Checked; set => radioBtnOff3.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOff4 { get => radioBtnOff4.Checked; set => radioBtnOff4.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOff5 { get => radioBtnOff5.Checked; set => radioBtnOff5.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOff6 { get => radioBtnOff6.Checked; set => radioBtnOff6.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOff7 { get => radioBtnOff7.Checked; set => radioBtnOff7.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOn0 { get => radioBtnOn0.Checked; set => radioBtnOn0.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOn1 { get => radioBtnOn1.Checked; set => radioBtnOn1.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOn2 { get => radioBtnOn2.Checked; set => radioBtnOn2.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOn3 { get => radioBtnOn3.Checked; set => radioBtnOn3.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOn4 { get => radioBtnOn4.Checked; set => radioBtnOn4.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOn5 { get => radioBtnOn5.Checked; set => radioBtnOn5.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOn6 { get => radioBtnOn6.Checked; set => radioBtnOn6.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputOn7 { get => radioBtnOn7.Checked; set => radioBtnOn7.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputPwm0 { get => radioBtnPwm0.Checked; set => radioBtnPwm0.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputPwm1 { get => radioBtnPwm1.Checked; set => radioBtnPwm1.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputPwm2 { get => radioBtnPwm2.Checked; set => radioBtnPwm2.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputPwm3 { get => radioBtnPwm3.Checked; set => radioBtnPwm3.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputPwm4 { get => radioBtnPwm4.Checked; set => radioBtnPwm4.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputPwm5 { get => radioBtnPwm5.Checked; set => radioBtnPwm5.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputPwm6 { get => radioBtnPwm6.Checked; set => radioBtnPwm6.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OutputPwm7 { get => radioBtnPwm7.Checked; set => radioBtnPwm7.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal OutputDutyCycle0 { get => numericDutyCycle0.Value; set => numericDutyCycle0.Value = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal OutputDutyCycle1 { get => numericDutyCycle1.Value; set => numericDutyCycle1.Value = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal OutputDutyCycle2 { get => numericDutyCycle2.Value; set => numericDutyCycle2.Value = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal OutputDutyCycle3 { get => numericDutyCycle3.Value; set => numericDutyCycle3.Value = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal OutputDutyCycle4 { get => numericDutyCycle4.Value; set => numericDutyCycle4.Value = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal OutputDutyCycle5 { get => numericDutyCycle5.Value; set => numericDutyCycle5.Value = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal OutputDutyCycle6 { get => numericDutyCycle6.Value; set => numericDutyCycle6.Value = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal OutputDutyCycle7 { get => numericDutyCycle7.Value; set => numericDutyCycle7.Value = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CommandData { get => textBoxCommandData.Text; set => textBoxCommandData.Text = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SendEnabled { set => btnSend.Enabled = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SentLabelVisible { get => labelSent.Visible; set => labelSent.Visible = value; }

        public event EventHandler? SendClicked;
        public event EventHandler? PortChanged;

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendClicked?.Invoke(this, EventArgs.Empty);
        }

        private void comboBoxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            PortChanged?.Invoke(this, e);
        }

        public void StartSendTimer()
        {
            _timer.Start();
        }

        public void StopSendTimer()
        {
            _timer.Stop();
        }
    }
}
