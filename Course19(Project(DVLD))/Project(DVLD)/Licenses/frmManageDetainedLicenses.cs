using DVLD_BusinessLayer.Licenses;
using Project_DVLD_.Applications;
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

namespace Project_DVLD_.Licenses
{
    public partial class frmManageDetainedLicenses : Form
    {

        DataTable dtDetainedLicenses = new DataTable();
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
            _RefreshDetainedTable();
        }


        private void _RefreshDetainedTable()
        {

            dtDetainedLicenses = clsDetainedLicenses.ListDetainedLicenses();
            if (dtDetainedLicenses.Rows.Count < 0)
            {
                contextMenuStrip1.Enabled = false;
                return;
            }
            else
            {
                contextMenuStrip1.Enabled = true;
            }
            dgvDetainList.DataSource = dtDetainedLicenses;
            lbRecords.Text = dgvDetainList.Rows.Count.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Filter()
        {
            string FilterBy = "";

            switch (cbFilterBy.Text)
            {
                case "None":
                    FilterBy = "None";
                    break;
                case "Detain ID":
                    FilterBy = "DetainID";
                    break;
                case "License ID":
                    FilterBy = "LicenseID";
                    break;
                case "Released By":
                    FilterBy = "ReleasedByUserID";
                    break;
                case "Release Application ID":
                    FilterBy = "ReleaseApplicationID";
                    break;
                case "Detained By":
                    FilterBy = "CreatedByUserID";
                    break;
            }

            if(FilterBy == "None" || txtSearch.Text == "")
            {
                dtDetainedLicenses.DefaultView.RowFilter = "";
                lbRecords.Text = dgvDetainList.Rows.Count.ToString();

            }
            else
            {
                dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterBy, txtSearch.Text);
                lbRecords.Text = dgvDetainList.Rows.Count.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                txtSearch.Visible = false;
                cbIsReleased.Visible = false;
                dtDetainedLicenses.DefaultView.RowFilter = "";
                lbRecords.Text = dgvDetainList.Rows.Count.ToString();
            }
            else if (cbFilterBy.Text == "Is Released")
            {
                cbIsReleased.Visible = true;
                txtSearch.Visible = false;
            }
            else
            {
                cbIsReleased.Visible = false;
                txtSearch.Visible = true;
            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsReleased.Text == "Yes")
            {
                dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", "IsReleased", true);
                lbRecords.Text = dgvDetainList.Rows.Count.ToString();
            }
            else
            {
                dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", "IsReleased", false);
                lbRecords.Text = dgvDetainList.Rows.Count.ToString();
            }
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainLicense();
            frm.ShowDialog();
            _RefreshDetainedTable();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLicenses SelectedLicense = clsLicenses.GetLicenseInfo((int)dgvDetainList.CurrentRow.Cells[1].Value);
            Form frm = new frmShowPersonDetails(SelectedLicense.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void shoeLicenseDetailesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLicenses SelectedLicense = clsLicenses.GetLicenseInfo((int)dgvDetainList.CurrentRow.Cells[1].Value);
            Form frm = new frmShowLicenseInfo(SelectedLicense.ApplicationID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLicenses SelectedLicense = clsLicenses.GetLicenseInfo((int)dgvDetainList.CurrentRow.Cells[1].Value);
            Form frm = new frmShowLicenseHistory(SelectedLicense.DriverID);
            frm.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainList.CurrentRow.Cells[1].Value;
            if(!clsDetainedLicenses.isDetained(LicenseID))
            {
                MessageBox.Show("This license is not detained.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Form frm = new frmReleaseDetainedLicense((int)dgvDetainList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshDetainedTable();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
