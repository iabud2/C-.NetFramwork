using DVLD_BusinessLayer.Drivers;
using DVLD_BusinessLayer.Licenses;
using Project_DVLD_.Licenses;
using Project_DVLD_.People;
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
    public partial class frm_IL_List : Form
    {
        public frm_IL_List()
        {
            InitializeComponent();
            _RefreshLicensesTable();
        }

        DataTable dtInternationalLicenses = clsInternationalLicenses.ListInternationalLisenses();


        private void _RefreshLicensesTable()
        {
            dgvInternationalLicenses.DataSource = dtInternationalLicenses;
            lbRecords.Text = dgvInternationalLicenses.Rows.Count.ToString() + " Record(s)";
            dgvInternationalLicenses.Columns[0].Width = 150;
            dgvInternationalLicenses.Columns[1].Width = 100;
            dgvInternationalLicenses.Columns[2].Width = 75;
            dgvInternationalLicenses.Columns[3].Width = 100;
            dgvInternationalLicenses.Columns[4].Width = 150;
            dgvInternationalLicenses.Columns[5].Width = 150;
            dgvInternationalLicenses.Columns[6].Width = 75;
            dgvInternationalLicenses.Columns[7].Width = 100;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewIL_Click(object sender, EventArgs e)
        {
            Form frm = new frmIssueInternationalLicense();
            frm.ShowDialog();
            _RefreshLicensesTable();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Filter = "";
            Filter = cbFilterBy.SelectedItem.ToString();
            dtInternationalLicenses.DefaultView.RowFilter = "";

            if (Filter == "None")
            {
                cbStatus.Visible = false;
                txtSearch.Visible = false;
                return;
            }
            else if (Filter == "IsActive")
            {
                cbStatus.Visible = true;
                txtSearch.Visible = false;
            }
            else
            {
                cbStatus.Visible = false;
                txtSearch.Visible = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterBy();
        }




        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbStatus.Text == "Yes")
            {
                dtInternationalLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", cbFilterBy.Text, true);
                lbRecords.Text = dtInternationalLicenses.Rows.Count.ToString();
            }
            else
            {
                dtInternationalLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", cbFilterBy.Text, false);
                lbRecords.Text = dtInternationalLicenses.Rows.Count.ToString();
            }
        }

        private void FilterBy()
        {
            string Filter = cbFilterBy.Text;

            if (Filter == "None" || txtSearch.Text == string.Empty)
            {
                dtInternationalLicenses.DefaultView.RowFilter = "";
                lbRecords.Text = dtInternationalLicenses.Rows.Count.ToString();
            }
            else
            {
                dtInternationalLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", Filter, txtSearch.Text);
                lbRecords.Text = dtInternationalLicenses.Rows.Count.ToString();
            }

            
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsDrivers Driver = clsDrivers.GetDriverInfo((int)dgvInternationalLicenses.CurrentRow.Cells[2].Value);
            Form frm = new frmShowPersonDetails(Driver.PersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShow_IL_Info((int)dgvInternationalLicenses.CurrentRow.Cells[2].Value);
            frm.ShowDialog();   
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowLicenseHistory((int)dgvInternationalLicenses.CurrentRow.Cells[2].Value);
            frm.ShowDialog();
        }
    }
}
