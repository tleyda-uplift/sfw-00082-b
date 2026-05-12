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
            label1.Location = new Point(205, 24);
            label1.Name = "label1";
            label1.Size = new Size(25, 15);
            label1.TabIndex = 0;
            label1.Text = "VID";
            // 
            // texboxVendorId
            // 
            texboxVendorId.Location = new Point(242, 21);
            texboxVendorId.Name = "texboxVendorId";
            texboxVendorId.Size = new Size(54, 23);
            texboxVendorId.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(312, 24);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 2;
            label2.Text = "PID";
            // 
            // textBoxProductId
            // 
            textBoxProductId.Location = new Point(343, 21);
            textBoxProductId.Name = "textBoxProductId";
            textBoxProductId.Size = new Size(59, 23);
            textBoxProductId.TabIndex = 3;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(431, 21);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(512, 21);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(75, 23);
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
            tabControlApp.Location = new Point(10, 50);
            tabControlApp.Name = "tabControlApp";
            tabControlApp.Padding = new Point(16, 16);
            tabControlApp.SelectedIndex = 0;
            tabControlApp.Size = new Size(581, 604);
            tabControlApp.TabIndex = 6;
            // 
            // tabPageLedTest
            // 
            tabPageLedTest.Controls.Add(ledTestView);
            tabPageLedTest.Location = new Point(4, 50);
            tabPageLedTest.Margin = new Padding(2);
            tabPageLedTest.Name = "tabPageLedTest";
            tabPageLedTest.Padding = new Padding(2);
            tabPageLedTest.Size = new Size(573, 550);
            tabPageLedTest.TabIndex = 3;
            tabPageLedTest.Text = "LED Test";
            tabPageLedTest.UseVisualStyleBackColor = true;
            // 
            // ledTestView
            // 
            ledTestView.Location = new Point(11, 7);
            ledTestView.Margin = new Padding(1);
            ledTestView.Name = "ledTestView";
            ledTestView.Size = new Size(560, 539);
            ledTestView.TabIndex = 0;
            // 
            // tabPageCommand
            // 
            tabPageCommand.Controls.Add(outputCommandView);
            tabPageCommand.Location = new Point(4, 50);
            tabPageCommand.Name = "tabPageCommand";
            tabPageCommand.Padding = new Padding(3);
            tabPageCommand.Size = new Size(573, 550);
            tabPageCommand.TabIndex = 1;
            tabPageCommand.Text = "Outputs Command";
            tabPageCommand.UseVisualStyleBackColor = true;
            // 
            // outputCommandView
            // 
            outputCommandView.Location = new Point(7, 3);
            outputCommandView.Margin = new Padding(4, 5, 4, 5);
            outputCommandView.Name = "outputCommandView";
            outputCommandView.Size = new Size(560, 540);
            outputCommandView.TabIndex = 0;
            // 
            // tabPageInputConfig
            // 
            tabPageInputConfig.Controls.Add(inputConfiigView);
            tabPageInputConfig.Location = new Point(4, 50);
            tabPageInputConfig.Name = "tabPageInputConfig";
            tabPageInputConfig.Padding = new Padding(3);
            tabPageInputConfig.Size = new Size(573, 550);
            tabPageInputConfig.TabIndex = 2;
            tabPageInputConfig.Text = "Input Config";
            tabPageInputConfig.UseVisualStyleBackColor = true;
            // 
            // inputConfiigView
            // 
            inputConfiigView.Location = new Point(9, 7);
            inputConfiigView.Margin = new Padding(4, 5, 4, 5);
            inputConfiigView.Name = "inputConfiigView";
            inputConfiigView.Size = new Size(455, 532);
            inputConfiigView.TabIndex = 0;
            // 
            // tabPageStatus
            // 
            tabPageStatus.Controls.Add(statusView);
            tabPageStatus.Location = new Point(4, 50);
            tabPageStatus.Name = "tabPageStatus";
            tabPageStatus.Padding = new Padding(3);
            tabPageStatus.Size = new Size(573, 550);
            tabPageStatus.TabIndex = 0;
            tabPageStatus.Text = "Status";
            tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // statusView
            // 
            statusView.Location = new Point(12, 11);
            statusView.Margin = new Padding(1);
            statusView.Name = "statusView";
            statusView.Size = new Size(557, 480);
            statusView.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(603, 666);
            Controls.Add(tabControlApp);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(textBoxProductId);
            Controls.Add(label2);
            Controls.Add(texboxVendorId);
            Controls.Add(label1);
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
