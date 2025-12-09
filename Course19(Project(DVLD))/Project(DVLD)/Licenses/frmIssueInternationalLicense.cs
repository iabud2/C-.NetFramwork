using DVLD_BusinessLayer.Application;
using DVLD_BusinessLayer.Drivers;
using DVLD_BusinessLayer.GeneralClasses;
using DVLD_BusinessLayer.Licenses;
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
    public partial class frmIssueInternationalLicense: Form
    {
        clsInternationalLicenses NewInternationalLicense = new clsInternationalLicenses();

        public frmIssueInternationalLicense()
        {
            InitializeComponent();
        }
        
        public frmIssueInternationalLicense(int DriverID)
        {
            InitializeComponent();
            clsLicenses LicenseInfo = clsLicenses.GetSpecificLicenseForDriver(DriverID, 13);
            ucFindLicense1.FillData(LicenseInfo.LicenseID);
            ucFindLicense1_OnLicenseSelected(LicenseInfo.LicenseID);
        }

        private void frmIssueInternationalLicense_Load(object sender, EventArgs e)
        {
            lbPaidFees.Text = clsApplicationTypes.GetApplicationTypeInfo(Convert.ToInt32
                            (clsApplications.enApplicaionType.NewInternationalDrivingLicense)).ApplicationFees.ToString();
            lbCreatedBy.Text = clsGlobal.CurrentUserLogedin.UserName;
            lbApplicationDate.Text = DateTime.Now.ToString();
            lbLastStatusDate.Text = DateTime.Now.ToString();
            if(NewInternationalLicense == null)
            {
                btnIssue.Enabled = false;
            }
        }

        private void ucFindLicense1_OnLicenseSelected(int obj)
        {
            if(clsInternationalLicenses.IsExist_ByLLID(obj))
            {
                MessageBox.Show($"Driver Already Have an Active International License!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gbApplicationInfo.Enabled = false;
                return;
            }
            btnIssue.Enabled = true;
            lblShowLicenseHistory.Enabled = true;
           

        }

        private void btnCLose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnIssue_Click(object sender, EventArgs e)
        {
            NewInternationalLicense.ApplicationDate = DateTime.Now;
            NewInternationalLicense.PersonID = ucFindLicense1.LicenseInfo.DriverInfo.PersonID;
            NewInternationalLicense.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            NewInternationalLicense.PaidFees = clsApplicationTypes.GetApplicationTypeInfo(6).ApplicationFees;
            NewInternationalLicense.ApplicationType = (int)clsApplications.enApplicaionType.NewInternationalDrivingLicense;
            NewInternationalLicense.LastStatusDate = DateTime.Now;
            NewInternationalLicense.CreatedByUser = clsGlobal.CurrentUserLogedin.UserID;
            NewInternationalLicense.DriverID = ucFindLicense1.LicenseInfo.DriverID;
            NewInternationalLicense.LocalLicenseID = ucFindLicense1.LicenseID;
            NewInternationalLicense.IssueDate = DateTime.Now;
            NewInternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            NewInternationalLicense.IsActive = true;
            
            if(!NewInternationalLicense.SaveIL())
            {
                MessageBox.Show($"Failed to Issue International License, try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ucFindLicense1.ActiveSearch(false);
            MessageBox.Show($"International License Issued Successfully With LicenseID: {NewInternationalLicense.InternationalLicenseID}", 
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblShowLicenseInfo.Enabled = true;
            lbApplicationID.Text = NewInternationalLicense.ApplicationID.ToString();
            lbInternationalLicenseID.Text = NewInternationalLicense.InternationalLicenseID.ToString();
            lbLastStatusDate.Text = DateTime.Now.ToString();
            lbExpirationDate.Text = NewInternationalLicense.ExpirationDate.ToString();
            lbPersonID.Text = NewInternationalLicense.PersonID.ToString();
            lbLocalLicenseID.Text = NewInternationalLicense.LocalLicenseID.ToString();
            gbApplicationInfo.Enabled = true;
            btnIssue.Enabled = false;


        }

        private void lblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowLicenseHistory(ucFindLicense1.LicenseInfo.DriverID);
            frm.ShowDialog();
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShow_IL_Info(ucFindLicense1.LicenseInfo.DriverID);
            frm.ShowDialog();
        }
    }
}
