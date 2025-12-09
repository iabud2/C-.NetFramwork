using DVLD_BusinessLayer.GeneralClasses;
using DVLD_BusinessLayer.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DVLD_.Tests
{
    public partial class frmTakeTest : Form
    {
        enum enMode { TakeTest = 1, ShowTestResult =2 }
        enMode Mode = enMode.TakeTest;
        private int _AppointmentID = -1;
        clsTestsAppointments Appointment;
        public frmTakeTest(int AppointmentID)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            FillForm();
        }

        public void FillForm()
        {
            ucAppointmentInfo.LoadInfo(_AppointmentID);
            clsTests Test = clsTests.GetTestInfoByAppointmentID(_AppointmentID);
            Appointment = clsTestsAppointments.GetAppointmentDetails(_AppointmentID);
            if(Test == null)
                Mode = enMode.TakeTest;
            else
                Mode = enMode.ShowTestResult;

            if(Mode == enMode.ShowTestResult)
            {
                rbFail.Enabled = false;
                rbPass.Enabled = false;
                txtNotes.Enabled = false;
                btnSave.Enabled = false;
                if (Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;
                txtNotes.Text = Test.Notes;
                lbTestLocked.Visible = true;
                return;
            }
            
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsTests NewTest = new clsTests();
            NewTest.TestAppointmentID = _AppointmentID;
            if(rbPass.Checked)
                NewTest.TestResult = true;
            else
                NewTest.TestResult = false;
            NewTest.Notes = txtNotes.Text;
            NewTest.CreatedByUser = clsGlobal.CurrentUserLogedin.UserID;
            if(NewTest.Save())
            {
               {
                    MessageBox.Show("Test Taken Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
               this.Close();
            }
            else
            {
                MessageBox.Show("Failed To Save Date, Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
    }
}
