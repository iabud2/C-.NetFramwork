using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CountriesDataLayer
{
    public class clsCountriesDataAccess
    {
        public static bool GetCountryByID(int CountryId, ref string CountryName, ref string code, ref string phoneCode)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Countries
                                        WHERE CountryID = @Id";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Id", CountryId);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    CountryName = (string)reader["CountryName"];
                    if (reader["Code"] != DBNull.Value)
                    {
                        code = (string)reader["Code"];
                    }
                    else
                    {
                        code = "";
                    }
                    if (reader["PhoneCode"] != DBNull.Value)
                    {
                        phoneCode = (string)reader["PhoneCode"];
                    }
                    else
                    {
                        phoneCode = "";
                    }
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

        public static bool GetCountryByName(ref int countryId, ref string CountryName, ref string code, ref string phoneCode)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Countries
                                        WHERE CountryName LIKE '%' + @CountryName + '%';";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    countryId = (int)reader["CountryID"];
                    CountryName = (string)reader["CountryName"];
                    if (reader["Code"] != DBNull.Value)
                    {
                        code = (string)reader["Code"];
                    }
                    else
                    {
                        code = "";
                    }
                    if (reader["PhoneCode"] != DBNull.Value)
                    {
                        phoneCode = (string)reader["PhoneCode"];
                    }
                    else
                    {
                        phoneCode = "";
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewCountry(string CountryName, string code, string phoneCode)
        {
            int CountryID = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Countries (CountryName, Code, PhoneCode)
                                VALUES (@CountryName, @code, @PhoneCode);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);
          
            command.Parameters.AddWithValue("@CountryName", CountryName);
            
            if(code != "")
                command.Parameters.AddWithValue("@code", code);
            else
                command.Parameters.AddWithValue("@code", System.DBNull.Value);
            //---
            if (phoneCode != "")
                command.Parameters.AddWithValue("@PhoneCode", phoneCode);
            else
                command.Parameters.AddWithValue("@PhoneCode", System.DBNull.Value);
            
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    CountryID = InsertedID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error :" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return CountryID;
        }

        public static bool UpdateCountry(int countryID, string countryName, string code, string phone_code)
        {
            int RowsEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE Countries 
                                SET
                                    CountryName = @countryName,
                                    Code = @code,
                                    PhoneCode = @phonecode
                                WHERE CountryID = @countryID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@countryID", countryID);
            command.Parameters.AddWithValue("@countryName", countryName);

            if (code != "")
                command.Parameters.AddWithValue("@code", code);
            else
                command.Parameters.AddWithValue("@code", System.DBNull.Value);
            //---
            if (phone_code != "")
                command.Parameters.AddWithValue("@PhoneCode", phone_code);
            else
                command.Parameters.AddWithValue("@PhoneCode", System.DBNull.Value);

            try
            {
                connection.Open();
                RowsEffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (RowsEffected > 0);
        }

        public static bool DeleteCountry(int countryID)
        {
            int rowsEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"DELETE FROM Countries 
                                    WHERE CountryID = @countryID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@countryID", countryID);

            try
            {
                connection.Open();
                rowsEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsEffected > 0);
        }

        public static DataTable ListCountries()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Countries ORDER BY CountryName";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
            //    Console.WriteLine("Error :" + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool IsCountryExist(int countryID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT Find=1 FROM Countries 
                                                WHERE CountryID = @countryID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@countryID", countryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsCountryExist(string countryName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT Find=1 FROM Countries 
                                                WHERE CountryName Like '%' + @countryName + '%'; ";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@countryName", countryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
               // Console.WriteLine("Error : " + ex.Message);
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
