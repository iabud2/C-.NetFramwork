using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class frmMessageBox : Form
    {
        public frmMessageBox()
        {
            InitializeComponent();
        }

        private void ShowMessageBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi, This Is a MessageBox!");
        }

        private void btnMessageBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi, This Is a MessageBox!", "This Is a title!");
        }

        private void btnShowMessageBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm", "Are You Sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MessageBox.Show("User Pressed Ok!", "result");
            }
        }

        private void btnShowMessagebox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("User Pressed Ok!", "result");
            }
        }

        private void CloseFrm4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btwShowMessageBox5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                MessageBox.Show("User Pressed Ok!", "result");
            }
        }
    }
}
