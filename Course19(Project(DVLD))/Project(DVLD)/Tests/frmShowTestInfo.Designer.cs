namespace Project_DVLD_.Tests
{
    partial class frmShowTestInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowTestInfo));
            this.ucAppointmentInfo1 = new Project_DVLD_.Controls.ucAppointmentInfo();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbResult = new System.Windows.Forms.Label();
            this.lbTitle2 = new System.Windows.Forms.Label();
            this.lbNotes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucAppointmentInfo1
            // 
            this.ucAppointmentInfo1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucAppointmentInfo1.Location = new System.Drawing.Point(12, 12);
            this.ucAppointmentInfo1.Name = "ucAppointmentInfo1";
            this.ucAppointmentInfo1.Size = new System.Drawing.Size(495, 534);
            this.ucAppointmentInfo1.TabIndex = 20;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lbTitle.Location = new System.Drawing.Point(12, 568);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(86, 25);
            this.lbTitle.TabIndex = 21;
            this.lbTitle.Text = "Result:";
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResult.Location = new System.Drawing.Point(104, 574);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(41, 19);
            this.lbResult.TabIndex = 22;
            this.lbResult.Text = "????";
            // 
            // lbTitle2
            // 
            this.lbTitle2.AutoSize = true;
            this.lbTitle2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle2.ForeColor = System.Drawing.Color.Maroon;
            this.lbTitle2.Location = new System.Drawing.Point(12, 606);
            this.lbTitle2.Name = "lbTitle2";
            this.lbTitle2.Size = new System.Drawing.Size(81, 25);
            this.lbTitle2.TabIndex = 23;
            this.lbTitle2.Text = "Notes:";
            // 
            // lbNotes
            // 
            this.lbNotes.AutoSize = true;
            this.lbNotes.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotes.Location = new System.Drawing.Point(104, 612);
            this.lbNotes.Name = "lbNotes";
            this.lbNotes.Size = new System.Drawing.Size(46, 19);
            this.lbNotes.TabIndex = 24;
            this.lbNotes.Text = "None";
            // 
            // frmShowTestInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 697);
            this.Controls.Add(this.lbNotes);
            this.Controls.Add(this.lbTitle2);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.ucAppointmentInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShowTestInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Test Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.ucAppointmentInfo ucAppointmentInfo1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Label lbTitle2;
        private System.Windows.Forms.Label lbNotes;
    }
}