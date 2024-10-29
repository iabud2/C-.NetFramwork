using DVLD_BusinessLayer;
using DVLD_BusinessLayer.GeneralClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Project_DVLD_
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Login()
        {
            clsUsers UserLog = clsUsers.FindUser(tbUserName.Text);
            if (UserLog == null)
            {
                MessageBox.Show("UserName/Password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (UserLog.Password != tbPassword.Text)
            {
                MessageBox.Show("UserName/Password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!UserLog.IsActive)
            {
                MessageBox.Show("This Account is deactivated Contact With Your Manager");
                return false;
            }
            clsGlobal.CurrentUserLogedin = UserLog;
            this.Hide();
            Form frmMain = new frmMainScreen(this);
            frmMain.ShowDialog();
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Login())
            {
                if (cbRememberMe.Checked == true)
                {
                    clsGlobal.RememberLoginInfo(tbUserName.Text.Trim(), tbPassword.Text.Trim());
                }
                else
                {
                    clsGlobal.RememberLoginInfo("", "");
                }
            }
            else
            {
                return;
            }
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            string username = "", password = "";

            if(clsGlobal.RestoreLoginInfo(ref username, ref password))
            {
                tbUserName.Text = username;
                tbPassword.Text = password; 
                cbRememberMe.Checked = true;
            }
            else
            {
                cbRememberMe.Checked = false;
            }
        }
    }
}
