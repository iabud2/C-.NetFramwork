using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DVLD_.Applications
{
    public partial class frmShowLDLA_Info : Form
    {
        private int _LDLA_ID = -1;
        public frmShowLDLA_Info(int LDLA_ID)
        {
            InitializeComponent();
            _LDLA_ID = LDLA_ID;
        }


        private void btnCLose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLDLA_Info_Load(object sender, EventArgs e)
        {
            if(_LDLA_ID == -1)
            {
                MessageBox.Show("Application Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ucShowApplicationInfo1.LoadInfo(_LDLA_ID);
        }
    }
}
