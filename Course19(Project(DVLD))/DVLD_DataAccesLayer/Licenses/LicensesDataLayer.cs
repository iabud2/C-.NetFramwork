using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
namespace DVLD_DataAccesLayer.Licenses
{
    static public class LicensesDataLayer
    {
        //crud operations for Licenses Table:
        //Columns: LicenseID, ApplicationID, DriverID, LicenseClassID,IssueDate, ExpirationDate,
        //Notes, PaidFees, isActive, IssueReason, CreatedByUser.

        static public bool GetLicenseInfo(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
                        ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, ref bool isActive, ref string IssueReason, ref int CreatedBy)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM Licenses 
                                    WHERE LicenseID = @LicenseID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)Reader["ApplicationID"];
                    DriverID = (int)Reader["DriverID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    Notes = Reader["Notes"].ToString();
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    isActive = (bool)Reader["isActive"];
                    IssueReason = Reader["IssueReason"].ToString();
                    CreatedBy = (int)Reader["CreatedByUser"];
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

        static public bool GetActiveLicenseInfo(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
                        ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, ref bool isActive, ref string IssueReason, ref int CreatedBy)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM Licenses
                                WHERE LicenseID = @LicenseID 
                                AND isActive = 1";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)Reader["ApplicationID"];
                    DriverID = (int)Reader["DriverID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    Notes = Reader["Notes"].ToString();
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    isActive = (bool)Reader["isActive"];
                    IssueReason = Reader["IssueReason"].ToString();
                    CreatedBy = (int)Reader["CreatedByUser"];
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
        static public bool GetLicenseInfoByApp_ID(ref int LicenseID, int ApplicationID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate, 
                           ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, ref bool isActive, ref string IssueReason, ref int CreatedBy)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM Licenses
                                        WHERE ApplicationID = @ApplicationID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if(Reader.Read())
                {
                    isFound = true;
                    LicenseID = (int)Reader["LicenseID"];
                    DriverID = (int)Reader["DriverID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    Notes = Reader["Notes"].ToString();
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    isActive = (bool)Reader["isActive"];
                    IssueReason = Reader["IssueReason"].ToString();
                    CreatedBy = (int)Reader["CreatedByUser"];
                }
                Reader.Close();
            }
            catch (Exception ex) 
            {
                //Exception Here!.
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }



        static public int IssueNewLicense(int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate,
                                        string Notes, float PaidFees, bool isActive, string IssueReason, int CreatedBy)
        {
            int NewID = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Licenses
                            (ApplicationID, DriverID,
                             LicenseClassID, IssueDate,
                             ExpirationDate, Notes,
                             PaidFees, isActive,
                             IssueReason, CreatedByUser)
                            Values
                            (@ApplicationID, @DriverID,
                             @LicenseClassID, @IssueDate,
                             @ExpirationDate, @Notes,
                             @PaidFees, @isActive,
                             @IssueReason, @CreatedBy);
                            
                            SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@Notes", Notes);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@isActive", isActive);
            Command.Parameters.AddWithValue("@IssueReason", IssueReason);
            Command.Parameters.AddWithValue("@CreatedBy", CreatedBy);

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

            return (NewID);
        }

        static public bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate,
                      DateTime ExpirationDate, string Notes, float PaidFees, bool isActive, string IssueReason, int CreatedBy)
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"UPDATE Licenses
                               SET
                                ApplicationID = @ApplicationID,
                                DriverID = @DriverID,
                                LicenseClassID = @LicenseClassID,
                                IssueDate = @IssueDate,
                                ExpirationDate = @ExpirationDate,
                                Notes = @Notes,
                                PaidFees = @PaidFees,
                                isActive = @isActive,
                                IssueReason = @IssueReason,
                                CreatedByUser = @CreatedBy
                               WHERE LicenseID = @LicenseID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@Notes", Notes);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@isActive", isActive);
            Command.Parameters.AddWithValue("@IssueReason", IssueReason);
            Command.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            Command.Parameters.AddWithValue("LicenseID", LicenseID);

            try
            {
                Connection.Open();
                EffectedRows = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Tybe Exception Here.
            }
            finally
            {
                Connection.Close();
            }
            return (EffectedRows > 0);
        }

        static public bool LicenseActivation(int LicenseID, bool isAcitve)
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"UPDATE Licenses
                                SET isActive = @isActive
                             WHERE LicenseID = @LicenseID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@isActive", isAcitve);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                EffectedRows = Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //Tybe Exception Here
            }
            finally
            {
                Connection.Close();
            }

            return (EffectedRows > 0);
        }

        static public bool DeactivatePrevious(int NewLicenseID,int DriverID, int LicenseClassID)
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"UPDATE Licenses
                                SET isActive = 0
                             WHERE DriverID = @DriverID AND LicenseClassID = @LicenseClassID
                             AND LicenseID <> @NewLicenseID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@NewLicenseID", NewLicenseID);
            try
            {
                Connection.Open();
                EffectedRows = Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //Tybe Exception Here
            }
            finally
            {
                Connection.Close();
            }
            return (EffectedRows > 0);
        }

        static public bool DeleteLicense(int LicenseID)
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM Licenses
                                    WHERE LicenseID = @LicenseID";
            SqlCommand Command = new SqlCommand(@Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                EffectedRows = Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //Tybe Exception Here
            }
            finally
            {
                Connection.Close();
            }

            return (EffectedRows > 0);
        }

        static public bool isExist(int LicenseID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM Licenses
                                WHERE LicenseID = @LicenseID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                isFound = Reader.HasRows;
                Reader.Close();
            }
            catch (Exception e)
            {
                //Tybe Exception Here
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        static public bool isExist_ByApp_ID(int ApplicationID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM Licenses
                                    WHERE ApplicationID = @ApplicationID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader(); 
                if(Reader.Read())
                {
                    isFound = true;
                }
                Reader.Close();
            }
            catch(Exception e) 
            {
                //Exception Here.
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        static public DataTable ListAllLicenses()
        {
            DataTable dtLicenses = new DataTable();
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Licenses;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if(Reader.HasRows)
                {
                    dtLicenses.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception e)
            {
                //Tybe Exception Here
            }
            finally
            {
                Connection.Close();
            }

            return dtLicenses;
        }
        
        static public bool GetSpecificLicenseForDriver(ref int LicenseID, ref int ApplicationID, int DriverID, int LicenseClassID, ref DateTime IssueDate,
                           ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, ref bool isActive, ref string IssueReason, ref int CreatedBy)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM Licenses
                                        WHERE DriverID = @DriverID AND LicenseClassID = @LicenseClassID AND isActive = 1";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    LicenseID = (int)Reader["LicenseID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    Notes = Reader["Notes"].ToString();
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    isActive = (bool)Reader["isActive"];
                    IssueReason = Reader["IssueReason"].ToString();
                    CreatedBy = (int)Reader["CreatedByUser"];
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                //Exception Here!.
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        static public DataTable GetLicensesListForDriverID(int DriverID)
        {
            DataTable dtLicenses = new DataTable();
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Licenses.LicenseID , Licenses.ApplicationID, LicenseClasses.ClassName, 
		                        Licenses.IssueDate, Licenses.ExpirationDate, Licenses.isActive FROM Licenses
		                      INNER JOIN LicenseClasses ON Licenses.LicenseClassID = LicenseClasses.ClassID
		                    WHERE Licenses.DriverID = @DriverID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if(Reader.HasRows)
                {
                    dtLicenses.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception e)
            {
                //Exception Here.
            }
            finally 
            { 
                Connection.Close(); 
            }

            return dtLicenses;
        }

        static public bool isLicenseDetained(int LicenseID)
        {
            bool isDetained = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT isActive FROM Licenses
                                    WHERE LicenseID = @LicenseID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if(Reader.Read()) 
                {
                    isDetained = (bool)Reader["isActive"];
                }
                Reader.Close();
            }
            catch (Exception e) 
            {
                //Tybe Exception Here.
            }
            finally
            {
                Connection.Close(); 
            }

            return isDetained;
        }

        static public bool DoesDriverHaveLicenseClass(int DriverID, int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Top 1 Found = 1 FROM Licenses
                            WHERE DriverID = @DriverID AND LicenseClassID = @LicenseClassID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                isFound = Reader.HasRows;
                Reader.Close();
            }
            catch (Exception e)
            {
                //Type Exception Here!
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }
        
    }



}
