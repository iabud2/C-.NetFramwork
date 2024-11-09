using DVLD_DataAccesLayer.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.CompilerServices;
using DVLD_BusinessLayer.Licenses;
using DVLD_BusinessLayer.Tests;

namespace DVLD_BusinessLayer.Application
{
    public class cls_LDLA : clsApplications
    {
        //this is The business Layer for Local Driving License Appliactions.
        public int LDLA_ID { get; set; }
        public int LicenseClassID { get; set; }

        public clsLicenseClasses LicenseClassInfo;
        enum enMode { AddNew = 0, Update = 1 }
        private enMode Mode;




        public cls_LDLA()
        {
            LDLA_ID = -1;
            LicenseClassID = -1;
            Mode = enMode.AddNew;
        }

        private cls_LDLA(int ldla_ID, int Applicat_ID, int personID, DateTime applicationDate, int applicationTypeID, enApplicationStatus applicationStatus,
                            DateTime lastStatusDate, float paidFees, int createdByUserID, int licenseClassID)
        {
            this.LDLA_ID = ldla_ID;
            this.ApplicationID = Applicat_ID;
            this.PersonID = personID;
            this.ApplicationDate = applicationDate;
            this.ApplicationType = applicationTypeID;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUser = createdByUserID;
            this.CreatedByUserInfo = clsUsers.FindUser(createdByUserID);
            this.LicenseClassID = licenseClassID;
            this.LicenseClassInfo = clsLicenseClasses.Find(licenseClassID);
            Mode = enMode.Update;

        }

        static public DataTable ListAll_LDLA()
        {
            return (Local_DL_ApplicationsDataLayer.Get_LDLA_List());
        }

        static public cls_LDLA GetLDLAInfo(int ldla_ID)
        {
            int applicationID = -1, licenseClassID = -1;
            bool IsFound = Local_DL_ApplicationsDataLayer.FindLocal_DL_Application(ldla_ID, ref applicationID, ref licenseClassID);
            if (IsFound)
            {
                //LoadApplicationInfo
                clsApplications Application = clsApplications.GetApplicationInfo(applicationID);

                //Now Return cls_LDLA Object By using the private Constructor.

                return new cls_LDLA(ldla_ID, applicationID, Application.PersonID, Application.ApplicationDate, Application.ApplicationType,
                                        (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees,
                                        Application.CreatedByUser, licenseClassID);
            }
            else
                return null;
        }


        static public cls_LDLA GetLDLAInfo_ByApplicationID(int applicationID)
        {
            int ldlaID = -1, licenseClassID = -1;
            bool isFound = Local_DL_ApplicationsDataLayer.GetLDLA_ByApplicationiD(ref ldlaID, applicationID, ref licenseClassID);

            if(isFound)
            {
                clsApplications Application = clsApplications.GetApplicationInfo(applicationID);

                return new cls_LDLA(ldlaID, applicationID, Application.PersonID, Application.ApplicationDate, Application.ApplicationType,
                                    (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees,
                                    Application.CreatedByUser, licenseClassID);
            }
            return null;
        }

        private bool AddNewLDLA()
        {
            int NewID = Local_DL_ApplicationsDataLayer.AddNew_LDLA(this.ApplicationID, this.LicenseClassID);
            return (NewID != -1);
        }

        private bool UpdateLDLA()
        {
            return (Local_DL_ApplicationsDataLayer.Update_LDLA(this.LDLA_ID, this.ApplicationID, this.LicenseClassID));
        }

        private bool DeleteLDLA()
        {
            bool IsLDLA_Deleted = false;
            bool IsBaseApplicationDeleted = false;
            IsLDLA_Deleted = Local_DL_ApplicationsDataLayer.Delete_LDLA(this.LDLA_ID);
            if (!IsLDLA_Deleted) 
            {
                return false;
            }
            IsBaseApplicationDeleted = base.DeleteApplication();
            return IsBaseApplicationDeleted;
        }

        static public bool DoesPassTestType(int ldlaID,clsTestTypes.enTestType TestTypeID)
        {
            return (Local_DL_ApplicationsDataLayer.DoesPassTestType(ldlaID, (int)TestTypeID));
        }
        public bool DoesPassTestType(clsTestTypes.enTestType TestTypeID)
        {
            return (Local_DL_ApplicationsDataLayer.DoesPassTestType(this.LDLA_ID, (int)TestTypeID));
        }

        public bool DoesPassPreviousTestType(clsTestTypes.enTestType CurrentTest)
        {
            switch (CurrentTest)
            {
                case clsTestTypes.enTestType.VisionTest:
                    return true;
                case clsTestTypes.enTestType.WrittenTest:
                    return this.DoesPassTestType(clsTestTypes.enTestType.VisionTest);
                case clsTestTypes.enTestType.StreetTest:
                    return this.DoesPassTestType(clsTestTypes.enTestType.WrittenTest);
                default:
                    return false;
            }
        }

        public bool Save()
        {
            base.Mode = (clsApplications.enMode)Mode;
            if(!base.Save())
            {
                return false;
            }


            switch (Mode)
            {
                case enMode.AddNew:
                    if (AddNewLDLA())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return UpdateLDLA();
            }
            return false;
        }



    }
}
