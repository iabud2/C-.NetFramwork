namespace Project1
{
    partial class frmpbox
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnApple = new System.Windows.Forms.Button();
            this.btnBanana = new System.Windows.Forms.Button();
            this.ImageFromFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::Project1.Properties.Resources.Apple;
            this.pictureBox1.Location = new System.Drawing.Point(204, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(343, 245);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnApple
            // 
            this.btnApple.FlatAppearance.BorderSize = 4;
            this.btnApple.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApple.Location = new System.Drawing.Point(204, 325);
            this.btnApple.Name = "btnApple";
            this.btnApple.Size = new System.Drawing.Size(135, 63);
            this.btnApple.TabIndex = 1;
            this.btnApple.Text = "Apple";
            this.btnApple.UseVisualStyleBackColor = true;
            this.btnApple.Click += new System.EventHandler(this.btnApple_Click);
            // 
            // btnBanana
            // 
            this.btnBanana.FlatAppearance.BorderSize = 4;
            this.btnBanana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanana.Location = new System.Drawing.Point(412, 325);
            this.btnBanana.Name = "btnBanana";
            this.btnBanana.Size = new System.Drawing.Size(135, 63);
            this.btnBanana.TabIndex = 2;
            this.btnBanana.Text = "Banana";
            this.btnBanana.UseVisualStyleBackColor = true;
            this.btnBanana.Click += new System.EventHandler(this.btnBanana_Click);
            // 
            // ImageFromFile
            // 
            this.ImageFromFile.FlatAppearance.BorderSize = 4;
            this.ImageFromFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImageFromFile.Location = new System.Drawing.Point(312, 394);
            this.ImageFromFile.Name = "ImageFromFile";
            this.ImageFromFile.Size = new System.Drawing.Size(135, 44);
            this.ImageFromFile.TabIndex = 3;
            this.ImageFromFile.Text = "ImageFromFile";
            this.ImageFromFile.UseVisualStyleBackColor = true;
            this.ImageFromFile.Click += new System.EventHandler(this.ImageFromFile_Click);
            // 
            // frmpbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ImageFromFile);
            this.Controls.Add(this.btnBanana);
            this.Controls.Add(this.btnApple);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmpbox";
            this.Text = "frmpbox";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnApple;
        private System.Windows.Forms.Button btnBanana;
        private System.Windows.Forms.Button ImageFromFile;
    }
}