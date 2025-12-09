using DVLD_DataAccesLayer.Drivers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_BusinessLayer.Drivers
{
    public class clsDrivers
    {
        enum enMode {Update = 0, Add  =1 }
        enMode Mode = enMode.Add;
        public int DriverID { set;get;}
        public int PersonID { set;get;}
        public DateTime CreatedDate { set;get;}
        public int CreatedBy { set;get;}

        private clsDrivers(int driverID, int perosnID, int createdBy, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = perosnID;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
            Mode = enMode.Update;
        }

        public clsDrivers()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedDate = DateTime.Now;
            CreatedBy = -1;
            Mode = enMode.Add;
        }

        static public DataTable GetDriversList()
        {
            return (DriversDataLayer.ListAllDrivers());
        }

        static public clsDrivers GetDriverInfo(int driverID)
        {
            int personID = -1, createdBy = -1;
            DateTime createdDate = DateTime.Now;
            if(DriversDataLayer.GetDriverInfo(driverID, ref personID, ref createdBy, ref createdDate))
            {
                return (new clsDrivers(driverID,  personID, createdBy, createdDate));
            }
            return null;
        }

        static public clsDrivers GetDriverInfoByPersonID(int personID)
        {
            int driverID = -1, createdBy = -1;
            DateTime creationDate = DateTime.Now;
            if(DriversDataLayer.GetDriverInfoByPersonID(personID, ref driverID, ref createdBy, ref creationDate))
            {
                return (new clsDrivers(driverID, personID, createdBy, creationDate));
            }
            return null;
        }


        
        private bool _AddNewDriver()
        {
            this.DriverID = DriversDataLayer.AddNewDriver(this.PersonID, this.CreatedBy, this.CreatedDate);
            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            return (DriversDataLayer.UpdateDriver(this.DriverID, this.PersonID, this.CreatedBy, this.CreatedDate));
        }

        

        static public bool DeleteDriver(int DriverID)
        {
            return (DriversDataLayer.DeleteDriver(DriverID));
        }

        static public bool isDriver(int personID)
        {
            return(DriversDataLayer.isDriver(personID));
        }

        public bool Save()
        {
            switch(Mode) 
            {
                case enMode.Add:
                    {
                        if (_AddNewDriver())
                        {
                            return true;
                        }
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateDriver();
                    }
            }
            return false;
        }
    }
}
