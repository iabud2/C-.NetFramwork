using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DVLD_DataAccesLayer.Applications
{
    static public class Local_DL_ApplicationsDataLayer
    {
        //we need to manage crud operations
        //for Local Driving Licence Applications.
        //Columns "LocalDrivingLicenseApplicationID"	"ApplicationID"	"LicenseClassID"

        static public bool FindLocal_DL_Application(int LDLA_ID, ref int ApplicationID, ref int ClassID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM LocalDrivingLicenseApplications
                                            WHERE LocalDrivingLicenseApplicationID = @LDLA_ID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLA_ID", LDLA_ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read()) 
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    ClassID = (int)reader["ClassID"];
                }
                reader.Close();
            }
            catch (Exception ex) 
            {

            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static DataTable Get_LDLA_List() 
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM LocalDrivingLicenseApplications;";
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
            catch (Exception e)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static int AddNew_LDLA(int ApplicationID, int ClassID)
        {
            int NewID = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO LocalDrivingLicenseApplications
                                    (ApplicationID, LicenseClassID)
                             VALUES
                                    (@ApplicationID, @ClassID);
                            
                            SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ClassID", ClassID);

            try
            {
                Connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    NewID = insertedID;
                }
            }
            catch (Exception e) 
            {

            }
            finally
            {
                Connection.Close();
            }
            return  NewID;
        }

        public static bool Update_LDLA(int ID, int ApplicationID, int ClassID)
        {
            int effectedRows = -1;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"UPDATE LocalDrivingLicenseApplications
                             SET
                                ApplicationID = @ApplicationID,
                                LicenseClassID = ClassID
                             WHERE LocalDrivingLicenseApplicationID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ID);
            command.Parameters.AddWithValue("@ClassID", ClassID);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                effectedRows = command.ExecuteNonQuery();
            }
            catch (Exception e) 
            {

            }
            finally
            {
                connection.Close();
            }

            return (effectedRows > 0);
        }

        public static bool Delete_LDLA(int ID)
        {
            int effectedRows = -1;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM LocalDrivingLiceseApplications
                                WHERE LocalDrivingLicenseApplicationID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                effectedRows = command.ExecuteNonQuery();
            }
            catch ( Exception e ) 
            {
            
            }
            finally 
            { 
                connection.Close(); 
            }

            return (effectedRows > 0);  
        }
    }
}
