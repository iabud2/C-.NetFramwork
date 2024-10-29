using DVLD_DataAccesLayer.Applications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_BusinessLayer.Application
{
    public class clsApplications
    {
        int ApplicationID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int PersonID { get; set; }
        public string ApplicationStatus { get; set; }
        public float PaidFees { get; set; }
        public int ApplicationType { get; set; }
        public DateTime LastStatusDate { get; set; }
        public int CreatedByUser { get; set; }

        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode;

        public clsApplications()
        {
            Mode = enMode.AddNew;
            ApplicationID = -1;
            ApplicationDate = DateTime.Now;
            PersonID = -1;
            ApplicationStatus = "";
            PaidFees = -1;
            ApplicationType = -1; ;
            LastStatusDate = DateTime.Now;
            CreatedByUser = -1;
        }

        private clsApplications(int applicationID, DateTime applicationDate, int personID, string applicationStatus, float paidFees,
                                                                    int applicationType, DateTime lastStatusDate, int createdByUser)
        {
            Mode = enMode.Update;
            ApplicationID = applicationID;
            ApplicationDate = applicationDate;
            PersonID = personID;
            ApplicationStatus = applicationStatus;
            PaidFees = paidFees;
            ApplicationType = applicationType;
            LastStatusDate = lastStatusDate;
            CreatedByUser = createdByUser;
        }

        static public clsApplications GetApplicationInfo(int ID)
        {
            DateTime ApplicatDate = DateTime.Now, LastStatusDate = DateTime.Now;
            int PersonID = -1, ApplicatType = -1, CreatedBy = -1;
            string ApplicatStatus = "";
            float Fees = -1;
            if (ApplicationsDataLayer.GetApplicationInfo(ID, ref ApplicatDate, ref PersonID, ref ApplicatStatus,
                                                                ref Fees, ref ApplicatType, ref LastStatusDate, ref CreatedBy))
            {
                return (new clsApplications(ID, ApplicatDate, PersonID, ApplicatStatus, Fees, ApplicatType, LastStatusDate, CreatedBy));
            }
            else
            {
                return null;
            }
        }

        static public DataTable GetApplicationsList()
        {
            return (ApplicationsDataLayer.GetApplicationsList());
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = ApplicationsDataLayer.AddNewApplication(this.ApplicationDate, this.PersonID, this.ApplicationStatus,
                                                        this.PaidFees, this.ApplicationType, this.LastStatusDate, this.CreatedByUser);
            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            return (ApplicationsDataLayer.UpdateApplication(this.ApplicationID, this.ApplicationDate, this.PersonID, this.ApplicationStatus,
                                                         this.PaidFees, this.ApplicationType, this.LastStatusDate, this.CreatedByUser));
        }


        static public bool DeleteApplication(int ID)
        {
            return (ApplicationsDataLayer.DeleteApplicationType(ID));
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return (_UpdateApplication());
            }
            return false;
        }

    }
}
