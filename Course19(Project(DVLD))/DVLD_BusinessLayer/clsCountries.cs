using DVLD_DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsCountries
    {
        public int ID { get; set; }
        public string CountryName { get; set; }

        public clsCountries()
        {
            ID = -1;
            CountryName = "";
        }

        private clsCountries(int CountryID, string CountryName)
        {
            this.ID = CountryID;
            this.CountryName = CountryName;
        }

        static public clsCountries Find(int CountryID)
        {
            string C_Name = "";
            if (CountriesDataAccess.GetCountryByCountryID(CountryID, ref C_Name))
            {
                return new clsCountries(CountryID, C_Name);
            }
            return null;
        }

        static public clsCountries Find(string CountryName)
        {
            int CountryID = -1;
            if(CountriesDataAccess.GetCountryByCountryName(ref CountryID, CountryName))
            {
                return new clsCountries(CountryID, CountryName);
            }
            return null;
        }

        static public DataTable GetAllCountries() 
        {
            return (CountriesDataAccess.GetAllCountries());
        }

    }
}
