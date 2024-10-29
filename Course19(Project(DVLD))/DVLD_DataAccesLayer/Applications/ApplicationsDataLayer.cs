using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccesLayer.Applications
{
    static public class ApplicationsDataLayer
    {
        //crud operation for Applications Table:
        
        static public bool GetApplicationInfo(int ApplicationID, ref DateTime ApplicationDate, ref int PersonID, ref string ApplicationStatus,
                       ref float PaidFees, ref int ApplicaitonType, ref DateTime LastStatusDate, ref int CreatedBy)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM Applications
                                           WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    isFound = true;
                    ApplicationDate = (DateTime)(reader["ApplicationDate"]);
                    PersonID = (int)reader["PersonID"];
                    ApplicationStatus = reader["ApplicationStatus"].ToString();
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    ApplicaitonType = (int)reader["ApplicationType"];
                    LastStatusDate = (DateTime)(reader["LastStatusData"]);
                    CreatedBy = (int)reader["CreatedByUser"];
                }
                reader.Close();
            }
            catch (Exception e)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        static public DataTable GetApplicationsList()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Applications";
            SqlCommand command = new SqlCommand(Query, connection);
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if ((reader.HasRows))
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

        static public int AddNewApplication(DateTime ApplicationDate, int PersonID, string ApplicationStatus, float PaidFees, int ApplicationType,
                                            DateTime LastStatusDate, int CreatedByUser)
        {
            int NewApplicationID = -1;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Applications
                                            (ApplicationDate, PersonID, ApplicationStatus, PaidFees, ApplicationType, LastStatusDate, CreatedByUser)
                             VALUES
                                  (@ApplicationDate, @PersonID, @ApplicationStatus, @PaidFees, @ApplicationType, @LastStatusDate, @CreatedByUser);
                            SELECT SCOPE_IDENTITY();";
            
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@ApplicationType", ApplicationType);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@CreatedByUser", CreatedByUser);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    NewApplicationID = InsertedID;
                }
            }
            catch(Exception ex) 
            {

            }
            finally
            {
                connection.Close();
            }

            return NewApplicationID;
        }

        static public bool UpdateApplication(int ID, DateTime ApplicationDate, int PersonID, string ApplicationStatus, float PaidFees,
                                            int ApplicationType, DateTime LastStatusDate, int CreatedByUser)
        {
            int EffectedRows = -1;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string query = @"UPDATE Applications
                            SET
                            (
                              ApplicationDate = @ApplicationDate,
                              PersonID = @PersonID,
                              ApplicationStatus = @ApplicationStatus,
                              PaidFees = @PaidFees,
                              ApplicationType = @ApplicationType,
                              LastStatusDate = @LastStatusDate,
                              CreatedByUser = @CreatedByUser         
                            )
                            WHERE ApplicationID = @ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@ApplicationType", ApplicationType);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@CreatedByUser", CreatedByUser);

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

        public static bool DeleteApplicationType(int ApplicationID)
        {
            int EffectedRows = -1;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string query = @"DELETE FROM Applications
                                        WHERE ApplicationID = @ApplicationID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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
        

    }
}
