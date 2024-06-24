using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccesLayer;
namespace DVLD_BusinessLayer
{
    public class clsPerson
    {   
        public enum enMode {AddNew = 0, Update = 1};

        public int PersonID { set; get; }
        public string NationalNo { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;}
        }
        
        
        public DateTime DateOfBirth { set; get; }
        public string Address { set; get; }
        public string Phone { set; get;}
        public string Email { set; get; }
        public int Gendor { set; get; }
        public int NationalityContryID { set; get; }

        public clsCountries CountryInfo;


        private string _ImagePath;

        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }





        public enMode Mode = enMode.AddNew;
        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.Gendor = 0;
            this.NationalityContryID = 1;
            this.ImagePath = "";
            this.Mode = enMode.AddNew;
        }

        private clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
                            string Address,string Phone, string Email, int Gendor, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.Gendor = Gendor;
            this.NationalityContryID =  NationalityCountryID;
            this.CountryInfo = clsCountries.Find(NationalityContryID);
            this.ImagePath = ImagePath;
            Mode = enMode.Update;

        }
        

        static public  clsPerson FindPersonByID(int ID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int Gendor = -1, NationalityContryID = -1;
            if(PeopleDataAccess.FindPersonByID(ID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                                               ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityContryID, ref ImagePath) )
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Address, Phone, Email, Gendor,
                                    NationalityContryID, ImagePath);
            }
            return null;
        }

        static public clsPerson FindPersonByNationalityNo(string NationalNo) 
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int PersonID = -1, Gendor = -1, NationalityContryID = -1;

            if (PeopleDataAccess.FindPersonByNationalNo( ref PersonID, NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                                                       ref Gendor, ref Address, ref Phone, ref Email, ref NationalityContryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Address, Phone, Email, Gendor,
                    NationalityContryID, ImagePath);
            }
            return null;
        }

        static public clsPerson FindPersonByFirstName(string FirstName)
        {
            int PersonID = -1, Gendor = -1, CountryID = -1;
            DateTime DateOfBirth = DateTime.Now;
            string NationalNo = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";

            if (PeopleDataAccess.FindPersonByFirstName(ref PersonID, ref NationalNo, FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                                                                ref Gendor, ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath))
            {
                return (new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Address, Phone, Email, Gendor, CountryID, ImagePath));
            }
            return null;
        }

        static public clsPerson FindPersonBySecondName(string SecondName)
        {
            int PersonID = -1, Gendor = -1, CountryID = -1;
            DateTime DateOfBirth = DateTime.Now;
            string NationalNo = "", FirstName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";

            if (PeopleDataAccess.FindPersonBySecondName(ref PersonID, ref NationalNo, ref FirstName, SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                                                                ref Gendor, ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath))
            {
                return (new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Address, Phone, Email, Gendor, CountryID, ImagePath));
            }
            return null;
        }

        static public clsPerson FindPersonByThirdName(string ThirdName)
        {
            int PersonID = -1, Gendor = -1, CountryID = -1;
            DateTime DateOfBirth = DateTime.Now;
            string NationalNo = "", FirstName = "", SecondName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";

            if (PeopleDataAccess.FindPersonByThirdName(ref PersonID, ref NationalNo, ref FirstName, ref SecondName, ThirdName, ref LastName, ref DateOfBirth,
                                                                ref Gendor, ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath))
            {
                return (new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Address, Phone, Email, Gendor, CountryID, ImagePath));
            }
            return null;
        }

        static public clsPerson FindPersonByLastName(string LastName)
        {
            int PersonID = -1, Gendor = -1, CountryID = -1;
            DateTime DateOfBirth = DateTime.Now;
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", Address = "", Phone = "", Email = "", ImagePath = "";

            if (PeopleDataAccess.FindPersonByLastName(ref PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName,  LastName, ref DateOfBirth,
                                                                ref Gendor, ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath))
            {
                return (new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Address, Phone, Email, Gendor, CountryID, ImagePath));
            }
            return null;
        }

        static public clsPerson FindPersonByNationality(int CountryID)
        {
            int PersonID = -1, Gendor = -1;
            DateTime DateOfBirth = DateTime.Now;
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";

            if (PeopleDataAccess.FindPersonByNationality(ref PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                                                                ref Gendor, ref Address, ref Phone, ref Email,  CountryID, ref ImagePath))
            {
                return (new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Address, Phone, Email, Gendor, CountryID, ImagePath));
            }
            return null;
        }

        static public clsPerson FindPersonByGendor(int Gendor)
        {
            int PersonID = -1, CountryID = -1;
            DateTime DateOfBirth = DateTime.Now;
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";

            if (PeopleDataAccess.FindPersonByGendor(ref PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                                                                Gendor, ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath))
            {
                return (new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Address, Phone, Email, Gendor, CountryID, ImagePath));
            }
            return null;
        }

        static public clsPerson FindPersonByPhone(string Phone)
        {
            int PersonID = -1, CountryID = -1, Gendor = -1;
            DateTime DateOfBirth = DateTime.Now;
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Email = "", ImagePath = "";

            if (PeopleDataAccess.FindPersonByPhone(ref PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                                                                ref Gendor, ref Address,  Phone, ref Email, ref CountryID, ref ImagePath))
            {
                return (new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Address, Phone, Email, Gendor, CountryID, ImagePath));
            }
            return null;
        }

        static public clsPerson FindPersonByEmail(string Email)
        {
            int PersonID = -1, CountryID = -1, Gendor = -1;
            DateTime DateOfBirth = DateTime.Now;
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", ImagePath = "";

            if (PeopleDataAccess.FindPersonByEmail(ref PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                                                                ref Gendor, ref Address, ref Phone, Email, ref CountryID, ref ImagePath))
            {
                return (new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Address, Phone, Email, Gendor, CountryID, ImagePath));
            }
            return null;
        }
        
        //CRUD Operations: Create - Read - Update - Delete: 
        private bool AddNewPerson()
        {
            this.PersonID = PeopleDataAccess.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName
                                                            , this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email,
                                                             this.NationalityContryID, this.ImagePath);
            return (PersonID != -1);
        }

        public static DataTable GetPeopleList()
        {
            return (PeopleDataAccess.GetPeopleList());
        }

        private bool UpdatePerson()
        {
            return (PeopleDataAccess.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                                        this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityContryID, this.ImagePath));
        }

        public bool DeletePerson(int PersonID)
        {
            return (PeopleDataAccess.DeletePerson(PersonID));
        }

        public static bool IsPersonExist(int ID)
        {
            return (PeopleDataAccess.IsPersonExist(ID));
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return (PeopleDataAccess.IsPersonExist(NationalNo));
        }

        public bool Save()
        {
            switch(Mode)
            {
            case enMode.AddNew:
                if (AddNewPerson())
                {
                    Mode = enMode.Update;
                    return true;
                } 
                else
                {
                    return false;       
                }
            case enMode.Update:
                return UpdatePerson();
            }
            return false;
        }
    }
}
