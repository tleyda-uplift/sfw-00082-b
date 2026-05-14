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
            tabControlApp = new TabControl();
            tabPageLedTest = new TabPage();
            ledTestView = new LedTestView();
            tabPageCommand = new TabPage();
            outputCommandView = new OutputCommandView();
            tabPageInputConfig = new TabPage();
            inputConfiigView = new InputConfiigView();
            tabPageStatus = new TabPage();
            statusView = new StatusView();
            tabControlApp.SuspendLayout();
            tabPageLedTest.SuspendLayout();
            tabPageCommand.SuspendLayout();
            tabPageInputConfig.SuspendLayout();
            tabPageStatus.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(234, 32);
            label1.Name = "label1";
            label1.Size = new Size(33, 20);
            label1.TabIndex = 0;
            label1.Text = "VID";
            // 
            // texboxVendorId
            // 
            texboxVendorId.Location = new Point(277, 28);
            texboxVendorId.Margin = new Padding(3, 4, 3, 4);
            texboxVendorId.Name = "texboxVendorId";
            texboxVendorId.Size = new Size(61, 27);
            texboxVendorId.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(357, 32);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 2;
            label2.Text = "PID";
            // 
            // textBoxProductId
            // 
            textBoxProductId.Location = new Point(392, 28);
            textBoxProductId.Margin = new Padding(3, 4, 3, 4);
            textBoxProductId.Name = "textBoxProductId";
            textBoxProductId.Size = new Size(67, 27);
            textBoxProductId.TabIndex = 3;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(478, 11);
            btnConnect.Margin = new Padding(3, 4, 3, 4);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(86, 47);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(570, 11);
            btnDisconnect.Margin = new Padding(3, 4, 3, 4);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(101, 47);
            btnDisconnect.TabIndex = 5;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // tabControlApp
            // 
            tabControlApp.Controls.Add(tabPageLedTest);
            tabControlApp.Controls.Add(tabPageCommand);
            tabControlApp.Controls.Add(tabPageInputConfig);
            tabControlApp.Controls.Add(tabPageStatus);
            tabControlApp.Location = new Point(11, 66);
            tabControlApp.Margin = new Padding(3, 4, 3, 4);
            tabControlApp.Name = "tabControlApp";
            tabControlApp.Padding = new Point(16, 16);
            tabControlApp.SelectedIndex = 0;
            tabControlApp.Size = new Size(664, 806);
            tabControlApp.TabIndex = 6;
            // 
            // tabPageLedTest
            // 
            tabPageLedTest.BackColor = SystemColors.Control;
            tabPageLedTest.Controls.Add(ledTestView);
            tabPageLedTest.Location = new Point(4, 55);
            tabPageLedTest.Margin = new Padding(2, 2, 2, 2);
            tabPageLedTest.Name = "tabPageLedTest";
            tabPageLedTest.Padding = new Padding(2, 2, 2, 2);
            tabPageLedTest.Size = new Size(656, 747);
            tabPageLedTest.TabIndex = 3;
            tabPageLedTest.Text = "LED Test";
            // 
            // ledTestView
            // 
            ledTestView.Location = new Point(13, 10);
            ledTestView.Margin = new Padding(1, 2, 1, 2);
            ledTestView.Name = "ledTestView";
            ledTestView.Size = new Size(640, 718);
            ledTestView.TabIndex = 0;
            // 
            // tabPageCommand
            // 
            tabPageCommand.BackColor = SystemColors.Control;
            tabPageCommand.Controls.Add(outputCommandView);
            tabPageCommand.Location = new Point(4, 55);
            tabPageCommand.Margin = new Padding(3, 4, 3, 4);
            tabPageCommand.Name = "tabPageCommand";
            tabPageCommand.Padding = new Padding(3, 4, 3, 4);
            tabPageCommand.Size = new Size(656, 747);
            tabPageCommand.TabIndex = 1;
            tabPageCommand.Text = "Outputs Command";
            // 
            // outputCommandView
            // 
            outputCommandView.BackColor = Color.Transparent;
            outputCommandView.Location = new Point(8, 4);
            outputCommandView.Margin = new Padding(5, 6, 5, 6);
            outputCommandView.Name = "outputCommandView";
            outputCommandView.Size = new Size(640, 720);
            outputCommandView.TabIndex = 0;
            // 
            // tabPageInputConfig
            // 
            tabPageInputConfig.BackColor = SystemColors.Control;
            tabPageInputConfig.Controls.Add(inputConfiigView);
            tabPageInputConfig.Location = new Point(4, 55);
            tabPageInputConfig.Margin = new Padding(3, 4, 3, 4);
            tabPageInputConfig.Name = "tabPageInputConfig";
            tabPageInputConfig.Padding = new Padding(3, 4, 3, 4);
            tabPageInputConfig.Size = new Size(656, 747);
            tabPageInputConfig.TabIndex = 2;
            tabPageInputConfig.Text = "Input Config";
            // 
            // inputConfiigView
            // 
            inputConfiigView.Location = new Point(8, 4);
            inputConfiigView.Margin = new Padding(5, 6, 5, 6);
            inputConfiigView.Name = "inputConfiigView";
            inputConfiigView.Size = new Size(639, 734);
            inputConfiigView.TabIndex = 0;
            // 
            // tabPageStatus
            // 
            tabPageStatus.BackColor = SystemColors.Control;
            tabPageStatus.Controls.Add(statusView);
            tabPageStatus.Location = new Point(4, 55);
            tabPageStatus.Margin = new Padding(3, 4, 3, 4);
            tabPageStatus.Name = "tabPageStatus";
            tabPageStatus.Padding = new Padding(3, 4, 3, 4);
            tabPageStatus.Size = new Size(656, 747);
            tabPageStatus.TabIndex = 0;
            tabPageStatus.Text = "Status";
            // 
            // statusView
            // 
            statusView.Location = new Point(14, 14);
            statusView.Margin = new Padding(1, 2, 1, 2);
            statusView.Name = "statusView";
            statusView.Size = new Size(637, 734);
            statusView.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(689, 844);
            Controls.Add(tabControlApp);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(textBoxProductId);
            Controls.Add(label2);
            Controls.Add(texboxVendorId);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "HID Test App";
            tabControlApp.ResumeLayout(false);
            tabPageLedTest.ResumeLayout(false);
            tabPageCommand.ResumeLayout(false);
            tabPageInputConfig.ResumeLayout(false);
            tabPageStatus.ResumeLayout(false);
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
        private TabControl tabControlApp;
        private TabPage tabPageStatus;
        public TabPage tabPageCommand;
        private OutputCommandView outputCommandView;
        private TabPage tabPageInputConfig;
        private InputConfiigView inputConfiigView;
        private StatusView statusView;
        private TabPage tabPageLedTest;
        private LedTestView ledTestView;
    }
}
