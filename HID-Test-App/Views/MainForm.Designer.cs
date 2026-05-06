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
            tabPageLedTest = new TabPage();
            ledTestView = new LedTestView();
            tabPageCommand = new TabPage();
            outputCommandView = new OutputCommandView();
            tabPageInputConfig = new TabPage();
            inputConfiigView = new InputConfiigView();
            tabPageStatus = new TabPage();
            statusView = new StatusView();
            tabsStatusCommand.SuspendLayout();
            tabPageLedTest.SuspendLayout();
            tabPageCommand.SuspendLayout();
            tabPageInputConfig.SuspendLayout();
            tabPageStatus.SuspendLayout();
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
            tabsStatusCommand.Controls.Add(tabPageLedTest);
            tabsStatusCommand.Controls.Add(tabPageCommand);
            tabsStatusCommand.Controls.Add(tabPageInputConfig);
            tabsStatusCommand.Controls.Add(tabPageStatus);
            tabsStatusCommand.Location = new Point(14, 83);
            tabsStatusCommand.Margin = new Padding(4, 5, 4, 5);
            tabsStatusCommand.Name = "tabsStatusCommand";
            tabsStatusCommand.Padding = new Point(16, 16);
            tabsStatusCommand.SelectedIndex = 0;
            tabsStatusCommand.Size = new Size(830, 955);
            tabsStatusCommand.TabIndex = 6;
            // 
            // tabPageLedTest
            // 
            tabPageLedTest.Controls.Add(ledTestView);
            tabPageLedTest.Location = new Point(4, 60);
            tabPageLedTest.Name = "tabPageLedTest";
            tabPageLedTest.Padding = new Padding(3);
            tabPageLedTest.Size = new Size(822, 891);
            tabPageLedTest.TabIndex = 3;
            tabPageLedTest.Text = "LED Test";
            tabPageLedTest.UseVisualStyleBackColor = true;
            // 
            // ledTestView
            // 
            ledTestView.Location = new Point(16, 12);
            ledTestView.Name = "ledTestView";
            ledTestView.Size = new Size(800, 899);
            ledTestView.TabIndex = 0;
            // 
            // tabPageCommand
            // 
            tabPageCommand.Controls.Add(outputCommandView);
            tabPageCommand.Location = new Point(4, 60);
            tabPageCommand.Margin = new Padding(4, 5, 4, 5);
            tabPageCommand.Name = "tabPageCommand";
            tabPageCommand.Padding = new Padding(4, 5, 4, 5);
            tabPageCommand.Size = new Size(822, 891);
            tabPageCommand.TabIndex = 1;
            tabPageCommand.Text = "Outputs Command";
            tabPageCommand.UseVisualStyleBackColor = true;
            // 
            // outputCommandView
            // 
            outputCommandView.Location = new Point(10, 5);
            outputCommandView.Margin = new Padding(6, 8, 6, 8);
            outputCommandView.Name = "outputCommandView";
            outputCommandView.Size = new Size(800, 900);
            outputCommandView.TabIndex = 0;
            // 
            // tabPageInputConfig
            // 
            tabPageInputConfig.Controls.Add(inputConfiigView);
            tabPageInputConfig.Location = new Point(4, 60);
            tabPageInputConfig.Margin = new Padding(4, 5, 4, 5);
            tabPageInputConfig.Name = "tabPageInputConfig";
            tabPageInputConfig.Padding = new Padding(4, 5, 4, 5);
            tabPageInputConfig.Size = new Size(822, 891);
            tabPageInputConfig.TabIndex = 2;
            tabPageInputConfig.Text = "Input Config";
            tabPageInputConfig.UseVisualStyleBackColor = true;
            // 
            // inputConfiigView
            // 
            inputConfiigView.Location = new Point(13, 12);
            inputConfiigView.Margin = new Padding(6, 8, 6, 8);
            inputConfiigView.Name = "inputConfiigView";
            inputConfiigView.Size = new Size(650, 887);
            inputConfiigView.TabIndex = 0;
            // 
            // tabPageStatus
            // 
            tabPageStatus.Controls.Add(statusView);
            tabPageStatus.Location = new Point(4, 60);
            tabPageStatus.Margin = new Padding(4, 5, 4, 5);
            tabPageStatus.Name = "tabPageStatus";
            tabPageStatus.Padding = new Padding(4, 5, 4, 5);
            tabPageStatus.Size = new Size(822, 891);
            tabPageStatus.TabIndex = 0;
            tabPageStatus.Text = "Status";
            tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // statusView
            // 
            statusView.Location = new Point(17, 18);
            statusView.Name = "statusView";
            statusView.Size = new Size(705, 800);
            statusView.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(861, 1110);
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
        private TabControl tabsStatusCommand;
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
