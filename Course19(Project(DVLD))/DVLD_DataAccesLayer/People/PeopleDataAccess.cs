using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net.Sockets;

namespace DVLD_DataAccesLayer
{
    public class PeopleDataAccess
    {
        public static bool FindPersonByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth
                                         ,ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int Nationality, ref string ImagePath)
        {
            bool isFound = false;
            
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM People 
                                            WHERE PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    NationalNo = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];
                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)Reader["ThirdName"];
                    else
                        ThirdName = "";
                    LastName = (string)Reader["LastName"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = (int)Reader["Gendor"];
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];
                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];
                    else
                        Email = "";

                    Nationality = (int)Reader["NationalityCountryID"];
                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)Reader["ImagePath"];
                    else
                        ImagePath = "";
                }
                Reader.Close(); 
            }
            catch (Exception ex) 
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool FindPersonByNationalNo(ref int PersonID, string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth
                                         , ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int Nationality, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            
            string Query = @"SELECT * from People
                                     WHERE NationalNo = @NationalNo;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try 
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if(Reader.Read())
                {
                    //Name
                    IsFound = true;
                    PersonID = (int)Reader["PersonID"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];
                  
                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)Reader["ThirdName"];
                    else
                        ThirdName = "";
                  
                    LastName = (string)Reader["LastName"];
                   
                    //More Info:

                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = (int)Reader["Gendor"];
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];
                  
                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];
                    else
                        Email = "";

                    Nationality = (int)Reader["NationalityCountryID"];

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)Reader["ImagePath"];
                    else
                        ImagePath = "";
                }
                Reader.Close();
            }
            catch (Exception ex) 
            {
                IsFound = false;
            }
            finally 
            {
                connection.Close();
            }


            return IsFound;
        }

        public static bool FindPersonByFirstName(ref int PersonID, ref string NationalNo, string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth
                                 , ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int Nationality, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT * from People
                                     WHERE FirstName = @FirstName;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    //Name
                    IsFound = true;
                    PersonID = (int)Reader["PersonID"];
                    NationalNo = (string)Reader["NationalNo"];
                    SecondName = (string)Reader["SecondName"];

                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)Reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)Reader["LastName"];

                    //More Info:

                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = (int)Reader["Gendor"];
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];

                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];
                    else
                        Email = "";

                    Nationality = (int)Reader["NationalityCountryID"];

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)Reader["ImagePath"];
                    else
                        ImagePath = "";
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

        public static bool FindPersonBySecondName(ref int PersonID, ref string NationalNo, ref string FirstName, string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth
                         , ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int Nationality, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT * from People
                                     WHERE SecondName = @SecondName;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@SecondName", SecondName);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    //Name
                    IsFound = true;
                    PersonID = (int)Reader["PersonID"];
                    NationalNo = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];

                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)Reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)Reader["LastName"];

                    //More Info:

                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = (int)Reader["Gendor"];
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];

                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];
                    else
                        Email = "";

                    Nationality = (int)Reader["NationalityCountryID"];

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)Reader["ImagePath"];
                    else
                        ImagePath = "";
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

        public static bool FindPersonByThirdName(ref int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName,  string ThirdName, ref string LastName, ref DateTime DateOfBirth
                 , ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int Nationality, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT * from People
                                     WHERE ThirdName = @ThirdName;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ThirdName", ThirdName);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    //Name
                    IsFound = true;
                    PersonID = (int)Reader["PersonID"];
                    NationalNo = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];

                    LastName = (string)Reader["LastName"];

                    //More Info:

                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = (int)Reader["Gendor"];
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];

                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];
                    else
                        Email = "";

                    Nationality = (int)Reader["NationalityCountryID"];

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)Reader["ImagePath"];
                    else
                        ImagePath = "";
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

        public static bool FindPersonByLastName(ref int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, string LastName, ref DateTime DateOfBirth
              , ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int Nationality, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT * from People
                                     WHERE LastName = @LastName;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LastName", LastName);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    //Name
                    IsFound = true;
                    PersonID = (int)Reader["PersonID"];
                    NationalNo = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];


                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)Reader["ThirdName"];
                    else
                        ThirdName = "";

                    //More Info:

                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = (int)Reader["Gendor"];
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];

                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];
                    else
                        Email = "";

                    Nationality = (int)Reader["NationalityCountryID"];

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)Reader["ImagePath"];
                    else
                        ImagePath = "";
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

        public static bool FindPersonByNationality(ref int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth
             , ref int Gendor, ref string Address, ref string Phone, ref string Email, int Nationality, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT * from People
                                     WHERE NationalityCountryID = @Nationality;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Nationality", Nationality);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    //Name
                    IsFound = true;
                    PersonID = (int)Reader["PersonID"];
                    NationalNo = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];


                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)Reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)Reader["LastName"];
                    //More Info:

                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = (int)Reader["Gendor"];
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];

                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];
                    else
                        Email = "";

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)Reader["ImagePath"];
                    else
                        ImagePath = "";
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

        public static bool FindPersonByGendor(ref int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth
             , int Gendor, ref string Address, ref string Phone, ref string Email, ref int Nationality, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT * from People
                                     WHERE Gendor = @Gendor;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Gendor", Gendor);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    //Name
                    IsFound = true;
                    PersonID = (int)Reader["PersonID"];
                    NationalNo = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];


                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)Reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)Reader["LastName"];
                    //More Info:

                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Nationality = (int)Reader["NationalityCountryID"];
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];

                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];
                    else
                        Email = "";

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)Reader["ImagePath"];
                    else
                        ImagePath = "";
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

        public static bool FindPersonByPhone(ref int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth
             , ref int Gendor, ref string Address, string Phone, ref string Email, ref int Nationality, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT * from People
                                     WHERE Phone = @Phone;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Phone", Phone);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    //Name
                    IsFound = true;
                    PersonID = (int)Reader["PersonID"];
                    NationalNo = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];


                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)Reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)Reader["LastName"];
                    //More Info:

                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Nationality = (int)Reader["NationalityCountryID"];
                    Address = (string)Reader["Address"];
                    Gendor = (int)Reader["Gendor"];

                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];
                    else
                        Email = "";

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)Reader["ImagePath"];
                    else
                        ImagePath = "";
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }


        public static bool FindPersonByEmail(ref int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth
            , ref int Gendor, ref string Address, ref string Phone,  string Email, ref int Nationality, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT * from People
                                     WHERE Email = @Email;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Email", Email);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    //Name
                    IsFound = true;
                    PersonID = (int)Reader["PersonID"];
                    NationalNo = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];


                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)Reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)Reader["LastName"];
                    //More Info:

                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Nationality = (int)Reader["NationalityCountryID"];
                    Address = (string)Reader["Address"];
                    Gendor = (int)Reader["Gendor"];
                    Phone = (string)Reader["Phone"];

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)Reader["ImagePath"];
                    else
                        ImagePath = "";
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

        public static bool DeletePerson(int PersonID)
        {
            int EffectedRows = 0;

            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"DELETE FROM People
                                        WHERE PersonID = @PersonID;";


            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                EffectedRows = command.ExecuteNonQuery();
          
            }
            catch(Exception ex) 
            {
                EffectedRows = 0;
            }
            finally
            {
                connection.Close();
            }

            return (EffectedRows > 0);                     
        }
    
        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
                                        DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int CountryID, string ImagePath)
        {
            int EffectedRows = 0;

            SqlConnection connection = new SqlConnection( DVLD_DataAccessSettings.ConnectionString);

            string Query = @"UPDATE People 
                                SET 
                                    NationalNo = @NationalNo,
                                    FirstName = @FirstName,
                                    SecondName = @SecondName,
                                    ThirdName = @ThirdName,
                                    LastName = @LastName,
                                    DateOfBirth = @DateOfBirth,
                                    Gendor = @Gendor,
                                    Address = @Address,
                                    Phone = @Phone,
                                    Email = @Email,
                                    NationalityCountryID = @CountryID,
                                    ImagePath = @ImagePath
                            WHERE PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "" && ThirdName != null)
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", "");

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "" && Email != null)
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", "");

            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", "");

            try
            {
                connection.Open();

                EffectedRows = command.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {

            }
            finally
            {
                connection.Close();
            }

            return (EffectedRows > 0);
        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
                                int Gendor, string Address, string Phone, string Email, int Nationality, string ImagePath)
        {

            int PersonID = -1;

            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO People(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, 
                                                 Email, NationalityCountryID, ImagePath)
                                                    Values(@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor,    
                                                    @Address, @Phone, @Email, @Nationality, @ImagePath);
                                                 
                                                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName == "")
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "" && Email != null)
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            command.Parameters.AddWithValue("@Nationality", Nationality);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    PersonID = InsertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }


        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM People
                                                WHERE PersonID = @PersonID";
        
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                isFound = Reader.HasRows;
                Reader.Close();
            }
            catch
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM People
                                                WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                isFound = Reader.HasRows;
                Reader.Close();
            }
            catch
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }





        public static DataTable GetPeopleList()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, 
                                            People.DateOfBirth,People.Gendor,
                                            CASE
                                            WHEN People.Gendor = 0 THEN 'Female'
                                            ELSE 'Male'
                                            END As GendorCaption,
                                            People.Address, People.Phone, People.Email, People.NationalityCountryID, 
                                            Countries.CountryName, People.ImagePath
                                            FROM People
                                            INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID;";
        
            
            SqlCommand Command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                
                if(Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception ex) 
            {
                return null;
            }
            finally
            {
                connection.Close( );
            }

            return dt;
        }    

        

    
    }
}
