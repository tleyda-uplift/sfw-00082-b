using HID_Test_App.Presenters;
using HID_Test_App.Services;
using System.ComponentModel;

namespace HID_Test_App.Views
{
    public partial class InputConfiigView : UserControl, IInputConfigView
    {
        private InputConfigPresenter? _presenter;
        public InputConfiigView()
        {
            InitializeComponent();
        }

        public void Initialize(IHidService hidService)
        {
            _presenter = new InputConfigPresenter(this, hidService);
        }

        private void btnInputConfigSend_Click(object sender, EventArgs e)
        {
            SendClicked?.Invoke(this, EventArgs.Empty);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int InputPort { get => comboBoxInputPort.SelectedIndex; set => comboBoxInputPort.SelectedIndex = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool InputEnable0 { get => checkBoxInputEnable0.Checked; set => checkBoxInputEnable0.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool InputEnable1 { get => checkBoxInputEnable1.Checked; set => checkBoxInputEnable1.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool InputEnable2 { get => checkBoxInputEnable2.Checked; set => checkBoxInputEnable2.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool InputEnable3 { get => checkBoxInputEnable3.Checked; set => checkBoxInputEnable3.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool InputEnable4 { get => checkBoxInputEnable4.Checked; set => checkBoxInputEnable4.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool InputEnable5 { get => checkBoxInputEnable5.Checked; set => checkBoxInputEnable5.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool InputEnable6 { get => checkBoxInputEnable6.Checked; set => checkBoxInputEnable6.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool InputEnable7 { get => checkBoxInputEnable7.Checked; set => checkBoxInputEnable7.Checked = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PullResistor0 { get => comboBoxResistor0.SelectedIndex; set => comboBoxResistor0.SelectedIndex = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PullResistor1 { get => comboBoxResistor1.SelectedIndex; set => comboBoxResistor1.SelectedIndex = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PullResistor2 { get => comboBoxResistor2.SelectedIndex; set => comboBoxResistor2.SelectedIndex = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PullResistor3 { get => comboBoxResistor3.SelectedIndex; set => comboBoxResistor3.SelectedIndex = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PullResistor4 { get => comboBoxResistor4.SelectedIndex; set => comboBoxResistor4.SelectedIndex = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PullResistor5 { get => comboBoxResistor5.SelectedIndex; set => comboBoxResistor5.SelectedIndex = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PullResistor6 { get => comboBoxResistor6.SelectedIndex; set => comboBoxResistor6.SelectedIndex = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PullResistor7 { get => comboBoxResistor7.SelectedIndex; set => comboBoxResistor7.SelectedIndex = value; }

        public event EventHandler? SendClicked;
    }
}
