using DVLD_BusinessLayer.Application;
using DVLD_BusinessLayer.Drivers;
using DVLD_BusinessLayer.GeneralClasses;
using DVLD_BusinessLayer.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DVLD_.Licenses
{
    partial class frmIssueLocalDrivingLicense : Form
    {
        private int _LDLA_ID = -1;
        private cls_LDLA _LDLA_Info;
        public frmIssueLocalDrivingLicense(int LDLA_ID)
        {
            InitializeComponent();
            _LDLA_ID = LDLA_ID;
        } 

        private  void _LoadInfo()
        {
            if (_LDLA_ID == -1)
                return;
            ucShowApplicationInfo1.LoadInfo(_LDLA_ID);
            _LDLA_Info = cls_LDLA.GetLDLAInfo(_LDLA_ID);
            

        }

        private void frmIssueLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsDrivers Driver1 = new clsDrivers();
            clsLicenses license1 = new clsLicenses();
            if (!clsDrivers.isDriver(_LDLA_Info.PersonID))
            {
                Driver1.PersonID = _LDLA_Info.PersonID;
                Driver1.CreatedBy = clsGlobal.CurrentUserLogedin.UserID;
                Driver1.CreatedDate = DateTime.Now;
                if (!Driver1.Save())
                {
                    MessageBox.Show("Failed To Add New Driver, Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                Driver1 = clsDrivers.GetDriverInfoByPersonID(_LDLA_Info.PersonID);
            }

            license1.ApplicationID = _LDLA_Info.ApplicationID;
            license1.DriverID = Driver1.DriverID;
            license1.LicenseClassID = _LDLA_Info.LicenseClassID;
            license1.IssueDate = DateTime.Now;
            license1.ExpirationDate = license1.IssueDate.AddYears(_LDLA_Info.LicenseClassInfo.DefaultValidityDate);
            license1.Notes = txtNotes.Text;
            license1.PaidFees = _LDLA_Info.LicenseClassInfo.ClassFees;
            license1.IsActive = true;
            license1.IssueReason = _LDLA_Info.LicenseClassInfo.ClassDescription;
            license1.CreatedBy = clsGlobal.CurrentUserLogedin.UserID;

            if(!license1.Save())
            {
                MessageBox.Show("Failed To Issue New License! Try Again.",
                 "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }
            else
            {
                MessageBox.Show("License Added Successfully With LicenseID = " + license1.LicenseID.ToString(),
                                 "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _LDLA_Info.ApplicationStatus = clsApplications.enApplicationStatus.Completed;

            if (!_LDLA_Info.SetComplete())
            {
                MessageBox.Show("Failed To Update Application Status, Contact With Your Admin!",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Application Status Updated Successfully!",
                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();

        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
