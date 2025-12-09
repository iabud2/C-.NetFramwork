using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;
using DVLD_BusinessLayer.Application;
using DVLD_DataAccesLayer.Licenses;
using System.Runtime.CompilerServices;
using DVLD_BusinessLayer.Drivers;
using DVLD_BusinessLayer.GeneralClasses;
namespace DVLD_BusinessLayer.Licenses
{
    public class clsDetainedLicenses
    {
        enum enDetainModeMode { Add = 1, Update = 2 }
        enDetainModeMode DetainModeMode;
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public float FineFees { get; set; }
        public DateTime DetainDate { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleasedDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }        
        public int CreatedByUserID { get; set; }

        public clsDetainedLicenses()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.FineFees = -1;
            this.DetainDate = DateTime.Now;
            this.IsReleased = false;
            this.ReleasedDate = DateTime.Now;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;
            this.CreatedByUserID = -1;
            DetainModeMode = enDetainModeMode.Add;
        }

        private clsDetainedLicenses(int detainID, int licenseID, float finefees, DateTime detaindate, bool isReleased, 
                                    DateTime releasedDate, int releasedByUserID, int releaseApplicationID, int createdByUserID)
        {
            this.DetainID = detainID;
            this.LicenseID = licenseID;
            this.FineFees = finefees;
            this.DetainDate = detaindate;
            this.IsReleased = isReleased;
            this.ReleasedDate = releasedDate;
            this.ReleasedByUserID = releasedByUserID;
            this.ReleaseApplicationID = releaseApplicationID;
            this.CreatedByUserID = createdByUserID;
            DetainModeMode = enDetainModeMode.Update;
        }

        static public clsDetainedLicenses GetDetainInfo(int DetainID)
        {
            int licenseID = -1, relesedbyUserID = -1, releaseApplicationID = -1, createdBy = -1;
            DateTime detainDate = DateTime.Now, releaseDate = DateTime.Now;
            float finefees = -1;
            bool isReleased = false;

            if(DetainedLicensesDataLayer.GetDetainInfo(DetainID, ref licenseID, ref finefees, ref detainDate, ref isReleased,
                                        ref releaseDate, ref relesedbyUserID, ref releaseApplicationID, ref createdBy))
            {
                return new clsDetainedLicenses(DetainID, licenseID, finefees, detainDate, isReleased, releaseDate, relesedbyUserID,
                                            releaseApplicationID, createdBy);
            }


            return null;
        }

        static public clsDetainedLicenses GetDetainInfoByLicenseID(int licenseID)
        {
            int DetainID = -1, relesedbyUserID = -1, releaseApplicationID = -1, createdBy = -1;
            DateTime detainDate = DateTime.Now, releaseDate = DateTime.Now;
            float finefees = -1;
            bool isReleased = false;

            if (DetainedLicensesDataLayer.GetDetainInfoByLicenseID(ref DetainID, licenseID, ref finefees, ref detainDate, ref isReleased,
                                        ref releaseDate, ref relesedbyUserID, ref releaseApplicationID, ref createdBy))
            {
                return new clsDetainedLicenses(DetainID, licenseID, finefees, detainDate, isReleased, releaseDate, relesedbyUserID,
                                            releaseApplicationID, createdBy);
            }


            return null;
        }

        static public clsDetainedLicenses GetActiveDetainInfo(int licenseID)
        {
            int DetainID = -1, relesedbyUserID = -1, releaseApplicationID = -1, createdBy = -1;
            DateTime detainDate = DateTime.Now, releaseDate = DateTime.Now;
            float finefees = -1;
            bool isReleased = false;

            if (DetainedLicensesDataLayer.GetActiveDetainInfo(ref DetainID, licenseID, ref finefees, ref detainDate, ref isReleased,
                                        ref releaseDate, ref relesedbyUserID, ref releaseApplicationID, ref createdBy))
            {
                return new clsDetainedLicenses(DetainID, licenseID, finefees, detainDate, isReleased, releaseDate, relesedbyUserID,
                                            releaseApplicationID, createdBy);
            }


            return null;
        }

        private bool _DetainLicense()
        {
            this.DetainID = DetainedLicensesDataLayer.DetainLicense(this.LicenseID, this.FineFees, this.DetainDate, this.IsReleased, this.CreatedByUserID);
            return DetainID != -1;
        }

        private bool _ReleaseLicense()
        {
            clsApplications Application = new clsApplications();
            Application.ApplicationDate = DateTime.Now;
            Application.PersonID = clsLicenses.GetLicenseInfo(this.LicenseID).DriverInfo.PersonID;
            Application.ApplicationStatus = clsApplications.enApplicationStatus.New;
            Application.PaidFees = clsApplicationTypes.GetApplicationTypeInfo((int)clsApplications.enApplicaionType.ReleaseDetainedDrivingLicense).ApplicationFees;
            Application.ApplicationType = (int)clsApplications.enApplicaionType.ReleaseDetainedDrivingLicense;
            Application.LastStatusDate = DateTime.Now;
            Application.CreatedByUser = clsGlobal.CurrentUserLogedin.UserID;

            if (!Application.Save())
                return false;

            this.ReleaseApplicationID = Application.ApplicationID;
            bool IsComplete = DetainedLicensesDataLayer.ReleaseDetainedLicense(this.DetainID, this.IsReleased, this.ReleasedDate, this.ReleasedByUserID, this.ReleaseApplicationID);
            if (!IsComplete)
                return false;
            
            Application.SetComplete();
            return true;
        }

        public bool isDetained()
        {
            return (DetainedLicensesDataLayer.IsDetained(this.LicenseID));
        }
        static public bool isDetained(int LicenseID)
        {
            return (DetainedLicensesDataLayer.IsDetained(LicenseID));
        }
        public bool DetainLicense()
        {
            this.DetainDate = DateTime.Now;
            this.IsReleased = false;
            return _DetainLicense();
        }

        public bool ReleaseLicense()
        {
            this.IsReleased = true;
            this.ReleasedDate = DateTime.Now;
            this.ReleasedByUserID = clsGlobal.CurrentUserLogedin.UserID;

            return _ReleaseLicense();
        }

        static public DataTable ListDetainedLicenses()
        {
            return DetainedLicensesDataLayer.ListDetainedLicenses();
        }
    }
}
