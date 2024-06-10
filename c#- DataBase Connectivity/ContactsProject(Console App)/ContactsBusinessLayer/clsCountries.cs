using System;
using System.Data;
using CountriesDataLayer;


namespace CountriesBusinessLayer
{
    public class clsCountries
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string PhoneCode { get; set; }


        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        public clsCountries()
        {
            this.CountryID = -1;
            this.CountryName = "";
            this.CountryCode = "";
            this.PhoneCode = "";
            this.Mode = enMode.AddNew;
        }

        private clsCountries(int countryID, string countryName, string code, string phoneCode)
        {
            this.CountryID = countryID;
            this.CountryName = countryName;
            this.CountryCode= code;
            this.PhoneCode = phoneCode;
            this.Mode = enMode.Update;
        }

        public static clsCountries FindCountryByID(int id)
        {
            string CountryName = "", code = "", phoneCode = "";
            if (clsCountriesDataAccess.GetCountryByID(id, ref CountryName, ref code, ref phoneCode))
            {
                return new clsCountries(id, CountryName, code, phoneCode);
            }
            else
            {
                return null;
            }
        }

        public static clsCountries FindCountryByName(string CountryName)
        {
            int countryid = -1;
            string code = "", phoneCode = "";
            if (clsCountriesDataAccess.GetCountryByName(ref countryid, ref CountryName, ref code, ref phoneCode))
            {
                return new clsCountries(countryid, CountryName, code, phoneCode);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewCountry()
        {
            this.CountryID = clsCountriesDataAccess.AddNewCountry(this.CountryName, this.CountryCode, this.PhoneCode);
            return(this.CountryID != -1);
        }


        private bool _UpdateCountry()
        {
            return (clsCountriesDataAccess.UpdateCountry(this.CountryID, this.CountryName, this.CountryCode, this.PhoneCode));
        }

        public static bool DeleteContact(int countryID)
        {
            return(clsCountriesDataAccess.DeleteCountry(countryID));
        }

        public static DataTable ListAllCountries()
        {
            return (clsCountriesDataAccess.ListCountries());
        }

        public static bool IsCountryExist(int ID)
        {
            return (clsCountriesDataAccess.IsCountryExist(ID));
        }

        public static bool IsCountryExist(string CountryName)
        {
            return (clsCountriesDataAccess.IsCountryExist(CountryName));
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                        return true;
                    break;
                case enMode.Update:
                    return _UpdateCountry();
            }
            return false;
        }
    }
}
