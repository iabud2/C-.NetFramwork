using DVLD_DataAccesLayer.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DVLD_BusinessLayer.Tests
{
    public class clsTestsAppointments
    {
        public int AppointmentID { set; get; }
        public int LDLA_ID { set; get; }
        public int TestTypeID { set; get; }
        public DateTime AppointmentDate { set; get; }
        public float PaidFees { set; get; }
        public bool isLocked { set; get; }
        public int CreatedByUser { set; get; }

        enum enMode { AddNew = 0, Update = 1}
        enMode Mode;
        public clsTestsAppointments()
        {
            Mode = enMode.AddNew;
            this.AppointmentID = -1;
            this.LDLA_ID = -1;
            this.TestTypeID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = -1;
            this.isLocked = false;
            this.CreatedByUser = -1;
        }

        private clsTestsAppointments(int appointmentID, int lDLA_ID, int testTypeID, DateTime appointmentDate, float paidFees, bool isLocked, int createdByUser)
        {
            AppointmentID = appointmentID;
            LDLA_ID = lDLA_ID;
            TestTypeID = testTypeID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            this.isLocked = isLocked;
            CreatedByUser = createdByUser;
            Mode = enMode.Update;
        }

        public clsTestsAppointments GetAppointmentDetails(int appointmentID)
        {
            int ldlaID = -1, testTypeID = -1, createdby = -1;
            DateTime appointmentDate = DateTime.Now;
            float paidFees = -1;
            bool islocked = false;

            if (TestsAppointmentsDataLayer.GetTestAppointmentInfo(appointmentID, ref ldlaID, ref testTypeID, ref appointmentDate, 
                                            ref paidFees, ref islocked, ref createdby))
            {
                return new clsTestsAppointments(appointmentID, ldlaID, testTypeID, appointmentDate, paidFees, isLocked, createdby);
            }
            return null;
        }

        static public DataTable ListAllAppointments()
        {
            return(TestsAppointmentsDataLayer.ListAllAppointments());
        }

        private bool _AddNewAppointment()
        {
            this.AppointmentID = TestsAppointmentsDataLayer.AddNewAppointment(this.LDLA_ID, this.TestTypeID, this.AppointmentDate, this.PaidFees,
                                                            this.isLocked, this.CreatedByUser);
            return (this.AppointmentID != -1);
        }

        private bool _UpdateAppointment()
        {
            return (TestsAppointmentsDataLayer.UpdateAppointment(this.AppointmentID, this.LDLA_ID, this.TestTypeID, this.AppointmentDate,
                                                this.PaidFees, this.isLocked, this.CreatedByUser));
        }

        static public bool DeleteAppointment(int appointmentID)
        {
            return (TestsAppointmentsDataLayer.DeleteAppointment(appointmentID));
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                {
                    if(_AddNewAppointment()) 
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                }
                case enMode.Update:
                {
                    return (_UpdateAppointment());
                }
            }
            return false;
        }
    }
}
