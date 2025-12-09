using DVLD_BusinessLayer;
using DVLD_BusinessLayer.Application;
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
    public partial class frmReplacement_LostDamaged_License : Form
    {
        public frmReplacement_LostDamaged_License()
        {
            InitializeComponent();
        }

        private int SelectedLicenseID = -1;
        private clsLicenses OldLicense;
        private clsLicenses NewLicense;

        private void ucFindLicense1_OnLicenseSelected(int obj)
        {
            SelectedLicenseID = obj;
            OldLicense = clsLicenses.GetLicenseInfo(SelectedLicenseID);
            lblShowLicenseHistory.Enabled = true;

            if (!OldLicense.IsActive)
            {
                MessageBox.Show($"License With ID : {OldLicense.LicenseID} Not Active.", "Not Active!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssue.Enabled = false;
                gbApplicationInfo.Enabled = false;
                gbApplicationType.Enabled = false;
                return;
            }


            if (OldLicense.isLicenseExpired())
            {
                MessageBox.Show($"Selected License Is Expired!", "Expired!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssue.Enabled = false;
                gbApplicationInfo.Enabled = false;
                gbApplicationType.Enabled = false;
                return;
            }

  
            btnIssue.Enabled = true;
            gbApplicationInfo.Enabled = true;
            gbApplicationType.Enabled = true;
            NewLicense = OldLicense;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(rbReplaceForLost.Checked)
            {
                if (NewLicense.ReplaceForLost(txtNotes.Text) == null)
                {
                    MessageBox.Show("Failed To Replace License, Contact With Admin!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (rbReplaceForDamaged.Checked)
            {
                if (NewLicense.ReplaceForDamaged(txtNotes.Text) == null)
                {
                    MessageBox.Show("Failed To Replace License, Contact With Admin!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            btnIssue.Enabled = false;
            lbRenewApplicationID.Text = NewLicense.ApplicationID.ToString();
            lbExpiredLicenseID.Text = OldLicense.ApplicationID.ToString();
            lbApplicationDate.Text = DateTime.Now.ToString();
            lbExpirationDate.Text = NewLicense.ExpirationDate.ToString();
            lbIssueDate.Text = NewLicense.IssueDate.ToString();
            lbNewLicenseID.Text = NewLicense.LicenseID.ToString();
            lbApplicationFees.Text = clsApplicationTypes.GetApplicationTypeInfo((int)clsApplications.enApplicaionType.RenewDrivinLicense).ApplicationFees.ToString();
            lbLicenseFees.Text = clsLicenseClasses.Find(NewLicense.LicenseClassID).ClassFees.ToString();
            lbTotalFees.Text = (clsApplicationTypes.GetApplicationTypeInfo((int)clsApplications.enApplicaionType.RenewDrivinLicense).ApplicationFees + 
                            clsLicenseClasses.Find(NewLicense.LicenseClassID).ClassFees).ToString();
            lbCreatedBy.Text = clsGlobal.CurrentUserLogedin.UserName;

            lblShowLicenseInfo.Enabled = true;
        }

        private void lblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowLicenseHistory(OldLicense.DriverID);
            frm.ShowDialog();
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowLicenseInfo(NewLicense.ApplicationID);
            frm.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCLose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblShowLicenseInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowLicenseInfo(NewLicense.ApplicationID);
            frm.ShowDialog();
        }

        private void lblShowLicenseHistory_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowLicenseHistory(OldLicense.DriverID);
            frm.ShowDialog();
        }


    }
}
