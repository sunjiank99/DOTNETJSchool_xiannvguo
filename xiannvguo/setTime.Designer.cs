namespace xiannvguo
{
    partial class setTime
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.starYear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.starMonth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.starDay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.endYear = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.endMonth = new System.Windows.Forms.TextBox();
            this.endDay = new System.Windows.Forms.TextBox();
            this.timeEnsure = new System.Windows.Forms.Button();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // starYear
            // 
            this.starYear.Location = new System.Drawing.Point(44, 36);
            this.starYear.Name = "starYear";
            this.starYear.Size = new System.Drawing.Size(43, 21);
            this.starYear.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "年";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // starMonth
            // 
            this.starMonth.Location = new System.Drawing.Point(117, 35);
            this.starMonth.Name = "starMonth";
            this.starMonth.Size = new System.Drawing.Size(35, 21);
            this.starMonth.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "月";
            // 
            // starDay
            // 
            this.starDay.Location = new System.Drawing.Point(181, 36);
            this.starDay.Name = "starDay";
            this.starDay.Size = new System.Drawing.Size(34, 21);
            this.starDay.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "日";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "开始时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "结束时间";
            // 
            // endYear
            // 
            this.endYear.Location = new System.Drawing.Point(46, 102);
            this.endYear.Name = "endYear";
            this.endYear.Size = new System.Drawing.Size(41, 21);
            this.endYear.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "年";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(158, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "月";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(223, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "日";
            // 
            // endMonth
            // 
            this.endMonth.Location = new System.Drawing.Point(117, 102);
            this.endMonth.Name = "endMonth";
            this.endMonth.Size = new System.Drawing.Size(35, 21);
            this.endMonth.TabIndex = 12;
            // 
            // endDay
            // 
            this.endDay.Location = new System.Drawing.Point(182, 102);
            this.endDay.Name = "endDay";
            this.endDay.Size = new System.Drawing.Size(35, 21);
            this.endDay.TabIndex = 12;
            // 
            // timeEnsure
            // 
            this.timeEnsure.Location = new System.Drawing.Point(267, 44);
            this.timeEnsure.Name = "timeEnsure";
            this.timeEnsure.Size = new System.Drawing.Size(75, 58);
            this.timeEnsure.TabIndex = 13;
            this.timeEnsure.Text = "确定";
            this.timeEnsure.UseVisualStyleBackColor = true;
            this.timeEnsure.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeStart.Location = new System.Drawing.Point(44, 138);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(200, 21);
            this.dateTimeStart.TabIndex = 14;
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(44, 180);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(200, 21);
            this.dateTimeEnd.TabIndex = 15;
            // 
            // setTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 233);
            this.Controls.Add(this.dateTimeEnd);
            this.Controls.Add(this.dateTimeStart);
            this.Controls.Add(this.timeEnsure);
            this.Controls.Add(this.endDay);
            this.Controls.Add(this.endMonth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.endYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.starDay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.starMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.starYear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "setTime";
            this.Load += new System.EventHandler(this.setTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox starYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox starMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox starDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox endYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox endMonth;
        private System.Windows.Forms.TextBox endDay;
        private System.Windows.Forms.Button timeEnsure;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
    }
}