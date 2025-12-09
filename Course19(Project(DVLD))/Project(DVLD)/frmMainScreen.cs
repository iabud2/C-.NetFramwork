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
using Project_DVLD_.Users;
using DVLD_BusinessLayer.GeneralClasses;
using Project_DVLD_.Applications;
using Project_DVLD_.Tests;
using Project_DVLD_.Licenses;
namespace Project_DVLD_ 
{
    public partial class frmMainScreen : Form
    {
        private Form _frmLogin = new LoginScreen();
        public frmMainScreen(Form frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }


        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form PeopleForm = new frmPeopleList();
            PeopleForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            pbUserImage.ImageLocation = clsGlobal.CurrentUserLogedin.GetUserImage();
            lbUserName.Text = "User: " + clsGlobal.CurrentUserLogedin.GetFirstName();
        }




        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUserLogedin = null;
            _frmLogin.Show();
            this.Close();
        }

        private void currenstUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUserInfo(clsGlobal.CurrentUserLogedin.UserID);
            frm.ShowDialog();
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmChangePassword(clsGlobal.CurrentUserLogedin.UserID);
            frm.ShowDialog();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateUser();
            frm.ShowDialog();
        }

        private void usersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListUsers();
            frm.ShowDialog();
        }



        private void peopleListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FPeopleList = new frmPeopleList();
            FPeopleList.ShowDialog();
        }

        private void findPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindPerson frm = new frmFindPerson();
            frm.ShowDialog();
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeletePerson frm = new frmDeletePerson();
            frm.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FAddNew = new frmAddUpdatePerson();
            FAddNew.ShowDialog();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmApplicationTypes = new frmManageApplicationTypes();
            frmApplicationTypes.ShowDialog();  
        }

        private void managgeTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageTestTypes();
            frm.ShowDialog();
        }

        private void localLicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateLDL_Application();
            frm.ShowDialog();
        }
        private void glovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmIssueInternationalLicense();
            frm.ShowDialog();
        }

        private void localDrivingLicensesApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmLDLAL_List();
            frm.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frm_IL_List();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmRenewDrivingLicense();
            frm.ShowDialog();
        }

        private void replacmentForLostOrDamageLicencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReplacement_LostDamaged_License();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmDriversList();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void mangageDetainedLicenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageDetainedLicenses();
            frm.ShowDialog();
        }
    }
}
