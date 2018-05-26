namespace xiannvguo
{
    partial class altercheck
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
            this.stockOrOrder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selfMotion = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stockOrOrder
            // 
            this.stockOrOrder.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stockOrOrder.Location = new System.Drawing.Point(55, 54);
            this.stockOrOrder.Name = "stockOrOrder";
            this.stockOrOrder.Size = new System.Drawing.Size(205, 27);
            this.stockOrOrder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "备货检验";
            // 
            // selfMotion
            // 
            this.selfMotion.AutoSize = true;
            this.selfMotion.Location = new System.Drawing.Point(288, 61);
            this.selfMotion.Name = "selfMotion";
            this.selfMotion.Size = new System.Drawing.Size(48, 16);
            this.selfMotion.TabIndex = 2;
            this.selfMotion.Text = "自动";
            this.selfMotion.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // altercheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 156);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selfMotion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stockOrOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "altercheck";
            this.Load += new System.EventHandler(this.altercheck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox stockOrOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox selfMotion;
        private System.Windows.Forms.Button button1;
    }
}