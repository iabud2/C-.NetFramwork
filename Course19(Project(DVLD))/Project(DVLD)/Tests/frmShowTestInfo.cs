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
    public partial class frmShowTestInfo : Form
    {
        private int _AppointmentID;
        public frmShowTestInfo(int AppointmentID)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            FillData();
        }

        private void FillData()
        {
            clsTests Test = clsTests.GetTestInfoByAppointmentID(_AppointmentID);
            ucAppointmentInfo1.LoadInfo(_AppointmentID);
            if(Test == null)
            {
                lbResult.Text = "Not Taken Yet";
            }
            else
            {
                if (Test.TestResult)
                    lbResult.Text = "Pass";
                else
                    lbResult.Text = "Fail";
                if (Test.Notes == "")
                    lbNotes.Text = "None";
                else
                    lbNotes.Text = Test.Notes;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
