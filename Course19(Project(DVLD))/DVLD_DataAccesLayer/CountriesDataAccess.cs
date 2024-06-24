using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccesLayer
{
    static public class CountriesDataAccess
    {
        public  static bool GetCountryByCountryID(int CountryID, ref string CountryName)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Countries
                                            WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if(Reader.Read())
                {
                    isFound = true;
                    CountryName = (string)Reader["CountryName"];
                }
                Reader.Close();
            }
            catch (Exception ex) 
            {
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }

        public static bool GetCountryByCountryName(ref int CountryID, string CountryName)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Countries
                                            WHERE CountryName = @CountryName";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;
                    CountryID = (int)Reader["CountryID"];
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Countries";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
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
            return dt;
        }
    }
}
