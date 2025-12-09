namespace Project_DVLD_.Tests
{
    partial class frmScheduleTest
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
            this.ucScheduleAppointment1 = new Project_DVLD_.Controls.ucScheduleAppointment();
            this.SuspendLayout();
            // 
            // ucScheduleAppointment1
            // 
            this.ucScheduleAppointment1.BackColor = System.Drawing.Color.White;
            this.ucScheduleAppointment1.Location = new System.Drawing.Point(12, 14);
            this.ucScheduleAppointment1.Name = "ucScheduleAppointment1";
            this.ucScheduleAppointment1.Size = new System.Drawing.Size(496, 621);
            this.ucScheduleAppointment1.TabIndex = 21;
            this.ucScheduleAppointment1.TestType = DVLD_BusinessLayer.Tests.clsTestTypes.enTestType.VisionTest;
            // 
            // frmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(528, 653);
            this.Controls.Add(this.ucScheduleAppointment1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmScheduleTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScheduleTest";
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.ucScheduleAppointment ucScheduleAppointment1;
    }
}