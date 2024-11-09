namespace Project_DVLD_.Applications
{
    partial class frmAddUpdateLDL_Apllication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdateLDL_Apllication));
            this.tcLDLA = new System.Windows.Forms.TabControl();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.tpApplicationInfo = new System.Windows.Forms.TabPage();
            this.lbApplicationDate = new System.Windows.Forms.Label();
            this.cbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.lbApplicationFees = new System.Windows.Forms.Label();
            this.lbLDLA_ID = new System.Windows.Forms.Label();
            this.lbTitle5 = new System.Windows.Forms.Label();
            this.lbtitle4 = new System.Windows.Forms.Label();
            this.lbTitle3 = new System.Windows.Forms.Label();
            this.lbTitle2 = new System.Windows.Forms.Label();
            this.lbTitle1 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCLose1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ucFindPerson1 = new Project_DVLD_.Controls.ucFindPerson();
            this.tcLDLA.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.tpApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcLDLA
            // 
            this.tcLDLA.Controls.Add(this.tpPersonalInfo);
            this.tcLDLA.Controls.Add(this.tpApplicationInfo);
            this.tcLDLA.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tcLDLA.Location = new System.Drawing.Point(12, 134);
            this.tcLDLA.Name = "tcLDLA";
            this.tcLDLA.SelectedIndex = 0;
            this.tcLDLA.Size = new System.Drawing.Size(1062, 493);
            this.tcLDLA.TabIndex = 0;
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tpPersonalInfo.Controls.Add(this.btnNext);
            this.tpPersonalInfo.Controls.Add(this.ucFindPerson1);
            this.tpPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonalInfo.Size = new System.Drawing.Size(1054, 467);
            this.tpPersonalInfo.TabIndex = 0;
            this.tpPersonalInfo.Text = "Peorsonal Info";
            this.tpPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.LightGray;
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::Project_DVLD_.Properties.Resources.next_button;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(956, 403);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(85, 36);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpApplicationInfo
            // 
            this.tpApplicationInfo.Controls.Add(this.lbApplicationDate);
            this.tpApplicationInfo.Controls.Add(this.cbLicenseClasses);
            this.tpApplicationInfo.Controls.Add(this.lbCreatedBy);
            this.tpApplicationInfo.Controls.Add(this.lbApplicationFees);
            this.tpApplicationInfo.Controls.Add(this.lbLDLA_ID);
            this.tpApplicationInfo.Controls.Add(this.lbTitle5);
            this.tpApplicationInfo.Controls.Add(this.lbtitle4);
            this.tpApplicationInfo.Controls.Add(this.lbTitle3);
            this.tpApplicationInfo.Controls.Add(this.lbTitle2);
            this.tpApplicationInfo.Controls.Add(this.lbTitle1);
            this.tpApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.tpApplicationInfo.Name = "tpApplicationInfo";
            this.tpApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpApplicationInfo.Size = new System.Drawing.Size(1054, 467);
            this.tpApplicationInfo.TabIndex = 1;
            this.tpApplicationInfo.Text = "Application Info";
            this.tpApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // lbApplicationDate
            // 
            this.lbApplicationDate.AutoSize = true;
            this.lbApplicationDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationDate.Location = new System.Drawing.Point(324, 115);
            this.lbApplicationDate.Name = "lbApplicationDate";
            this.lbApplicationDate.Size = new System.Drawing.Size(37, 23);
            this.lbApplicationDate.TabIndex = 34;
            this.lbApplicationDate.Text = "???";
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClasses.FormattingEnabled = true;
            this.cbLicenseClasses.Location = new System.Drawing.Point(328, 187);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(262, 21);
            this.cbLicenseClasses.TabIndex = 33;
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreatedBy.Location = new System.Drawing.Point(324, 314);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(37, 23);
            this.lbCreatedBy.TabIndex = 32;
            this.lbCreatedBy.Text = "???";
            // 
            // lbApplicationFees
            // 
            this.lbApplicationFees.AutoSize = true;
            this.lbApplicationFees.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationFees.Location = new System.Drawing.Point(324, 240);
            this.lbApplicationFees.Name = "lbApplicationFees";
            this.lbApplicationFees.Size = new System.Drawing.Size(37, 23);
            this.lbApplicationFees.TabIndex = 31;
            this.lbApplicationFees.Text = "???";
            // 
            // lbLDLA_ID
            // 
            this.lbLDLA_ID.AutoSize = true;
            this.lbLDLA_ID.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLDLA_ID.Location = new System.Drawing.Point(324, 46);
            this.lbLDLA_ID.Name = "lbLDLA_ID";
            this.lbLDLA_ID.Size = new System.Drawing.Size(37, 23);
            this.lbLDLA_ID.TabIndex = 29;
            this.lbLDLA_ID.Text = "???";
            // 
            // lbTitle5
            // 
            this.lbTitle5.AutoSize = true;
            this.lbTitle5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle5.Location = new System.Drawing.Point(62, 312);
            this.lbTitle5.Name = "lbTitle5";
            this.lbTitle5.Size = new System.Drawing.Size(134, 25);
            this.lbTitle5.TabIndex = 28;
            this.lbTitle5.Text = "Created By:";
            // 
            // lbtitle4
            // 
            this.lbtitle4.AutoSize = true;
            this.lbtitle4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtitle4.Location = new System.Drawing.Point(62, 238);
            this.lbtitle4.Name = "lbtitle4";
            this.lbtitle4.Size = new System.Drawing.Size(190, 25);
            this.lbtitle4.TabIndex = 27;
            this.lbtitle4.Text = "Application Fees:";
            // 
            // lbTitle3
            // 
            this.lbTitle3.AutoSize = true;
            this.lbTitle3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle3.Location = new System.Drawing.Point(62, 180);
            this.lbTitle3.Name = "lbTitle3";
            this.lbTitle3.Size = new System.Drawing.Size(158, 25);
            this.lbTitle3.TabIndex = 26;
            this.lbTitle3.Text = "License Class:";
            // 
            // lbTitle2
            // 
            this.lbTitle2.AutoSize = true;
            this.lbTitle2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle2.Location = new System.Drawing.Point(62, 113);
            this.lbTitle2.Name = "lbTitle2";
            this.lbTitle2.Size = new System.Drawing.Size(193, 25);
            this.lbTitle2.TabIndex = 25;
            this.lbTitle2.Text = "Application Date:";
            // 
            // lbTitle1
            // 
            this.lbTitle1.AutoSize = true;
            this.lbTitle1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle1.Location = new System.Drawing.Point(62, 44);
            this.lbTitle1.Name = "lbTitle1";
            this.lbTitle1.Size = new System.Drawing.Size(127, 25);
            this.lbTitle1.TabIndex = 24;
            this.lbTitle1.Text = "L.D.L.A ID:";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Firebrick;
            this.lbTitle.Location = new System.Drawing.Point(226, 37);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(631, 45);
            this.lbTitle.TabIndex = 20;
            this.lbTitle.Text = "Local Driving License Application";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(985, 633);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 43);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "       Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCLose1
            // 
            this.btnCLose1.BackColor = System.Drawing.Color.White;
            this.btnCLose1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCLose1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCLose1.FlatAppearance.BorderSize = 2;
            this.btnCLose1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCLose1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCLose1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCLose1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLose1.ForeColor = System.Drawing.Color.Black;
            this.btnCLose1.Image = ((System.Drawing.Image)(resources.GetObject("btnCLose1.Image")));
            this.btnCLose1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCLose1.Location = new System.Drawing.Point(886, 633);
            this.btnCLose1.Name = "btnCLose1";
            this.btnCLose1.Size = new System.Drawing.Size(93, 43);
            this.btnCLose1.TabIndex = 21;
            this.btnCLose1.Text = "       Close";
            this.btnCLose1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCLose1.UseVisualStyleBackColor = false;
            this.btnCLose1.Click += new System.EventHandler(this.btnCLose1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1040, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 42);
            this.btnClose.TabIndex = 23;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucFindPerson1
            // 
            this.ucFindPerson1.FilterEnabled = true;
            this.ucFindPerson1.Location = new System.Drawing.Point(6, 6);
            this.ucFindPerson1.Name = "ucFindPerson1";
            this.ucFindPerson1.Size = new System.Drawing.Size(1035, 391);
            this.ucFindPerson1.TabIndex = 0;
            // 
            // frmAddUpdateLDL_Apllication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1094, 688);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCLose1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.tcLDLA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateLDL_Apllication";
            this.Text = "frmAddUpdateLDL_Apllication";
            this.Load += new System.EventHandler(this.frmAddUpdateLDL_Apllication_Load);
            this.tcLDLA.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpApplicationInfo.ResumeLayout(false);
            this.tpApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcLDLA;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private System.Windows.Forms.TabPage tpApplicationInfo;
        private Controls.ucFindPerson ucFindPerson1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCLose1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbTitle1;
        private System.Windows.Forms.Label lbLDLA_ID;
        private System.Windows.Forms.Label lbTitle5;
        private System.Windows.Forms.Label lbtitle4;
        private System.Windows.Forms.Label lbTitle3;
        private System.Windows.Forms.Label lbTitle2;
        private System.Windows.Forms.ComboBox cbLicenseClasses;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.Label lbApplicationFees;
        private System.Windows.Forms.Label lbApplicationDate;
    }
}