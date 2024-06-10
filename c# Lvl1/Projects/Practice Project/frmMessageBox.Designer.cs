namespace Project1
{
    partial class frmMessageBox
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
            this.ShowMessageBox1 = new System.Windows.Forms.Button();
            this.btnMessageBox2 = new System.Windows.Forms.Button();
            this.btnShowMessageBox3 = new System.Windows.Forms.Button();
            this.btnShowMessagebox4 = new System.Windows.Forms.Button();
            this.CloseFrm4 = new System.Windows.Forms.Button();
            this.btwShowMessageBox5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ShowMessageBox1
            // 
            this.ShowMessageBox1.Location = new System.Drawing.Point(14, 47);
            this.ShowMessageBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ShowMessageBox1.Name = "ShowMessageBox1";
            this.ShowMessageBox1.Size = new System.Drawing.Size(156, 59);
            this.ShowMessageBox1.TabIndex = 0;
            this.ShowMessageBox1.Text = "Show Message Box1";
            this.ShowMessageBox1.UseVisualStyleBackColor = true;
            this.ShowMessageBox1.Click += new System.EventHandler(this.ShowMessageBox1_Click);
            // 
            // btnMessageBox2
            // 
            this.btnMessageBox2.Location = new System.Drawing.Point(178, 47);
            this.btnMessageBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMessageBox2.Name = "btnMessageBox2";
            this.btnMessageBox2.Size = new System.Drawing.Size(156, 59);
            this.btnMessageBox2.TabIndex = 1;
            this.btnMessageBox2.Text = "Show Message Box2";
            this.btnMessageBox2.UseVisualStyleBackColor = true;
            this.btnMessageBox2.Click += new System.EventHandler(this.btnMessageBox2_Click);
            // 
            // btnShowMessageBox3
            // 
            this.btnShowMessageBox3.Location = new System.Drawing.Point(14, 123);
            this.btnShowMessageBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowMessageBox3.Name = "btnShowMessageBox3";
            this.btnShowMessageBox3.Size = new System.Drawing.Size(156, 59);
            this.btnShowMessageBox3.TabIndex = 2;
            this.btnShowMessageBox3.Text = "Show Message Box3";
            this.btnShowMessageBox3.UseVisualStyleBackColor = true;
            this.btnShowMessageBox3.Click += new System.EventHandler(this.btnShowMessageBox3_Click);
            // 
            // btnShowMessagebox4
            // 
            this.btnShowMessagebox4.Location = new System.Drawing.Point(178, 123);
            this.btnShowMessagebox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowMessagebox4.Name = "btnShowMessagebox4";
            this.btnShowMessagebox4.Size = new System.Drawing.Size(156, 59);
            this.btnShowMessagebox4.TabIndex = 3;
            this.btnShowMessagebox4.Text = "Show Message Box4";
            this.btnShowMessagebox4.UseVisualStyleBackColor = true;
            this.btnShowMessagebox4.Click += new System.EventHandler(this.btnShowMessagebox4_Click);
            // 
            // CloseFrm4
            // 
            this.CloseFrm4.Location = new System.Drawing.Point(178, 200);
            this.CloseFrm4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CloseFrm4.Name = "CloseFrm4";
            this.CloseFrm4.Size = new System.Drawing.Size(156, 59);
            this.CloseFrm4.TabIndex = 4;
            this.CloseFrm4.Text = "Close";
            this.CloseFrm4.UseVisualStyleBackColor = true;
            this.CloseFrm4.Click += new System.EventHandler(this.CloseFrm4_Click);
            // 
            // btwShowMessageBox5
            // 
            this.btwShowMessageBox5.Location = new System.Drawing.Point(13, 200);
            this.btwShowMessageBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btwShowMessageBox5.Name = "btwShowMessageBox5";
            this.btwShowMessageBox5.Size = new System.Drawing.Size(156, 59);
            this.btwShowMessageBox5.TabIndex = 5;
            this.btwShowMessageBox5.Text = "Show Message Box5";
            this.btwShowMessageBox5.UseVisualStyleBackColor = true;
            this.btwShowMessageBox5.Click += new System.EventHandler(this.btwShowMessageBox5_Click);
            // 
            // frmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.btwShowMessageBox5);
            this.Controls.Add(this.CloseFrm4);
            this.Controls.Add(this.btnShowMessagebox4);
            this.Controls.Add(this.btnShowMessageBox3);
            this.Controls.Add(this.btnMessageBox2);
            this.Controls.Add(this.ShowMessageBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMessageBox";
            this.Text = "frmMessageBox";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShowMessageBox1;
        private System.Windows.Forms.Button btnMessageBox2;
        private System.Windows.Forms.Button btnShowMessageBox3;
        private System.Windows.Forms.Button btnShowMessagebox4;
        private System.Windows.Forms.Button CloseFrm4;
        private System.Windows.Forms.Button btwShowMessageBox5;
    }
}