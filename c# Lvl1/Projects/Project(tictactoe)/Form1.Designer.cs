using System.Drawing;

namespace Project_tictactoe_
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.lbTurn = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbWinner = new System.Windows.Forms.Label();
            this.btnResetGame = new System.Windows.Forms.Button();
            this.pbBox3 = new System.Windows.Forms.PictureBox();
            this.pbBox9 = new System.Windows.Forms.PictureBox();
            this.pbBox6 = new System.Windows.Forms.PictureBox();
            this.pbBox8 = new System.Windows.Forms.PictureBox();
            this.pbBox4 = new System.Windows.Forms.PictureBox();
            this.pbBox7 = new System.Windows.Forms.PictureBox();
            this.pbBox5 = new System.Windows.Forms.PictureBox();
            this.pbBox2 = new System.Windows.Forms.PictureBox();
            this.pbBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("MV Boli", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(213, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(448, 63);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tic-Tac-Toe Game";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(553, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 45);
            this.label2.TabIndex = 11;
            this.label2.Text = "Turn";
            // 
            // lbTurn
            // 
            this.lbTurn.AutoSize = true;
            this.lbTurn.BackColor = System.Drawing.Color.Black;
            this.lbTurn.Font = new System.Drawing.Font("MV Boli", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurn.ForeColor = System.Drawing.Color.White;
            this.lbTurn.Location = new System.Drawing.Point(560, 164);
            this.lbTurn.Name = "lbTurn";
            this.lbTurn.Size = new System.Drawing.Size(182, 63);
            this.lbTurn.TabIndex = 12;
            this.lbTurn.Tag = "Player1";
            this.lbTurn.Text = "Player1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(553, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 45);
            this.label4.TabIndex = 13;
            this.label4.Text = "Winner";
            // 
            // lbWinner
            // 
            this.lbWinner.AutoSize = true;
            this.lbWinner.BackColor = System.Drawing.Color.Black;
            this.lbWinner.Font = new System.Drawing.Font("MV Boli", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWinner.ForeColor = System.Drawing.Color.Lime;
            this.lbWinner.Location = new System.Drawing.Point(562, 272);
            this.lbWinner.Name = "lbWinner";
            this.lbWinner.Size = new System.Drawing.Size(213, 49);
            this.lbWinner.TabIndex = 14;
            this.lbWinner.Tag = "InProgress";
            this.lbWinner.Text = "In Progress";
            // 
            // btnResetGame
            // 
            this.btnResetGame.BackColor = System.Drawing.Color.Black;
            this.btnResetGame.Font = new System.Drawing.Font("MV Boli", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetGame.ForeColor = System.Drawing.Color.White;
            this.btnResetGame.Location = new System.Drawing.Point(644, 403);
            this.btnResetGame.Name = "btnResetGame";
            this.btnResetGame.Size = new System.Drawing.Size(208, 47);
            this.btnResetGame.TabIndex = 15;
            this.btnResetGame.Text = "Restart Game";
            this.btnResetGame.UseVisualStyleBackColor = false;
            this.btnResetGame.Click += new System.EventHandler(this.btnResetGame_Click);
            // 
            // pbBox3
            // 
            this.pbBox3.Location = new System.Drawing.Point(356, 119);
            this.pbBox3.Name = "pbBox3";
            this.pbBox3.Size = new System.Drawing.Size(119, 83);
            this.pbBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBox3.TabIndex = 10;
            this.pbBox3.TabStop = false;
            this.pbBox3.Tag = "None";
            this.pbBox3.Click += new System.EventHandler(this.ButtonClick);
            // 
            // pbBox9
            // 
            this.pbBox9.Location = new System.Drawing.Point(356, 319);
            this.pbBox9.Name = "pbBox9";
            this.pbBox9.Size = new System.Drawing.Size(119, 83);
            this.pbBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBox9.TabIndex = 9;
            this.pbBox9.TabStop = false;
            this.pbBox9.Tag = "None";
            this.pbBox9.Click += new System.EventHandler(this.ButtonClick);
            // 
            // pbBox6
            // 
            this.pbBox6.Location = new System.Drawing.Point(356, 220);
            this.pbBox6.Name = "pbBox6";
            this.pbBox6.Size = new System.Drawing.Size(119, 83);
            this.pbBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBox6.TabIndex = 8;
            this.pbBox6.TabStop = false;
            this.pbBox6.Tag = "None";
            this.pbBox6.Click += new System.EventHandler(this.ButtonClick);
            // 
            // pbBox8
            // 
            this.pbBox8.Location = new System.Drawing.Point(215, 319);
            this.pbBox8.Name = "pbBox8";
            this.pbBox8.Size = new System.Drawing.Size(119, 83);
            this.pbBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBox8.TabIndex = 7;
            this.pbBox8.TabStop = false;
            this.pbBox8.Tag = "None";
            this.pbBox8.Click += new System.EventHandler(this.ButtonClick);
            // 
            // pbBox4
            // 
            this.pbBox4.Location = new System.Drawing.Point(75, 220);
            this.pbBox4.Name = "pbBox4";
            this.pbBox4.Size = new System.Drawing.Size(119, 83);
            this.pbBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBox4.TabIndex = 6;
            this.pbBox4.TabStop = false;
            this.pbBox4.Tag = "None";
            this.pbBox4.Click += new System.EventHandler(this.ButtonClick);
            // 
            // pbBox7
            // 
            this.pbBox7.Location = new System.Drawing.Point(75, 319);
            this.pbBox7.Name = "pbBox7";
            this.pbBox7.Size = new System.Drawing.Size(119, 83);
            this.pbBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBox7.TabIndex = 5;
            this.pbBox7.TabStop = false;
            this.pbBox7.Tag = "None";
            this.pbBox7.Click += new System.EventHandler(this.ButtonClick);
            // 
            // pbBox5
            // 
            this.pbBox5.Location = new System.Drawing.Point(215, 220);
            this.pbBox5.Name = "pbBox5";
            this.pbBox5.Size = new System.Drawing.Size(119, 83);
            this.pbBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBox5.TabIndex = 4;
            this.pbBox5.TabStop = false;
            this.pbBox5.Tag = "None";
            this.pbBox5.Click += new System.EventHandler(this.ButtonClick);
            // 
            // pbBox2
            // 
            this.pbBox2.Location = new System.Drawing.Point(215, 119);
            this.pbBox2.Name = "pbBox2";
            this.pbBox2.Size = new System.Drawing.Size(119, 83);
            this.pbBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBox2.TabIndex = 3;
            this.pbBox2.TabStop = false;
            this.pbBox2.Tag = "None";
            this.pbBox2.Click += new System.EventHandler(this.ButtonClick);
            // 
            // pbBox1
            // 
            this.pbBox1.Location = new System.Drawing.Point(75, 119);
            this.pbBox1.Name = "pbBox1";
            this.pbBox1.Size = new System.Drawing.Size(119, 83);
            this.pbBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBox1.TabIndex = 2;
            this.pbBox1.TabStop = false;
            this.pbBox1.Tag = "None";
            this.pbBox1.Click += new System.EventHandler(this.ButtonClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Project_tictactoe_.Properties.Resources.blackbg;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(852, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "1";
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 450);
            this.Controls.Add(this.btnResetGame);
            this.Controls.Add(this.lbWinner);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbTurn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbBox3);
            this.Controls.Add(this.pbBox9);
            this.Controls.Add(this.pbBox6);
            this.Controls.Add(this.pbBox8);
            this.Controls.Add(this.pbBox4);
            this.Controls.Add(this.pbBox7);
            this.Controls.Add(this.pbBox5);
            this.Controls.Add(this.pbBox2);
            this.Controls.Add(this.pbBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbBox1;
        private System.Windows.Forms.PictureBox pbBox2;
        private System.Windows.Forms.PictureBox pbBox5;
        private System.Windows.Forms.PictureBox pbBox4;
        private System.Windows.Forms.PictureBox pbBox8;
        private System.Windows.Forms.PictureBox pbBox6;
        private System.Windows.Forms.PictureBox pbBox9;
        private System.Windows.Forms.PictureBox pbBox3;
        private System.Windows.Forms.PictureBox pbBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTurn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbWinner;
        private System.Windows.Forms.Button btnResetGame;
    }
}

