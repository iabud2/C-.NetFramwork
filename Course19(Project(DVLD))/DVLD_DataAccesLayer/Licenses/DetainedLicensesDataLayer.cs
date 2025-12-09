using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccesLayer.Licenses
{
    static public class DetainedLicensesDataLayer
    {
        //We Need To Handle Crud Operations For (Detained Licenses) Table.
        //Columns: DetainedID - LicenseID - FineFees - DetainedDate -
        //IsReleased - ReleasedDate - ReleasedByUserID - ReleasedApplicationID - CreatedByUserID.

        static public int DetainLicense(int LicenseID, float FineFees, DateTime DetainedDate, bool IsReleased,
                                      int CreatedByUserID)
        {
            int DetainID = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO DetainedLicenses
                                (LicenseID, FineFees, DetainedDate, IsReleased ,CreatedByUserID)
                            VALUES
                                (@LicenseID, @FineFees, @DetainedDate, @IsReleased, @CreatedByUserID);
            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@DetainedDate", DetainedDate);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    DetainID = InsertedID;
                }
            }
            catch (Exception e)
            {
                //Exception Here!
            }
            finally
            {
                Connection.Close();
            }
            return DetainID;
        }

        static public bool ReleaseDetainedLicense(int DetainID, bool IsReleased, DateTime ReleasedDate, int ReleasedByUserID
                                    , int ReleaseApplicationID)
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"UPDATE DetainedLicenses
                            SET
                                IsReleased = @IsReleased, ReleasedDate = @ReleasedDate,
                                ReleasedByUserID = @ReleasedByUserID, ReleaseApplicationID = @ReleaseApplicationID
                            WHERE DetainID = @DetainID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DetainID", DetainID);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);
            Command.Parameters.AddWithValue("@ReleasedDate", ReleasedDate);
            Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

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

        static public DataTable ListDetainedLicenses()
        {
            DataTable dtDetainedLicenses = new DataTable();
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM DetainedLicenses;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if(Reader.HasRows)
                {
                    dtDetainedLicenses.Load(Reader);
                }
                Reader.Close();
            }
            catch(Exception e)
            {
                //Exception Here!
            }
            finally
            {
                Connection.Close();
            }

            return dtDetainedLicenses;
        }

        static public bool GetDetainInfo(int DetainID, ref int LicenseID, ref float FineFees, ref DateTime DetainedDate, ref bool IsReleased, 
                                            ref DateTime ReleasedDate, ref int ReleasedByUserID, ref int ReleaseApplicationID, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM DetainedLicenses
                                WHERE DetainID = @DetainID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if(Reader.Read())
                {
                    isFound = true;
                    LicenseID = (int)Reader["LicenseID"];
                    FineFees = Convert.ToSingle(Reader["FineFees"]);
                    DetainedDate = (DateTime)Reader["DetainedDate"];
                    IsReleased = (bool)Reader["IsReleased"];
                    if (Reader["ReleasedDate"] != System.DBNull.Value)
                        ReleasedDate = (DateTime)Reader["ReleasedDate"];
                    

                    if (Reader["ReleasedByUserID"] != System.DBNull.Value)
                        ReleasedByUserID = (int)Reader["ReleasedByUserID"];

                    if (Reader["ReleaseApplicationID"] != System.DBNull.Value)
                        ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];
                }

                CreatedByUserID = (int)Reader["CreatedByUserID"];

                Reader.Close();
            }
            catch(Exception e)
            {
                //Exception Here!
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }

        static public bool GetDetainInfoByLicenseID(ref int DetainID, int LicenseID, ref float FineFees, ref DateTime DetainedDate, ref bool IsReleased,
                                    ref DateTime ReleasedDate, ref int ReleasedByUserID, ref int ReleaseApplicationID, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM DetainedLicenses
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
                    DetainID = (int)Reader["DetainID"];
                    FineFees = Convert.ToSingle(Reader["FineFees"]);
                    DetainedDate = (DateTime)Reader["DetainedDate"];
                    IsReleased = (bool)Reader["IsReleased"];
                    if (Reader["ReleasedDate"] != System.DBNull.Value)
                        ReleasedDate = (DateTime)Reader["ReleasedDate"];


                    if (Reader["ReleasedByUserID"] != System.DBNull.Value)
                        ReleasedByUserID = (int)Reader["ReleasedByUserID"];

                    if (Reader["ReleaseApplicationID"] != System.DBNull.Value)
                        ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];
                }

                CreatedByUserID = (int)Reader["CreatedByUserID"];

                Reader.Close();
            }
            catch (Exception e)
            {
                //Exception Here!
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }
        
        static public bool GetActiveDetainInfo(ref int DetainID, int LicenseID, ref float FineFees, ref DateTime DetainedDate, ref bool IsReleased,
                                    ref DateTime ReleasedDate, ref int ReleasedByUserID, ref int ReleaseApplicationID, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM DetainedLicenses
                                WHERE LicenseID = @LicenseID AND IsReleased = 0";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    DetainID = (int)Reader["DetainID"];
                    FineFees = Convert.ToSingle(Reader["FineFees"]);
                    DetainedDate = (DateTime)Reader["DetainedDate"];
                    IsReleased = (bool)Reader["IsReleased"];
                    if (Reader["ReleasedDate"] != System.DBNull.Value)
                        ReleasedDate = (DateTime)Reader["ReleasedDate"];


                    if (Reader["ReleasedByUserID"] != System.DBNull.Value)
                        ReleasedByUserID = (int)Reader["ReleasedByUserID"];

                    if (Reader["ReleaseApplicationID"] != System.DBNull.Value)
                        ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];
                }

                CreatedByUserID = (int)Reader["CreatedByUserID"];

                Reader.Close();
            }
            catch (Exception e)
            {
                //Exception Here!
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }



        public static bool DeleteDetainInfo(int DetainID)
        {
            int EffectedRows = -1;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM DetainedLicenses
                                    WHERE DetainID = @DetainID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DetainID", DetainID);
            
            try
            {
                Connection.Open();
                EffectedRows = Command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                //Exception Here!
            }
            finally
            {
                Connection.Close();
            }

            return EffectedRows > 0;
        }
        
        public static bool IsDetained(int LicenseID)
        {
            bool IsDetained = false;
            SqlConnection Connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM DetainedLicenses
                                WHERE LicenseID = @LicenseID AND IsReleased = 0";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                IsDetained = Reader.HasRows;
                Reader.Close();
            }
            catch(Exception e)
            {
                //Exception Here!
            }
            finally
            {
                Connection.Close();
            }

            return IsDetained;
        }


    }
}
