using System;
using System.Data;
using ContactsBusinessLayer;
using CountriesBusinessLayer;


namespace Project_Contacts_
{
    internal class Program
    {
        static void testFindContact(int ID)

        {
            clsContacts Contact1 = clsContacts.Find(ID);

            if (Contact1 != null)
            {
                Console.WriteLine(Contact1.FirstName+ " " + Contact1.LastName);
                Console.WriteLine(Contact1.Email);
                Console.WriteLine(Contact1.Phone);
                Console.WriteLine(Contact1.Address);
                Console.WriteLine(Contact1.DateOfBirth);
                Console.WriteLine(Contact1.CountryID);
                Console.WriteLine(Contact1.ImagePath);
            }
            else 
            {
                Console.WriteLine("Contact [" + ID + "] Not found!");   
            }
        }


        public static  void testAddNewContact()
        {
            clsContacts Contact1 = new clsContacts();

            Contact1.FirstName = "Mona";
            Contact1.LastName = "Ali";
            Contact1.Email = "Monaali@gmail.com";
            Contact1.Phone = "0551133221";
            Contact1.Address = "113 Easey";
            Contact1.DateOfBirth = new DateTime(1997, 1, 1, 1, 1, 1);
            Contact1.CountryID = 6;
            Contact1.ImagePath = "";
        
            if(Contact1.Save())
            {
                Console.WriteLine("Contact Added Successfully with id=" + Contact1.ID);
            }
        }

        public static void testUpdateContact(int contactID)
        {
            clsContacts contact = clsContacts.Find(contactID);
            if(contact != null) 
            {
                contact.FirstName = "Mohammed";
                contact.LastName = "Alsamani";
                contact.Email = "awadiah@gmail.com";
                contact.Phone = "09988123";
                contact.Address = "123 Kadaro";
                contact.DateOfBirth = new DateTime(1999, 1, 1, 1, 1, 1);
                contact.CountryID = 7;
                contact.ImagePath = "https://www.instagram.com/p/3R6KR9K2_3/?igsh=MTdneGxqcXV5M3R3NQ==";
            }

            if(contact.Save())
            {
                Console.WriteLine("Record Updated Successfully");
            }
        }

        public static void testDeleteContact(int ID)
        {
            if(clsContacts.DeleteContact(ID))
            {
                Console.WriteLine("Record Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Faild to delete record.");
            }
        }

        public static void testGetAllContacts()
        {
            DataTable data = clsContacts.GetAallContacts();

            Console.WriteLine("Contacts Table Records:");

            foreach(DataRow row in data.Rows) 
            {
                Console.WriteLine($"{row["ContactID"]}- {row["FirstName"]} {row["LastName"]}");
            }
        }

        public static void testIsContactExist(int ID)
        {
            if(clsContacts.IsContactExist(ID))
            {
                Console.WriteLine("Contact Found");
            }
            else 
            {
                Console.WriteLine("Contact Not Found");
            }
        }

        static public void testGetCountryByID(int countryID)
        {
            clsCountries country = clsCountries.FindCountryByID(countryID);
            if (country != null)
            {
                Console.WriteLine(country.CountryID);
                Console.WriteLine(country.CountryName);
            }
            else
            {
                Console.WriteLine("Country Not Found");
            }
        }

        static public void testGetCountryByName(string countryName)
        {
            clsCountries country = clsCountries.FindCountryByName(countryName);
            if (country != null)
            {
                Console.WriteLine(country.CountryID);
                Console.WriteLine(country.CountryName);
            }
            else
            {
                Console.WriteLine("Country Not Found");
            }
        }

        static public void testAddNewCountry()
        {
            clsCountries country = new clsCountries();
            country.CountryName = "Jordan";
            country.CountryCode = "962";
            country.PhoneCode = "962";

            if (country.Save())
            {
                Console.WriteLine($"Country {country.CountryName} Added Successfully with ID : {country.CountryID}");
            }
            else
            {
                Console.WriteLine($"Adding Country {country.CountryName} Faild");
            }
        }

        static public void testUpdateCountry()
        {
            clsCountries country = clsCountries.FindCountryByID(8);
            country.CountryName = "Oman";
            if (country != null)
            {
                country.Save();
                Console.WriteLine($"Country with ID:{country.CountryID}, Updated To: {country.CountryName}");
            }
            else
            {
                Console.WriteLine("Updating Country Faild!");
            }


        }

        public static void testDeleteCountry(int ID)
        {
            if (clsCountries.DeleteContact(ID))
            {
                Console.WriteLine("Record Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Delete Record Faild");
            }
        }

        public static void testListCountries()
        {
            DataTable dt = clsCountries.ListAllCountries();

            Console.WriteLine("Table 'Countries' Items:");

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["CountryID"]}, {row["CountryName"]} ");
            }

        }

        public static void testIsExistByID(int ID)
        {
            if (clsCountries.IsCountryExist(ID))
            {
                Console.WriteLine("Record Found");
            }
            else
            {
                Console.WriteLine("Record Not Found");
            }
        }

        public static void testIsExistByName(string name)
        {
            if (clsCountries.IsCountryExist(name))
            {
                Console.WriteLine("Record Found");
            }
            else
            {
                Console.WriteLine("Record Not Found");
            }
        }

        static void Main(string[] args)
        {
            //testFindContact(9);

            //testAddNewContact();

            //testUpdateContact(2);

            //testDeleteContact(11);

            //testGetAllContacts();

            //testIsContactExist(1);

            //testGetCountryByID(7);

            //testGetCountryByName("saudi");

            //testAddNewCountry();

            //testUpdateCountry();

            //testDeleteCountry(8);

            //testListCountries();

            //testIsExistByID(100);

            //testIsExistByName("Egypt");
            Console.ReadKey();
            
        }
    }
}
