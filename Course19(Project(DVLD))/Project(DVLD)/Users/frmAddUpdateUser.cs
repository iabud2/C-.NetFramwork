using DVLD_BusinessLayer;
using DVLD_BusinessLayer.GeneralClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DVLD_.Users
{
    public partial class frmAddUpdateUser : Form
    {
        private clsUsers _User1;
        private int _UserID;
        private enum enMode {AddNew = 0, Update =1};
        enMode Mode;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }


        public frmAddUpdateUser(int userID)
        {
            InitializeComponent();
            _UserID = userID;
            Mode = enMode.Update;
        }


        
        private void _ResetDefaultValues()
        {
            if(Mode == enMode.AddNew) 
            {
                lbFormTitle.Text = "Add New User";
                this.Text = "Add New User";
                _User1 = new clsUsers();
                this.Text = "Add New User";
                tpLoginInfo.Enabled = false;
            }
            else 
            {
                lbFormTitle.Text = "Update User";
                this.Text = "Update User";
                tpLoginInfo.Enabled = true;
                btnNext.Enabled = true;
                btnSave.Enabled = true;
                this.Text = "Update User Info";
                return;
            }

            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cbIsActive.Enabled = true;

        }

        private void _LoadUserData()
        {
            _User1 = clsUsers.FindUser(_UserID);
            ucFindPerson1.FilterEnabled = false;

            if( _User1 == null)
            {
                MessageBox.Show("No User With ID = " + _UserID, "User Not Foud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            ucFindPerson1.LoadPersonInfo(_User1.PersonID);
            lbShowUserId.Text = _UserID.ToString();
            txtUserName.Text = _User1.UserName;
            txtPassword.Text = _User1.Password;
            txtConfirmPassword.Text = _User1.Password;
            cbIsActive.Checked = _User1.IsActive;
        }




        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            
            if(Mode == enMode.Update) 
                _LoadUserData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcUserManagment.SelectedTab = tcUserManagment.TabPages["tpLoginInfo"];
                return;
            }

            if(ucFindPerson1.PersonID != -1)
            {
                if(clsUsers.isUserExistsForPersonID(ucFindPerson1.PersonID)) 
                {
                    MessageBox.Show("Selected Person is Already User!", "Already User", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }
                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcUserManagment.SelectedTab = tcUserManagment.TabPages["tpLoginInfo"];
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person!", "No Person Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }

            if (Mode == enMode.AddNew)
            {
                if(clsUsers.isExists(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "Username user by nother person!");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }
            }
            else
            {
                if(_User1.UserName != txtUserName.Text.Trim()) 
                {
                    if(clsUsers.isExists(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "Username user by nother person!");
                    }
                    else 
                    {
                        errorProvider1.SetError(txtUserName, null);
                    }
                }
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtPassword.Text.Trim())) 
            {
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel= true;
                errorProvider1.SetError(txtConfirmPassword, "Password confirmation does not match password");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren()) 
            {
                MessageBox.Show("Some Fields are not valid, check the red icons(s) behind the fields", "Save Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _User1.UserName = txtUserName.Text.Trim();
            _User1.PersonID = ucFindPerson1.PersonID;
            _User1.Password = txtPassword.Text.Trim();
            _User1.IsActive = cbIsActive.Checked;

            if (Mode == enMode.Update)
            {
                int loggedInUserID = clsGlobal.CurrentUserLogedin.UserID;

                if (clsGlobal.CurrentUserLogedin.IsActive != cbIsActive.Checked)
                {
                    MessageBox.Show("You can't change your activation status contact with admin",
                                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (_User1.Save())
            {
                Mode = enMode.Update;
                lbFormTitle.Text = "Update User";
                this.Text = "Update User";
                lbShowUserId.Text = _User1.UserID.ToString();

                MessageBox.Show("Data Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data doesn't Saved, Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
