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
            lbUserName.Text = clsGlobal.CurrentUserLogedin.GetName();
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
            Form frm = new frmAddUpdateLDL_Apllication();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmLDLAL_List();
            frm.ShowDialog();
        }
    }
}
