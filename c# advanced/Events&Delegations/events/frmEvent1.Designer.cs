namespace c__advanced.events
{
    partial class frmEvent1
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
            this.ctrlSimpleCalculator1 = new c__advanced.events.ctrlSimpleCalculator();
            this.SuspendLayout();
            // 
            // ctrlSimpleCalculator1
            // 
            this.ctrlSimpleCalculator1.Location = new System.Drawing.Point(77, 22);
            this.ctrlSimpleCalculator1.Name = "ctrlSimpleCalculator1";
            this.ctrlSimpleCalculator1.Size = new System.Drawing.Size(491, 210);
            this.ctrlSimpleCalculator1.TabIndex = 0;
            this.ctrlSimpleCalculator1.OnCalculateComplete += new System.EventHandler<c__advanced.events.ctrlSimpleCalculator.CalculateCompleteEvent>(this.ctrlSimpleCalculator1_OnCalculateComplete);
            // 
            // Event1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 274);
            this.Controls.Add(this.ctrlSimpleCalculator1);
            this.Name = "Event1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlSimpleCalculator ctrlSimpleCalculator1;
    }
}