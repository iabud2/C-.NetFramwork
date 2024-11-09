using DVLD_DataAccesLayer.Licenses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer.Licenses
{
    public class clsLicenseClasses
    {
        public int ClassID { set; get; }
        public string ClassName { set; get; }
        public string ClassDescription { set; get; }
        public int MinAllowedAge { set; get; }
        public int DefaultValidityDate { set; get; }
        public float ClassFees { set; get; }

        enum enMode { AddNew = 1, Update = 2 }
        enMode Mode;

        public clsLicenseClasses()
        {
            this.ClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinAllowedAge = -1;
            this.DefaultValidityDate = -1;
            this.ClassFees = -1;
            Mode = enMode.AddNew;
        }

        private clsLicenseClasses(int classID, string className, string classDescription,int minAllowedAge, int defaultValidityDate, float fees)
        {
            this.ClassID = classID;
            this.ClassName = className;
            this.ClassDescription = classDescription;
            this.MinAllowedAge = minAllowedAge;
            this.DefaultValidityDate = defaultValidityDate;
            this.ClassFees= fees;
            Mode = enMode.Update;
        }

        static public DataTable ListLicenseClasses()
        {
            return (LicenseClassesDataLayer.ListLicenseClasses());
        }

        static public bool DeleteLicenseClass(int ClassID)
        {
            return(LicenseClassesDataLayer.DeleteLicenseClass(ClassID));
        }

        static public clsLicenseClasses Find(int classID)
        {
            int minAllowedAge = -1, defaultValidityDate = -1;
            string name = "", description = "";
            float fees = -1;
            if(LicenseClassesDataLayer.GetLicenseClassInfo(classID, ref name, ref description, ref minAllowedAge, 
                                            ref  defaultValidityDate, ref fees))
            {
                return new clsLicenseClasses(classID, name, description, minAllowedAge, defaultValidityDate, fees);
            }
            return null;
        }

        static public clsLicenseClasses Find(string name)
        {
            int classID = -1;
            int minAllowedAge = -1, defaultValidityDate = -1;
            string description = "";
            float fees = -1;
            if (LicenseClassesDataLayer.GetLicenseClassByClassName(ref classID,  name, ref description, ref minAllowedAge,
                                            ref defaultValidityDate, ref fees))
            {
                return new clsLicenseClasses(classID, name, description, minAllowedAge, defaultValidityDate, fees);
            }
            return null;
        }

        private bool _AddNewLC()
        {
            this.ClassID = LicenseClassesDataLayer.AddNewLicenseClass(this.ClassName, this.ClassDescription, this.MinAllowedAge,
                                                            this.DefaultValidityDate, this.ClassFees);
            return (this.ClassID != -1);
        }

        private bool _UpdateLicenseClass()
        {
            return (LicenseClassesDataLayer.UpdateLicenseClass(this.ClassID, this.ClassName, this.ClassDescription, this.MinAllowedAge,
                                                                this.DefaultValidityDate, this.ClassFees));
        }
        

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLC())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateLicenseClass();
            }
            return false;
        }
    }
}
