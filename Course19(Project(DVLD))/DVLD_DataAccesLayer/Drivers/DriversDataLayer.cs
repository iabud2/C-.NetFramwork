using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccesLayer.Drivers
{
    static public class DriversDataLayer
    {
       //this is the data access layer for table 
       //Columns : 1-DriverID, 2-PersonID, 3-CreatedByUser, 4-CreatedDate.

        static public bool GetDriverInfo(int DriverID, ref int PersonID, ref int CreatedByUser, ref DateTime CreatedDate)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM Drivers 
                                    WHERE DriverID = @DriverID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if(Reader.Read())
                {
                    isFound = true;
                    PersonID = (int)Reader["PersonID"];
                    CreatedByUser = (int)Reader["CreatedByUser"];
                    CreatedDate = (DateTime)Reader["CreatedDate"];
                }
                Reader.Close();
            }
            catch (Exception ex) 
            {
                //Tybe Exception Here.
            }
            finally
            {
                Connection.Close();    
            }
            
            return isFound;
        }

        static public bool GetDriverInfoByPersonID(int PersonID, ref int DriverID, ref int CreatedBy, ref DateTime CreatedDate)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection (DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM Drivers
                                    WHERE PersonID = @PersonID";
            SqlCommand Command = new SqlCommand (Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if(Reader.Read())
                {
                    isFound = true;
                    DriverID = (int)Reader["DriverID"];
                    CreatedBy = (int)Reader["CreatedByUser"];
                    CreatedDate = (DateTime)Reader["CreatedDate"];
                }
                Reader.Close();
            }
            catch (Exception ex) 
            {
                //Exception Here.
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        static public DataTable ListAllDrivers() 
        {
            DataTable dtDrives = new DataTable();
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Drivers_View";
            SqlCommand Command = new SqlCommand(Query, Connection);
            
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if(Reader.HasRows)
                {
                    dtDrives.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception ex) 
            {
                //Tybe Exception Here.
            }
            finally
            {
                Connection.Close();
            }

            return dtDrives;
        }

        public static int AddNewDriver(int PersonID, int CreatedByUser, DateTime CreatedDate)
        {
            int NewID = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Drivers
                             (PersonID, CreatedByUser, CreatedDate)
                             VALUES
                             (@PersonID, @CreatedBy, @CreatedDate);
                                
                            SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CreatedBy", CreatedByUser);
            Command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID)) 
                {
                    NewID = InsertedID;
                }
            }
            catch (Exception ex) 
            {
                //Tybe Exception Here.
            }
            finally
            {
                Connection.Close();
            }
            return NewID;
        }
    
        static public bool UpdateDriver(int DriverID, int PersonID, int CreatedByUser, DateTime CreatedDate)
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"UPDATE Drivers
                                SET 
                                    PerosnID = @PerosnID,
                                    CreatedByUser = @CreatedBy,
                                    CreatedDate = @CreatedDate
                                WHERE DriverID = @DriverID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CreatedBy", CreatedByUser);
            Command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            Command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                Connection.Open();
                EffectedRows = Command.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                //Type Exception Here.
            }
            finally
            {
                Connection.Close();
            }

            return (EffectedRows > 0);
        }

        static public bool DeleteDriver(int DriverID) 
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM Drivers
                                WHERE DriverID = @DriverID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                Connection.Open();
                EffectedRows = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Type Exception Here.
            }
            finally
            {
                Connection.Close();
            }

            return (EffectedRows > 0);
        }
    
        static public bool isDriver(int PersonID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Found = 1 From Drivers 
                                    WHERE PersonID = @PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID",PersonID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                isFound = Reader.HasRows;
                Reader.Close();
            }
            catch (Exception ex) 
            {
                //Tybe Exception Here.
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }

        static public bool isExist(int DriverID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Found = 1 From Drivers 
                                    WHERE DriverID = @DriverID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                isFound = Reader.HasRows;
                Reader.Close();
            }
            catch (Exception ex)
            {
                //Tybe Exception Here.
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }
    }
}
