using DVLD_BusinessLayer;
using DVLD_BusinessLayer.Application;
using DVLD_BusinessLayer.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DVLD_.Applications
{
    public partial class frmReleaseDetainedLicense : Form
    {

        private int _LicenseID = -1;

        private clsLicenses _SelectedLicense = new clsLicenses();

        private clsDetainedLicenses _DetainedInfo = new clsDetainedLicenses();
        
        private clsDetainedLicenses _DetainedLicense = new clsDetainedLicenses();
        
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicense(int DetainID)
        {
            InitializeComponent();
            _DetainedLicense = clsDetainedLicenses.GetDetainInfo(DetainID);
            _LicenseID = _DetainedLicense.LicenseID;
            _SelectedLicense = clsLicenses.GetLicenseInfo(_LicenseID);
            btnRelease.Enabled = true;
            gbDetainInfo.Enabled = true;
            ucFindLicense1.FillData(_LicenseID);
            LoadDetainInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCLose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucFindLicense1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;
            _SelectedLicense = clsLicenses.GetLicenseInfo(_LicenseID);
            if(!_SelectedLicense.isDetained())
            {
                MessageBox.Show($"Selected License With ID:{_LicenseID} is Not Detained!", "Not Detained", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnRelease.Enabled = true;
            gbDetainInfo.Enabled = true;
            LoadDetainInfo();
        }

        private void LoadDetainInfo()
        {
            _DetainedInfo = clsDetainedLicenses.GetActiveDetainInfo(_LicenseID);
            lbDetainID.Text = _DetainedInfo.DetainID.ToString();
            lbLicenseID.Text = _DetainedInfo.LicenseID.ToString();
            lbDetainDate.Text = _DetainedInfo.DetainDate.ToString();
            lbDetainedBy.Text = clsUsers.FindUser(_DetainedInfo.CreatedByUserID).UserName;
            lbFineFees.Text = _DetainedInfo.FineFees.ToString();
            lbReleaseFees.Text = clsApplicationTypes.GetApplicationTypeInfo((int)clsApplications.enApplicaionType.ReleaseDetainedDrivingLicense).ApplicationFees.ToString();
            lbTotalFees.Text = ((clsApplicationTypes.GetApplicationTypeInfo((int)clsApplications.enApplicaionType.ReleaseDetainedDrivingLicense).ApplicationFees)
                                    + _DetainedInfo.FineFees).ToString();
        }
        private void Release()
        {
            clsDetainedLicenses ReleaseLicense = _DetainedInfo;
            if(ReleaseLicense.ReleaseLicense())
            {
                MessageBox.Show("License Released Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRelease.Enabled = false;
                ucFindLicense1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Failed To Release License!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            Release();
        }
    }
}
