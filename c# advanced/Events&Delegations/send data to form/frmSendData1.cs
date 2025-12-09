using c__advanced.send_data_to_form;
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
    public partial class frmSendData1 : Form
    {
        public frmSendData1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int personID) && textBox1.Text != string.Empty)
            {
                Form form2 = new frmSendData2(personID);
                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter a valid Person ID.");
            }
        }
    }
}
