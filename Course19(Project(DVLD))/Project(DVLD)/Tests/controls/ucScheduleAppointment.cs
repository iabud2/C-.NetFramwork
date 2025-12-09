using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer.Application;
using DVLD_BusinessLayer.GeneralClasses;
using DVLD_BusinessLayer.Tests;
using Project_DVLD_.Properties;
namespace Project_DVLD_.Controls
{
    public partial class ucScheduleAppointment : UserControl
    {
        enum enMode { Add = 0, Update = 1 }
        enMode Mode = enMode.Add;
        enum enCreationMode { FirstTime = 0, Retake = 1}
        enCreationMode CreationMode = enCreationMode.FirstTime;

        clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;

        clsTestTypes TestTypeInfo;

        private int _LDLA_ID = -1;
       
        private int _AppointmentID = -1;

        private cls_LDLA _LDL_Application;

        private clsTestsAppointments _TestAppointment;
        public ucScheduleAppointment()
        {
            InitializeComponent();
        }

        public clsTestTypes.enTestType TestType
        {
            get
            {
                return _TestType;
            }
            
            set 
            {
                _TestType = value;
                switch (_TestType)
                {
                    case clsTestTypes.enTestType.VisionTest:
                        {   
                            pbTestType.Image = Resources.visionTest128;
                            break;
                        }
                    case clsTestTypes.enTestType.WrittenTest:
                        {   
                            pbTestType.Image = Resources.writtenTest128;
                            break;
                        }
                    case clsTestTypes.enTestType.StreetTest:
                        {   
                            pbTestType.Image = Resources.streetTest128;
                            break;
                        }
                }
            }
        }

        public void LoadInfo(int ldla_ID, int appointmentID = -1)
        {
            if (_AppointmentID == -1)
                Mode = enMode.Add;
            else
                Mode = enMode.Update;

            _LDLA_ID = ldla_ID;
            _AppointmentID = appointmentID;
            _LDL_Application = cls_LDLA.GetLDLAInfo(ldla_ID);
            TestTypeInfo = clsTestTypes.GetTestTypeInfo(_TestType);

            if (Mode == enMode.Update)
                _LoadAppointMentInfo();
            else
                _TestAppointment = new clsTestsAppointments();


            if (_LDL_Application == null)
            {
                MessageBox.Show("Local Application With ID:" + ldla_ID.ToString() + " Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_LDL_Application.DoesPersonAttendTestType(_TestType))
            {
                CreationMode = enCreationMode.Retake;
            }
            else
            {
                CreationMode = enCreationMode.FirstTime;
            }
            FillData();

            if (HandleLockedAppointment())
                return;
            if (HandleDoesNotPassPreviousTest())
                return;
            if (HandleActiveAppointment())
                return;
        }

        private void FillData()
        {        
            
            if (CreationMode == enCreationMode.FirstTime)
            {
                lbTitle.Text = "Schedule " + TestTypeInfo.Title;
                gbRetake.Enabled = false;
                lbRetakeFees.Text = "0";
                lbTotalFees.Text = TestTypeInfo.Fees.ToString();
            }
            else
            {
                lbTitle.Text = "Retake " + TestTypeInfo.Title;
                gbRetake.Enabled = true;
                lbRetakeFees.Text = clsApplicationTypes.GetApplicationTypeInfo((int)clsApplications.enApplicaionType.RetakeTest).ApplicationFees.ToString();
                lbTotalFees.Text = (Convert.ToSingle(lbRetakeFees.Text) + TestTypeInfo.Fees).ToString();
            }


            lbDL_ID.Text = _LDLA_ID.ToString();
            lbLicenseClass.Text = _LDL_Application.LicenseClassInfo.ClassName;
            lbPersonName.Text = _LDL_Application.PersonFullName;

            if (Mode == enMode.Update)
                dtpSetAppointment.Value = _TestAppointment.AppointmentDate;
            else
                dtpSetAppointment.MinDate = DateTime.Now;

            lbFees.Text = TestTypeInfo.Fees.ToString();

            if (CreationMode == enCreationMode.FirstTime)
                lbTrials.Text = "0";
            else
                lbTrials.Text = _LDL_Application.TotalTrialPerTest(_TestType).ToString();
        }

        private void _LoadAppointMentInfo()
        {
            _TestAppointment = clsTestsAppointments.GetAppointmentDetails(_AppointmentID);
            if(_TestAppointment == null)
            {
                MessageBox.Show("Appointment With ID:" + _AppointmentID.ToString() + " Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpSetAppointment.Enabled = false;
                return;
            }
        }

        private bool HandleLockedAppointment()
        {
            if(_TestAppointment.isLocked) 
            {
                dtpSetAppointment.Enabled = false;
                lbMessage.Visible = true;
                lbMessage.Text = "This Appointment Is Locked!";
                btnSave.Enabled = false;
                return true;
            }
            else
            {
                dtpSetAppointment.Enabled = true;
                lbMessage.Visible = false;
                btnSave.Enabled = true;
                return false;
            }
            
        }

        private bool HandleDoesNotPassPreviousTest()
        {
            if(!_LDL_Application.DoesPassPreviousTestType(_TestType)) 
            {
                dtpSetAppointment.Enabled = false;
                lbMessage.Visible = true;
                lbMessage.Text = "Make Sure The Applicant Already Passed All Previous Tests!";
                btnSave.Enabled = false;
                return true;
            }
            else
            {
                dtpSetAppointment.Enabled = true;
                lbMessage.Visible = false;
                btnSave.Enabled = true;
                return false;
            }

        }

        private bool HandleActiveAppointment()
        {
            if (_LDL_Application.IsThereAnActiveScheduledTest(_TestType))
            {
                dtpSetAppointment.Enabled = false;
                lbMessage.Visible = true;
                lbMessage.Text = "Applicant already has Active Appointment For This Test!";
                btnSave.Enabled = false;
                return true;
            }
            else
            {
                dtpSetAppointment.Enabled = true;
                lbMessage.Visible = false;
                btnSave.Enabled = true;
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestAppointment.LDLA_ID = _LDLA_ID;
            _TestAppointment.TestTypeID = (int)_TestType;
            _TestAppointment.AppointmentDate = dtpSetAppointment.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lbTotalFees.Text);
            _TestAppointment.CreatedByUser = clsGlobal.CurrentUserLogedin.UserID;

            if(_TestAppointment.Save())
            {
                MessageBox.Show("Appointment Scheduled Successfully!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Faild! Try Again.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucScheduleAppointment_Load(object sender, EventArgs e)
        {

        }
    }
}
