using DVLD_DataAccesLayer.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.CompilerServices;
namespace DVLD_BusinessLayer.Application
{
    public class cls_LDLA
    {
        //this is The business Layer for Local Driving License Appliactions.
        public int LDLA_ID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        enum enMode { AddNew = 0, Update = 1}
        private enMode Mode;
        
        
        
        
        public cls_LDLA()
        {
            LDLA_ID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
            Mode = enMode.AddNew;
        }

        private cls_LDLA(int ldla_ID, int Applicat_ID, int ClassID)
        {
            this.LDLA_ID = ldla_ID;
            ApplicationID = Applicat_ID;
            LicenseClassID = ClassID;
            Mode = enMode.Update;
        }

        static public DataTable ListAll_LDLA()
        {
            return (Local_DL_ApplicationsDataLayer.Get_LDLA_List());
        }

        static public cls_LDLA GetApplicationInfo(int ldla_ID)
        {
             int applicat_ID = -1 , ClassID = -1 ;
            if (Local_DL_ApplicationsDataLayer.FindLocal_DL_Application(ldla_ID, ref applicat_ID, ref ClassID))
            {
                return new cls_LDLA(ldla_ID, applicat_ID, ClassID);
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

        private bool DeleteLDLA(int ldla_ID) 
        {
            return (Local_DL_ApplicationsDataLayer.Delete_LDLA(ldla_ID));
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew;
                    if(AddNewLDLA()) 
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
