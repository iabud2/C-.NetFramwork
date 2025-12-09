namespace Project_DVLD_.Users
{
    partial class frmUserInfo
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
            this.ucUserInformation1 = new Project_DVLD_.Controls.ucUserInformation();
            this.lbFormTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucUserInformation1
            // 
            this.ucUserInformation1.Location = new System.Drawing.Point(12, 57);
            this.ucUserInformation1.Name = "ucUserInformation1";
            this.ucUserInformation1.Size = new System.Drawing.Size(1138, 425);
            this.ucUserInformation1.TabIndex = 11;
            // 
            // lbFormTitle
            // 
            this.lbFormTitle.AutoSize = true;
            this.lbFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbFormTitle.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFormTitle.ForeColor = System.Drawing.Color.Black;
            this.lbFormTitle.Location = new System.Drawing.Point(385, 9);
            this.lbFormTitle.Name = "lbFormTitle";
            this.lbFormTitle.Size = new System.Drawing.Size(382, 58);
            this.lbFormTitle.TabIndex = 12;
            this.lbFormTitle.Text = "User Information";
            // 
            // frmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 494);
            this.Controls.Add(this.lbFormTitle);
            this.Controls.Add(this.ucUserInformation1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUserInfo";
            this.Text = "User Information";
            this.Load += new System.EventHandler(this.frmUserInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.ucUserInformation ucUserInformation1;
        private System.Windows.Forms.Label lbFormTitle;
    }
}