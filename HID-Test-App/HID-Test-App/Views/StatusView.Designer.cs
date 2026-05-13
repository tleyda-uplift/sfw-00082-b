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
            groupBox4 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxRawStatus
            // 
            textBoxRawStatus.Location = new Point(7, 32);
            textBoxRawStatus.Margin = new Padding(4, 5, 4, 5);
            textBoxRawStatus.Multiline = true;
            textBoxRawStatus.Name = "textBoxRawStatus";
            textBoxRawStatus.Size = new Size(726, 101);
            textBoxRawStatus.TabIndex = 1;
            // 
            // listBoxInputStatus1
            // 
            listBoxInputStatus1.Font = new Font("Segoe UI", 12F);
            listBoxInputStatus1.FormattingEnabled = true;
            listBoxInputStatus1.Location = new Point(9, 37);
            listBoxInputStatus1.Margin = new Padding(4, 5, 4, 5);
            listBoxInputStatus1.Name = "listBoxInputStatus1";
            listBoxInputStatus1.SelectionMode = SelectionMode.None;
            listBoxInputStatus1.Size = new Size(227, 260);
            listBoxInputStatus1.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBoxInputStatus1);
            groupBox1.Location = new Point(17, 20);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(246, 340);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Port 1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listBoxInputStatus2);
            groupBox2.Location = new Point(269, 20);
            groupBox2.Margin = new Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 5, 4, 5);
            groupBox2.Size = new Size(246, 340);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Port 2";
            // 
            // listBoxInputStatus2
            // 
            listBoxInputStatus2.Font = new Font("Segoe UI", 12F);
            listBoxInputStatus2.FormattingEnabled = true;
            listBoxInputStatus2.Location = new Point(9, 37);
            listBoxInputStatus2.Margin = new Padding(4, 5, 4, 5);
            listBoxInputStatus2.Name = "listBoxInputStatus2";
            listBoxInputStatus2.SelectionMode = SelectionMode.None;
            listBoxInputStatus2.Size = new Size(227, 260);
            listBoxInputStatus2.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(listBoxInputStatus3);
            groupBox3.Location = new Point(520, 20);
            groupBox3.Margin = new Padding(4, 5, 4, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 5, 4, 5);
            groupBox3.Size = new Size(246, 340);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Port 3";
            // 
            // listBoxInputStatus3
            // 
            listBoxInputStatus3.Font = new Font("Segoe UI", 12F);
            listBoxInputStatus3.FormattingEnabled = true;
            listBoxInputStatus3.Location = new Point(9, 37);
            listBoxInputStatus3.Margin = new Padding(4, 5, 4, 5);
            listBoxInputStatus3.Name = "listBoxInputStatus3";
            listBoxInputStatus3.SelectionMode = SelectionMode.None;
            listBoxInputStatus3.Size = new Size(227, 260);
            listBoxInputStatus3.TabIndex = 2;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBoxRawStatus);
            groupBox4.Location = new Point(26, 748);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(740, 141);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "Status Message Data";
            // 
            // StatusView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "StatusView";
            Size = new Size(800, 920);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox textBoxRawStatus;
        private ListBox listBoxInputStatus1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ListBox listBoxInputStatus2;
        private GroupBox groupBox3;
        private ListBox listBoxInputStatus3;
        private GroupBox groupBox4;
    }
}
