using DVLD_BusinessLayer.GeneralClasses;
using DVLD_BusinessLayer.Licenses;
using Project_DVLD_.Licenses;
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
    public partial class frmDetainLicense : Form
    {
        private int _LicenseID = -1;
        private clsLicenses _SelectedLicense = new clsLicenses();
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void ucFindLicense1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;
            _SelectedLicense = clsLicenses.GetLicenseInfo(_LicenseID);
            if (!_SelectedLicense.IsActive)
            {
                MessageBox.Show("Selected License Not Active, Choose Active License!", "Not Active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_SelectedLicense.isDetained())
            {
                MessageBox.Show("Selected License Already Detained, Release The License To Detain it Again", "Detained", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            lbLicenseID.Text = _LicenseID.ToString();
            gbDetainInfo.Enabled =true;
            btnDetain.Enabled = true;
            lblShowLicenseHistory.Enabled = true;
            lblShowLicenseInfo.Enabled = true;
        }

        private void Detain()
        {
            clsDetainedLicenses DetainLicense = new clsDetainedLicenses();
            DetainLicense.LicenseID = _LicenseID;
            DetainLicense.FineFees = Convert.ToSingle(txtFineFees.Text);
            DetainLicense.DetainDate =DateTime.Now;
            DetainLicense.CreatedByUserID = clsGlobal.CurrentUserLogedin.UserID;
            DetainLicense.IsReleased = false;

            if (DetainLicense.DetainLicense())
            {
                MessageBox.Show("License Detained Successfully");
                lbDetainID.Text = DetainLicense.DetainID.ToString();
                lbDetainDate.Text = DetainLicense.DetainDate.ToString();
                lbDetainedBy.Text = clsGlobal.CurrentUserLogedin.UserName;
                txtFineFees.Text = DetainLicense.FineFees.ToString();
                txtFineFees.ReadOnly = true;
                gbDetainInfo.Enabled= true;
                ucFindLicense1.Enabled = false;
                btnDetain.Enabled = false;
            }
            else
            {
                MessageBox.Show("Failed To Detain License");
            }
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if(txtFineFees.Text==string.Empty)
            {
                MessageBox.Show("Please Enter Fine Fees To Detain License", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Detain();
        }

        private void btnCLose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowLicenseHistory(_SelectedLicense.DriverID);
            frm.ShowDialog();
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowLicenseInfo(_SelectedLicense.ApplicationID);
            frm.ShowDialog();
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
