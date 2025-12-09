namespace Project_DVLD_.Licenses
{
    partial class frmShowLicenseHistory
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.ucPersonDetails1 = new Project_DVLD_.ucPersonDetails();
            this.ucLicensesHistory1 = new Project_DVLD_.Controls.ucLicensesHistory();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 34F, System.Drawing.FontStyle.Bold);
            this.lbTitle.ForeColor = System.Drawing.Color.Brown;
            this.lbTitle.Location = new System.Drawing.Point(326, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(374, 56);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "License History";
            // 
            // ucPersonDetails1
            // 
            this.ucPersonDetails1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ucPersonDetails1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucPersonDetails1.Location = new System.Drawing.Point(13, 71);
            this.ucPersonDetails1.Margin = new System.Windows.Forms.Padding(4);
            this.ucPersonDetails1.Name = "ucPersonDetails1";
            this.ucPersonDetails1.Size = new System.Drawing.Size(1014, 302);
            this.ucPersonDetails1.TabIndex = 0;
            // 
            // ucLicensesHistory1
            // 
            this.ucLicensesHistory1.Location = new System.Drawing.Point(10, 396);
            this.ucLicensesHistory1.Name = "ucLicensesHistory1";
            this.ucLicensesHistory1.Size = new System.Drawing.Size(1017, 309);
            this.ucLicensesHistory1.TabIndex = 2;
            // 
            // frmShowLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1038, 717);
            this.Controls.Add(this.ucLicensesHistory1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.ucPersonDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "License History";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucPersonDetails ucPersonDetails1;
        private System.Windows.Forms.Label lbTitle;
        private Controls.ucLicensesHistory ucLicensesHistory1;
    }
}