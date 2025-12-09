using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccesLayer.Tests
{
    static public class TestsDataLayer
    {
        //Table(Tests) colmns is : "TestID" int PK, "TestAppointmentID" int FK, "TestResult" bit, "Notes" nvarchar(100), "CreatedByUserID" int FK.

        //Crud Operations For 'Tests' Table.

        static public bool GetTestInformation(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedBy)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM Tests
                                        WHERE TestID = @TestID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if(reader.Read())
                {
                    isFound = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    Notes = reader["Notes"].ToString();
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

        static public bool GetTestInfoByAppointmentId(int AppointmentID, ref int TestID, ref bool TestResult, ref string Notes, ref int CreatedBy)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM Tests 
                                WHERE TestAppointmentID = @AppointmentID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if(reader.Read())
                {
                    IsFound = true;
                    TestID = (int)reader["TestID"];
                    TestResult = (bool)reader["TestResult"];
                    Notes = reader["Notes"].ToString();
                    CreatedBy = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch (Exception e) 
            {
                //Type Your Exception Here.
            }
            finally
            {
                Connection.Close();
            }
            return IsFound;    
        }
        public static DataTable ListAllTests()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Tests;";
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
            catch(Exception e)
            {
                
            }
            finally
            {
                Connection.Close();
            }


            return dt;
        }

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUser)
        {
            int NewID = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Tests
                            (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                            VALUES
                            (@TestAppointmentID, @TestResult, @Notes, @CreatedByUser);
                            
                            SELECT SCOPE_IDENTITY();";
        
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            Command.Parameters.AddWithValue("@Notes", Notes);
            Command.Parameters.AddWithValue("@CreatedByUser", CreatedByUser);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    NewID = insertedID;
                }
            }
            catch(Exception e) 
            {
            }
            finally
            {
                Connection.Close();
            }
            return NewID;
        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUser)
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"UPDATE Tests
                             SET
                                TestAppointmentID = @TestAppointmentID,
                                TestResult = @TestResult,
                                Notes = @Notes,
                                CreatedByUserID = @CreatedByUser,
                             WHERE TestID = @TestID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            Command.Parameters.AddWithValue("@Notes", Notes);
            Command.Parameters.AddWithValue("@CreatedByUser", CreatedByUser);
            Command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                Connection.Open();
                EffectedRows = Command.ExecuteNonQuery();
            }
            catch(Exception e) 
            {

            }
            finally
            {
                Connection.Close();
            }
          
            return (EffectedRows > 0);
        }

        public static bool DeleteTest(int TestID)
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM Tests
                             WHERE TestID = @TestID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestID", TestID);

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
