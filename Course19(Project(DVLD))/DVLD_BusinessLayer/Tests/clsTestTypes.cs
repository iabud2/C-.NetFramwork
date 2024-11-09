using DVLD_DataAccesLayer.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DVLD_BusinessLayer.Tests
{
    public class clsTestTypes
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3}

        public clsTestTypes.enTestType ID { set; get; }
        public string Title {  set; get; }
        public string Description { set; get; }
        public float Fees { set; get; } 

        enum enMode { AddNew = 0, Update = 1}
        enMode Mode;
        
        public clsTestTypes()
        {
            Mode = enMode.AddNew;
            this.ID = clsTestTypes.enTestType.VisionTest;
            this.Title = "";
            this.Description = "";
            this.Fees = -1;
        }

        private clsTestTypes(clsTestTypes.enTestType id, string name, string description, float fees)
        {
            Mode = enMode.Update;
            this.ID = id;
            this.Title = name;
            this.Description = description;
            this.Fees = fees;
        }

        private bool AddNewTestType()
        {
            this.ID = (clsTestTypes.enTestType)TestTypesDataLayer.AddNewTestType(this.Title, this.Description, this.Fees);    
            return((int)this.ID != -1);
        }

        private bool UpdateTestType() 
        {
            return (TestTypesDataLayer.UpdateTestTYpe((int)this.ID, this.Title, this.Description, this.Fees));    
        }

        static public DataTable ListTestTypes()
        {
            return(TestTypesDataLayer.GetTestTypesList()); 
        }

        static public clsTestTypes GetTestTypeInfo(clsTestTypes.enTestType ID)
        {
            string Title = "", Description = "";
            float Fees = 0;
            if (TestTypesDataLayer.GetTestTypeInfo((int)ID , ref Title, ref Description, ref Fees))
            {
                return (new clsTestTypes(ID, Title, Description, Fees));
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (AddNewTestType())
                    {
                        Mode = enMode.AddNew;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return (UpdateTestType());
            }
            return false;
        }


    }
}
