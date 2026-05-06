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
            labelStatus = new Label();
            panelLedDisplay1 = new Panel();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            panelLedDisplay2 = new Panel();
            groupBox3 = new GroupBox();
            panelLedDisplay3 = new Panel();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // btnLedTestStart
            // 
            btnLedTestStart.Location = new Point(18, 30);
            btnLedTestStart.Name = "btnLedTestStart";
            btnLedTestStart.Size = new Size(130, 77);
            btnLedTestStart.TabIndex = 0;
            btnLedTestStart.Text = "Start Test";
            btnLedTestStart.UseVisualStyleBackColor = true;
            btnLedTestStart.Click += btnLedTestStart_Click;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelStatus.Location = new Point(88, 335);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(47, 25);
            labelStatus.TabIndex = 1;
            labelStatus.Text = "N/A";
            // 
            // panelLedDisplay1
            // 
            panelLedDisplay1.BackColor = Color.Gray;
            panelLedDisplay1.Location = new Point(33, 54);
            panelLedDisplay1.Name = "panelLedDisplay1";
            panelLedDisplay1.Size = new Size(47, 46);
            panelLedDisplay1.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panelLedDisplay1);
            groupBox1.Location = new Point(18, 138);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(130, 150);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "LED 1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panelLedDisplay2);
            groupBox2.Location = new Point(186, 138);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(130, 150);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "LED 2";
            // 
            // panelLedDisplay2
            // 
            panelLedDisplay2.BackColor = Color.Gray;
            panelLedDisplay2.Location = new Point(33, 54);
            panelLedDisplay2.Name = "panelLedDisplay2";
            panelLedDisplay2.Size = new Size(47, 46);
            panelLedDisplay2.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(panelLedDisplay3);
            groupBox3.Location = new Point(357, 138);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(130, 150);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "LED 3";
            // 
            // panelLedDisplay3
            // 
            panelLedDisplay3.BackColor = Color.Gray;
            panelLedDisplay3.Location = new Point(33, 54);
            panelLedDisplay3.Name = "panelLedDisplay3";
            panelLedDisplay3.Size = new Size(47, 46);
            panelLedDisplay3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 335);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 6;
            label1.Text = "Status:";
            // 
            // LedTestView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(labelStatus);
            Controls.Add(btnLedTestStart);
            Name = "LedTestView";
            Size = new Size(638, 731);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLedTestStart;
        private Label labelStatus;
        private Panel panelLedDisplay1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Panel panelLedDisplay2;
        private GroupBox groupBox3;
        private Panel panelLedDisplay3;
        private Label label1;
    }
}
