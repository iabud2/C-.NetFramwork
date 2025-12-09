using DVLD_BusinessLayer.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccesLayer.Licenses;
using System.Runtime.CompilerServices;
using DVLD_BusinessLayer.Application;

namespace DVLD_BusinessLayer.Licenses
{
    public class clsInternationalLicenses : clsApplications
    {
        public int InternationalLicenseID { set; get; }
        public int DriverID { set; get; }
        public int LocalLicenseID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public bool IsActive { set; get; }  
        public clsDrivers DriverInfo { set; get; }
        public clsLicenses LocalLicenseInfo { set; get; }
        
        enum enILMode { Add = 0, Update = 1}
        enILMode ILMode = enILMode.Add;

        public clsInternationalLicenses() 
        {
            base.ApplicationID = -1;
            base.ApplicationDate = DateTime.Now;
            base.PersonID = -1;
            base.ApplicationStatus = enApplicationStatus.New;
            base.PaidFees = -1;
            base.ApplicationType = (int)clsApplications.enApplicaionType.NewInternationalDrivingLicense;
            base.LastStatusDate = DateTime.Now;
            base.CreatedByUser = -1;
            this.InternationalLicenseID = -1;
            this.DriverID = -1;
            this.LocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = true;
            this.DriverInfo = new clsDrivers();
            this.LocalLicenseInfo = new clsLicenses();
            this.ILMode = enILMode.Add;
        }

        private clsInternationalLicenses(int IL_ID, int applicationID, DateTime applicationDate, int personID, clsApplications.enApplicationStatus applicationStatus,
                                          float paidFees, clsApplications.enApplicaionType applicaionType, DateTime lastStatusDate ,int driverID, int locallicenseID, 
                                        DateTime issueDate, DateTime expirationDate, bool isActive, int createdbyUserID)
        {
            base.ApplicationDate = applicationDate;
            base.ApplicationID = applicationID;
            base.PersonID = personID;
            base.ApplicationStatus = applicationStatus;
            base.PaidFees = paidFees;
            base.ApplicationType = (int)applicaionType;
            base.LastStatusDate = lastStatusDate;

            this.InternationalLicenseID = IL_ID;
            this.DriverID = driverID;
            this.LocalLicenseID = locallicenseID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.IsActive = isActive;
            this.DriverInfo = clsDrivers.GetDriverInfo(driverID);
            this.LocalLicenseInfo = clsLicenses.GetActiveLicenseInfo(locallicenseID);
            base.CreatedByUser = createdbyUserID;           
            this.ILMode = enILMode.Update;
        }

        public static DataTable ListInternationalLisenses() 
        {
            return (InternationalLicensesDataLayer.ListInternationalLicenses());
        }

        public static DataTable ListInternationalLicensesForDriverID(int DriverID)
        {
            return (InternationalLicensesDataLayer.ListInternationalLicensesForDriverID(DriverID));
        }

        public static clsInternationalLicenses GetInternationalLicenseInfo(int IL_ID)
        {
            int ApplicationID = -1, DriverID = -1, LocalLicenseID = -1,CreatedBy = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            bool isActive = false;
            
            
            if(InternationalLicensesDataLayer.GetInternationlLicenseInfo(IL_ID, ref ApplicationID, ref DriverID, ref LocalLicenseID, ref issueDate,
                                                        ref expirationDate, ref isActive, ref CreatedBy))
            {
                clsApplications Application = clsApplications.GetApplicationInfo(ApplicationID);
                return new clsInternationalLicenses(IL_ID, ApplicationID, Application.ApplicationDate, Application.PersonID, Application.ApplicationStatus,
                                                    Application.PaidFees, (clsApplications.enApplicaionType)Application.ApplicationType, Application.LastStatusDate
                                                    , DriverID, LocalLicenseID, issueDate, expirationDate, isActive, CreatedBy);
            }
            return null;
        }

        public static clsInternationalLicenses GetInternationalLicenseInfoByDriverID(int DriverID)
        {
            int IL_ID = -1, ApplicationID = -1, LocalLicenseID = -1, CreatedBy = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            bool isActive = false;

            if(InternationalLicensesDataLayer.Get_InternationalLicense_Info_By_DriverID(ref IL_ID , ref ApplicationID ,DriverID, ref LocalLicenseID,
                ref issueDate, ref expirationDate, ref isActive, ref CreatedBy))
            {
                clsApplications Application = clsApplications.GetApplicationInfo(ApplicationID);
                return new clsInternationalLicenses(IL_ID, ApplicationID, Application.ApplicationDate, Application.PersonID, Application.ApplicationStatus,
                                                    Application.PaidFees, (clsApplications.enApplicaionType)Application.ApplicationType, Application.LastStatusDate
                                                    ,DriverID, LocalLicenseID, issueDate, expirationDate, isActive, CreatedBy);
            }
            return null;
        }
        private bool AddNewInternationalLicense()
        {
            
            this.InternationalLicenseID = InternationalLicensesDataLayer.AddNewInternationalLicense(base.ApplicationID, this.DriverID, this.LocalLicenseID,
                                                            this.IssueDate, this.ExpirationDate, this.IsActive, base.CreatedByUser);
            return this.InternationalLicenseID != -1;
        }

        private bool UpdateInternationalLicense()
        {
            return (InternationalLicensesDataLayer.UpdateInternationalLicenseInfo(this.InternationalLicenseID, base.ApplicationID, this.DriverID, this.LocalLicenseID,
                                                    this.IssueDate, this.ExpirationDate, this.IsActive, base.CreatedByUser));
        }

        public bool DeleteInternationalLicense()
        {
            return (InternationalLicensesDataLayer.DeleteInternationalLicense(this.InternationalLicenseID));
        }

        public static bool DeleteInternationalLicense(int IL_ID)
        {
            return (InternationalLicensesDataLayer.DeleteInternationalLicense(IL_ID));
        }

        public static bool ActivationStatus(int IL_ID, bool isActive)
        {
            if (InternationalLicensesDataLayer.InternationalLicenseActivation(IL_ID, isActive))
            {
                return true;
            }
            return false;
        }

        public bool ActivationStatus(bool isActive)
        {
            if (InternationalLicensesDataLayer.InternationalLicenseActivation(this.InternationalLicenseID, isActive))
            {
                return true;
            }
            return false;
        }

        public static bool IsExist(int IL_ID)
        {
            return InternationalLicensesDataLayer.IsExist(IL_ID);
        }


        public static bool IsExist_ByLLID(int LocalLicenseID)
        {
            return InternationalLicensesDataLayer.isDriverHaveAcive_IL_ByLLID(LocalLicenseID);
        }

        public static bool DoesDriverHaveActiveLicense(int DriverID)
        {
            return InternationalLicensesDataLayer.isDriverHaveActive_IL(DriverID);
        }

        public static bool IsExistByDriverID(int DriverID)
        {
            return InternationalLicensesDataLayer.IsExist_ByDriverID(DriverID);
        }
        public bool SaveIL()
        {
            base.Mode = (clsApplications.enMode)ILMode;
            if (!base.Save())
                return false;

            switch (ILMode)
            {
                case enILMode.Add:
                {
                    if (AddNewInternationalLicense())
                    {
                        ILMode = enILMode.Update;
                        return true;
                    }
                    else
                        return false;
                    }
                case enILMode.Update:
                    return UpdateInternationalLicense();
                }
                return false;
            }

        
    }
}
