namespace HID_Test_App.Views
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            texboxVendorId = new TextBox();
            label2 = new Label();
            textBoxProductId = new TextBox();
            btnConnect = new Button();
            btnDisconnect = new Button();
            tabsStatusCommand = new TabControl();
            tabPageStatus = new TabPage();
            tabPageCommand = new TabPage();
            groupBox8 = new GroupBox();
            checkBoxEnableChange7 = new CheckBox();
            radioBtnOff7 = new RadioButton();
            radioBtnOn7 = new RadioButton();
            radioBtnPwm7 = new RadioButton();
            numericDutyCycle7 = new NumericUpDown();
            groupBox7 = new GroupBox();
            checkBoxEnableChange6 = new CheckBox();
            radioBtnOff6 = new RadioButton();
            radioBtnOn6 = new RadioButton();
            radioBtnPwm6 = new RadioButton();
            numericDutyCycle6 = new NumericUpDown();
            groupBox6 = new GroupBox();
            checkBoxEnableChange5 = new CheckBox();
            radioBtnOff5 = new RadioButton();
            radioBtnOn5 = new RadioButton();
            radioBtnPwm5 = new RadioButton();
            numericDutyCycle5 = new NumericUpDown();
            groupBox5 = new GroupBox();
            checkBoxEnableChange4 = new CheckBox();
            radioBtnOff4 = new RadioButton();
            radioBtnOn4 = new RadioButton();
            radioBtnPwm4 = new RadioButton();
            numericDutyCycle4 = new NumericUpDown();
            groupBox4 = new GroupBox();
            checkBoxEnableChange3 = new CheckBox();
            radioBtnOff3 = new RadioButton();
            radioBtnOn3 = new RadioButton();
            radioBtnPwm3 = new RadioButton();
            numericDutyCycle3 = new NumericUpDown();
            groupBox3 = new GroupBox();
            checkBoxEnableChange2 = new CheckBox();
            radioBtnOff2 = new RadioButton();
            radioBtnOn2 = new RadioButton();
            radioBtnPwm2 = new RadioButton();
            numericDutyCycle2 = new NumericUpDown();
            groupBox2 = new GroupBox();
            checkBoxEnableChange1 = new CheckBox();
            radioBtnOff1 = new RadioButton();
            radioBtnOn1 = new RadioButton();
            radioBtnPwm1 = new RadioButton();
            numericDutyCycle1 = new NumericUpDown();
            groupBox1 = new GroupBox();
            radioBtnPwm0 = new RadioButton();
            radioBtnOn0 = new RadioButton();
            radioBtnOff0 = new RadioButton();
            numericDutyCycle0 = new NumericUpDown();
            checkBoxEnableChange0 = new CheckBox();
            btnSend = new Button();
            textBoxCommandData = new TextBox();
            comboBoxPort = new ComboBox();
            tabsStatusCommand.SuspendLayout();
            tabPageCommand.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle7).BeginInit();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle6).BeginInit();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle5).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle4).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle3).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle2).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle0).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(293, 40);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(41, 25);
            label1.TabIndex = 0;
            label1.Text = "VID";
            // 
            // texboxVendorId
            // 
            texboxVendorId.Location = new Point(346, 35);
            texboxVendorId.Margin = new Padding(4, 5, 4, 5);
            texboxVendorId.Name = "texboxVendorId";
            texboxVendorId.Size = new Size(75, 31);
            texboxVendorId.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(446, 40);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(40, 25);
            label2.TabIndex = 2;
            label2.Text = "PID";
            // 
            // textBoxProductId
            // 
            textBoxProductId.Location = new Point(490, 35);
            textBoxProductId.Margin = new Padding(4, 5, 4, 5);
            textBoxProductId.Name = "textBoxProductId";
            textBoxProductId.Size = new Size(83, 31);
            textBoxProductId.TabIndex = 3;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(616, 35);
            btnConnect.Margin = new Padding(4, 5, 4, 5);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(107, 38);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(731, 35);
            btnDisconnect.Margin = new Padding(4, 5, 4, 5);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(107, 38);
            btnDisconnect.TabIndex = 5;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // tabsStatusCommand
            // 
            tabsStatusCommand.Controls.Add(tabPageStatus);
            tabsStatusCommand.Controls.Add(tabPageCommand);
            tabsStatusCommand.Location = new Point(14, 83);
            tabsStatusCommand.Margin = new Padding(4, 5, 4, 5);
            tabsStatusCommand.Name = "tabsStatusCommand";
            tabsStatusCommand.SelectedIndex = 0;
            tabsStatusCommand.Size = new Size(830, 900);
            tabsStatusCommand.TabIndex = 6;
            // 
            // tabPageStatus
            // 
            tabPageStatus.Location = new Point(4, 34);
            tabPageStatus.Margin = new Padding(4, 5, 4, 5);
            tabPageStatus.Name = "tabPageStatus";
            tabPageStatus.Padding = new Padding(4, 5, 4, 5);
            tabPageStatus.Size = new Size(822, 862);
            tabPageStatus.TabIndex = 0;
            tabPageStatus.Text = "Status";
            tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // tabPageCommand
            // 
            tabPageCommand.Controls.Add(groupBox8);
            tabPageCommand.Controls.Add(groupBox7);
            tabPageCommand.Controls.Add(groupBox6);
            tabPageCommand.Controls.Add(groupBox5);
            tabPageCommand.Controls.Add(groupBox4);
            tabPageCommand.Controls.Add(groupBox3);
            tabPageCommand.Controls.Add(groupBox2);
            tabPageCommand.Controls.Add(groupBox1);
            tabPageCommand.Controls.Add(btnSend);
            tabPageCommand.Controls.Add(textBoxCommandData);
            tabPageCommand.Controls.Add(comboBoxPort);
            tabPageCommand.Location = new Point(4, 34);
            tabPageCommand.Margin = new Padding(4, 5, 4, 5);
            tabPageCommand.Name = "tabPageCommand";
            tabPageCommand.Padding = new Padding(4, 5, 4, 5);
            tabPageCommand.Size = new Size(822, 862);
            tabPageCommand.TabIndex = 1;
            tabPageCommand.Text = "Outputs Command";
            tabPageCommand.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(checkBoxEnableChange7);
            groupBox8.Controls.Add(radioBtnOff7);
            groupBox8.Controls.Add(radioBtnOn7);
            groupBox8.Controls.Add(radioBtnPwm7);
            groupBox8.Controls.Add(numericDutyCycle7);
            groupBox8.Location = new Point(27, 775);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(535, 68);
            groupBox8.TabIndex = 50;
            groupBox8.TabStop = false;
            groupBox8.Text = "Output 8";
            // 
            // checkBoxEnableChange7
            // 
            checkBoxEnableChange7.AutoSize = true;
            checkBoxEnableChange7.Location = new Point(7, 31);
            checkBoxEnableChange7.Margin = new Padding(4, 5, 4, 5);
            checkBoxEnableChange7.Name = "checkBoxEnableChange7";
            checkBoxEnableChange7.Size = new Size(98, 29);
            checkBoxEnableChange7.TabIndex = 38;
            checkBoxEnableChange7.TabStop = false;
            checkBoxEnableChange7.Text = "Change";
            checkBoxEnableChange7.UseVisualStyleBackColor = true;
            // 
            // radioBtnOff7
            // 
            radioBtnOff7.AutoSize = true;
            radioBtnOff7.Location = new Point(167, 30);
            radioBtnOff7.Margin = new Padding(4, 5, 4, 5);
            radioBtnOff7.Name = "radioBtnOff7";
            radioBtnOff7.Size = new Size(63, 29);
            radioBtnOff7.TabIndex = 40;
            radioBtnOff7.TabStop = true;
            radioBtnOff7.Text = "Off";
            radioBtnOff7.UseVisualStyleBackColor = true;
            // 
            // radioBtnOn7
            // 
            radioBtnOn7.AutoSize = true;
            radioBtnOn7.Location = new Point(238, 30);
            radioBtnOn7.Margin = new Padding(4, 5, 4, 5);
            radioBtnOn7.Name = "radioBtnOn7";
            radioBtnOn7.Size = new Size(61, 29);
            radioBtnOn7.TabIndex = 41;
            radioBtnOn7.TabStop = true;
            radioBtnOn7.Text = "On";
            radioBtnOn7.UseVisualStyleBackColor = true;
            // 
            // radioBtnPwm7
            // 
            radioBtnPwm7.AutoSize = true;
            radioBtnPwm7.Location = new Point(307, 30);
            radioBtnPwm7.Margin = new Padding(4, 5, 4, 5);
            radioBtnPwm7.Name = "radioBtnPwm7";
            radioBtnPwm7.Size = new Size(80, 29);
            radioBtnPwm7.TabIndex = 42;
            radioBtnPwm7.TabStop = true;
            radioBtnPwm7.Text = "PWM";
            radioBtnPwm7.UseVisualStyleBackColor = true;
            // 
            // numericDutyCycle7
            // 
            numericDutyCycle7.Location = new Point(398, 28);
            numericDutyCycle7.Margin = new Padding(4, 5, 4, 5);
            numericDutyCycle7.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericDutyCycle7.Name = "numericDutyCycle7";
            numericDutyCycle7.Size = new Size(113, 31);
            numericDutyCycle7.TabIndex = 39;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(checkBoxEnableChange6);
            groupBox7.Controls.Add(radioBtnOff6);
            groupBox7.Controls.Add(radioBtnOn6);
            groupBox7.Controls.Add(radioBtnPwm6);
            groupBox7.Controls.Add(numericDutyCycle6);
            groupBox7.Location = new Point(27, 692);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(535, 68);
            groupBox7.TabIndex = 49;
            groupBox7.TabStop = false;
            groupBox7.Text = "Output 7";
            // 
            // checkBoxEnableChange6
            // 
            checkBoxEnableChange6.AutoSize = true;
            checkBoxEnableChange6.Location = new Point(7, 31);
            checkBoxEnableChange6.Margin = new Padding(4, 5, 4, 5);
            checkBoxEnableChange6.Name = "checkBoxEnableChange6";
            checkBoxEnableChange6.Size = new Size(98, 29);
            checkBoxEnableChange6.TabIndex = 33;
            checkBoxEnableChange6.TabStop = false;
            checkBoxEnableChange6.Text = "Change";
            checkBoxEnableChange6.UseVisualStyleBackColor = true;
            // 
            // radioBtnOff6
            // 
            radioBtnOff6.AutoSize = true;
            radioBtnOff6.Location = new Point(167, 28);
            radioBtnOff6.Margin = new Padding(4, 5, 4, 5);
            radioBtnOff6.Name = "radioBtnOff6";
            radioBtnOff6.Size = new Size(63, 29);
            radioBtnOff6.TabIndex = 35;
            radioBtnOff6.TabStop = true;
            radioBtnOff6.Text = "Off";
            radioBtnOff6.UseVisualStyleBackColor = true;
            // 
            // radioBtnOn6
            // 
            radioBtnOn6.AutoSize = true;
            radioBtnOn6.Location = new Point(238, 30);
            radioBtnOn6.Margin = new Padding(4, 5, 4, 5);
            radioBtnOn6.Name = "radioBtnOn6";
            radioBtnOn6.Size = new Size(61, 29);
            radioBtnOn6.TabIndex = 36;
            radioBtnOn6.TabStop = true;
            radioBtnOn6.Text = "On";
            radioBtnOn6.UseVisualStyleBackColor = true;
            // 
            // radioBtnPwm6
            // 
            radioBtnPwm6.AutoSize = true;
            radioBtnPwm6.Location = new Point(307, 30);
            radioBtnPwm6.Margin = new Padding(4, 5, 4, 5);
            radioBtnPwm6.Name = "radioBtnPwm6";
            radioBtnPwm6.Size = new Size(80, 29);
            radioBtnPwm6.TabIndex = 37;
            radioBtnPwm6.TabStop = true;
            radioBtnPwm6.Text = "PWM";
            radioBtnPwm6.UseVisualStyleBackColor = true;
            // 
            // numericDutyCycle6
            // 
            numericDutyCycle6.Location = new Point(398, 28);
            numericDutyCycle6.Margin = new Padding(4, 5, 4, 5);
            numericDutyCycle6.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericDutyCycle6.Name = "numericDutyCycle6";
            numericDutyCycle6.Size = new Size(113, 31);
            numericDutyCycle6.TabIndex = 34;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(checkBoxEnableChange5);
            groupBox6.Controls.Add(radioBtnOff5);
            groupBox6.Controls.Add(radioBtnOn5);
            groupBox6.Controls.Add(radioBtnPwm5);
            groupBox6.Controls.Add(numericDutyCycle5);
            groupBox6.Location = new Point(27, 604);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(531, 68);
            groupBox6.TabIndex = 48;
            groupBox6.TabStop = false;
            groupBox6.Text = "Output 6";
            // 
            // checkBoxEnableChange5
            // 
            checkBoxEnableChange5.AutoSize = true;
            checkBoxEnableChange5.Location = new Point(11, 39);
            checkBoxEnableChange5.Margin = new Padding(4, 5, 4, 5);
            checkBoxEnableChange5.Name = "checkBoxEnableChange5";
            checkBoxEnableChange5.Size = new Size(98, 29);
            checkBoxEnableChange5.TabIndex = 28;
            checkBoxEnableChange5.TabStop = false;
            checkBoxEnableChange5.Text = "Change";
            checkBoxEnableChange5.UseVisualStyleBackColor = true;
            // 
            // radioBtnOff5
            // 
            radioBtnOff5.AutoSize = true;
            radioBtnOff5.Location = new Point(167, 32);
            radioBtnOff5.Margin = new Padding(4, 5, 4, 5);
            radioBtnOff5.Name = "radioBtnOff5";
            radioBtnOff5.Size = new Size(63, 29);
            radioBtnOff5.TabIndex = 30;
            radioBtnOff5.TabStop = true;
            radioBtnOff5.Text = "Off";
            radioBtnOff5.UseVisualStyleBackColor = true;
            // 
            // radioBtnOn5
            // 
            radioBtnOn5.AutoSize = true;
            radioBtnOn5.Location = new Point(240, 31);
            radioBtnOn5.Margin = new Padding(4, 5, 4, 5);
            radioBtnOn5.Name = "radioBtnOn5";
            radioBtnOn5.Size = new Size(61, 29);
            radioBtnOn5.TabIndex = 31;
            radioBtnOn5.TabStop = true;
            radioBtnOn5.Text = "On";
            radioBtnOn5.UseVisualStyleBackColor = true;
            // 
            // radioBtnPwm5
            // 
            radioBtnPwm5.AutoSize = true;
            radioBtnPwm5.Location = new Point(311, 32);
            radioBtnPwm5.Margin = new Padding(4, 5, 4, 5);
            radioBtnPwm5.Name = "radioBtnPwm5";
            radioBtnPwm5.Size = new Size(80, 29);
            radioBtnPwm5.TabIndex = 32;
            radioBtnPwm5.TabStop = true;
            radioBtnPwm5.Text = "PWM";
            radioBtnPwm5.UseVisualStyleBackColor = true;
            // 
            // numericDutyCycle5
            // 
            numericDutyCycle5.Location = new Point(402, 32);
            numericDutyCycle5.Margin = new Padding(4, 5, 4, 5);
            numericDutyCycle5.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericDutyCycle5.Name = "numericDutyCycle5";
            numericDutyCycle5.Size = new Size(113, 31);
            numericDutyCycle5.TabIndex = 29;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(checkBoxEnableChange4);
            groupBox5.Controls.Add(radioBtnOff4);
            groupBox5.Controls.Add(radioBtnOn4);
            groupBox5.Controls.Add(radioBtnPwm4);
            groupBox5.Controls.Add(numericDutyCycle4);
            groupBox5.Location = new Point(27, 519);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(533, 68);
            groupBox5.TabIndex = 47;
            groupBox5.TabStop = false;
            groupBox5.Text = "Output 5";
            // 
            // checkBoxEnableChange4
            // 
            checkBoxEnableChange4.AutoSize = true;
            checkBoxEnableChange4.Location = new Point(13, 31);
            checkBoxEnableChange4.Margin = new Padding(4, 5, 4, 5);
            checkBoxEnableChange4.Name = "checkBoxEnableChange4";
            checkBoxEnableChange4.Size = new Size(98, 29);
            checkBoxEnableChange4.TabIndex = 23;
            checkBoxEnableChange4.TabStop = false;
            checkBoxEnableChange4.Text = "Change";
            checkBoxEnableChange4.UseVisualStyleBackColor = true;
            // 
            // radioBtnOff4
            // 
            radioBtnOff4.AutoSize = true;
            radioBtnOff4.Location = new Point(169, 30);
            radioBtnOff4.Margin = new Padding(4, 5, 4, 5);
            radioBtnOff4.Name = "radioBtnOff4";
            radioBtnOff4.Size = new Size(63, 29);
            radioBtnOff4.TabIndex = 25;
            radioBtnOff4.TabStop = true;
            radioBtnOff4.Text = "Off";
            radioBtnOff4.UseVisualStyleBackColor = true;
            // 
            // radioBtnOn4
            // 
            radioBtnOn4.AutoSize = true;
            radioBtnOn4.Location = new Point(244, 30);
            radioBtnOn4.Margin = new Padding(4, 5, 4, 5);
            radioBtnOn4.Name = "radioBtnOn4";
            radioBtnOn4.Size = new Size(61, 29);
            radioBtnOn4.TabIndex = 26;
            radioBtnOn4.TabStop = true;
            radioBtnOn4.Text = "On";
            radioBtnOn4.UseVisualStyleBackColor = true;
            // 
            // radioBtnPwm4
            // 
            radioBtnPwm4.AutoSize = true;
            radioBtnPwm4.Location = new Point(313, 32);
            radioBtnPwm4.Margin = new Padding(4, 5, 4, 5);
            radioBtnPwm4.Name = "radioBtnPwm4";
            radioBtnPwm4.Size = new Size(80, 29);
            radioBtnPwm4.TabIndex = 27;
            radioBtnPwm4.TabStop = true;
            radioBtnPwm4.Text = "PWM";
            radioBtnPwm4.UseVisualStyleBackColor = true;
            // 
            // numericDutyCycle4
            // 
            numericDutyCycle4.Location = new Point(404, 28);
            numericDutyCycle4.Margin = new Padding(4, 5, 4, 5);
            numericDutyCycle4.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericDutyCycle4.Name = "numericDutyCycle4";
            numericDutyCycle4.Size = new Size(113, 31);
            numericDutyCycle4.TabIndex = 24;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(checkBoxEnableChange3);
            groupBox4.Controls.Add(radioBtnOff3);
            groupBox4.Controls.Add(radioBtnOn3);
            groupBox4.Controls.Add(radioBtnPwm3);
            groupBox4.Controls.Add(numericDutyCycle3);
            groupBox4.Location = new Point(27, 436);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(535, 68);
            groupBox4.TabIndex = 46;
            groupBox4.TabStop = false;
            groupBox4.Text = "Output 4";
            // 
            // checkBoxEnableChange3
            // 
            checkBoxEnableChange3.AutoSize = true;
            checkBoxEnableChange3.Location = new Point(14, 32);
            checkBoxEnableChange3.Margin = new Padding(4, 5, 4, 5);
            checkBoxEnableChange3.Name = "checkBoxEnableChange3";
            checkBoxEnableChange3.Size = new Size(98, 29);
            checkBoxEnableChange3.TabIndex = 18;
            checkBoxEnableChange3.TabStop = false;
            checkBoxEnableChange3.Text = "Change";
            checkBoxEnableChange3.UseVisualStyleBackColor = true;
            // 
            // radioBtnOff3
            // 
            radioBtnOff3.AutoSize = true;
            radioBtnOff3.Location = new Point(170, 31);
            radioBtnOff3.Margin = new Padding(4, 5, 4, 5);
            radioBtnOff3.Name = "radioBtnOff3";
            radioBtnOff3.Size = new Size(63, 29);
            radioBtnOff3.TabIndex = 20;
            radioBtnOff3.TabStop = true;
            radioBtnOff3.Text = "Off";
            radioBtnOff3.UseVisualStyleBackColor = true;
            // 
            // radioBtnOn3
            // 
            radioBtnOn3.AutoSize = true;
            radioBtnOn3.Location = new Point(240, 32);
            radioBtnOn3.Margin = new Padding(4, 5, 4, 5);
            radioBtnOn3.Name = "radioBtnOn3";
            radioBtnOn3.Size = new Size(61, 29);
            radioBtnOn3.TabIndex = 21;
            radioBtnOn3.TabStop = true;
            radioBtnOn3.Text = "On";
            radioBtnOn3.UseVisualStyleBackColor = true;
            // 
            // radioBtnPwm3
            // 
            radioBtnPwm3.AutoSize = true;
            radioBtnPwm3.Location = new Point(314, 31);
            radioBtnPwm3.Margin = new Padding(4, 5, 4, 5);
            radioBtnPwm3.Name = "radioBtnPwm3";
            radioBtnPwm3.Size = new Size(80, 29);
            radioBtnPwm3.TabIndex = 22;
            radioBtnPwm3.TabStop = true;
            radioBtnPwm3.Text = "PWM";
            radioBtnPwm3.UseVisualStyleBackColor = true;
            // 
            // numericDutyCycle3
            // 
            numericDutyCycle3.Location = new Point(405, 29);
            numericDutyCycle3.Margin = new Padding(4, 5, 4, 5);
            numericDutyCycle3.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericDutyCycle3.Name = "numericDutyCycle3";
            numericDutyCycle3.Size = new Size(113, 31);
            numericDutyCycle3.TabIndex = 19;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkBoxEnableChange2);
            groupBox3.Controls.Add(radioBtnOff2);
            groupBox3.Controls.Add(radioBtnOn2);
            groupBox3.Controls.Add(radioBtnPwm2);
            groupBox3.Controls.Add(numericDutyCycle2);
            groupBox3.Location = new Point(27, 362);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(538, 68);
            groupBox3.TabIndex = 45;
            groupBox3.TabStop = false;
            groupBox3.Text = "Output 3";
            // 
            // checkBoxEnableChange2
            // 
            checkBoxEnableChange2.AutoSize = true;
            checkBoxEnableChange2.Location = new Point(17, 32);
            checkBoxEnableChange2.Margin = new Padding(4, 5, 4, 5);
            checkBoxEnableChange2.Name = "checkBoxEnableChange2";
            checkBoxEnableChange2.Size = new Size(98, 29);
            checkBoxEnableChange2.TabIndex = 13;
            checkBoxEnableChange2.TabStop = false;
            checkBoxEnableChange2.Text = "Change";
            checkBoxEnableChange2.UseVisualStyleBackColor = true;
            // 
            // radioBtnOff2
            // 
            radioBtnOff2.AutoSize = true;
            radioBtnOff2.Location = new Point(173, 31);
            radioBtnOff2.Margin = new Padding(4, 5, 4, 5);
            radioBtnOff2.Name = "radioBtnOff2";
            radioBtnOff2.Size = new Size(63, 29);
            radioBtnOff2.TabIndex = 15;
            radioBtnOff2.TabStop = true;
            radioBtnOff2.Text = "Off";
            radioBtnOff2.UseVisualStyleBackColor = true;
            // 
            // radioBtnOn2
            // 
            radioBtnOn2.AutoSize = true;
            radioBtnOn2.Location = new Point(248, 31);
            radioBtnOn2.Margin = new Padding(4, 5, 4, 5);
            radioBtnOn2.Name = "radioBtnOn2";
            radioBtnOn2.Size = new Size(61, 29);
            radioBtnOn2.TabIndex = 16;
            radioBtnOn2.TabStop = true;
            radioBtnOn2.Text = "On";
            radioBtnOn2.UseVisualStyleBackColor = true;
            // 
            // radioBtnPwm2
            // 
            radioBtnPwm2.AutoSize = true;
            radioBtnPwm2.Location = new Point(317, 31);
            radioBtnPwm2.Margin = new Padding(4, 5, 4, 5);
            radioBtnPwm2.Name = "radioBtnPwm2";
            radioBtnPwm2.Size = new Size(80, 29);
            radioBtnPwm2.TabIndex = 17;
            radioBtnPwm2.TabStop = true;
            radioBtnPwm2.Text = "PWM";
            radioBtnPwm2.UseVisualStyleBackColor = true;
            // 
            // numericDutyCycle2
            // 
            numericDutyCycle2.Location = new Point(408, 29);
            numericDutyCycle2.Margin = new Padding(4, 5, 4, 5);
            numericDutyCycle2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericDutyCycle2.Name = "numericDutyCycle2";
            numericDutyCycle2.Size = new Size(113, 31);
            numericDutyCycle2.TabIndex = 14;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBoxEnableChange1);
            groupBox2.Controls.Add(radioBtnOff1);
            groupBox2.Controls.Add(radioBtnOn1);
            groupBox2.Controls.Add(radioBtnPwm1);
            groupBox2.Controls.Add(numericDutyCycle1);
            groupBox2.Location = new Point(25, 279);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(535, 68);
            groupBox2.TabIndex = 44;
            groupBox2.TabStop = false;
            groupBox2.Text = "Output 2";
            // 
            // checkBoxEnableChange1
            // 
            checkBoxEnableChange1.AutoSize = true;
            checkBoxEnableChange1.Location = new Point(19, 31);
            checkBoxEnableChange1.Margin = new Padding(4, 5, 4, 5);
            checkBoxEnableChange1.Name = "checkBoxEnableChange1";
            checkBoxEnableChange1.Size = new Size(98, 29);
            checkBoxEnableChange1.TabIndex = 8;
            checkBoxEnableChange1.TabStop = false;
            checkBoxEnableChange1.Text = "Change";
            checkBoxEnableChange1.UseVisualStyleBackColor = true;
            // 
            // radioBtnOff1
            // 
            radioBtnOff1.AutoSize = true;
            radioBtnOff1.Location = new Point(175, 30);
            radioBtnOff1.Margin = new Padding(4, 5, 4, 5);
            radioBtnOff1.Name = "radioBtnOff1";
            radioBtnOff1.Size = new Size(63, 29);
            radioBtnOff1.TabIndex = 10;
            radioBtnOff1.TabStop = true;
            radioBtnOff1.Text = "Off";
            radioBtnOff1.UseVisualStyleBackColor = true;
            // 
            // radioBtnOn1
            // 
            radioBtnOn1.AutoSize = true;
            radioBtnOn1.Location = new Point(250, 32);
            radioBtnOn1.Margin = new Padding(4, 5, 4, 5);
            radioBtnOn1.Name = "radioBtnOn1";
            radioBtnOn1.Size = new Size(61, 29);
            radioBtnOn1.TabIndex = 11;
            radioBtnOn1.TabStop = true;
            radioBtnOn1.Text = "On";
            radioBtnOn1.UseVisualStyleBackColor = true;
            // 
            // radioBtnPwm1
            // 
            radioBtnPwm1.AutoSize = true;
            radioBtnPwm1.Location = new Point(319, 32);
            radioBtnPwm1.Margin = new Padding(4, 5, 4, 5);
            radioBtnPwm1.Name = "radioBtnPwm1";
            radioBtnPwm1.Size = new Size(80, 29);
            radioBtnPwm1.TabIndex = 12;
            radioBtnPwm1.TabStop = true;
            radioBtnPwm1.Text = "PWM";
            radioBtnPwm1.UseVisualStyleBackColor = true;
            // 
            // numericDutyCycle1
            // 
            numericDutyCycle1.Location = new Point(410, 30);
            numericDutyCycle1.Margin = new Padding(4, 5, 4, 5);
            numericDutyCycle1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericDutyCycle1.Name = "numericDutyCycle1";
            numericDutyCycle1.Size = new Size(113, 31);
            numericDutyCycle1.TabIndex = 9;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioBtnPwm0);
            groupBox1.Controls.Add(radioBtnOn0);
            groupBox1.Controls.Add(radioBtnOff0);
            groupBox1.Controls.Add(numericDutyCycle0);
            groupBox1.Controls.Add(checkBoxEnableChange0);
            groupBox1.Location = new Point(27, 197);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(528, 68);
            groupBox1.TabIndex = 43;
            groupBox1.TabStop = false;
            groupBox1.Text = "Output 1";
            // 
            // radioBtnPwm0
            // 
            radioBtnPwm0.AutoSize = true;
            radioBtnPwm0.Location = new Point(315, 30);
            radioBtnPwm0.Margin = new Padding(4, 5, 4, 5);
            radioBtnPwm0.Name = "radioBtnPwm0";
            radioBtnPwm0.Size = new Size(80, 29);
            radioBtnPwm0.TabIndex = 7;
            radioBtnPwm0.TabStop = true;
            radioBtnPwm0.Text = "PWM";
            radioBtnPwm0.UseVisualStyleBackColor = true;
            // 
            // radioBtnOn0
            // 
            radioBtnOn0.AutoSize = true;
            radioBtnOn0.Location = new Point(246, 30);
            radioBtnOn0.Margin = new Padding(4, 5, 4, 5);
            radioBtnOn0.Name = "radioBtnOn0";
            radioBtnOn0.Size = new Size(61, 29);
            radioBtnOn0.TabIndex = 6;
            radioBtnOn0.TabStop = true;
            radioBtnOn0.Text = "On";
            radioBtnOn0.UseVisualStyleBackColor = true;
            // 
            // radioBtnOff0
            // 
            radioBtnOff0.AutoSize = true;
            radioBtnOff0.Location = new Point(173, 30);
            radioBtnOff0.Margin = new Padding(4, 5, 4, 5);
            radioBtnOff0.Name = "radioBtnOff0";
            radioBtnOff0.Size = new Size(63, 29);
            radioBtnOff0.TabIndex = 5;
            radioBtnOff0.TabStop = true;
            radioBtnOff0.Text = "Off";
            radioBtnOff0.UseVisualStyleBackColor = true;
            // 
            // numericDutyCycle0
            // 
            numericDutyCycle0.Location = new Point(408, 28);
            numericDutyCycle0.Margin = new Padding(4, 5, 4, 5);
            numericDutyCycle0.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericDutyCycle0.Name = "numericDutyCycle0";
            numericDutyCycle0.Size = new Size(113, 31);
            numericDutyCycle0.TabIndex = 4;
            // 
            // checkBoxEnableChange0
            // 
            checkBoxEnableChange0.AutoSize = true;
            checkBoxEnableChange0.Location = new Point(17, 31);
            checkBoxEnableChange0.Margin = new Padding(4, 5, 4, 5);
            checkBoxEnableChange0.Name = "checkBoxEnableChange0";
            checkBoxEnableChange0.Size = new Size(98, 29);
            checkBoxEnableChange0.TabIndex = 3;
            checkBoxEnableChange0.TabStop = false;
            checkBoxEnableChange0.Text = "Change";
            checkBoxEnableChange0.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(670, 108);
            btnSend.Margin = new Padding(4, 5, 4, 5);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(107, 83);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // textBoxCommandData
            // 
            textBoxCommandData.Location = new Point(27, 108);
            textBoxCommandData.Margin = new Padding(4, 5, 4, 5);
            textBoxCommandData.Multiline = true;
            textBoxCommandData.Name = "textBoxCommandData";
            textBoxCommandData.Size = new Size(611, 81);
            textBoxCommandData.TabIndex = 1;
            // 
            // comboBoxPort
            // 
            comboBoxPort.FormattingEnabled = true;
            comboBoxPort.Items.AddRange(new object[] { "Port 1", "Port 2", "Port 3" });
            comboBoxPort.Location = new Point(27, 30);
            comboBoxPort.Margin = new Padding(4, 5, 4, 5);
            comboBoxPort.Name = "comboBoxPort";
            comboBoxPort.Size = new Size(171, 33);
            comboBoxPort.TabIndex = 0;
            comboBoxPort.SelectedIndexChanged += comboBoxPort_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(861, 1003);
            Controls.Add(tabsStatusCommand);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(textBoxProductId);
            Controls.Add(label2);
            Controls.Add(texboxVendorId);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            Text = "HID Test App";
            tabsStatusCommand.ResumeLayout(false);
            tabPageCommand.ResumeLayout(false);
            tabPageCommand.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle7).EndInit();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle6).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle5).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle4).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle3).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle2).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericDutyCycle0).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox texboxVendorId;
        private Label label2;
        private TextBox textBoxProductId;
        private Button btnConnect;
        private Button btnDisconnect;
        private TabControl tabsStatusCommand;
        private TabPage tabPageStatus;
        public TabPage tabPageCommand;
        private ComboBox comboBoxPort;
        private TextBox textBoxCommandData;
        private Button btnSend;
        private NumericUpDown numericDutyCycle0;
        private CheckBox checkBoxEnableChange0;
        private RadioButton radioBtnPwm0;
        private RadioButton radioBtnOn0;
        private RadioButton radioBtnOff0;
        private RadioButton radioBtnPwm7;
        private RadioButton radioBtnOn7;
        private RadioButton radioBtnOff7;
        private NumericUpDown numericDutyCycle7;
        private CheckBox checkBoxEnableChange7;
        private RadioButton radioBtnPwm6;
        private RadioButton radioBtnOn6;
        private RadioButton radioBtnOff6;
        private NumericUpDown numericDutyCycle6;
        private CheckBox checkBoxEnableChange6;
        private RadioButton radioBtnPwm5;
        private RadioButton radioBtnOn5;
        private RadioButton radioBtnOff5;
        private NumericUpDown numericDutyCycle5;
        private CheckBox checkBoxEnableChange5;
        private RadioButton radioBtnPwm4;
        private RadioButton radioBtnOn4;
        private RadioButton radioBtnOff4;
        private NumericUpDown numericDutyCycle4;
        private CheckBox checkBoxEnableChange4;
        private RadioButton radioBtnPwm3;
        private RadioButton radioBtnOn3;
        private RadioButton radioBtnOff3;
        private NumericUpDown numericDutyCycle3;
        private CheckBox checkBoxEnableChange3;
        private RadioButton radioBtnPwm2;
        private RadioButton radioBtnOn2;
        private RadioButton radioBtnOff2;
        private NumericUpDown numericDutyCycle2;
        private CheckBox checkBoxEnableChange2;
        private RadioButton radioBtnPwm1;
        private RadioButton radioBtnOn1;
        private RadioButton radioBtnOff1;
        private NumericUpDown numericDutyCycle1;
        private CheckBox checkBoxEnableChange1;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private GroupBox groupBox6;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private GroupBox groupBox8;
        private GroupBox groupBox7;
    }
}
