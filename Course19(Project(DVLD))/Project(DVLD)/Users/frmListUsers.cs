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

namespace Project_DVLD_.Users
{
    public partial class frmListUsers : Form
    {
        public frmListUsers()
        {
            InitializeComponent();
        }

        private DataTable _dtUsers;


        private void _RefreshUsersTable()
        {
            _dtUsers = clsUsers.ListAllUsers();
            dgvUsersList.DataSource = _dtUsers;
            lblRecordsCount.Text = _dtUsers.Rows.Count.ToString();

            dgvUsersList.Columns[0].HeaderText = "User ID";
            dgvUsersList.Columns[0].Width = 110;

            dgvUsersList.Columns[1].HeaderText = "Person ID";
            dgvUsersList.Columns[1].Width = 110;

            dgvUsersList.Columns[2].HeaderText = "Username";
            dgvUsersList.Columns[2].Width = 110;

            dgvUsersList.Columns[3].HeaderText = "isActive";
            dgvUsersList.Columns[3].Width = 110;

            dgvUsersList.Columns[4].HeaderText = "Full Name";
            dgvUsersList.Columns[4].Width = 300;
        }



        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersTable();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            BoxesVisibilityStatus();
        }

        private void FilterBy()
        {
            string Filter = "";
            switch (cbFilterBy.Text)
            {
                case "UserID":
                    Filter = "UserID";
                    break;

                case "Username":
                    Filter = "Username";
                    break;

                case "PersonID":
                    Filter = "PersonID";
                    break;

                case "FullName":
                    Filter = "FullName";
                    break;

                default:
                    Filter = "None";
                    break;

            }

            if (Filter == "None" || tbSearch.Text.Trim() == "")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsersList.Rows.Count.ToString();

                return;
            }

            if (Filter != "FullName" && Filter != "Username")
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", Filter, tbSearch.Text.Trim());
                lblRecordsCount.Text = dgvUsersList.Rows.Count.ToString();

                tbSearch.Focus();
            }
            else
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", Filter, tbSearch.Text.Trim());
                lblRecordsCount.Text = dgvUsersList.Rows.Count.ToString();
                tbSearch.Focus();
            }


        }


        private void BoxesVisibilityStatus()
        {
            if (cbFilterBy.Text != "None" && cbFilterBy.Text != "IsActive")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsersList.Rows.Count.ToString();

                tbSearch.Visible = true;
                tbSearch.Text = string.Empty;
                tbSearch.Focus();
            }
            else
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsersList.Rows.Count.ToString();
                tbSearch.Text = string.Empty;
                tbSearch.Visible = false;
            }

            if (cbFilterBy.Text == "IsActive")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsersList.Rows.Count.ToString();
                cbActivateStatus.Visible = true;
                cbActivateStatus.Focus();
                cbActivateStatus.SelectedIndex = 0;
            }
            else
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsersList.Rows.Count.ToString();
                cbActivateStatus.Visible = false;
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            FilterBy();
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "PersonID" || cbFilterBy.Text == "UserID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void cbActivateStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string isActive = cbActivateStatus.Text;
            string Filter = "isActive";
            switch (cbActivateStatus.Text)
            {
                case "Yes":
                    isActive = "1";
                    break;

                case "No":
                    isActive = "0";
                    break;

                case "All":
                    isActive = cbActivateStatus.Text;
                    break;
            }
            
            if (isActive == "All")
            {
                _dtUsers.DefaultView.RowFilter = "";
            }
            else
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", Filter, isActive);
                lblRecordsCount.Text = dgvUsersList.Rows.Count.ToString();

            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form frm =  new frmAddUpdateUser();
            frm.ShowDialog();
            _RefreshUsersTable();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewUser_Click(sender, e);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateUser((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshUsersTable();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedUserID = (int)dgvUsersList.CurrentRow.Cells[0].Value;

            if(SelectedUserID == clsGlobal.CurrentUserLogedin.UserID)
            {
                MessageBox.Show("You Can't Delete The Current Logged In User!", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((MessageBox.Show("Are you sure you want to delete User with User ID: " + SelectedUserID + " ?", "Delete User", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) == DialogResult.OK)
            {
                if (clsUsers.DeleteUser(SelectedUserID))
                {
                    MessageBox.Show("User Deleted Successfully!", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUsersTable();
                }
                else
                {
                    MessageBox.Show("User Does Not Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUserInfo((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmChangePassword((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }



        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented Yet!", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented Yet!", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
