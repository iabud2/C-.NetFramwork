using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccesLayer.Applications
{
    static public class ApplicationsTypesDataLayer
    {

        public static int AddNewApplicationType(string ApplicationTitle, float ApplicationFees)
        {
            int NewID = -1;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO ApplicationTypes
                                    (ApplicationTypeTitle, ApplicationFees)
                            VALUES 
                                   (@ApplicationTitle, @ApplicationFees);

                            SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@ApplicationTitle", ApplicationTitle);
            cmd.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    NewID = insertedID;
                }

            }
            catch(Exception ex) 
            {
                
            }
            finally
            {
                connection.Close();
            }
            return NewID;
        }
        
        public static bool GetApplictionTypeInfo(int ApplicationID, ref string ApplicationName, ref float ApplicationFees)
        {
            bool isFound = false;
            SqlConnection conn = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM ApplicationTypes 
                                        WHERE ApplicationTypeID = @ApplicationID;";

            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ApplicationName = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = Convert.ToSingle(reader["ApplicationFees"]);
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch(Exception ex)
            {
                isFound = false;
            }
            finally
            {
                conn.Close();
            }
            
            return isFound;
        }

        public static DataTable GetAllApplicationsTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string query = "SELECT * FROM ApplicationTypes";
            SqlCommand command = new SqlCommand(query, connection);
            
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
            catch (Exception ex)
            {
                return null;

            }
            finally
            {
                connection.Close();
            }
            
            
            return dt;
        }
 
        public static bool UpdateApplicationType(int TypeID, string TypeName, float TypeFees)
        {
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string query = @"UPDATE ApplicationTypes 
                                    SET ApplicationTypeTitle = @TypeName, ApplicationFees = @TypeFees
                                        WHERE ApplicationTypeID = @TypeID;";
            
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TypeID", TypeID);
            cmd.Parameters.AddWithValue("@TypeName", TypeName);
            cmd.Parameters.AddWithValue("@TypeFees", TypeFees);

            int effectedRows = -1;
            try 
            {
                connection.Open();
                effectedRows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) 
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (effectedRows > 0);
        }
    
        public static bool DeleteApplicationType(int TypeID)
        {
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string query = @"DELETE FROM ApplicationTypes 
                                    WHERE ApplicationTypeID = @TypeID;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TypeID", TypeID);

            int effectedRows = -1;
            try
            {
                connection.Open();
                effectedRows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (effectedRows > 0);
        }


    }


}
