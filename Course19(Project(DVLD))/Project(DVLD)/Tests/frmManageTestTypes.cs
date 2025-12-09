using DVLD_BusinessLayer.Tests;
using Project_DVLD_.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DVLD_.Tests
{
    public partial class frmManageTestTypes : Form
    {

        DataTable dt;
        public frmManageTestTypes()
        {
            InitializeComponent();
            ManageTestTypes_Load();
        }

        private void ManageTestTypes_Load()
        {
            _RefreshTestTypesTable();
        }

        private void _RefreshTestTypesTable()
        {
            dt = clsTestTypes.ListTestTypes();
            dgvTestTypes.DataSource = dt;


            dgvTestTypes.Columns[0].Width = 100;
            dgvTestTypes.Columns[0].HeaderText = "TestID";

            dgvTestTypes.Columns[1].Width = 200;
            dgvTestTypes.Columns[1].HeaderText = "TestTitle";

            dgvTestTypes.Columns[2].Width = 250;
            dgvTestTypes.Columns[2].HeaderText = "Test Description";

            dgvTestTypes.Columns[3].Width = 105;
            dgvTestTypes.Columns[3].HeaderText = "Test Fees";

            lbRecords.Text = "Total Records: " + dgvTestTypes.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm  = new frmEditTestType((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshTestTypesTable();
        }
    }
}
