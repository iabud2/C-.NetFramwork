using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccesLayer.Tests;
using System.Xml.XPath;
using System.Runtime.CompilerServices;

namespace DVLD_BusinessLayer.Tests
{
    public class clsTests
    {
        public int TestID { set; get; }
        public int TestAppointmentID { set; get;}
        public bool TestResult { set; get; }
        public string Notes { set; get; }
        public int CreatedByUser { set; get; }
            
        enum enMode { AddNew = 0, Update = 1}
        enMode Mode;
        public clsTests()
        {
            Mode = enMode.AddNew;
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.CreatedByUser = -1;

        }

        private clsTests(int testID, int AppointmentID, bool Result, string notes, int CreatedBy)
        {
            this.TestID = testID;
            this.TestAppointmentID = AppointmentID;
            this.TestResult = Result;
            this.Notes = notes;
            this.CreatedByUser = CreatedBy;
            Mode = enMode.Update;
        }

        static public clsTests GetTestInfo(int testID)
        {
            int AppointmentID = -1, CreatedBy = -1;
            string notes = "";
            bool result = false;
            if(TestsDataLayer.GetTestInformation(testID, ref AppointmentID, ref result, ref notes, ref CreatedBy))
                return (new clsTests(testID, AppointmentID, result, notes, CreatedBy));
            else
                return null;
        }

        static public clsTests GetTestInfoByAppointmentID(int AppointmentID)
        {
            int TestID = -1, CreatedBy = -1;
            string Notes = "";
            bool result = false;
            if (TestsDataLayer.GetTestInfoByAppointmentId(AppointmentID, ref TestID, ref result, ref Notes, ref CreatedBy))
            {
                return (new clsTests(TestID, AppointmentID, result, Notes, CreatedBy));
            }
            else
                return null;

        }

        static public DataTable ListAllTests()
        {
            return (TestsDataLayer.ListAllTests());
        }
        
        private bool _AddNewTest()
        {
            this.TestID = TestsDataLayer.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUser);

            return(this.TestID != -1);
        }

        private bool _UpdateTest()
        {
            return (TestsDataLayer.UpdateTest(this.TestID,this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUser));
        }

        public bool DeleteTest(int testID)
        {
            return (TestsDataLayer.DeleteTest(testID));
        }

        public bool Save()
        {
            if (!clsTestsAppointments.LockAppointment(this.TestAppointmentID))
                return false;
            switch (Mode)
            {
                case enMode.AddNew:
                {   
                  if (_AddNewTest())
                  {
                      Mode = enMode.Update;
                      return true;
                  }
                  else
                      return false;
                }
                case enMode.Update:
                {
                        return _UpdateTest();
                }
            }
            return false;
        }
         

    }
}
