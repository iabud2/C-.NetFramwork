using System;
using System.Data;
using System.Data.SqlClient;

namespace Practice
{
    internal class Program
    {
        static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456";
        
        static void PrintAllContacts()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE ContactID = 1";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) 
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {contactID}");
                    Console.WriteLine($"Name: {firstName} {lastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();

                }
                reader.Close();
                connection.Close();

            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error :" + ex.Message);
            }

        }

        static void PrintAllContactsWithFirstName(string FirstName)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE FirstName = @FirstName";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {contactID}");
                    Console.WriteLine($"Name: {firstName} {lastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();

                }
                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
        }

        static void PrintALlContactsWithFirstNameAndCountryId(string FirstName, int CountryId) 
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE FirstName = @FirstName and CountryID = @CountryId";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@CountryID", CountryId);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {contactID}");
                    Console.WriteLine($"Name: {firstName} {lastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();

                }
                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
        }
        
        static void SearchContactsStarstWith(string StartsWith)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE FirstName LIKE '' + @StartsWith + '%'";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@StartsWith", StartsWith);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {contactID}");
                    Console.WriteLine($"Name: {firstName} {lastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();

                }
                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
        }

        static void SearchContactsEndstWith(string EndsWith)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE FirstName LIKE '%' + @EndsWith + ''";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@EndsWith", EndsWith);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {contactID}");
                    Console.WriteLine($"Name: {firstName} {lastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();

                }
                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
        }

        static void SearchContactsContains(string Contains)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE FirstName LIKE '%' + @Contains + '%'";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {contactID}");
                    Console.WriteLine($"Name: {firstName} {lastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();

                }
                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
        }

        static String GetFirstName(int ConactId)
        {
            string FirstName = "";

            SqlConnection connection = new SqlConnection(ConnectionString);
            
            string Query = "SELECT FirstName FROM Contacts WHERE ContactID = @ContactId";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ContactId", ConactId);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result != null)
                {
                    FirstName = result.ToString();
                }
                else
                {
                    FirstName = "";
                }

                connection.Close();
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Error : " + ex.Message);

            }

            return FirstName;
        }

        public struct stContact
        {
            public int ID {  get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public  string Phone { get; set; }
            public string Address { get; set; }
            public int CountryId { get; set; }
        }

        static bool FindContactByID(int ContactId, ref stContact ContactInfo)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE ContactID = @ContactId";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ContactId", ContactId);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ContactInfo.ID = (int)reader["ContactID"];
                    ContactInfo.FirstName = (string)reader["FirstName"];
                    ContactInfo.LastName = (string)reader["LastName"];
                    ContactInfo.Email = (string)reader["Email"];
                    ContactInfo.Phone = (string)reader["Phone"];
                    ContactInfo.Address = (string)reader["Address"];
                    ContactInfo.CountryId = (int)reader["CountryID"];

                }
                else
                {
                    isFound = false;                  
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " +  ex.Message);
            }

            return isFound;
        }

        static void PrintRecord(stContact ContactInfo)
        {
            Console.WriteLine("ContactID: " + ContactInfo.ID);
            Console.WriteLine("FirstName: " + ContactInfo.FirstName);
            Console.WriteLine("LastName: " + ContactInfo.LastName);
            Console.WriteLine("Email: " + ContactInfo.Email);
            Console.WriteLine($"Phone: {ContactInfo.Phone}");
            Console.WriteLine($"Address: {ContactInfo.Address}");
            Console.WriteLine($"CountryID: {ContactInfo.CountryId}");
        }

        static void AddNewContact(stContact ContactInfo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, CountryID)
                            VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @CountryId);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@FirstName", ContactInfo.FirstName);
            command.Parameters.AddWithValue("@LastName", ContactInfo.LastName);
            command.Parameters.AddWithValue("@Email", ContactInfo.Email);
            command.Parameters.AddWithValue("@Phone", ContactInfo.Phone);
            command.Parameters.AddWithValue("@Address", ContactInfo.Address);
            command.Parameters.AddWithValue("@CountryId", ContactInfo.CountryId);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    Console.WriteLine($"Newly inserted ID: {insertedID}");
                }
                else
                {
                    Console.WriteLine("Failed to retrieve the inserted ID.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message ); 
            }

            connection.Close();
        }

        static void UpdateContact(int ContactId, stContact ContactInfo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = @"UPDATE Contacts  SET FirstName = @FirstName, LastName = @LastName,
                            Email = @Email, Phone = @Phone, Address = @Address, CountryID = @CountryId WHERE ContactID = @ContactId";
            
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@FirstName", ContactInfo.FirstName);
            command.Parameters.AddWithValue("@LastName", ContactInfo.LastName);
            command.Parameters.AddWithValue("@Email", ContactInfo.Email);
            command.Parameters.AddWithValue("@Phone", ContactInfo.Phone);
            command.Parameters.AddWithValue("@Address", ContactInfo.Address);
            command.Parameters.AddWithValue("@CountryId", ContactInfo.CountryId);
            command.Parameters.AddWithValue("@ContactId", ContactId);
                
            try
            {
                connection.Open();

                int RowsEffected = command.ExecuteNonQuery();

                if (RowsEffected > 0) 
                {
                    Console.WriteLine($"Update {RowsEffected} Rows Done Successfully1");
                }
                else
                {
                    Console.WriteLine("Now Rows Effected");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message );
            }

            connection.Close();
        }

        static void DeleteContact(int ContactId)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = @"DELETE Contacts 
                                    WHERE ContactID = @ContactId";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ContactId", ContactId);

            try
            {
                connection.Open();

                int RowsEffected = command.ExecuteNonQuery();

                if (RowsEffected > 0)
                {
                    Console.WriteLine("Record Deleted Successfully!");
                }
                else
                {
                    Console.WriteLine("No Rows Effected");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }

            connection.Close();
        }
        static void Main(string[] args)
        {

            PrintAllContacts();

            PrintAllContactsWithFirstName("Jane");

            PrintALlContactsWithFirstNameAndCountryId("Jane", 1);

            //--------------------------------------------------

            SearchContactsStarstWith("J");

            SearchContactsEndstWith("e");

            SearchContactsContains("an");

            //---------------------------------------------------

            
            Console.WriteLine(GetFirstName(900));

            stContact contact = new stContact();

            if(FindContactByID(1, ref contact))
            {
                PrintRecord(contact);
            }
            else 
            {
                Console.WriteLine("Contact Not Found");
            }
            

            //---------------------------------------------------

            
            stContact contact1 = new stContact
            {
                FirstName = "Mona",
                LastName = "Ali",
                Email = "Mona@Ez.com",
                Phone = "02555558",
                Address = "123 Hard Street",
                CountryId = 1
            };

            AddNewContact(contact1);
            

            //---------------------------------------------------

            
            stContact contact2 = new stContact
            {
                FirstName = "Hoda",
                LastName = "Khaled",
                Email = "Hoda@Ex.com",
                Phone = "0994921",
                Address = "123 Hoda Street",
                CountryId = 2
            };

            UpdateContact(8, contact2);
            


            //---------------------------------------------------

            DeleteContact(10);
            Console.ReadKey();
        }
    }
}
