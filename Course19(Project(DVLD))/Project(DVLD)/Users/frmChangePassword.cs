using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DVLD_.Users
{
    public partial class frmChangePassword : Form
    {
        private int _UserID = -1;
        private clsUsers _user;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _user = clsUsers.FindUser(_UserID);
        }


        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            if (_UserID == -1)
                return;
            if (_user == null)
                return;
            ucUserInformation1.LoadInformation(_UserID);
        }


        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
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
                MessageBox.Show("Make Sure u filled all fields with valid Data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _user.Password = txtPassword.Text.Trim();
            if(_user.Save())
            {
                MessageBox.Show("Password Changed Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Faild to change password TryAgain!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtCurrentPassword.Text.Trim() != _user.Password)
                errorProvider1.SetError(txtCurrentPassword, "Password incorrect!");
            else
                errorProvider1.SetError(txtCurrentPassword, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
