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
            SuspendLayout();
            // 
            // btnRequestStatus
            // 
            btnRequestStatus.Location = new Point(23, 28);
            btnRequestStatus.Name = "btnRequestStatus";
            btnRequestStatus.Size = new Size(157, 85);
            btnRequestStatus.TabIndex = 0;
            btnRequestStatus.Text = "Request";
            btnRequestStatus.UseVisualStyleBackColor = true;
            btnRequestStatus.Click += btnRequestStatus_Click;
            // 
            // StatusView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRequestStatus);
            Name = "StatusView";
            Size = new Size(612, 655);
            ResumeLayout(false);
        }

        #endregion

        private Button btnRequestStatus;
    }
}
