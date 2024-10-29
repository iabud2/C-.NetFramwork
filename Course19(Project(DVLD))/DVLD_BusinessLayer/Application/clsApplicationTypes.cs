using DVLD_DataAccesLayer.Applications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_BusinessLayer.Application
{
    public class clsApplicationTypes
    {
        public int ApplicationID { get; set; }

        public string ApplicationName { get; set; }

        public float ApplicationFees { get; set; }

        enum enMode { AddNew = 0, Update = 1 };

        enMode Mode;

        public clsApplicationTypes()
        {
            ApplicationID = -1;
            ApplicationName = "";
            ApplicationFees = -1;
            Mode = enMode.AddNew;
        }

        private clsApplicationTypes(int ID, string Name, float Fees)
        {
            ApplicationID = ID;
            ApplicationName = Name;
            ApplicationFees = Fees;
            Mode = enMode.Update;
        }

        //let's handle crud opreations:

        private bool _AddNewApplicationType()
        {
            this.ApplicationID = ApplicationsTypesDataLayer.AddNewApplicationType(this.ApplicationName, this.ApplicationFees);

            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplicationType()
        {
            return (ApplicationsTypesDataLayer.UpdateApplicationType(this.ApplicationID, this.ApplicationName, this.ApplicationFees));
        }

        static public bool DeleteApplicationType(int ID)
        {
            return (ApplicationsTypesDataLayer.DeleteApplicationType(ID));
        }

        static public DataTable GetApplicationTypesList()
        {
            return (ApplicationsTypesDataLayer.GetAllApplicationsTypes());
        }

        static public clsApplicationTypes GetApplicationTypeInfo(int ID, string Name, float Fees)
        {
            if(ApplicationsTypesDataLayer.GetApplictionTypeInfo(ID, ref Name, ref Fees))
            {
                return new clsApplicationTypes(ID, Name, Fees);
            }
            return null;
        }

        static public clsApplicationTypes Find(int ID)
        {
            string Title = "";
            float Fees = -1;
            return (GetApplicationTypeInfo(ID, Title, Fees));
            
        }

        public bool Save()
        {
            switch (Mode)
            {
                case (enMode.AddNew):
                    if (_AddNewApplicationType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case (enMode.Update):
                    return (_UpdateApplicationType());
            }
            return false;
        }

    }
}
