namespace Project_DVLD_.Applications
{
    partial class frmShowLDLA_Info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowLDLA_Info));
            this.ucShowApplicationInfo1 = new Project_DVLD_.Controls.ucShowLDLApplicationInfo();
            this.SuspendLayout();
            // 
            // ucShowApplicationInfo1
            // 
            this.ucShowApplicationInfo1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucShowApplicationInfo1.Location = new System.Drawing.Point(10, 12);
            this.ucShowApplicationInfo1.Name = "ucShowApplicationInfo1";
            this.ucShowApplicationInfo1.Size = new System.Drawing.Size(1000, 421);
            this.ucShowApplicationInfo1.TabIndex = 0;
            // 
            // frmShowLDLA_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1020, 445);
            this.Controls.Add(this.ucShowApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShowLDLA_Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Application Info";
            this.Load += new System.EventHandler(this.frmShowLDLA_Info_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ucShowLDLApplicationInfo ucShowApplicationInfo1;
    }
}