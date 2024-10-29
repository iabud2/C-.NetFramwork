using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccesLayer.Tests
{
    public class TestTypesDataLayer
    {
        //crud operations for Test Types table.

        static public bool GetTestTypeInfo(int ID, ref string Title, ref string Description, ref float fees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM TestTypes
                                    WHERE TestTypeID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    isFound = true;
                    Title = (string)reader["TestTypeTitle"];
                    Description = (string)reader["TestTypeDescription"];
                    fees = Convert.ToSingle(reader["TestTypeFees"]);
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception ex) 
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        static public DataTable GetTestTypesList()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM TestTypes";
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
            catch (Exception ex) 
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        static public int AddNewTestType(string Title, string Description, float Fees)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO TestTypes
                                         (TestTypeTitle, TestTypeDescription, TestTypeFees)
                                    VALUES 
                                         (@Title, @Description, @Fees);
                            
                            SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Fees", Fees);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ID = InsertedID;
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                connection.Close();
            }

            return ID;
        }











        static public bool UpdateTestTYpe(int ID, string Title, string Description, float Fees)
        {
            int EffectedRows = -1;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"UPDATE TestTypes 
                                             SET TestTypeTitle = @Title,
                                                 TestTypeDescription = @Description,
                                                 TestTypeFees = @Fees
                                             WHERE TestTypeID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                EffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                    
            }
            finally
            {
                connection.Close();
            }
            return(EffectedRows > 0);
        }

        static public bool FindTestType(int ID)
        {
            string Title = "", Description = "";
            float Fees = -1;
            return (GetTestTypeInfo(ID, ref Title, ref Description, ref Fees));
        }

        static public bool DeleteTestype(int id)
        {
            int EffectedRows = -1;
            SqlConnection connection = new SqlConnection(DVLD_DataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM TestTypes
                                    WHERE TestTypeID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", id);

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
