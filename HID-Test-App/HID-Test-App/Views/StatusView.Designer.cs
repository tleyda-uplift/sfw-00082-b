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
            textBoxRawStatus = new TextBox();
            listBoxInputStatus1 = new ListBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            listBoxInputStatus2 = new ListBox();
            groupBox3 = new GroupBox();
            listBoxInputStatus3 = new ListBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxRawStatus
            // 
            textBoxRawStatus.Location = new Point(18, 412);
            textBoxRawStatus.Multiline = true;
            textBoxRawStatus.Name = "textBoxRawStatus";
            textBoxRawStatus.Size = new Size(512, 62);
            textBoxRawStatus.TabIndex = 1;
            // 
            // listBoxInputStatus1
            // 
            listBoxInputStatus1.Font = new Font("Segoe UI", 12F);
            listBoxInputStatus1.FormattingEnabled = true;
            listBoxInputStatus1.Location = new Point(6, 22);
            listBoxInputStatus1.Name = "listBoxInputStatus1";
            listBoxInputStatus1.SelectionMode = SelectionMode.None;
            listBoxInputStatus1.Size = new Size(160, 172);
            listBoxInputStatus1.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBoxInputStatus1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(172, 204);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Port 1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listBoxInputStatus2);
            groupBox2.Location = new Point(188, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(172, 204);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Port 2";
            // 
            // listBoxInputStatus2
            // 
            listBoxInputStatus2.Font = new Font("Segoe UI", 12F);
            listBoxInputStatus2.FormattingEnabled = true;
            listBoxInputStatus2.Location = new Point(6, 22);
            listBoxInputStatus2.Name = "listBoxInputStatus2";
            listBoxInputStatus2.SelectionMode = SelectionMode.None;
            listBoxInputStatus2.Size = new Size(160, 172);
            listBoxInputStatus2.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(listBoxInputStatus3);
            groupBox3.Location = new Point(364, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(172, 204);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Port 3";
            // 
            // listBoxInputStatus3
            // 
            listBoxInputStatus3.Font = new Font("Segoe UI", 12F);
            listBoxInputStatus3.FormattingEnabled = true;
            listBoxInputStatus3.Location = new Point(6, 22);
            listBoxInputStatus3.Name = "listBoxInputStatus3";
            listBoxInputStatus3.SelectionMode = SelectionMode.None;
            listBoxInputStatus3.Size = new Size(160, 172);
            listBoxInputStatus3.TabIndex = 2;
            // 
            // StatusView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(textBoxRawStatus);
            Margin = new Padding(2);
            Name = "StatusView";
            Size = new Size(570, 515);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxRawStatus;
        private ListBox listBoxInputStatus1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ListBox listBoxInputStatus2;
        private GroupBox groupBox3;
        private ListBox listBoxInputStatus3;
    }
}
