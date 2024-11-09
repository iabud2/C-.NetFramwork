using DVLD_BusinessLayer;
using DVLD_BusinessLayer.Application;
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

namespace Project_DVLD_.Applications
{
    public partial class frmAddUpdateLDL_Apllication : Form
    {
        enum enMode {AddNew =0, Update = 1}
        enMode Mode;
        cls_LDLA LDL_Application;
        int ApplicationID = -1;
        int LDLA_ID;
        public frmAddUpdateLDL_Apllication()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }

        public frmAddUpdateLDL_Apllication(int ldla_ID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            this.LDLA_ID = ldla_ID;
        }

        private void LoadInfo()
        {
            ucFindPerson1.FilterEnabled = false;
            LDL_Application = cls_LDLA.GetLDLAInfo(LDLA_ID);
            this.ApplicationID = cls_LDLA.GetLDLAInfo(LDLA_ID).ApplicationID;

            if (LDL_Application == null)
            {
                MessageBox.Show("No Application With ID:" + LDLA_ID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            ucFindPerson1.LoadPersonInfo(LDL_Application.PersonID);
            lbLDLA_ID.Text = LDLA_ID.ToString();
            lbApplicationDate.Text = LDL_Application.ApplicationDate.ToString();
            cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(clsLicenseClasses.Find(LDL_Application.LicenseClassID).ClassName);
            lbApplicationFees.Text = LDL_Application.PaidFees.ToString();
            lbCreatedBy.Text = LDL_Application.CreatedByUserInfo.UserName;
        }   


        private void Fill_LicenseClasses()
        {
            DataTable dt = clsLicenseClasses.ListLicenseClasses();

            foreach (DataRow dr in dt.Rows) 
            {
                cbLicenseClasses.Items.Add(dr["ClassName"]);
            }
        }        


        private void _ResetDefaultValues()
        {
            Fill_LicenseClasses();
            if(Mode == enMode.AddNew)
            {
                lbTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                LDL_Application = new cls_LDLA();
                tpApplicationInfo.Enabled = false;
                cbLicenseClasses.SelectedIndex = 1;
                lbApplicationFees.Text = clsApplicationTypes.GetApplicationTypeInfo(
                                            (int)clsApplications.enApplicaionType.NewDrivingLicense).ApplicationFees.ToString();
                lbApplicationDate.Text = DateTime.Now.ToShortDateString();
                lbCreatedBy.Text = clsGlobal.CurrentUserLogedin.UserName.ToString();
            }
            else
            {
                lbTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
                btnNext.Enabled = true;
            }

        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if(Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcLDLA.SelectedTab = tcLDLA.TabPages["tpApplicationInfo"];
                return;
            }
            
            if(ucFindPerson1.PersonID != -1)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcLDLA.SelectedTab = tcLDLA.TabPages["tpApplicationInfo"];
            }
            else
            {
                MessageBox.Show("Make Sure Person Selected", "Select Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnCLose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int isThereAnActiveApplicationID = -1;
            int LicenseClassID = (clsLicenseClasses.Find(cbLicenseClasses.Text)).ClassID;
            isThereAnActiveApplicationID = clsApplications.GetActiveApplicationIDForLicenseClass(ucFindPerson1.PersonID, clsApplications.enApplicaionType.NewDrivingLicense, LicenseClassID);
        
            if(isThereAnActiveApplicationID != -1)
            {
                MessageBox.Show($"There is an Active Application for PersonID{ucFindPerson1.PersonID} in this Class!", 
                                                "Cannot Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            LDL_Application.PersonID = ucFindPerson1.PersonID;
            LDL_Application.ApplicationDate = DateTime.Now;
            LDL_Application.ApplicationType = 1;
            LDL_Application.ApplicationStatus = clsApplications.enApplicationStatus.New;
            LDL_Application.LastStatusDate = DateTime.Now;
            LDL_Application.PaidFees = Convert.ToSingle(lbApplicationFees.Text);
            LDL_Application.CreatedByUser = clsGlobal.CurrentUserLogedin.UserID;
            LDL_Application.LicenseClassID = LicenseClassID;

            if(LDL_Application.Save())
            {
                Mode = enMode.Update;
                lbTitle.Text = "Update Local Driving License Application";
                this.Text = lbTitle.Text;
                MessageBox.Show("Application Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Application doesn't Added Successfully TryAgain!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void frmAddUpdateLDL_Apllication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if(Mode == enMode.Update) 
            {
                LoadInfo();
            }
            return;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
