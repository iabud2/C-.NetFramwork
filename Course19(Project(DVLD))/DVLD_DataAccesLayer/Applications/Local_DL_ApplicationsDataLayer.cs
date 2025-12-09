using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.Design;
using System.Runtime.Remoting.Messaging;
using System.ComponentModel;
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
                if (reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    ClassID = (int)reader["LicenseClassID"];
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

        static public bool GetLDLA_ByApplicationiD(ref int LDLAID, int ApplicationID, ref int LicenseClassID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM LocalDrivingLicenseApplications 
                                    WHERE ApplicationID = @ApplicationID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if(Reader.Read())
                {
                    IsFound = true;
                    LDLAID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];
                    Reader.Close();
                }

            }
            catch (Exception ex) 
            {
                //Type Exception.
            }
            finally
            {
                Connection.Close();
            }
            return IsFound;
        }

        static public bool DoesPassTestType(int LDLAID, int TestTypeID)
        {
            bool isPass = false;
            SqlConnection  Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM LocalDrivingLicenseApplications
                             INNER JOIN TestsAppointments ON 
                              LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestsAppointments.LocalDrivingLicenseApplicationID
                             INNER JOIN Tests ON TestsAppointments.AppointmentID = Tests.TestAppointmentID
                             WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDLAID
                             AND
                                TestsAppointments.TestTypeID = @TestTypeID
                             AND 
                                Tests.TestResult = 1";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LDLAID", LDLAID);
            Command.Parameters.AddWithValue("@TestTypeID",TestTypeID);
            
            try
            {
                
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if(Result != null)
                {
                    isPass = true;
                }
                               
            }
            catch(Exception ex) 
            {
                //Type any exception.
            }
            finally
            {
                Connection.Close();
            }

            return isPass;                  
        }

        static public bool isPersonAttendTestType(int LDLAID, int TestTypeID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT TOP 1 Found = 1 FROM LocalDrivingLicenseApplications
                            INNER JOIN TestsAppointments ON TestsAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                            INNER JOIN Tests ON Tests.TestAppointmentID = TestsAppointments.AppointmentID
                            WHERE 
                            LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDLAID AND
                            TestsAppointments.TestTypeID = @TestTypeID
                            ORDER BY TestsAppointments.AppointmentID desc; ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LDLAID", LDLAID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if(result != null)
                {
                    isFound = true;
                }
            }
            catch (Exception ex) 
            {
                //Exception Here
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        static public int TotalTrailsPerTest(int LDLAID, int TestTypeID)
        {
            int TotalTrails = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Count(*) FROM LocalDrivingLicenseApplications
                            INNER JOIN TestsAppointments ON
                            LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestsAppointments.LocalDrivingLicenseApplicationID
                                WHERE 
                                    LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDLA_ID 
                                    AND TestsAppointments.TestTypeID =  @TestTypeID
                                    AND TestsAppointments.IsLocked = 1;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LDLA_ID", LDLAID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(), out int Trials))
                {
                    TotalTrails = Trials;
                }
            }
            catch (Exception e) 
            {
                //Tybe Exception Here.
            }
            finally
            {
                Connection.Close();
            }

            return TotalTrails;
        }

        static public int TotalPassedTests(int LDLA_ID)
        {
            int TotalTrials = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Count(*) FROM LocalDrivingLicenseApplications
                                INNER JOIN TestsAppointments ON 
                                LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestsAppointments.LocalDrivingLicenseApplicationID
                                INNER JOIN Tests ON TestsAppointments.AppointmentID = Tests.TestAppointmentID
                             WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDLA_ID AND Tests.TestResult = 1;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LDLA_ID", LDLA_ID);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();    
                if(result != null && int.TryParse(result.ToString(), out int Trials))
                {
                    TotalTrials = Trials;
                }
            }
            catch(Exception e) 
            {
                //Tybe Exception Here.
            }
            finally
            {
                Connection.Close();
            }


            return TotalTrials;
        }
        public static bool IsThereAnActiveScheduledTest(int LDLAID, int TestTypeID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM LocalDrivingLicenseApplications
                                INNER JOIN TestsAppointments ON 
                                TestsAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                             WHERE
                             LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDLAID
                             AND
                             TestsAppointments.TestTypeID = @TestTypeID
                             AND 
                             TestsAppointments.IsLocked = 0;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LDLAID", LDLAID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if(result != null)
                {
                    isFound = true;
                }
            }
            catch(Exception e) 
            {
                //Type Exception
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }


        public static DataTable Get_LDLA_List()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM LocalDrivingLicenseApplications_View;";
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
            return NewID;
        }

        public static bool Update_LDLA(int ID, int ClassID)
        {
            int effectedRows = -1;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"UPDATE LocalDrivingLicenseApplications
                             SET
                                LicenseClassID = @ClassID
                             WHERE LocalDrivingLicenseApplicationID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
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
            string Query = @"DELETE FROM LocalDrivingLicenseApplications
                                WHERE LocalDrivingLicenseApplicationID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
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
    }
}
