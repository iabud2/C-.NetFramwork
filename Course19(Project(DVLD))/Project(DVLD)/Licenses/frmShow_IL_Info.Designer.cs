namespace Project_DVLD_.Licenses
{
    partial class frmShow_IL_Info
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
            this.label1 = new System.Windows.Forms.Label();
            this.ucShow_IL_Info1 = new Project_DVLD_.Controls.ucShow_IL_Info();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F);
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(287, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "International License Details";
            // 
            // ucShow_IL_Info1
            // 
            this.ucShow_IL_Info1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucShow_IL_Info1.Location = new System.Drawing.Point(12, 54);
            this.ucShow_IL_Info1.Name = "ucShow_IL_Info1";
            this.ucShow_IL_Info1.Size = new System.Drawing.Size(970, 316);
            this.ucShow_IL_Info1.TabIndex = 0;
            // 
            // frmShow_IL_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 382);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucShow_IL_Info1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShow_IL_Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "International License Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ucShow_IL_Info ucShow_IL_Info1;
        private System.Windows.Forms.Label label1;
    }
}