using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c__advanced.delegation
{
    public partial class frmDelegation1 : Form
    {
        public frmDelegation1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDelegation2 frm3 = new frmDelegation2();
            frm3.Show();
            frm3.DataBack += Frm3_DataBack;
        }

        private void Frm3_DataBack(object sender, int PersonID)
        {
            MessageBox.Show("Person ID received: " + PersonID.ToString());
            textBox1.Text = PersonID.ToString();
        }
    }
}
