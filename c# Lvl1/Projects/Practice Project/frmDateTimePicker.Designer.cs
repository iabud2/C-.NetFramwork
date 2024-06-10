namespace Project1
{
    partial class frmDateTimePicker
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblShowDateTime = new System.Windows.Forms.Label();
            this.btnLongFormat = new System.Windows.Forms.Button();
            this.btnShortFormat = new System.Windows.Forms.Button();
            this.btnShowLocalTime = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(31, 67);
            this.dateTimePicker1.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(281, 26);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lblShowDateTime
            // 
            this.lblShowDateTime.AutoSize = true;
            this.lblShowDateTime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowDateTime.Location = new System.Drawing.Point(409, 75);
            this.lblShowDateTime.Name = "lblShowDateTime";
            this.lblShowDateTime.Size = new System.Drawing.Size(104, 16);
            this.lblShowDateTime.TabIndex = 1;
            this.lblShowDateTime.Text = "Date Time String";
            // 
            // btnLongFormat
            // 
            this.btnLongFormat.Location = new System.Drawing.Point(31, 139);
            this.btnLongFormat.Name = "btnLongFormat";
            this.btnLongFormat.Size = new System.Drawing.Size(135, 54);
            this.btnLongFormat.TabIndex = 2;
            this.btnLongFormat.Text = "Show Long Format";
            this.btnLongFormat.UseVisualStyleBackColor = true;
            this.btnLongFormat.Click += new System.EventHandler(this.btnLongFormat_Click);
            // 
            // btnShortFormat
            // 
            this.btnShortFormat.Location = new System.Drawing.Point(177, 139);
            this.btnShortFormat.Name = "btnShortFormat";
            this.btnShortFormat.Size = new System.Drawing.Size(135, 54);
            this.btnShortFormat.TabIndex = 3;
            this.btnShortFormat.Text = "Show Short Format";
            this.btnShortFormat.UseVisualStyleBackColor = true;
            this.btnShortFormat.Click += new System.EventHandler(this.btnShortFormat_Click);
            // 
            // btnShowLocalTime
            // 
            this.btnShowLocalTime.Location = new System.Drawing.Point(107, 199);
            this.btnShowLocalTime.Name = "btnShowLocalTime";
            this.btnShowLocalTime.Size = new System.Drawing.Size(135, 54);
            this.btnShowLocalTime.TabIndex = 4;
            this.btnShowLocalTime.Text = "Show local time";
            this.btnShowLocalTime.UseVisualStyleBackColor = true;
            this.btnShowLocalTime.Click += new System.EventHandler(this.btnShowLocalTime_Click);
            // 
            // frmDateTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnShowLocalTime);
            this.Controls.Add(this.btnShortFormat);
            this.Controls.Add(this.btnLongFormat);
            this.Controls.Add(this.lblShowDateTime);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "frmDateTimePicker";
            this.Text = "frmDateTimePicker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblShowDateTime;
        private System.Windows.Forms.Button btnLongFormat;
        private System.Windows.Forms.Button btnShortFormat;
        private System.Windows.Forms.Button btnShowLocalTime;
    }
}