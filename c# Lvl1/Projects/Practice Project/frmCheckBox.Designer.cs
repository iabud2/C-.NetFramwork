namespace Project1
{
    partial class frmCheckBox
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
            this.chkTomato = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rdbtnSmall = new System.Windows.Forms.RadioButton();
            this.rdbtnLarge = new System.Windows.Forms.RadioButton();
            this.rdbtnMedium = new System.Windows.Forms.RadioButton();
            this.btnRadiobtnStatus = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCheckPizzaCrust = new System.Windows.Forms.Button();
            this.rdbtnThin = new System.Windows.Forms.RadioButton();
            this.rdbtnThick = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkTomato
            // 
            this.chkTomato.AutoSize = true;
            this.chkTomato.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTomato.Location = new System.Drawing.Point(25, 49);
            this.chkTomato.Name = "chkTomato";
            this.chkTomato.Size = new System.Drawing.Size(190, 23);
            this.chkTomato.TabIndex = 0;
            this.chkTomato.Text = "Do You Want Tomato?";
            this.chkTomato.UseVisualStyleBackColor = true;
            this.chkTomato.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(25, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "CheckBox Status";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rdbtnSmall
            // 
            this.rdbtnSmall.AutoSize = true;
            this.rdbtnSmall.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnSmall.Location = new System.Drawing.Point(6, 21);
            this.rdbtnSmall.Name = "rdbtnSmall";
            this.rdbtnSmall.Size = new System.Drawing.Size(57, 20);
            this.rdbtnSmall.TabIndex = 2;
            this.rdbtnSmall.TabStop = true;
            this.rdbtnSmall.Text = "Small";
            this.rdbtnSmall.UseVisualStyleBackColor = true;
            // 
            // rdbtnLarge
            // 
            this.rdbtnLarge.AutoSize = true;
            this.rdbtnLarge.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnLarge.Location = new System.Drawing.Point(8, 73);
            this.rdbtnLarge.Name = "rdbtnLarge";
            this.rdbtnLarge.Size = new System.Drawing.Size(57, 20);
            this.rdbtnLarge.TabIndex = 4;
            this.rdbtnLarge.TabStop = true;
            this.rdbtnLarge.Text = "Large";
            this.rdbtnLarge.UseVisualStyleBackColor = true;
            // 
            // rdbtnMedium
            // 
            this.rdbtnMedium.AutoSize = true;
            this.rdbtnMedium.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnMedium.Location = new System.Drawing.Point(8, 47);
            this.rdbtnMedium.Name = "rdbtnMedium";
            this.rdbtnMedium.Size = new System.Drawing.Size(70, 20);
            this.rdbtnMedium.TabIndex = 3;
            this.rdbtnMedium.TabStop = true;
            this.rdbtnMedium.Text = "Medium";
            this.rdbtnMedium.UseVisualStyleBackColor = true;
            this.rdbtnMedium.CheckedChanged += new System.EventHandler(this.rdbtnMedium_CheckedChanged);
            // 
            // btnRadiobtnStatus
            // 
            this.btnRadiobtnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRadiobtnStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRadiobtnStatus.Location = new System.Drawing.Point(8, 119);
            this.btnRadiobtnStatus.Name = "btnRadiobtnStatus";
            this.btnRadiobtnStatus.Size = new System.Drawing.Size(129, 42);
            this.btnRadiobtnStatus.TabIndex = 5;
            this.btnRadiobtnStatus.Text = "Check Your Pizza Size";
            this.btnRadiobtnStatus.UseVisualStyleBackColor = true;
            this.btnRadiobtnStatus.Click += new System.EventHandler(this.btnRadiobtnStatus_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRadiobtnStatus);
            this.groupBox1.Controls.Add(this.rdbtnMedium);
            this.groupBox1.Controls.Add(this.rdbtnLarge);
            this.groupBox1.Controls.Add(this.rdbtnSmall);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 177);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Size:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCheckPizzaCrust);
            this.groupBox2.Controls.Add(this.rdbtnThin);
            this.groupBox2.Controls.Add(this.rdbtnThick);
            this.groupBox2.Location = new System.Drawing.Point(240, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 177);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Crust:";
            // 
            // btnCheckPizzaCrust
            // 
            this.btnCheckPizzaCrust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckPizzaCrust.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckPizzaCrust.Location = new System.Drawing.Point(18, 110);
            this.btnCheckPizzaCrust.Name = "btnCheckPizzaCrust";
            this.btnCheckPizzaCrust.Size = new System.Drawing.Size(120, 42);
            this.btnCheckPizzaCrust.TabIndex = 2;
            this.btnCheckPizzaCrust.Text = "Check Pizza Crust";
            this.btnCheckPizzaCrust.UseVisualStyleBackColor = true;
            this.btnCheckPizzaCrust.Click += new System.EventHandler(this.btnCheckPizzaCrust_Click);
            // 
            // rdbtnThin
            // 
            this.rdbtnThin.AutoSize = true;
            this.rdbtnThin.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnThin.Location = new System.Drawing.Point(18, 68);
            this.rdbtnThin.Name = "rdbtnThin";
            this.rdbtnThin.Size = new System.Drawing.Size(50, 20);
            this.rdbtnThin.TabIndex = 1;
            this.rdbtnThin.TabStop = true;
            this.rdbtnThin.Text = "Thin";
            this.rdbtnThin.UseVisualStyleBackColor = true;
            // 
            // rdbtnThick
            // 
            this.rdbtnThick.AutoSize = true;
            this.rdbtnThick.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnThick.Location = new System.Drawing.Point(18, 38);
            this.rdbtnThick.Name = "rdbtnThick";
            this.rdbtnThick.Size = new System.Drawing.Size(55, 20);
            this.rdbtnThick.TabIndex = 0;
            this.rdbtnThick.TabStop = true;
            this.rdbtnThick.Text = "Thick";
            this.rdbtnThick.UseVisualStyleBackColor = true;
            // 
            // frmCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkTomato);
            this.Name = "frmCheckBox";
            this.Text = "frmCheckBox";
            this.Load += new System.EventHandler(this.frmCheckBox_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkTomato;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rdbtnSmall;
        private System.Windows.Forms.RadioButton rdbtnLarge;
        private System.Windows.Forms.RadioButton rdbtnMedium;
        private System.Windows.Forms.Button btnRadiobtnStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbtnThin;
        private System.Windows.Forms.RadioButton rdbtnThick;
        private System.Windows.Forms.Button btnCheckPizzaCrust;
    }
}