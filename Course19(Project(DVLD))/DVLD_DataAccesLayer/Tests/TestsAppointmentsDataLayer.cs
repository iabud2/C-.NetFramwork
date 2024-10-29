using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccesLayer.Tests
{
    static public class TestsAppointmentsDataLayer
    {
        //table(Tests Appointments) columns : "AppointmentID" int PK, "LocalDrivingLicenseApplicationID" FK int, "TestTypeID" int FK, 
        //"Appointment Date" datetime, "PaidFees" smallmoney, "IsLocked" bit, "CreatedByUserID" int FK.
        //as always.. Crud operations.

        static public bool GetTestAppointmentInfo(int AppointmentID, ref int LDLA_ID, ref int TestTypeID, ref DateTime AppointmentDate, 
                            ref float PaidFees, ref bool IsLocked, ref int CreatedBy)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM TestAppointments
                                        WHERE AppointmentID = @AppointmentID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    LDLA_ID = (int)reader["TestAppointmentID"];
                    TestTypeID = (int)reader["TestTypeID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsLocked = (bool)reader["IsLocked"];
                    CreatedBy = (int)reader["CreatedByUserID"];
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

        public static DataTable ListAllAppointments()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM TestsAppointments;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
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
                Connection.Close();
            }


            return dt;
        }

        public static int AddNewAppointment(int LDLA_ID, int TestTypeID, DateTime AppointmentDate, float PaidFees, bool IsLocked, int CreatedBy)
        {
            int NewID = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO TestsAppointments
                            (LocalDrivingLicenseApplicationID, TestTypeID, AppointmentDate, PaidFeed, IsLocked, CreatedByUserID)
                            VALUES
                            (@LDLA_ID, @TestTypeID, @AppintmentDate, @PaidFeed, @IsLocked, @CreatedBy);
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LDLA_ID", LDLA_ID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@AppintmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFeed", PaidFees);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);
            Command.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
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

        public static bool UpdateAppointment(int AppintmentID, int LDLA_ID, int TestTypeID, DateTime AppointmentDate,
                                            float PaidFees, bool IsLocked, int CreatedBy)
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"UPDATE TestsAppointments
                             SET
                                LocalDrivingLicenseApplicationID = @LDLA_ID,
                                TestTypeID = @TestTypeID,
                                AppointmentDate = @AppointmentDate,
                                PaidFees = @PaidFees,
                                IsLocked = @IsLocked,
                                CreatedByUserID = @CreatedBy,
                             WHERE AppointmentID = @AppintmentID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppintmentID", AppintmentID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);
            Command.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            try
            {
                Connection.Open();
                EffectedRows = Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            finally
            {
                Connection.Close();
            }

            return (EffectedRows > 0);
        }

        public static bool DeleteAppointment(int AppointmentID)
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM TestsAppointments
                            WHERE AppointmentID = @AppointmentID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

            try
            {
                Connection.Open();
                EffectedRows = Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            finally
            {
                Connection.Close();
            }

            return (EffectedRows > 0);
        }

    }
}
