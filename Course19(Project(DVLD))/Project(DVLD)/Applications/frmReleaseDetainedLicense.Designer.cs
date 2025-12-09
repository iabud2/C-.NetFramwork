namespace Project_DVLD_.Applications
{
    partial class frmReleaseDetainedLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReleaseDetainedLicense));
            this.ucFindLicense1 = new Project_DVLD_.Controls.ucFindLicense();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDetainInfo = new System.Windows.Forms.GroupBox();
            this.lbTotalFees = new System.Windows.Forms.Label();
            this.lbTitle6 = new System.Windows.Forms.Label();
            this.lbReleaseFees = new System.Windows.Forms.Label();
            this.lbTitle5 = new System.Windows.Forms.Label();
            this.lbFineFees = new System.Windows.Forms.Label();
            this.lbDetainedBy = new System.Windows.Forms.Label();
            this.lbLicenseID = new System.Windows.Forms.Label();
            this.lbDetainDate = new System.Windows.Forms.Label();
            this.lbDetainID = new System.Windows.Forms.Label();
            this.lbTitle11 = new System.Windows.Forms.Label();
            this.lbTitle10 = new System.Windows.Forms.Label();
            this.lbTitle4 = new System.Windows.Forms.Label();
            this.lbTitle2 = new System.Windows.Forms.Label();
            this.lbTitle1 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.btnRelease = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.gbDetainInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // ucFindLicense1
            // 
            this.ucFindLicense1.BackColor = System.Drawing.Color.White;
            this.ucFindLicense1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucFindLicense1.Location = new System.Drawing.Point(11, 83);
            this.ucFindLicense1.Name = "ucFindLicense1";
            this.ucFindLicense1.Size = new System.Drawing.Size(1013, 449);
            this.ucFindLicense1.TabIndex = 35;
            this.ucFindLicense1.OnLicenseSelected += new System.Action<int>(this.ucFindLicense1_OnLicenseSelected);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(207, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(620, 67);
            this.label1.TabIndex = 39;
            this.label1.Text = "Release License";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gbDetainInfo
            // 
            this.gbDetainInfo.BackColor = System.Drawing.Color.White;
            this.gbDetainInfo.Controls.Add(this.pictureBox7);
            this.gbDetainInfo.Controls.Add(this.pictureBox5);
            this.gbDetainInfo.Controls.Add(this.pictureBox4);
            this.gbDetainInfo.Controls.Add(this.pictureBox3);
            this.gbDetainInfo.Controls.Add(this.pictureBox2);
            this.gbDetainInfo.Controls.Add(this.pictureBox1);
            this.gbDetainInfo.Controls.Add(this.pictureBox6);
            this.gbDetainInfo.Controls.Add(this.lbTotalFees);
            this.gbDetainInfo.Controls.Add(this.lbTitle6);
            this.gbDetainInfo.Controls.Add(this.lbReleaseFees);
            this.gbDetainInfo.Controls.Add(this.lbTitle5);
            this.gbDetainInfo.Controls.Add(this.lbFineFees);
            this.gbDetainInfo.Controls.Add(this.lbDetainedBy);
            this.gbDetainInfo.Controls.Add(this.lbLicenseID);
            this.gbDetainInfo.Controls.Add(this.lbDetainDate);
            this.gbDetainInfo.Controls.Add(this.lbDetainID);
            this.gbDetainInfo.Controls.Add(this.lbTitle11);
            this.gbDetainInfo.Controls.Add(this.lbTitle10);
            this.gbDetainInfo.Controls.Add(this.lbTitle4);
            this.gbDetainInfo.Controls.Add(this.lbTitle2);
            this.gbDetainInfo.Controls.Add(this.lbTitle1);
            this.gbDetainInfo.Enabled = false;
            this.gbDetainInfo.Font = new System.Drawing.Font("Tahoma", 16F);
            this.gbDetainInfo.Location = new System.Drawing.Point(12, 538);
            this.gbDetainInfo.Name = "gbDetainInfo";
            this.gbDetainInfo.Size = new System.Drawing.Size(1011, 193);
            this.gbDetainInfo.TabIndex = 40;
            this.gbDetainInfo.TabStop = false;
            this.gbDetainInfo.Text = "Detain Info";
            // 
            // lbTotalFees
            // 
            this.lbTotalFees.AutoSize = true;
            this.lbTotalFees.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbTotalFees.Location = new System.Drawing.Point(161, 158);
            this.lbTotalFees.Name = "lbTotalFees";
            this.lbTotalFees.Size = new System.Drawing.Size(37, 19);
            this.lbTotalFees.TabIndex = 26;
            this.lbTotalFees.Text = "N/A";
            // 
            // lbTitle6
            // 
            this.lbTitle6.AutoSize = true;
            this.lbTitle6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle6.Location = new System.Drawing.Point(6, 158);
            this.lbTitle6.Name = "lbTitle6";
            this.lbTitle6.Size = new System.Drawing.Size(100, 19);
            this.lbTitle6.TabIndex = 25;
            this.lbTitle6.Text = "Total Fees:";
            // 
            // lbReleaseFees
            // 
            this.lbReleaseFees.AutoSize = true;
            this.lbReleaseFees.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbReleaseFees.Location = new System.Drawing.Point(492, 120);
            this.lbReleaseFees.Name = "lbReleaseFees";
            this.lbReleaseFees.Size = new System.Drawing.Size(37, 19);
            this.lbReleaseFees.TabIndex = 24;
            this.lbReleaseFees.Text = "N/A";
            // 
            // lbTitle5
            // 
            this.lbTitle5.AutoSize = true;
            this.lbTitle5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle5.Location = new System.Drawing.Point(306, 120);
            this.lbTitle5.Name = "lbTitle5";
            this.lbTitle5.Size = new System.Drawing.Size(122, 19);
            this.lbTitle5.TabIndex = 23;
            this.lbTitle5.Text = "Release Fees:";
            // 
            // lbFineFees
            // 
            this.lbFineFees.AutoSize = true;
            this.lbFineFees.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbFineFees.Location = new System.Drawing.Point(161, 120);
            this.lbFineFees.Name = "lbFineFees";
            this.lbFineFees.Size = new System.Drawing.Size(37, 19);
            this.lbFineFees.TabIndex = 22;
            this.lbFineFees.Text = "N/A";
            // 
            // lbDetainedBy
            // 
            this.lbDetainedBy.AutoSize = true;
            this.lbDetainedBy.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbDetainedBy.Location = new System.Drawing.Point(492, 85);
            this.lbDetainedBy.Name = "lbDetainedBy";
            this.lbDetainedBy.Size = new System.Drawing.Size(37, 19);
            this.lbDetainedBy.TabIndex = 21;
            this.lbDetainedBy.Text = "N/A";
            // 
            // lbLicenseID
            // 
            this.lbLicenseID.AutoSize = true;
            this.lbLicenseID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbLicenseID.Location = new System.Drawing.Point(161, 81);
            this.lbLicenseID.Name = "lbLicenseID";
            this.lbLicenseID.Size = new System.Drawing.Size(37, 19);
            this.lbLicenseID.TabIndex = 15;
            this.lbLicenseID.Text = "N/A";
            // 
            // lbDetainDate
            // 
            this.lbDetainDate.AutoSize = true;
            this.lbDetainDate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbDetainDate.Location = new System.Drawing.Point(492, 46);
            this.lbDetainDate.Name = "lbDetainDate";
            this.lbDetainDate.Size = new System.Drawing.Size(37, 19);
            this.lbDetainDate.TabIndex = 13;
            this.lbDetainDate.Text = "N/A";
            // 
            // lbDetainID
            // 
            this.lbDetainID.AutoSize = true;
            this.lbDetainID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbDetainID.Location = new System.Drawing.Point(161, 46);
            this.lbDetainID.Name = "lbDetainID";
            this.lbDetainID.Size = new System.Drawing.Size(37, 19);
            this.lbDetainID.TabIndex = 12;
            this.lbDetainID.Text = "N/A";
            // 
            // lbTitle11
            // 
            this.lbTitle11.AutoSize = true;
            this.lbTitle11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle11.Location = new System.Drawing.Point(8, 120);
            this.lbTitle11.Name = "lbTitle11";
            this.lbTitle11.Size = new System.Drawing.Size(91, 19);
            this.lbTitle11.TabIndex = 10;
            this.lbTitle11.Text = "Fine Fees:";
            // 
            // lbTitle10
            // 
            this.lbTitle10.AutoSize = true;
            this.lbTitle10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle10.Location = new System.Drawing.Point(305, 81);
            this.lbTitle10.Name = "lbTitle10";
            this.lbTitle10.Size = new System.Drawing.Size(114, 19);
            this.lbTitle10.TabIndex = 9;
            this.lbTitle10.Text = "Detained By:";
            // 
            // lbTitle4
            // 
            this.lbTitle4.AutoSize = true;
            this.lbTitle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle4.Location = new System.Drawing.Point(306, 46);
            this.lbTitle4.Name = "lbTitle4";
            this.lbTitle4.Size = new System.Drawing.Size(113, 19);
            this.lbTitle4.TabIndex = 3;
            this.lbTitle4.Text = "Detain Date:";
            // 
            // lbTitle2
            // 
            this.lbTitle2.AutoSize = true;
            this.lbTitle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle2.Location = new System.Drawing.Point(6, 81);
            this.lbTitle2.Name = "lbTitle2";
            this.lbTitle2.Size = new System.Drawing.Size(99, 19);
            this.lbTitle2.TabIndex = 1;
            this.lbTitle2.Text = "License ID:";
            // 
            // lbTitle1
            // 
            this.lbTitle1.AutoSize = true;
            this.lbTitle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle1.Location = new System.Drawing.Point(6, 46);
            this.lbTitle1.Name = "lbTitle1";
            this.lbTitle1.Size = new System.Drawing.Size(93, 19);
            this.lbTitle1.TabIndex = 0;
            this.lbTitle1.Text = "Detain ID:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Project_DVLD_.Properties.Resources.Person24;
            this.pictureBox5.Location = new System.Drawing.Point(438, 80);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(24, 24);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 32;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Project_DVLD_.Properties.Resources.fees24;
            this.pictureBox4.Location = new System.Drawing.Point(438, 120);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 31;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Project_DVLD_.Properties.Resources.fees24;
            this.pictureBox3.Location = new System.Drawing.Point(118, 158);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 30;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Project_DVLD_.Properties.Resources.fees24;
            this.pictureBox2.Location = new System.Drawing.Point(118, 120);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project_DVLD_.Properties.Resources.ID24;
            this.pictureBox1.Location = new System.Drawing.Point(118, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Project_DVLD_.Properties.Resources.ID24;
            this.pictureBox6.Location = new System.Drawing.Point(118, 44);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(24, 24);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 27;
            this.pictureBox6.TabStop = false;
            // 
            // btnRelease
            // 
            this.btnRelease.BackColor = System.Drawing.Color.White;
            this.btnRelease.Enabled = false;
            this.btnRelease.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRelease.FlatAppearance.BorderSize = 2;
            this.btnRelease.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRelease.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelease.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.ForeColor = System.Drawing.Color.Black;
            this.btnRelease.Image = ((System.Drawing.Image)(resources.GetObject("btnRelease.Image")));
            this.btnRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelease.Location = new System.Drawing.Point(918, 746);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(106, 43);
            this.btnRelease.TabIndex = 38;
            this.btnRelease.Text = "     Release";
            this.btnRelease.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRelease.UseVisualStyleBackColor = false;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::Project_DVLD_.Properties.Resources.calender24;
            this.pictureBox7.Location = new System.Drawing.Point(438, 44);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(24, 24);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox7.TabIndex = 33;
            this.pictureBox7.TabStop = false;
            // 
            // frmReleaseDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1035, 798);
            this.Controls.Add(this.gbDetainInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucFindLicense1);
            this.Controls.Add(this.btnRelease);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReleaseDetainedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Release License";
            this.gbDetainInfo.ResumeLayout(false);
            this.gbDetainInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.ucFindLicense ucFindLicense1;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDetainInfo;
        private System.Windows.Forms.Label lbDetainedBy;
        private System.Windows.Forms.Label lbLicenseID;
        private System.Windows.Forms.Label lbDetainDate;
        private System.Windows.Forms.Label lbDetainID;
        private System.Windows.Forms.Label lbTitle11;
        private System.Windows.Forms.Label lbTitle10;
        private System.Windows.Forms.Label lbTitle4;
        private System.Windows.Forms.Label lbTitle2;
        private System.Windows.Forms.Label lbTitle1;
        private System.Windows.Forms.Label lbTotalFees;
        private System.Windows.Forms.Label lbTitle6;
        private System.Windows.Forms.Label lbReleaseFees;
        private System.Windows.Forms.Label lbTitle5;
        private System.Windows.Forms.Label lbFineFees;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}