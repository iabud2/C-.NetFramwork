using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using DVLD_DataAccesLayer.Licenses;
using DVLD_BusinessLayer.Drivers;
using DVLD_BusinessLayer.Application;
using DVLD_BusinessLayer.GeneralClasses;
namespace DVLD_BusinessLayer.Licenses
{
    public class clsLicenses
    {
        enum enMode { Update = 0, Add = 1}
        enMode Mode = enMode.Add;

        public int LicenseID {  get; set; }
        public int ApplicationID {  get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive {  get; set; }
        public string IssueReason {  get; set; }
        public int CreatedBy { get; set; }

        public clsDrivers DriverInfo = new clsDrivers();
 
        public clsLicenses()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = -1;
            this.IsActive = false;
            this.IssueReason = "";
            this.CreatedBy = -1;
            Mode = enMode.Add;
        }
            
        private clsLicenses(int licenseID, int applicationID, int driverID, int licenseClassID, DateTime issueDate, DateTime expirationDate, 
                                    string notes, float fees, bool isActive, string issueReason, int createdBy)
        {
            this.LicenseID = licenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.LicenseClassID = licenseClassID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.Notes = notes;
            this.PaidFees = fees;
            this.IsActive = isActive;
            this.IssueReason = issueReason;
            this.CreatedBy = createdBy;
            this.DriverInfo = clsDrivers.GetDriverInfo(DriverID);
            Mode = enMode.Update;
        }


        static public clsLicenses GetLicenseInfo(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClassID = -1, CreatedBy = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "", IssueReason = "";
            bool IsActive = false;
            float PaidFees = -1;

            if(LicensesDataLayer.GetLicenseInfo(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref Notes,
                                ref PaidFees, ref IsActive, ref IssueReason, ref CreatedBy))
            {

                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees,
                                        IsActive, IssueReason, CreatedBy);
            }
            return null;
        }

        static public clsLicenses GetSpecificLicenseForDriver(int DriverID, int LicenseClassID)
        {
            int ApplicationID = -1, CreatedBy = -1, LicenseID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "", IssueReason = "";
            bool IsActive = false;
            float PaidFees = -1;

            if (LicensesDataLayer.GetSpecificLicenseForDriver(ref LicenseID, ref ApplicationID, DriverID, LicenseClassID, ref IssueDate, ref ExpirationDate, ref Notes,
                                ref PaidFees, ref IsActive, ref IssueReason, ref CreatedBy))
            {

                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees,
                                        IsActive, IssueReason, CreatedBy);
            }
            return null;
        }

        static public clsLicenses GetActiveLicenseInfo(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClassID = -1, CreatedBy = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "", IssueReason = "";
            bool IsActive = false;
            float PaidFees = -1;

            if (LicensesDataLayer.GetActiveLicenseInfo(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref Notes,
                                ref PaidFees, ref IsActive, ref IssueReason, ref CreatedBy))
            {

                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees,
                                        IsActive, IssueReason, CreatedBy);
            }
            return null;
        }

        static public clsLicenses GetLicensesInfoByAppID(int ApplicationID)
        {
            int LicenseID = -1, DriverID = -1, LicenseClassID = -1, CreatedBy = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "", IssueReason = "";
            bool IsActive = false;
            float PaidFees = -1;

            if (LicensesDataLayer.GetLicenseInfoByApp_ID(ref LicenseID,  ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref Notes,
                                ref PaidFees, ref IsActive, ref IssueReason, ref CreatedBy))
            {
                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees,
                                        IsActive, IssueReason, CreatedBy);
            }
            return null;
        }

        static public DataTable GetLicensesList()
        {
            return(LicensesDataLayer.ListAllLicenses());
        }

        static public DataTable GetLicensesListForDriverID(int DriverID)
        {
            return LicensesDataLayer.GetLicensesListForDriverID(DriverID);
        }

        static public bool LicenseActivation(int LicenseID, bool isActive)
        {
            return (LicensesDataLayer.LicenseActivation(LicenseID, isActive));
        }

        public bool LicenseActivation(bool isActive)
        {
            return (LicensesDataLayer.LicenseActivation(this.DriverID, isActive));
        }

        static public bool DeactivatePrevious(int LicenseID, int DriverID, int LicenseClassID)
        {
            return (LicensesDataLayer.DeactivatePrevious(LicenseID, DriverID, LicenseClassID));
        }

        public bool DeactivatePrevious()
        {
            return (LicensesDataLayer.DeactivatePrevious(this.LicenseID,this.DriverID, this.LicenseClassID));
        }

        private bool _IssueNewLicense()
        {
            this.LicenseID = LicensesDataLayer.IssueNewLicense(this.ApplicationID, this.DriverID, LicenseClassID,
                                        this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedBy);
            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return (LicensesDataLayer.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate,
                                                    this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedBy));
        }

        public bool DeleteLicense(int LicenseID)
        {
            return(LicensesDataLayer.DeleteLicense(LicenseID));
        }

        public bool isLicenseExpired() 
        {
            return (DateTime.Now > this.ExpirationDate);
        }

        public bool isDetained()
        {
            return (DetainedLicensesDataLayer.IsDetained(this.LicenseID));
        }

        static public bool isDetained(int licenseID)
        {
            return (DetainedLicensesDataLayer.IsDetained(licenseID));
        }

        public clsLicenses RenewLicense(string notes)
        {
            clsApplications Application = new clsApplications();

            if (!isLicenseExpired())
                return null;
            Application.ApplicationDate = DateTime.Now;
            Application.PersonID = this.DriverInfo.PersonID;
            Application.ApplicationStatus = clsApplications.enApplicationStatus.New;
            Application.PaidFees = clsApplicationTypes.GetApplicationTypeInfo((int)clsApplications.enApplicaionType.RenewDrivinLicense).ApplicationFees;
            Application.ApplicationType = (int)clsApplications.enApplicaionType.RenewDrivinLicense;
            Application.LastStatusDate = DateTime.Now;
            Application.CreatedByUser = clsGlobal.CurrentUserLogedin.UserID;

            if (!Application.Save())
                return null;


            clsLicenses NewLicense = new clsLicenses();
            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClasses.Find(this.LicenseClassID).DefaultValidityDate);
            NewLicense.Notes = notes;
            NewLicense.PaidFees = clsLicenseClasses.Find(this.LicenseClassID).ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = "Renew License";
            NewLicense.CreatedBy = clsGlobal.CurrentUserLogedin.UserID;

            if (!NewLicense.Save())
                return null;

            Application.SetComplete();
            this.LicenseID = NewLicense.LicenseID;
            NewLicense.DeactivatePrevious();

            return NewLicense;       
        }



        public clsLicenses ReplaceForDamaged(string Notes)
        {
            clsApplications Application = new clsApplications();

            if (!this.IsActive)
                return null;


            Application.ApplicationDate = DateTime.Now;
            Application.PersonID = this.DriverInfo.PersonID;
            Application.ApplicationStatus = clsApplications.enApplicationStatus.New;
            Application.PaidFees = clsApplicationTypes.GetApplicationTypeInfo((int)clsApplications.enApplicaionType.ReplaceForDamagedDrivingLicense).ApplicationFees;
            Application.ApplicationType = (int)clsApplications.enApplicaionType.ReplaceForDamagedDrivingLicense;
            Application.LastStatusDate = DateTime.Now;
            Application.CreatedByUser = clsGlobal.CurrentUserLogedin.UserID;

            if (!Application.Save())
                return null;


            clsLicenses NewLicense = new clsLicenses();
            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClasses.Find(this.LicenseClassID).DefaultValidityDate);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = clsLicenseClasses.Find(this.LicenseClassID).ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = "Replace For Damaged";
            NewLicense.CreatedBy = clsGlobal.CurrentUserLogedin.UserID;

            if (!NewLicense.Save())
                return null;

            Application.SetComplete();
            this.LicenseID = NewLicense.LicenseID;
            NewLicense.DeactivatePrevious();

            return NewLicense;
        }


        public clsLicenses ReplaceForLost(string Notes) 
        {
            clsLicenses NewLicense = new clsLicenses();
            clsApplications Application = new clsApplications();

            if (!this.IsActive)
                return null;


            Application.ApplicationDate = DateTime.Now;
            Application.PersonID = this.DriverInfo.PersonID;
            Application.ApplicationStatus = clsApplications.enApplicationStatus.New;
            Application.PaidFees = clsApplicationTypes.GetApplicationTypeInfo((int)clsApplications.enApplicaionType.ReplaceLostDrivingLicense).ApplicationFees;
            Application.ApplicationType = (int)clsApplications.enApplicaionType.ReplaceLostDrivingLicense;
            Application.LastStatusDate = DateTime.Now;
            Application.CreatedByUser = clsGlobal.CurrentUserLogedin.UserID;

            if (!Application.Save())
                return null;


            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClasses.Find(this.LicenseClassID).DefaultValidityDate);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = clsLicenseClasses.Find(this.LicenseClassID).ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = "Replace For Lost License";
            NewLicense.CreatedBy = clsGlobal.CurrentUserLogedin.UserID;

            if (!NewLicense.Save())
                return null;

            Application.SetComplete();
            this.LicenseID = NewLicense.LicenseID;
            NewLicense.DeactivatePrevious();
            return NewLicense; 
        }

        static public bool IsExists(int LicenseID)
        {
            return(LicensesDataLayer.isExist(LicenseID));
        }


        static public bool isExists_By_AppID(int ApplicationID)
        {
            return(LicensesDataLayer.isExist_ByApp_ID(ApplicationID));
        }

        static public bool DoesDriverHaveLicenseClass(int DriverID, int LicenseClassID)
        {
            return (LicensesDataLayer.DoesDriverHaveLicenseClass(DriverID, LicenseClassID));
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    {
                        if(_IssueNewLicense())
                        {
                            return true;
                        }
                        return false;
                    }
                case enMode.Update:
                    {
                        return (_UpdateLicense());
                    }
            }
            return false;
        }

        //Don't forget (isExpired - RenewLicense - isDetained);
    }
}
