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
    public partial class TabControl : Form
    {
        public TabControl()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAge.Text) || string.IsNullOrEmpty(txtCountry.Text)) 
            {
                MessageBox.Show("Fill all Boxes");
                txtName.Clear();
                txtAge.Clear();
                txtCountry.Clear();
                return;
            }
            lblInfo.Text = "Name : " + txtName.Text + Environment.NewLine;
            lblInfo.Text += "Age : " + txtAge.Text + Environment.NewLine;
            lblInfo.Text += "Country : " + txtCountry.Text;
            txtName.Clear();
            txtAge.Clear();
            txtCountry.Clear();
        }
    }
}
