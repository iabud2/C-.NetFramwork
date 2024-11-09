using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccesLayer.Applications
{
    static public class ApplicationsDataLayer
    {
        //crud operation for Applications Table:
        
        static public bool GetApplicationInfo(int ApplicationID, ref DateTime ApplicationDate, ref int PersonID, ref int ApplicationStatus,
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
                    ApplicationStatus = (int)reader["ApplicationStatus"];
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

        static public int AddNewApplication(DateTime ApplicationDate, int PersonID, int ApplicationStatus, float PaidFees, int ApplicationType,
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

        static public bool UpdateApplication(int ID, DateTime ApplicationDate, int PersonID, int ApplicationStatus, float PaidFees,
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

        public static bool DeleteApplication(int ApplicationID)
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
        

        public static int GetActiveApplicationID(int PerosnID, int ApplicationtTypeID)
        {
            int ActiveApplicationID = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT ActiveApplicationID = ApplicationID FROM Applications
                                    WHERE PersonID = @PersonID AND ApplicationType = @ApplicationType AND ApplicationStatus = 1";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PerosnID);
            Command.Parameters.AddWithValue("@ApplicationType", ApplicationtTypeID);
            try
            {
                Connection.Open();
                Object result = Command.ExecuteScalar();
                if(result != null & int.TryParse(result.ToString(), out int ActiveID))
                {
                    ActiveApplicationID = ActiveID;
                }
            }
            catch(Exception ex) 
            {
            }
            finally
            {
                Connection.Close();
            }

            return ActiveApplicationID;
        }

        public static bool DeosPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return(GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveID = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Applications.ApplicationID FROM Applications
                                INNER JOIN LocalDrivingLicenseApplications ON 
                                    LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                                    WHERE PersonID = @PersonID AND ApplicationType = @ApplicationTypeID AND
                                    LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                                    AND Applications.ApplicationStatus = 1;";
            
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();
                Object result = Command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int resultID))
                {
                    ActiveID = resultID;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Connection.Close();
            }
            return ActiveID;

        }


        public static bool UpdateApplicationStatus(int ApplicationID, int  ApplicationStatus) 
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"UPDATE Applications
                            SET 
                                ApplicationStatus = @ApplicationStatus,
                                LastStatusDate = @LastStatusDate
                            WHERE ApplicationID = @ApplicationID;";
            
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                EffectedRows = Command.ExecuteNonQuery();
            }
            catch(Exception ex) 
            { }
            finally 
            {
                Connection.Close();
            }


            return (EffectedRows > 0);
        }


        static public bool IsApplicationExist(int ApplicationID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM Applications
                                    WHERE ApplicationID = @ApplicationID";
            SqlCommand Command = new SqlCommand(Query,  Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                isFound = Reader.HasRows;
                Reader.Close();
            }
            catch (Exception ex)
            {
                //Type Any Exception.
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }

        

    }
}
