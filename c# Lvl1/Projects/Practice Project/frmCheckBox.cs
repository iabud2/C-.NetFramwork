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
    public partial class frmCheckBox : Form
    {
        public frmCheckBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(chkTomato.Checked.ToString());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = chkTomato.Checked;
        }


        private void rdbtnMedium_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmCheckBox_Load(object sender, EventArgs e)
        {

        }

        private void btnRadiobtnStatus_Click(object sender, EventArgs e)
        {
            if(rdbtnSmall.Checked == true) 
            {
                MessageBox.Show("your pizza is small!");
            }
            else if (rdbtnMedium.Checked == true)
            {
                MessageBox.Show("your pizza is Medium!");
            }
            else if (rdbtnLarge.Checked == true)
            {
                MessageBox.Show("your pizza is Large!");
            }
        }

        private void btnCheckPizzaCrust_Click(object sender, EventArgs e)
        {
            if (rdbtnThick.Checked == true)
            {
                MessageBox.Show("your pizza has a thick crust!");
            }
            else if (rdbtnThin.Checked == true)
            {
                MessageBox.Show("your pizza has a thin crust!");
            }
        }
    }
}
