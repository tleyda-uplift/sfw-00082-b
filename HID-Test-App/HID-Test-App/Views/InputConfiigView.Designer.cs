namespace HID_Test_App.Views
{
    partial class InputConfiigView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxInputPort = new ComboBox();
            btnInputConfigSend = new Button();
            checkBoxInputEnable0 = new CheckBox();
            groupBox1 = new GroupBox();
            comboBoxResistor0 = new ComboBox();
            groupBox2 = new GroupBox();
            comboBoxResistor1 = new ComboBox();
            checkBoxInputEnable1 = new CheckBox();
            groupBox3 = new GroupBox();
            comboBoxResistor2 = new ComboBox();
            checkBoxInputEnable2 = new CheckBox();
            groupBox4 = new GroupBox();
            comboBoxResistor3 = new ComboBox();
            checkBoxInputEnable3 = new CheckBox();
            groupBox5 = new GroupBox();
            comboBoxResistor4 = new ComboBox();
            checkBoxInputEnable4 = new CheckBox();
            groupBox6 = new GroupBox();
            comboBoxResistor5 = new ComboBox();
            checkBoxInputEnable5 = new CheckBox();
            groupBox7 = new GroupBox();
            comboBoxResistor6 = new ComboBox();
            checkBoxInputEnable6 = new CheckBox();
            groupBox8 = new GroupBox();
            comboBoxResistor7 = new ComboBox();
            checkBoxInputEnable7 = new CheckBox();
            textBoxInputConfigRaw = new TextBox();
            groupBox9 = new GroupBox();
            labelSent = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox9.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxInputPort
            // 
            comboBoxInputPort.FormattingEnabled = true;
            comboBoxInputPort.Items.AddRange(new object[] { "Port 1", "Port 2", "Port 3" });
            comboBoxInputPort.Location = new Point(14, 12);
            comboBoxInputPort.Name = "comboBoxInputPort";
            comboBoxInputPort.Size = new Size(121, 23);
            comboBoxInputPort.TabIndex = 0;
            comboBoxInputPort.SelectedIndexChanged += comboBoxInputPort_SelectedIndexChanged;
            // 
            // btnInputConfigSend
            // 
            btnInputConfigSend.Location = new Point(469, 12);
            btnInputConfigSend.Name = "btnInputConfigSend";
            btnInputConfigSend.Size = new Size(70, 48);
            btnInputConfigSend.TabIndex = 1;
            btnInputConfigSend.Text = "Send";
            btnInputConfigSend.UseVisualStyleBackColor = true;
            btnInputConfigSend.Click += btnInputConfigSend_Click;
            // 
            // checkBoxInputEnable0
            // 
            checkBoxInputEnable0.AutoSize = true;
            checkBoxInputEnable0.Location = new Point(6, 22);
            checkBoxInputEnable0.Name = "checkBoxInputEnable0";
            checkBoxInputEnable0.Size = new Size(61, 19);
            checkBoxInputEnable0.TabIndex = 2;
            checkBoxInputEnable0.Text = "Enable";
            checkBoxInputEnable0.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBoxResistor0);
            groupBox1.Controls.Add(checkBoxInputEnable0);
            groupBox1.Location = new Point(14, 44);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 52);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input 1";
            // 
            // comboBoxResistor0
            // 
            comboBoxResistor0.FormattingEnabled = true;
            comboBoxResistor0.Items.AddRange(new object[] { "Pull Down", "Pull Up" });
            comboBoxResistor0.Location = new Point(93, 20);
            comboBoxResistor0.Name = "comboBoxResistor0";
            comboBoxResistor0.Size = new Size(121, 23);
            comboBoxResistor0.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBoxResistor1);
            groupBox2.Controls.Add(checkBoxInputEnable1);
            groupBox2.Location = new Point(14, 103);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 52);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Input 2";
            // 
            // comboBoxResistor1
            // 
            comboBoxResistor1.FormattingEnabled = true;
            comboBoxResistor1.Items.AddRange(new object[] { "Pull Down", "Pull Up" });
            comboBoxResistor1.Location = new Point(93, 20);
            comboBoxResistor1.Name = "comboBoxResistor1";
            comboBoxResistor1.Size = new Size(121, 23);
            comboBoxResistor1.TabIndex = 3;
            // 
            // checkBoxInputEnable1
            // 
            checkBoxInputEnable1.AutoSize = true;
            checkBoxInputEnable1.Location = new Point(6, 22);
            checkBoxInputEnable1.Name = "checkBoxInputEnable1";
            checkBoxInputEnable1.Size = new Size(61, 19);
            checkBoxInputEnable1.TabIndex = 2;
            checkBoxInputEnable1.Text = "Enable";
            checkBoxInputEnable1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(comboBoxResistor2);
            groupBox3.Controls.Add(checkBoxInputEnable2);
            groupBox3.Location = new Point(14, 151);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(250, 52);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Input 3";
            // 
            // comboBoxResistor2
            // 
            comboBoxResistor2.FormattingEnabled = true;
            comboBoxResistor2.Items.AddRange(new object[] { "Pull Down", "Pull Up" });
            comboBoxResistor2.Location = new Point(93, 20);
            comboBoxResistor2.Name = "comboBoxResistor2";
            comboBoxResistor2.Size = new Size(121, 23);
            comboBoxResistor2.TabIndex = 3;
            // 
            // checkBoxInputEnable2
            // 
            checkBoxInputEnable2.AutoSize = true;
            checkBoxInputEnable2.Location = new Point(6, 22);
            checkBoxInputEnable2.Name = "checkBoxInputEnable2";
            checkBoxInputEnable2.Size = new Size(61, 19);
            checkBoxInputEnable2.TabIndex = 2;
            checkBoxInputEnable2.Text = "Enable";
            checkBoxInputEnable2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(comboBoxResistor3);
            groupBox4.Controls.Add(checkBoxInputEnable3);
            groupBox4.Location = new Point(14, 200);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(250, 52);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "Input 4";
            // 
            // comboBoxResistor3
            // 
            comboBoxResistor3.FormattingEnabled = true;
            comboBoxResistor3.Items.AddRange(new object[] { "Pull Down", "Pull Up" });
            comboBoxResistor3.Location = new Point(93, 20);
            comboBoxResistor3.Name = "comboBoxResistor3";
            comboBoxResistor3.Size = new Size(121, 23);
            comboBoxResistor3.TabIndex = 3;
            // 
            // checkBoxInputEnable3
            // 
            checkBoxInputEnable3.AutoSize = true;
            checkBoxInputEnable3.Location = new Point(6, 22);
            checkBoxInputEnable3.Name = "checkBoxInputEnable3";
            checkBoxInputEnable3.Size = new Size(61, 19);
            checkBoxInputEnable3.TabIndex = 2;
            checkBoxInputEnable3.Text = "Enable";
            checkBoxInputEnable3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(comboBoxResistor4);
            groupBox5.Controls.Add(checkBoxInputEnable4);
            groupBox5.Location = new Point(14, 249);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(250, 52);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "Input 5";
            // 
            // comboBoxResistor4
            // 
            comboBoxResistor4.FormattingEnabled = true;
            comboBoxResistor4.Items.AddRange(new object[] { "Pull Down", "Pull Up" });
            comboBoxResistor4.Location = new Point(93, 20);
            comboBoxResistor4.Name = "comboBoxResistor4";
            comboBoxResistor4.Size = new Size(121, 23);
            comboBoxResistor4.TabIndex = 3;
            // 
            // checkBoxInputEnable4
            // 
            checkBoxInputEnable4.AutoSize = true;
            checkBoxInputEnable4.Location = new Point(6, 22);
            checkBoxInputEnable4.Name = "checkBoxInputEnable4";
            checkBoxInputEnable4.Size = new Size(61, 19);
            checkBoxInputEnable4.TabIndex = 2;
            checkBoxInputEnable4.Text = "Enable";
            checkBoxInputEnable4.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(comboBoxResistor5);
            groupBox6.Controls.Add(checkBoxInputEnable5);
            groupBox6.Location = new Point(14, 298);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(250, 52);
            groupBox6.TabIndex = 8;
            groupBox6.TabStop = false;
            groupBox6.Text = "Input 6";
            // 
            // comboBoxResistor5
            // 
            comboBoxResistor5.FormattingEnabled = true;
            comboBoxResistor5.Items.AddRange(new object[] { "Pull Down", "Pull Up" });
            comboBoxResistor5.Location = new Point(93, 20);
            comboBoxResistor5.Name = "comboBoxResistor5";
            comboBoxResistor5.Size = new Size(121, 23);
            comboBoxResistor5.TabIndex = 3;
            // 
            // checkBoxInputEnable5
            // 
            checkBoxInputEnable5.AutoSize = true;
            checkBoxInputEnable5.Location = new Point(6, 22);
            checkBoxInputEnable5.Name = "checkBoxInputEnable5";
            checkBoxInputEnable5.Size = new Size(61, 19);
            checkBoxInputEnable5.TabIndex = 2;
            checkBoxInputEnable5.Text = "Enable";
            checkBoxInputEnable5.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(comboBoxResistor6);
            groupBox7.Controls.Add(checkBoxInputEnable6);
            groupBox7.Location = new Point(14, 347);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(250, 52);
            groupBox7.TabIndex = 9;
            groupBox7.TabStop = false;
            groupBox7.Text = "Input 7";
            // 
            // comboBoxResistor6
            // 
            comboBoxResistor6.FormattingEnabled = true;
            comboBoxResistor6.Items.AddRange(new object[] { "Pull Down", "Pull Up" });
            comboBoxResistor6.Location = new Point(93, 20);
            comboBoxResistor6.Name = "comboBoxResistor6";
            comboBoxResistor6.Size = new Size(121, 23);
            comboBoxResistor6.TabIndex = 3;
            // 
            // checkBoxInputEnable6
            // 
            checkBoxInputEnable6.AutoSize = true;
            checkBoxInputEnable6.Location = new Point(6, 22);
            checkBoxInputEnable6.Name = "checkBoxInputEnable6";
            checkBoxInputEnable6.Size = new Size(61, 19);
            checkBoxInputEnable6.TabIndex = 2;
            checkBoxInputEnable6.Text = "Enable";
            checkBoxInputEnable6.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(comboBoxResistor7);
            groupBox8.Controls.Add(checkBoxInputEnable7);
            groupBox8.Location = new Point(14, 399);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(250, 52);
            groupBox8.TabIndex = 10;
            groupBox8.TabStop = false;
            groupBox8.Text = "Input 8";
            // 
            // comboBoxResistor7
            // 
            comboBoxResistor7.FormattingEnabled = true;
            comboBoxResistor7.Items.AddRange(new object[] { "Pull Down", "Pull Up" });
            comboBoxResistor7.Location = new Point(93, 20);
            comboBoxResistor7.Name = "comboBoxResistor7";
            comboBoxResistor7.Size = new Size(121, 23);
            comboBoxResistor7.TabIndex = 3;
            // 
            // checkBoxInputEnable7
            // 
            checkBoxInputEnable7.AutoSize = true;
            checkBoxInputEnable7.Location = new Point(6, 22);
            checkBoxInputEnable7.Name = "checkBoxInputEnable7";
            checkBoxInputEnable7.Size = new Size(61, 19);
            checkBoxInputEnable7.TabIndex = 2;
            checkBoxInputEnable7.Text = "Enable";
            checkBoxInputEnable7.UseVisualStyleBackColor = true;
            // 
            // textBoxInputConfigRaw
            // 
            textBoxInputConfigRaw.BackColor = SystemColors.ControlLightLight;
            textBoxInputConfigRaw.Location = new Point(6, 18);
            textBoxInputConfigRaw.Margin = new Padding(2, 2, 2, 2);
            textBoxInputConfigRaw.Multiline = true;
            textBoxInputConfigRaw.Name = "textBoxInputConfigRaw";
            textBoxInputConfigRaw.ReadOnly = true;
            textBoxInputConfigRaw.Size = new Size(518, 57);
            textBoxInputConfigRaw.TabIndex = 11;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(textBoxInputConfigRaw);
            groupBox9.Font = new Font("Segoe UI", 8F);
            groupBox9.Location = new Point(14, 469);
            groupBox9.Margin = new Padding(2, 2, 2, 2);
            groupBox9.Name = "groupBox9";
            groupBox9.Padding = new Padding(2, 2, 2, 2);
            groupBox9.Size = new Size(525, 83);
            groupBox9.TabIndex = 12;
            groupBox9.TabStop = false;
            groupBox9.Text = "Input Config Message Data";
            // 
            // labelSent
            // 
            labelSent.AutoSize = true;
            labelSent.BackColor = Color.Transparent;
            labelSent.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelSent.ForeColor = SystemColors.Highlight;
            labelSent.Location = new Point(430, 74);
            labelSent.Margin = new Padding(2, 0, 2, 0);
            labelSent.Name = "labelSent";
            labelSent.Size = new Size(111, 19);
            labelSent.TabIndex = 13;
            labelSent.Text = "Command Sent";
            labelSent.TextAlign = ContentAlignment.MiddleRight;
            // 
            // InputConfiigView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelSent);
            Controls.Add(groupBox9);
            Controls.Add(groupBox8);
            Controls.Add(groupBox7);
            Controls.Add(groupBox3);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnInputConfigSend);
            Controls.Add(comboBoxInputPort);
            Name = "InputConfiigView";
            Size = new Size(560, 552);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxInputPort;
        private Button btnInputConfigSend;
        private CheckBox checkBoxInputEnable0;
        private GroupBox groupBox1;
        private ComboBox comboBoxResistor0;
        private GroupBox groupBox2;
        private ComboBox comboBoxResistor1;
        private CheckBox checkBoxInputEnable1;
        private GroupBox groupBox3;
        private ComboBox comboBoxResistor2;
        private CheckBox checkBoxInputEnable2;
        private GroupBox groupBox4;
        private ComboBox comboBoxResistor3;
        private CheckBox checkBoxInputEnable3;
        private GroupBox groupBox5;
        private ComboBox comboBoxResistor4;
        private CheckBox checkBoxInputEnable4;
        private GroupBox groupBox6;
        private ComboBox comboBoxResistor5;
        private CheckBox checkBoxInputEnable5;
        private GroupBox groupBox7;
        private ComboBox comboBoxResistor6;
        private CheckBox checkBoxInputEnable6;
        private GroupBox groupBox8;
        private ComboBox comboBoxResistor7;
        private CheckBox checkBoxInputEnable7;
        private TextBox textBoxInputConfigRaw;
        private GroupBox groupBox9;
        private Label labelSent;
    }
}
