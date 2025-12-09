using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccesLayer.Licenses
{
    static public class LicenseClassesDataLayer
    {
        //Crud Operations For LicenseClasses Tabel.
        //Columns : "ClassID", "ClassName", "ClassDescription", "MinimumAllowedAge", "DefaultValidityDate", "ClassFees".

        public static bool GetLicenseClassInfo(int ClassID, ref string ClassName, ref string ClassDescription, ref int MinimumAllowedAge, ref int DefaValidityDate, ref float Fees)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM LicenseClasses
                                    WHERE ClassID = @ClassID;";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ClassID", ClassID);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    isFound = true;
                    ClassName = reader["ClassName"].ToString();
                    ClassDescription = reader["ClassDescription"].ToString();
                    MinimumAllowedAge = (int)reader["MinimumAllowedAge"];
                    DefaValidityDate = (int)reader["DefaultValidityDate"];
                    Fees = Convert.ToSingle(reader["ClassFees"]);
                }
                reader.Close();
            }
            catch (Exception ex) 
            {

            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }

        static public bool GetLicenseClassByClassName(ref int ID, string Name, ref string Description, ref int MinAllowedAge, 
                                            ref int DefaultValidityDate, ref float fees)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LicenseClasses 
                                WHERE ClassName = @ClassName";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ClassName", Name);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ID = (int)reader["ClassID"];
                    Description = reader["ClassDescription"].ToString();
                    MinAllowedAge = (int)reader["MinimumAllowedAge"];
                    DefaultValidityDate = (int)reader["DefaultValidityDate"];
                    fees = Convert.ToSingle(reader["ClassFees"]);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                //Type Your Exception.
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }



        static public DataTable ListLicenseClasses() 
        { 
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM LicenseClasses";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if(reader.HasRows) 
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch(Exception ex) 
            {

            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }

        static public int AddNewLicenseClass(string ClassName, string ClassDescription, int MinAllowedAge, int DefaultValidityDate, float Fees)
        {
            int NewID = -1;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO LicenseClasses
                                (ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityDate, ClassFees)
                             VALUES
                                (@ClassName, @ClassDescription, @MinAllowedAge, @DefaultValidityDate, @Fees);
                            
                               SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinAllowedAge", MinAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityDate", DefaultValidityDate);
            command.Parameters.AddWithValue("@Fees", Fees);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    NewID = insertedID;
                }
            }
            catch (Exception ex) 
            {

            }
            finally
            {
                connection.Close();
            }

            return NewID;
        }

        static public bool UpdateLicenseClass(int ClassID, string ClassName, string ClassDescription, int MinAllowedAge, int DefaultValidityDate, float Fees)
        {
            int EffectedRows = -1;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"UPDATE  LicenseClasses
                                SET
                                ClassName = @ClassName, 
                                ClassDescription = @ClassDescription, 
                                MinimumAllowedAge = @MinAllowedAge, 
                                DefaultValidityDate = @DefaultValidityDate, 
                                ClassFees = @Fees,

                             WHERE LicenseClassID = @ClassID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinAllowedAge", MinAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityDate", DefaultValidityDate);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@ClassID", ClassID);


            try
            {
                connection.Open();
                EffectedRows = command.ExecuteNonQuery();
            }
            catch(Exception e)
            {

            }
            finally
            {
                connection.Close();
            }

            return (EffectedRows > 0);
        }

        static public bool DeleteLicenseClass(int ClassID)
        {
            int EffectedRows = -1;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM LicenseClasses
                             WHERE LicenseClassID = @ClassID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ClassID", ClassID);


            try
            {
                connection.Open();
                EffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            finally
            {
                connection.Close();
            }

            return (EffectedRows > 0);
        }


    }
}
