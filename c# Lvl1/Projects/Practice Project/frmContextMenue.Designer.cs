namespace Project1
{
    partial class frmContextMenue
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
            this.components = new System.ComponentModel.Container();
            this.cmFormat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmChangeColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tmChangeFont = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmitTxt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tmClear = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.cmFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmFormat
            // 
            this.cmFormat.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmFormat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmChangeColor,
            this.tmChangeFont,
            this.tmClear});
            this.cmFormat.Name = "cmFormat";
            this.cmFormat.Size = new System.Drawing.Size(165, 76);
            this.cmFormat.Text = "Formating";
            // 
            // tmChangeColor
            // 
            this.tmChangeColor.Name = "tmChangeColor";
            this.tmChangeColor.Size = new System.Drawing.Size(210, 24);
            this.tmChangeColor.Text = "ChangeColor";
            this.tmChangeColor.Click += new System.EventHandler(this.tmChangeColor_Click);
            // 
            // tmChangeFont
            // 
            this.tmChangeFont.Name = "tmChangeFont";
            this.tmChangeFont.Size = new System.Drawing.Size(210, 24);
            this.tmChangeFont.Text = "Change Font";
            this.tmChangeFont.Click += new System.EventHandler(this.tmChangeFont_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hello, My Name Is Abdullah";
            // 
            // btnSubmitTxt
            // 
            this.btnSubmitTxt.Location = new System.Drawing.Point(74, 152);
            this.btnSubmitTxt.Name = "btnSubmitTxt";
            this.btnSubmitTxt.Size = new System.Drawing.Size(313, 42);
            this.btnSubmitTxt.TabIndex = 2;
            this.btnSubmitTxt.Text = "Submit";
            this.btnSubmitTxt.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.ContextMenuStrip = this.cmFormat;
            this.textBox1.Location = new System.Drawing.Point(74, 113);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(313, 24);
            this.textBox1.TabIndex = 3;
            // 
            // tmClear
            // 
            this.tmClear.Name = "tmClear";
            this.tmClear.Size = new System.Drawing.Size(210, 24);
            this.tmClear.Text = "Clear";
            this.tmClear.Click += new System.EventHandler(this.tmClear_Click);
            // 
            // frmContextMenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSubmitTxt);
            this.Controls.Add(this.label1);
            this.Name = "frmContextMenue";
            this.Text = "frmContextMenue";
            this.cmFormat.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmFormat;
        private System.Windows.Forms.ToolStripMenuItem tmChangeColor;
        private System.Windows.Forms.ToolStripMenuItem tmChangeFont;
        private System.Windows.Forms.ToolStripMenuItem tmClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmitTxt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}