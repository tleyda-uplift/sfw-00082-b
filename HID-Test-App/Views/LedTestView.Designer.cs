namespace HID_Test_App.Views
{
    partial class LedTestView
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
            btnLedTestStart = new Button();
            labelTemp = new Label();
            SuspendLayout();
            // 
            // btnLedTestStart
            // 
            btnLedTestStart.Location = new Point(18, 20);
            btnLedTestStart.Name = "btnLedTestStart";
            btnLedTestStart.Size = new Size(112, 77);
            btnLedTestStart.TabIndex = 0;
            btnLedTestStart.Text = "Start";
            btnLedTestStart.UseVisualStyleBackColor = true;
            btnLedTestStart.Click += btnLedTestStart_Click;
            // 
            // labelTemp
            // 
            labelTemp.AutoSize = true;
            labelTemp.Location = new Point(18, 125);
            labelTemp.Name = "labelTemp";
            labelTemp.Size = new Size(44, 25);
            labelTemp.TabIndex = 1;
            labelTemp.Text = "N/A";
            // 
            // LedTestView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelTemp);
            Controls.Add(btnLedTestStart);
            Name = "LedTestView";
            Size = new Size(638, 731);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLedTestStart;
        private Label labelTemp;
    }
}
