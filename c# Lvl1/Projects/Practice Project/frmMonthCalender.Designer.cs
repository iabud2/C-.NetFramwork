namespace Project1
{
    partial class frmMonthCalender
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnPeriodEnd = new System.Windows.Forms.Button();
            this.btnPeriodStart = new System.Windows.Forms.Button();
            this.btnPeriod = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(119, 47);
            this.monthCalendar1.MaxSelectionCount = 31;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // btnPeriodEnd
            // 
            this.btnPeriodEnd.Location = new System.Drawing.Point(239, 221);
            this.btnPeriodEnd.Name = "btnPeriodEnd";
            this.btnPeriodEnd.Size = new System.Drawing.Size(107, 47);
            this.btnPeriodEnd.TabIndex = 1;
            this.btnPeriodEnd.Text = "Show Period End";
            this.btnPeriodEnd.UseVisualStyleBackColor = true;
            this.btnPeriodEnd.Click += new System.EventHandler(this.btnPeriodEnd_Click);
            // 
            // btnPeriodStart
            // 
            this.btnPeriodStart.Location = new System.Drawing.Point(119, 221);
            this.btnPeriodStart.Name = "btnPeriodStart";
            this.btnPeriodStart.Size = new System.Drawing.Size(107, 47);
            this.btnPeriodStart.TabIndex = 2;
            this.btnPeriodStart.Text = "Show Period Start";
            this.btnPeriodStart.UseVisualStyleBackColor = true;
            this.btnPeriodStart.Click += new System.EventHandler(this.btnPeriodStart_Click);
            // 
            // btnPeriod
            // 
            this.btnPeriod.Location = new System.Drawing.Point(181, 274);
            this.btnPeriod.Name = "btnPeriod";
            this.btnPeriod.Size = new System.Drawing.Size(107, 47);
            this.btnPeriod.TabIndex = 3;
            this.btnPeriod.Text = "Show The Period";
            this.btnPeriod.UseVisualStyleBackColor = true;
            this.btnPeriod.Click += new System.EventHandler(this.btnPeriod_Click);
            // 
            // frmMonthCalender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 332);
            this.Controls.Add(this.btnPeriod);
            this.Controls.Add(this.btnPeriodStart);
            this.Controls.Add(this.btnPeriodEnd);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "frmMonthCalender";
            this.Text = "frmMonthCalender";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnPeriodEnd;
        private System.Windows.Forms.Button btnPeriodStart;
        private System.Windows.Forms.Button btnPeriod;
    }
}