using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DVLD_ 
{
    public partial class frmMainScreen : Form
    {
        public frmMainScreen()
        {
            InitializeComponent();
        }


        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form PeopleForm = new frmManagePeople();
            PeopleForm.ShowDialog();
        }
    }
}
