using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using static System.Net.Mime.MediaTypeNames;
namespace DVLD_DataAccesLayer.Licenses
{
    static public class InternationalLicensesDataLayer
    {
        //CRUD Operations for (International Licenses)
        //Columns : InternationalLicenseID - ApplicationID - DriverID - LocalLicenseID - IssueDate - ExpirationDate - IsActive - CreatedByUserID.

        public static DataTable ListInternationalLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM InternationalLicenses";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                //Exception Here
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }

        public static DataTable ListInternationalLicensesForDriverID(int DriverID)
        {
            DataTable dtLicenses = new DataTable();
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT InternationalLicenseID, ApplicationID, LocalLicenseID, IssueDate, ExpirationDate, IsActive
                                FROM InternationalLicenses 
                                    WHERE DriverID = @DriverID;";
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
            catch(Exception ex) 
            {
                //Exception Here.
            }
            finally
            {
                Connection.Close();
            }

            return dtLicenses;
        }

        public static bool GetInternationlLicenseInfo(int IL_ID, ref int ApplicationID, ref int DriverID, ref int LocalLicenseID, ref DateTime IssueDate,
                                                        ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM InternationalLicenses
                                    WHERE InternationalLicenseID = @IL_ID
                                    AND IsActive = 1";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@IL_ID", IL_ID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)Reader["ApplicationID"];
                    DriverID = (int)Reader["DriverID"];
                    LocalLicenseID = (int)Reader["LocalLicenseID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    IsActive = (bool)Reader["IsActive"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                //Exception Here!
            }
            finally
            {
                Connection.Close();
            }


            return isFound;
        }

        public static bool GetInternatiolLicenseInfoByApplicationID(ref int IL_ID, int ApplicationID, ref int DriverID, ref int LocalLicenseID, ref DateTime IssueDate,
                                                        ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM InternationalLicenses
                                    WHERE ApplicationID = @ApplictionID
                                    AND IsActive = 1";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    IL_ID = (int)Reader["InternationalLicenseID"];
                    DriverID = (int)Reader["DriverID"];
                    LocalLicenseID = (int)Reader["LocalLicenseID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    IsActive = (bool)Reader["IsActive"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                //Exception Here!
            }
            finally
            {
                Connection.Close();
            }


            return isFound;
        }

        public static bool Get_InternationalLicense_Info_By_DriverID(ref int IL_ID, ref int ApplicationID, int DriverID, ref int LocalLicenseID, ref DateTime IssueDate,
                                                        ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM InternationalLicenses
                                    WHERE DriverID = @DriverID
                                    AND IsActive = 1";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    IL_ID = (int)Reader["InternationalLicenseID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    LocalLicenseID = (int)Reader["LocalLicenseID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    IsActive = (bool)Reader["IsActive"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                //Exception Here!
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }

        public static bool Get_InternationalLicense_Info_By_L_LicenseID(ref int IL_ID, ref int ApplicationID, ref int DriverID, int LocalLicenseID, ref DateTime IssueDate,
                                                ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM InternationalLicenses
                                    WHERE LocalLicenseID = @LocalLicenseID
                                    AND IsActive = 1";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    IL_ID = (int)Reader["InternationalLicenseID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    DriverID = (int)Reader["DriverID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    IsActive = (bool)Reader["IsActive"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                //Exception Here!
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }
        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int LocalLicenseID, DateTime IssueDate,
                                                DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int NewID = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO InternationalLicenses
                              (
                                ApplicationID, DriverID,
                                LocalLicenseID, IssueDate,
                                ExpirationDate, IsActive, CreatedByUserID
                              )
                             VALUES
                              (
                                @ApplicationID, @DriverID,
                                @LocalLicenseID, @IssueDate,
                                @ExpirationDate, @IsActive, @CreatedByUserID                                
                              );
                            SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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
                //Exception Here!.
            }
            finally
            {
                Connection.Close();
            }
            return NewID;
        }

        static public bool InternationalLicenseActivation(int IL_ID, bool IsActive)
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"UPDATE InternationalLicenses
                            SET 
                                IsActive = @IsActive
                                WHERE InternationalLicenseID = @IL_ID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@IL_ID", IL_ID);

            try
            {
                Connection.Open();
                EffectedRows = Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //ExeptionHere!
            }
            finally
            {
                Connection.Close();
            }


            return EffectedRows > 0;
        }

        public static bool IsExist(int IL_ID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Found = 1 From InternationalLicenses
                                WHERE InternationalLicenseID = @IL_ID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@IL_ID", IL_ID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                isFound = Reader.HasRows;
                Reader.Close();
            }
            catch (Exception e)
            {
                //ExeptionHere!
            }
            finally
            {
                Connection.Close();
            }


            return isFound;
        }

        public static bool IsExist_ByDriverID(int DriverID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Found = 1 From InternationalLicenses
                                WHERE DriverID = @DriverID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("DriverID", DriverID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                isFound = Reader.HasRows;
                Reader.Close();
            }
            catch (Exception e)
            {
                //ExeptionHere!
            }
            finally
            {
                Connection.Close();
            }


            return isFound;
        }

        public static bool isDriverHaveActive_IL(int DriverID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Found = 1 From InternationalLicenses
                                WHERE DriverID = @DriverID
                                AND IsActive = 1";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                isFound = Reader.HasRows;
                Reader.Close();
            }
            catch (Exception e)
            {
                //ExeptionHere!
            }
            finally
            {
                Connection.Close();
            }


            return isFound;
        }

        public static bool isDriverHaveAcive_IL_ByLLID(int LocalLicenseID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Found = 1 From InternationalLicenses
                                WHERE LocalLicenseID = @LocalLicenseID
                                AND IsActive = 1";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                isFound = Reader.HasRows;
                Reader.Close();
            }
            catch (Exception e)
            {
                //ExeptionHere!
            }
            finally
            {
                Connection.Close();
            }


            return isFound;
        }



        public static bool UpdateInternationalLicenseInfo(int IL_ID, int ApplicationID, int DriverID, int LocalLicenseID, DateTime IssueDate,
                                                        DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"UPDATE InternationalLicenses
                            SET 
                                ApplicationID = @ApplicationID,
                                DriverID = @DriverID,
                                LocalLicenseID = @LocalLicenseID,
                                IssueDate = @IssueDate,
                                ExpirationDate = @ExpirationDate,
                                IsActive = @IsActive,
                                CreatedByUserID = @CreatedByUserID
                                WHERE InternationalLicenseID = @IL_ID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IL_ID", IL_ID);

            try
            {
                Connection.Open();
                EffectedRows = Command.ExecuteNonQuery();
            }
            catch (Exception e) 
            {
                //Exception Here!
            }
            finally
            {
                Connection.Close();
            }
            
            return EffectedRows > 0;
        }

        public static bool DeleteInternationalLicense(int IL_ID)
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM InternationalLicenses
                                WHERE InternationalLicenseID = @IL_ID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@IL_ID", IL_ID);
            try
            {
                Connection.Open();
                EffectedRows = Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //Exception Here!
            }
            finally
            {
                Connection.Close();
            }

            return EffectedRows > 0;
        }
    }
}
