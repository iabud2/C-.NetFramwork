using c__advanced.delegation;
using c__advanced.events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c__advanced
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new frmSendData1();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new frmDelegation1();
            frm.ShowDialog();
        }

        private void btnCalculatorEvent_Click(object sender, EventArgs e)
        {
            Form frm = new frmEvent1();
            frm.ShowDialog();
        }
    }
}
