using DVLD_BusinessLayer;
using DVLD_BusinessLayer.Application;
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

namespace Project_DVLD_.Controls
{
    public partial class ucShowLDLApplicationInfo : UserControl
    {
        private int _LDLAID = -1;
        cls_LDLA LDL_Application;
        public ucShowLDLApplicationInfo()
        {
            InitializeComponent();
        }
        public void LoadInfo(int LDLA_ID)
        {

            LDL_Application = cls_LDLA.GetLDLAInfo(LDLA_ID);
            _LDLAID = LDLA_ID;


            lbDrivingLicenseApplicationID.Text = LDL_Application.LDLA_ID.ToString();
            lbLicenseClass.Text = clsLicenseClasses.Find(LDL_Application.LicenseClassID).ClassName.ToString();
            lbPassedTests.Text = cls_LDLA.TotalPassedTests(LDLA_ID).ToString();
            lbApplicationID.Text = LDL_Application.ApplicationID.ToString();
            lbFees.Text = clsApplicationTypes.GetApplicationTypeInfo(LDL_Application.ApplicationType).ApplicationFees.ToString();
            lbPersonName.Text = LDL_Application.PersonFullName.ToString();
            lbApplicationType.Text = clsApplicationTypes.GetApplicationTypeInfo(LDL_Application.ApplicationType).ApplicationName.ToString();
            lbApplicationDate.Text = LDL_Application.ApplicationDate.ToString();
            lbLastStatusDate.Text = LDL_Application.LastStatusDate.ToString();
            lbApplicationStatus.Text = LDL_Application.StatusText.ToString();
            lbCreatedBy.Text = LDL_Application.CreatedByUserInfo.UserName.ToString();
        }

        private void lblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowPersonDetails(LDL_Application.PersonID);
            frm.ShowDialog();
        }

        private void ucShowApplicationInfo_Load(object sender, EventArgs e)
        {
            if (clsLicenses.isExists_By_AppID(_LDLAID))
            {
                lblLicenseInfo.Enabled = false;
            }
            else
            {
                lblLicenseInfo.Enabled = true;
            }
        }

        private void lblLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LDL_Application.ApplicationStatus == clsApplications.enApplicationStatus.Completed)
            {
                if (!clsLicenses.isExists_By_AppID(LDL_Application.ApplicationID))
                {
                    MessageBox.Show("License Not Found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Form frm = new frmShowLicenseInfo(LDL_Application.ApplicationID);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Application Not Complete", "Not Complete", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
