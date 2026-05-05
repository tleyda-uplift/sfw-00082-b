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
            outputCommandView = new OutputCommandView();
            tabPageInputConfig = new TabPage();
            inputConfiigView = new InputConfiigView();
            tabsStatusCommand.SuspendLayout();
            tabPageCommand.SuspendLayout();
            tabPageInputConfig.SuspendLayout();
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
            // tabsStatusCommand
            // 
            tabsStatusCommand.Controls.Add(tabPageStatus);
            tabsStatusCommand.Controls.Add(tabPageCommand);
            tabsStatusCommand.Controls.Add(tabPageInputConfig);
            tabsStatusCommand.Location = new Point(10, 50);
            tabsStatusCommand.Name = "tabsStatusCommand";
            tabsStatusCommand.SelectedIndex = 0;
            tabsStatusCommand.Size = new Size(581, 573);
            tabsStatusCommand.TabIndex = 6;
            // 
            // tabPageStatus
            // 
            tabPageStatus.Location = new Point(4, 24);
            tabPageStatus.Name = "tabPageStatus";
            tabPageStatus.Padding = new Padding(3);
            tabPageStatus.Size = new Size(573, 545);
            tabPageStatus.TabIndex = 0;
            tabPageStatus.Text = "Status";
            tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // tabPageCommand
            // 
            tabPageCommand.Controls.Add(outputCommandView);
            tabPageCommand.Location = new Point(4, 24);
            tabPageCommand.Name = "tabPageCommand";
            tabPageCommand.Padding = new Padding(3);
            tabPageCommand.Size = new Size(573, 545);
            tabPageCommand.TabIndex = 1;
            tabPageCommand.Text = "Outputs Command";
            tabPageCommand.UseVisualStyleBackColor = true;
            // 
            // outputCommandView
            // 
            outputCommandView.Location = new Point(7, 3);
            outputCommandView.Name = "outputCommandView";
            outputCommandView.Size = new Size(560, 540);
            outputCommandView.TabIndex = 0;
            // 
            // tabPageInputConfig
            // 
            tabPageInputConfig.Controls.Add(inputConfiigView);
            tabPageInputConfig.Location = new Point(4, 24);
            tabPageInputConfig.Name = "tabPageInputConfig";
            tabPageInputConfig.Padding = new Padding(3);
            tabPageInputConfig.Size = new Size(573, 545);
            tabPageInputConfig.TabIndex = 2;
            tabPageInputConfig.Text = "Input Config";
            tabPageInputConfig.UseVisualStyleBackColor = true;
            // 
            // inputConfiigView
            // 
            inputConfiigView.Location = new Point(9, 7);
            inputConfiigView.Name = "inputConfiigView";
            inputConfiigView.Size = new Size(455, 532);
            inputConfiigView.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(603, 666);
            Controls.Add(tabsStatusCommand);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(textBoxProductId);
            Controls.Add(label2);
            Controls.Add(texboxVendorId);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "HID Test App";
            tabsStatusCommand.ResumeLayout(false);
            tabPageCommand.ResumeLayout(false);
            tabPageInputConfig.ResumeLayout(false);
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
    }
}
