using DVLD_BusinessLayer.Application;
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
    public partial class frmManageApplicationTypes : Form
    {

        private DataTable _dtApplicationTypes; 




        public frmManageApplicationTypes()
        {
            InitializeComponent();
            _RefreshApplicationTypes();
        }

        private void _RefreshApplicationTypes()
        {
            _dtApplicationTypes = clsApplicationTypes.GetApplicationTypesList();
            dgvApplicationTypes.DataSource = _dtApplicationTypes;

            dgvApplicationTypes.Columns[0].HeaderText = "ID";
            dgvApplicationTypes.Columns[0].Width = 100;

            dgvApplicationTypes.Columns[1].HeaderText = "Name";
            dgvApplicationTypes.Columns[1].Width = 400;

            dgvApplicationTypes.Columns[2].HeaderText = "Fees";
            dgvApplicationTypes.Columns[2].Width = 100;

            lbRecords.Text = dgvApplicationTypes.Rows.Count.ToString()+ " Application Type(s)";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmEditApplicationTYpe((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplicationTypes();
        }
    }
}
