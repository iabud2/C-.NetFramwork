using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class frmPictureBoxExercise : Form
    {
        public frmPictureBoxExercise()
        {
            InitializeComponent();
        }

        private void UpdateImage()
        {
            if (rbBoy.Checked) 
            {
                pbExercise.Image = Image.FromFile(@"C:\Users\iabud\Desktop\Files\pictures\Boy.png");
                return;
            }
            if (rbGirl.Checked) 
            {
                pbExercise.Image = Image.FromFile(@"C:\Users\iabud\Desktop\Files\pictures\Girl.png");
                return;
            }
            if (rbBook.Checked)
            {
                pbExercise.Image = Image.FromFile(@"C:\Users\iabud\Desktop\Files\pictures\Book.png");
                return;
            }
            if (rbPen.Checked)
            {
                pbExercise.Image = Image.FromFile(@"C:\Users\iabud\Desktop\Files\pictures\Pen.png");
                return;
            }

        }

        private void frmPictureBoxExercise_Load(object sender, EventArgs e)
        {
            UpdateImage();
        }
    
        private void rbBoy_CheckedChanged(object sender, EventArgs e)
        {
            lbTitle.Text = ((RadioButton)sender).Tag.ToString();
            UpdateImage();
        }

        private void rbGirl_CheckedChanged(object sender, EventArgs e)
        {
            lbTitle.Text = ((RadioButton)sender).Tag.ToString();
            UpdateImage();
        }

        private void rbBook_CheckedChanged(object sender, EventArgs e)
        {
            lbTitle.Text = ((RadioButton)sender).Tag.ToString();
            UpdateImage();
        }

        private void rbPen_CheckedChanged(object sender, EventArgs e)
        {
            lbTitle.Text = ((RadioButton)sender).Tag.ToString();
            UpdateImage();
        }
    }
}
