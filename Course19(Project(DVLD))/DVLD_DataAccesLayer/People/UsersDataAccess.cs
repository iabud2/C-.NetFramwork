using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccesLayer.People
{
    public class UsersDataAccess
    {
        //list Users
        static public DataTable ListAllUsers()
        {
            DataTable Users = new DataTable();
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"select Users.UserID, People.PersonID, Users.UserName, Users.isActive,
                                            FullName = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName + ' ' 
                                                       from Users
                                                                    inner join People on Users.PersonID = People.PersonID;";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows) 
                {
                    Users.Load(reader);
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }

            return Users;
        }

        //by userid
        static public bool FindUser(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Users 
                                        WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["isActive"];
                }
                reader.Close();
            }
            catch(Exception ex) 
            {
                isFound = false;
            }
            finally 
            {
                connection.Close();
            }
           
            return isFound;
        }

        //by username
        static public bool FindUser(ref int UserID, ref int PersonID, string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Users 
                                        WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["isActive"];
                }
                reader.Close();
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

        //Add user
        static public int AddNewUser(int PersonID, string UserName, string Password, bool isActive)
        {
            int UserID = -1;

            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Users   
                                (PersonID, UserName, Password, isActive)
                             VALUES
                             (@PersonID, @UserName, @Password, @isActive);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@isActive", isActive);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    UserID = InsertedID;
                }
            }
            catch (Exception ex) 
            {
                
            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }

        static public bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool isActive)
        {
            int EffectedRows = -1;
            
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"UPDATE Users 
                                SET PersonID = @PersonID,
                                    UserName = @UserName,
                                    Password = @Password,
                                    isActive = @isActive
                                WHERE UserID = @UserID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@isActive", isActive);

            try
            {
                connection.Open();
                EffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                
            }
            finally
            {
                connection.Close();
            }

            return (EffectedRows > 0);

        }

        static public bool DeleteUser(int UserID)
        {
            int EffectedRows = -1;

            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"DELETE FROM Users
                                    WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                EffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {

            }
            finally
            {
                connection.Close();
            }

            return (EffectedRows > 0);
        }

        static public bool isExists(int UserID)
        {
            bool isFound = false;
           
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT Found = 1 FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
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

        static public bool isExists(string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT Found = 1 FROM Users WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
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

        static public bool isExistsByPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT Found = 1 FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
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

    }
}
