namespace HID_Test_App.Views
{
    partial class StatusView
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
            btnRequestStatus = new Button();
            textBoxRawStatus = new TextBox();
            SuspendLayout();
            // 
            // btnRequestStatus
            // 
            btnRequestStatus.Location = new Point(15, 28);
            btnRequestStatus.Margin = new Padding(2);
            btnRequestStatus.Name = "btnRequestStatus";
            btnRequestStatus.Size = new Size(110, 51);
            btnRequestStatus.TabIndex = 0;
            btnRequestStatus.Text = "Request";
            btnRequestStatus.UseVisualStyleBackColor = true;
            btnRequestStatus.Click += btnRequestStatus_Click;
            // 
            // textBoxRawStatus
            // 
            textBoxRawStatus.Location = new Point(143, 17);
            textBoxRawStatus.Multiline = true;
            textBoxRawStatus.Name = "textBoxRawStatus";
            textBoxRawStatus.Size = new Size(278, 62);
            textBoxRawStatus.TabIndex = 1;
            // 
            // StatusView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBoxRawStatus);
            Controls.Add(btnRequestStatus);
            Margin = new Padding(2);
            Name = "StatusView";
            Size = new Size(483, 393);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRequestStatus;
        private TextBox textBoxRawStatus;
    }
}
