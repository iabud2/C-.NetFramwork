using DVLD_BusinessLayer.Application;
using DVLD_BusinessLayer.Tests;
using Project_DVLD_.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DVLD_.Controls
{
    public partial class ucAppointmentInfo : UserControl
    {
        clsTestsAppointments Appointment;
        clsTestTypes.enTestType _TestType;
        public ucAppointmentInfo()
        {
            InitializeComponent();

        }

        private void Handle_TestType()
        {
            switch(Appointment.TestTypeID) 
            {
                case 1:
                    pictureBox1.Image = Resources.visionTest128;
                    _TestType = clsTestTypes.enTestType.VisionTest;
                    break;
                case 2:
                    pictureBox1.Image = Resources.writtenTest128;
                    _TestType = clsTestTypes.enTestType.WrittenTest;
                    break;
                case 3:
                    pictureBox1.Image = Resources.streetTest128;
                    _TestType = clsTestTypes.enTestType.StreetTest;
                    break;
            }
        }

        public void LoadInfo(int Appointment_ID)
        {
            Appointment = clsTestsAppointments.GetAppointmentDetails(Appointment_ID);
            if (Appointment == null)
            {
                MessageBox.Show("No Appointment Found With ID:" + Appointment_ID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Handle_TestType();

            cls_LDLA Application = cls_LDLA.GetLDLAInfo(Appointment.LDLA_ID);
            lbLDLA_ID.Text = Appointment.LDLA_ID.ToString();
            lbLC_ID.Text = Application.LicenseClassInfo.ClassName;
            lbFullName.Text = Application.PersonFullName;
            lbTrials.Text = Application.TotalTrialPerTest(_TestType).ToString();
            lbDate.Text = Appointment.AppointmentDate.ToString();
            lbFees.Text = Appointment.PaidFees.ToString();

            clsTests Test = clsTests.GetTestInfoByAppointmentID(Appointment_ID);
            if(Test == null)
            {
                lbTest_ID.Text = "Not Taken Yet";
            }
            else
            {
                lbTest_ID.Text = Test.TestID.ToString();
            }
                       
        }


    }
}


