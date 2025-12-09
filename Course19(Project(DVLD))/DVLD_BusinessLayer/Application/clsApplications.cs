using DVLD_DataAccesLayer.Applications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_BusinessLayer.Application
{
    public class clsApplications
    {
        protected enum enMode { AddNew = 0, Update = 1 }
      
        public enum enApplicaionType { NewDrivingLicense = 1, RenewDrivinLicense = 2, ReplaceLostDrivingLicense = 3, ReplaceForDamagedDrivingLicense = 4,
                                ReleaseDetainedDrivingLicense = 5, NewInternationalDrivingLicense = 6, RetakeTest = 8}

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 }

        public int ApplicationID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int PersonID { get; set; }
            
        public string PersonFullName
        {
            get
            {
                return clsPerson.FindPersonByID(PersonID).FullName; 
            }
        }

        public float PaidFees { get; set; }
        public int ApplicationType { get; set; }
        public clsApplicationTypes ApplicationTypeInfo;
        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusText 
        {
            get
            {
                switch(ApplicationStatus) 
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }     
        public DateTime LastStatusDate { get; set; }
        public int CreatedByUser { get; set; }
        public clsUsers CreatedByUserInfo;
        protected enMode Mode;

        public clsApplications()
        {
            Mode = enMode.AddNew;
            ApplicationID = -1;
            ApplicationDate = DateTime.Now;
            PersonID = -1;
            ApplicationStatus = enApplicationStatus.New;
            PaidFees = -1;
            ApplicationType = -1; ;
            LastStatusDate = DateTime.Now;
            CreatedByUser = -1;
        }

        private clsApplications(int applicationID, DateTime applicationDate, int personID, enApplicationStatus applicationStatus, float paidFees,
                                                                    int applicationType, DateTime lastStatusDate, int createdByUser)
        {
            Mode = enMode.Update;
            ApplicationID = applicationID;
            ApplicationDate = applicationDate;
            PersonID = personID;
            ApplicationStatus = applicationStatus;
            PaidFees = paidFees;
            ApplicationType = applicationType;
            ApplicationTypeInfo = clsApplicationTypes.GetApplicationTypeInfo(ApplicationType);
            LastStatusDate = lastStatusDate;
            CreatedByUser = createdByUser;
            CreatedByUserInfo = clsUsers.FindUser(CreatedByUser);
        }

        static public clsApplications GetApplicationInfo(int ID)
        {
            DateTime ApplicatDate = DateTime.Now, LastStatusDate = DateTime.Now;
            int PersonID = -1, ApplicatType = -1, CreatedBy = -1, ApplicatStatus = -1;
            float Fees = -1;
            if (ApplicationsDataLayer.GetApplicationInfo(ID, ref ApplicatDate, ref PersonID, ref ApplicatStatus,
                                                                ref Fees, ref ApplicatType, ref LastStatusDate, ref CreatedBy))
            {
                return (new clsApplications(ID, ApplicatDate, PersonID, (enApplicationStatus)ApplicatStatus, Fees, ApplicatType, LastStatusDate, CreatedBy));
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
            this.ApplicationID = ApplicationsDataLayer.AddNewApplication(this.ApplicationDate, this.PersonID, (int)this.ApplicationStatus,
                                                        this.PaidFees, this.ApplicationType, this.LastStatusDate, this.CreatedByUser);
            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            return (ApplicationsDataLayer.UpdateApplication(this.ApplicationID, this.ApplicationDate, this.PersonID, (int)this.ApplicationStatus,
                                                         this.PaidFees, this.ApplicationType, this.LastStatusDate, this.CreatedByUser));
        }


        public bool DeleteApplication()
        {
            return (ApplicationsDataLayer.DeleteApplication(this.ApplicationID));
        }

        static public bool isApplicationExist(int ApplicationID)
        {
            return(ApplicationsDataLayer.IsApplicationExist(ApplicationID));
        }

        public bool SetComplete()
        {
            return (ApplicationsDataLayer.UpdateApplicationStatus(this.ApplicationID, 3));
        }

        public bool Cancel()
        {
            return (ApplicationsDataLayer.UpdateApplicationStatus(this.ApplicationID, 2));
        }
        
        public bool New()
        {
            return (ApplicationsDataLayer.UpdateApplicationStatus(this.ApplicationID, 1));
        }

        static public bool DoesPersonHaveActiveApplication(int personID, clsApplications.enApplicaionType ApplicationType)
        {
            return (ApplicationsDataLayer.DeosPersonHaveActiveApplication(personID, (int)ApplicationType));
        }

        public bool DoesPersonHaveActiveApplication(clsApplications.enApplicaionType ApplicationType)
        {
            return (ApplicationsDataLayer.DeosPersonHaveActiveApplication(this.PersonID, (int)ApplicationType));
        }

        static public int GetActiveApplicationID(int PersonID, clsApplications.enApplicaionType ApplicationType)
        {
            return (ApplicationsDataLayer.GetActiveApplicationID(PersonID, (int)ApplicationType));
        }

        public int GetActiveApplicationID(clsApplications.enApplicaionType ApplicationType)
        {
            return (ApplicationsDataLayer.GetActiveApplicationID(this.PersonID, (int)ApplicationType));
        }

        static public int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplications.enApplicaionType ApplicationType, int LicenseClassID)
        {
            return (ApplicationsDataLayer.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationType, LicenseClassID));
        }

        public int GetActiveApplicationIDForLicenseClass(clsApplications.enApplicaionType ApplicationType, int LicenseClassID)
        {
            return (ApplicationsDataLayer.GetActiveApplicationIDForLicenseClass(this.PersonID, (int)ApplicationType, LicenseClassID));
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
