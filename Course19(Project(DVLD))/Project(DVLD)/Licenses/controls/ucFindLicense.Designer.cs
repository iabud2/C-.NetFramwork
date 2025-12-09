namespace Project_DVLD_.Controls
{
    partial class ucFindLicense
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
            this.Title = new System.Windows.Forms.Label();
            this.txtLicenseID = new System.Windows.Forms.MaskedTextBox();
            this.ucShowLicenseInfo1 = new Project_DVLD_.Controls.ucShowLicenseInfo();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Tahoma", 16F);
            this.Title.Location = new System.Drawing.Point(20, 22);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(115, 27);
            this.Title.TabIndex = 1;
            this.Title.Text = "LicenseID:";
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Location = new System.Drawing.Point(141, 29);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.Size = new System.Drawing.Size(270, 20);
            this.txtLicenseID.TabIndex = 3;
            this.txtLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenseID_KeyPress);
            // 
            // ucShowLicenseInfo1
            // 
            this.ucShowLicenseInfo1.Location = new System.Drawing.Point(25, 65);
            this.ucShowLicenseInfo1.Name = "ucShowLicenseInfo1";
            this.ucShowLicenseInfo1.Size = new System.Drawing.Size(948, 369);
            this.ucShowLicenseInfo1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::Project_DVLD_.Properties.Resources.Find32px;
            this.btnSearch.Location = new System.Drawing.Point(417, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(45, 41);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ucFindLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtLicenseID);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.ucShowLicenseInfo1);
            this.Name = "ucFindLicense";
            this.Size = new System.Drawing.Size(998, 469);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucShowLicenseInfo ucShowLicenseInfo1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.MaskedTextBox txtLicenseID;
        private System.Windows.Forms.Button btnSearch;
    }
}
