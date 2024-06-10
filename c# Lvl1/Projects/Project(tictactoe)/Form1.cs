using Project_tictactoe_.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_tictactoe_
{
    public partial class Form1 : Form
    {
        stGameStatus GameStatus;
        enTurn PlayerTurn = enTurn.Player1;
        enum enTurn
        {
            Player1,
            Player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;

        }

        private bool CheckValues(PictureBox Box1, PictureBox Box2, PictureBox Box3)
        {
            if (Box1.Tag.ToString() != "None" && Box1.Tag.ToString() == Box2.Tag.ToString() && Box1.Tag.ToString() == Box3.Tag.ToString())
            {
                Box1.BackColor = Color.GreenYellow;
                Box2.BackColor = Color.GreenYellow;
                Box3.BackColor = Color.GreenYellow;

                if (Box1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else if (Box1.Tag.ToString() == "O")
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }
            GameStatus.GameOver = false;
            return false;
        }

        private void EndGame()
        {
            lbTurn.Text = "Game Over";
            switch (GameStatus.Winner)
            {
                case enWinner.Player1:
                    lbWinner.Text = "Player1";
                    break;
                case enWinner.Player2:
                    lbWinner.Text = "Player2";
                    break;
                default:
                    lbWinner.Text = "DraW";
                    break;
            }
            MessageBox.Show("Game Over!", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CheckWinner()
        {
            //HorizontalWin
            //case1:
            if (CheckValues(pbBox1, pbBox2, pbBox3))
                return;
            //case2:
            if (CheckValues(pbBox4, pbBox5, pbBox6))
                return;
            //case3:
            if (CheckValues(pbBox7, pbBox8, pbBox9))
                return;

            //------------
            //VerticalWin
            //case1:
            if (CheckValues(pbBox1, pbBox4, pbBox7))
                return;
            //case2:
            if (CheckValues(pbBox2, pbBox5, pbBox8))
                return;
            //case3:
            if (CheckValues(pbBox3, pbBox6, pbBox9))
                return;
            //------------
            //CrossWin
            //case1:
            if (CheckValues(pbBox1, pbBox5, pbBox9))
                return;
            //case2:
            if (CheckValues(pbBox3, pbBox5, pbBox7))
                return;
        }








        public Form1()
        {
            InitializeComponent();
            ManageBackColors();
        }
       
        private void BoxesBg()
        {
            PictureBox[] pictureBoxes = { pbBox1, pbBox2, pbBox3, pbBox4, pbBox5, pbBox6, pbBox7, pbBox8, pbBox9 };
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.BackColor = Color.Transparent;
                pictureBox.Parent = this.pictureBox1;
                pictureBox.Image = Resources.GreenQuestionMark;
            }
        }

        private void ManageLabelbg()
        {
            label1.BackColor = Color.Transparent;
            label1.Parent = this.pictureBox1;
            label2.BackColor = Color.Transparent;
            label2.Parent = this.pictureBox1;
            label4.BackColor = Color.Transparent;
            label4.Parent = this.pictureBox1;
            lbWinner.BackColor = Color.Transparent;
            lbWinner.Parent = this.pictureBox1;
            lbTurn.BackColor = Color.Transparent;
            lbTurn.Parent = this.pictureBox1;
        }

        byte Counter = 0;
        private void ManageBackColors()
        {
            BoxesBg();
            ManageLabelbg();
        }

        private void Disable()
        {
            pbBox1.Enabled = false;
            pbBox2.Enabled = false;
            pbBox3.Enabled = false;
            pbBox4.Enabled = false;
            pbBox5.Enabled = false;
            pbBox6.Enabled = false;
            pbBox7.Enabled = false;
            pbBox8.Enabled = false;
            pbBox9.Enabled = false;
        }

        private void Reset() 
        {
            //Enable Boxes:

            pbBox1.Enabled = true;
            pbBox2.Enabled = true;
            pbBox3.Enabled = true;
            pbBox4.Enabled = true;
            pbBox5.Enabled = true;
            pbBox6.Enabled = true;
            pbBox7.Enabled = true;
            pbBox8.Enabled = true;
            pbBox9.Enabled = true;
            //Reset Tags:
            pbBox1.Tag = "None";
            pbBox2.Tag = "None";
            pbBox3.Tag = "None";
            pbBox4.Tag = "None"; 
            pbBox5.Tag = "None";
            pbBox6.Tag = "None";
            pbBox7.Tag = "None";
            pbBox8.Tag = "None";
            pbBox9.Tag = "None";
            //Reset Labels:
            lbTurn.Tag = "Player1";
            lbWinner.Tag = "InProgress";
            lbTurn.Text = "Player1";
            lbWinner.Text = "In Progress";
            ManageBackColors();
            Counter = 0;
        }

        private bool IsHorizontalWin()
        {
            //case1 win:
            if (pbBox1.Tag.ToString() == "X" && pbBox2.Tag.ToString() == "X" && pbBox3.Tag.ToString() == "X")
            {
                lbWinner.Tag = "Player1";
                MessageBox.Show("Player1 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player1";
                return true;
            }
            else if (pbBox1.Tag.ToString() == "O" && pbBox2.Tag.ToString() == "O" && pbBox3.Tag.ToString() == "O")
            {
                lbWinner.Tag = "Player2";
                MessageBox.Show("Player2 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player2";
                return true;
            }

            //case2 win:
            if (pbBox4.Tag.ToString() == "X" && pbBox5.Tag.ToString() == "X" && pbBox6.Tag.ToString() == "X")
            {
                lbWinner.Tag = "Player1";
                MessageBox.Show("Player1 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player1";
                return true;

            }
            else if (pbBox4.Tag.ToString() == "O" && pbBox5.Tag.ToString() == "O" && pbBox6.Tag.ToString() == "O")
            {
                lbWinner.Tag = "Player2";
                MessageBox.Show("Player2 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player2";
                return true;
            }

            //case3 win:
            if (pbBox7.Tag.ToString() == "X" && pbBox8.Tag.ToString() == "X" && pbBox9.Tag.ToString() == "X")
            {
                lbWinner.Tag = "Player1";
                MessageBox.Show("Player1 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player1";
                return true;

            }
            else if (pbBox7.Tag.ToString() == "O" && pbBox8.Tag.ToString() == "O" && pbBox9.Tag.ToString() == "O")
            {
                lbWinner.Tag = "Player2";
                MessageBox.Show("Player2 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player2";
                return true;
            }
            
            
            return false;
        }

        private bool IsVerticalWin()
        {
            //case1 win:
            if (pbBox1.Tag.ToString() == "X" && pbBox4.Tag.ToString() == "X" && pbBox7.Tag.ToString() == "X")
            {
                lbWinner.Tag = "Player1";
                MessageBox.Show("Player1 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player1";
                return true;
            }
            else if (pbBox1.Tag.ToString() == "O" && pbBox4.Tag.ToString() == "O" && pbBox7.Tag.ToString() == "O")
            {
                lbWinner.Tag = "Player2";
                MessageBox.Show("Player2 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player2";
                return true;
            }

            //case2 win:
            if (pbBox2.Tag.ToString() == "X" && pbBox5.Tag.ToString() == "X" && pbBox8.Tag.ToString() == "X")
            {
                lbWinner.Tag = "Player1";
                MessageBox.Show("Player1 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player1";
                return true;

            }
            else if (pbBox2.Tag.ToString() == "O" && pbBox5.Tag.ToString() == "O" && pbBox8.Tag.ToString() == "O")
            {
                lbWinner.Tag = "Player2";
                MessageBox.Show("Player2 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player2";
                return true;
            }

            //case3 win:
            if (pbBox3.Tag.ToString() == "X" && pbBox6.Tag.ToString() == "X" && pbBox9.Tag.ToString() == "X")
            {
                lbWinner.Tag = "Player1";
                MessageBox.Show("Player1 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player1";
                return true;
            }
            else if (pbBox3.Tag.ToString() == "O" && pbBox6.Tag.ToString() == "O" && pbBox9.Tag.ToString() == "O")
            {
                lbWinner.Tag = "Player2";
                MessageBox.Show("Player2 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player2";
                return true;
            }
         
            return false;
        }

        private bool IsCrossWin()
        {
            //case1 win:
            if (pbBox1.Tag.ToString() == "X" && pbBox5.Tag.ToString() == "X" && pbBox9.Tag.ToString() == "X")
            {
                lbWinner.Tag = "Player1";
                MessageBox.Show("Player1 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player1";
                return true;
            }
            else if (pbBox1.Tag.ToString() == "O" && pbBox5.Tag.ToString() == "O" && pbBox9.Tag.ToString() == "O")
            {
                lbWinner.Tag = "Player2";
                MessageBox.Show("Player2 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player2";
                return true;
            }

            //case2 win:
            if (pbBox3.Tag.ToString() == "X" && pbBox5.Tag.ToString() == "X" && pbBox7.Tag.ToString() == "X")
            {
                lbWinner.Tag = "Player1";
                MessageBox.Show("Player1 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player1";
                return true;
            }
            else if (pbBox3.Tag.ToString() == "O" && pbBox5.Tag.ToString() == "O" && pbBox7.Tag.ToString() == "O")
            {
                lbWinner.Tag = "Player2";
                MessageBox.Show("Player2 Won!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbWinner.Text = "Player2";
                return true;
            }
        
            return false;
        }

        private bool IsWin()
        {
            if(IsHorizontalWin() || IsVerticalWin() || IsCrossWin())
            {
                Disable();
                return true;
            }
            return false;            
        }
        
        private void Draw()
        {
            lbWinner.Text = "Draw";
            MessageBox.Show("Draw!", "Draw", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lbTurn.Text = "Game Over";
            Disable();
        }

        private bool IsGameOver()
        {
            if(IsWin())
            {
                lbTurn.Text = "Game Over";
                return true;
            }
            
            if(Counter == 9)
            {
                Draw();
                Disable();
                return true;
            }
            return false;
        }

        private void Choice(PictureBox PlayerChoice)
        {
            if (PlayerChoice.Tag.ToString() == "None" && lbTurn.Tag.ToString() == "Player1")
            {
                PlayerChoice.Image = Resources.Xmark;
                PlayerChoice.Tag = "X";
                lbTurn.Tag = "Player2";
                lbTurn.Text = "Player2";
                Counter++;
                IsGameOver();
            }
            else if (PlayerChoice.Tag.ToString() == "None" && lbTurn.Tag.ToString() == "Player2")
            {
                PlayerChoice.Image = Resources.Omark;
                PlayerChoice.Tag = "O";
                lbTurn.Tag = "Player1";
                lbTurn.Text = "Player1";
                Counter++;
                IsGameOver();
            }
            else
            {
                MessageBox.Show("Wrong Choice Try Again!", "WrongChoice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.White;
            Pen pen = new Pen(White);
            pen.Width = 8;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 200, 120, 200, 410);
            e.Graphics.DrawLine(pen, 350, 120, 350, 410);
            e.Graphics.DrawLine(pen, 70, 310, 450, 310);
            e.Graphics.DrawLine(pen, 70, 210, 450, 210);

        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Choice((PictureBox)sender);
        }
    
        private void btnResetGame_Click(object sender, EventArgs e)
        {
            Reset();
        }

    }
}
