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
    public partial class frmDelegation2 : Form
    {
        //Declare a delegate
        public delegate void DataBackHandler(object sender, int PersonID);

        //declare an event of the delegate type
        public event DataBackHandler DataBack;

        public frmDelegation2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int PersonID = -1;
            if (textBox1.Text == string.Empty || !int.TryParse(textBox1.Text, out int ID))
            {
                MessageBox.Show("Please enter a valid ID.");
                return;
            }

            PersonID = int.Parse(textBox1.Text);
            DataBack?.Invoke(this, PersonID);
            this.Close();
        }
    }
}
