using DVLD_BusinessLayer.Application;
using Project_DVLD_.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer.Tests;
using Project_DVLD_.Licenses;
using DVLD_BusinessLayer.Drivers;
namespace Project_DVLD_.Applications
{
    public partial class frmLDLAL_List : Form
    {
        DataTable dt_LDLA;
        public frmLDLAL_List()
        {
            InitializeComponent();
            _RefreshLDLA_List();
        }

        
        private void _RefreshLDLA_List()
        {
            dt_LDLA = cls_LDLA.ListAll_LDLA();
            dgvLDLA_List.DataSource = dt_LDLA;
            
            dgvLDLA_List.Columns[0].Width = 100;
            dgvLDLA_List.Columns[0].HeaderText = "LDLA_ID";
            dgvLDLA_List.Columns[1].Width = 250;
            dgvLDLA_List.Columns[2].Width = 100;
            dgvLDLA_List.Columns[3].Width = 250;
            dgvLDLA_List.Columns[4].Width = 150;
            dgvLDLA_List.Columns[5].Width = 99;
            dgvLDLA_List.Columns[6].Width = 100;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewLDLA_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateLDL_Application();
            frm.ShowDialog();
            _RefreshLDLA_List();
        }

        private void HandleCmsComponents()
        {
            int SelectedLDLA_ID = (int)dgvLDLA_List.CurrentRow.Cells[0].Value;
            string ApplicationStatus = dgvLDLA_List.CurrentRow.Cells[6].Value.ToString();


            if (ApplicationStatus == "Canceled")
            {
                editApplicationToolStripMenuItem.Enabled = false;
                sechduleTestToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
            }
            else if (ApplicationStatus == "Completed")
            {
                editApplicationToolStripMenuItem.Enabled = false;
                DeleteApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                sechduleTestToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = true; ;

            }
            else if (ApplicationStatus == "New")
            {
                editApplicationToolStripMenuItem.Enabled = true;
                DeleteApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;
                sechduleTestToolStripMenuItem.Enabled = true;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                showLicenseToolStripMenuItem.Enabled = false;
            }
            else
            {
                editApplicationToolStripMenuItem.Enabled = true;
                sechduleTestToolStripMenuItem.Enabled = true;
                DeleteApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;

            }



            if(cls_LDLA.DoesPassTestType(SelectedLDLA_ID, clsTestTypes.enTestType.VisionTest))
                sechduleVisionTestToolStripMenuItem.Enabled = false;
            else
                sechduleVisionTestToolStripMenuItem.Enabled = true;
           
            if (cls_LDLA.DoesPassTestType(SelectedLDLA_ID, clsTestTypes.enTestType.WrittenTest))
            
                sechduleWrittenTestToolStripMenuItem.Enabled = false;
            else
                sechduleWrittenTestToolStripMenuItem.Enabled = true;
         
            if (cls_LDLA.DoesPassTestType(SelectedLDLA_ID, clsTestTypes.enTestType.StreetTest))
                sechduleStreetTestToolStripMenuItem.Enabled = false;
            else
                sechduleStreetTestToolStripMenuItem.Enabled = true;
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowLDLA_Info((int)dgvLDLA_List.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateLDL_Application((int)dgvLDLA_List.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshLDLA_List();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cls_LDLA LDL_Application = cls_LDLA.GetLDLAInfo((int)dgvLDLA_List.CurrentRow.Cells[0].Value);
            if(LDL_Application == null) 
            {
                MessageBox.Show("Application Not Found Try Again!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LDL_Application.Cancel();
            _RefreshLDLA_List();
        }


        private void FilterBy()
        {
            string Filter = "";

            switch (cbFilterBy.Text) 
            {
                case "LDLA_ID":
                    Filter = "LocalDrivingLicenseApplicationID";
                    break;
                case "National_No":
                    Filter = "NationalNo";
                    break;
                case "FullName":
                    Filter = "FullName";
                    break;
                case "Status":
                    Filter = "Status";
                    break;
                default:
                    Filter = "None";
                    break;
            }

            if(Filter == "None" ||  txtSearch.Text.Trim() == "")
            {
                dt_LDLA.DefaultView.RowFilter = "";
                lbRecords.Text = dgvLDLA_List.Rows.Count.ToString();
                return;
            }

            if(Filter == "FullName" || Filter == "NationalNo")
            {
                dt_LDLA.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", Filter, txtSearch.Text);
                lbRecords.Text = dgvLDLA_List.Rows.Count.ToString();
            }
            else
            {
                dt_LDLA.DefaultView.RowFilter = string.Format("[{0}] = {1}", Filter, txtSearch.Text);
                lbRecords.Text = dgvLDLA_List.Rows.Count.ToString();
            }
            
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                txtSearch.Visible = false;
                cbStatus.Visible = false;
                return;
            }

            if (cbFilterBy.Text == "Status")
            {
                txtSearch.Visible = false;
                cbStatus.Visible = true;
            }
            else
            {
                txtSearch.Visible = true;
                txtSearch.Text = string.Empty;
                cbStatus.Visible = false;
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "LDLA_ID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }

            if (cbFilterBy.Text == "FullName")
            {
                e.Handled = (!char.IsLetter(e.KeyChar) && 
                !char.IsWhiteSpace(e.KeyChar) && 
                e.KeyChar != (char)Keys.Back && 
                !(Control.ModifierKeys == Keys.Control));
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterBy();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt_LDLA.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", "Status", cbStatus.Text);
            lbRecords.Text = dgvLDLA_List.Rows.Count.ToString();
        }

        private void DeleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLA_ID = (int)dgvLDLA_List.CurrentRow.Cells[0].Value;
            cls_LDLA LDL_Application = cls_LDLA.GetLDLAInfo(LDLA_ID);
            if(LDL_Application == null) 
            {
                MessageBox.Show("Application Not Found Try Again!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if((MessageBox.Show("Are You Sure You Want To delete this Application? ID = " + LDLA_ID.ToString(), 
                                    "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK))
            {
                if(LDL_Application.DeleteLDLA())
                {
                    MessageBox.Show("Application Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshLDLA_List();
                }
                else
                {
                    MessageBox.Show("Failed to delete application!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }   

        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListAppointments((int)dgvLDLA_List.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.VisionTest);
            frm.ShowDialog();
            _RefreshLDLA_List();
        }

        private void sechduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLA_ID = (int)dgvLDLA_List.CurrentRow.Cells[0].Value;
            if (!cls_LDLA.GetLDLAInfo(LDLA_ID).DoesPassPreviousTestType(clsTestTypes.enTestType.WrittenTest))
            {
                MessageBox.Show("Make Sure To Pass All Previous Tests!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form frm = new frmListAppointments(LDLA_ID, clsTestTypes.enTestType.WrittenTest);
            frm.ShowDialog();
            _RefreshLDLA_List();
        }

        private void sechduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLA_ID = (int)dgvLDLA_List.CurrentRow.Cells[0].Value;
            if(!cls_LDLA.GetLDLAInfo(LDLA_ID).DoesPassPreviousTestType(clsTestTypes.enTestType.StreetTest))
            {
                MessageBox.Show("Make Sure To Pass All Previous Tests!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form frm = new frmListAppointments(LDLA_ID, clsTestTypes.enTestType.StreetTest);
            frm.ShowDialog();
            _RefreshLDLA_List();
        }

        private void CheckTestStatus(object sender, CancelEventArgs e)
        {
            HandleCmsComponents();
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Selected_ID = (int)dgvLDLA_List.CurrentRow.Cells[0].Value;
            int PassedTests = (int)dgvLDLA_List.CurrentRow.Cells[5].Value;
            if(PassedTests != 3)
            {
                MessageBox.Show("Selected Person Doesn't Pass All Required Tests!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Form frm1 = new frmIssueLocalDrivingLicense(Selected_ID);
            frm1.ShowDialog();  
            _RefreshLDLA_List();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLA_ID = (int)dgvLDLA_List.CurrentRow.Cells[0].Value;
            cls_LDLA LDL_Application = cls_LDLA.GetLDLAInfo(LDLA_ID);

            Form frm = new frmShowLicenseInfo(LDL_Application.ApplicationID);
            frm.ShowDialog();   
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLA_ID = (int)dgvLDLA_List.CurrentRow.Cells[0].Value;
            cls_LDLA LDL_Application = cls_LDLA.GetLDLAInfo(LDLA_ID);
            clsDrivers Driver = clsDrivers.GetDriverInfoByPersonID(LDL_Application.PersonID);
            if(Driver == null)
            {
                MessageBox.Show("Person Does Not Have Any License History!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Form frm = new frmShowLicenseHistory(Driver.DriverID);
            frm.ShowDialog();
        }
    }
}
