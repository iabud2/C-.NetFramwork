using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAdapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = "Server=.;Database=HR_Database;User Id=sa;Password=sa123456;";
            DataSet dataset1 = new DataSet();

            string Query = "SELECT top 100 * FROM Employees;";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(Query, ConnectionString);

            SqlConnection Connection = new SqlConnection(ConnectionString);

            Connection.Open();

            dataAdapter.SelectCommand.Connection = Connection;

            dataAdapter.Fill(dataset1, "Employees");

            Connection.Close();

            DataTable EmployeesDatatable = dataset1.Tables["Employees"];
            foreach (DataRow row in EmployeesDatatable.Rows)
            {
                Console.WriteLine($"ID:{row["ID"]}, FirstName: {row["FirstName"]}, LastName:{row["LastName"]}, Gender:{row["Gendor"]}");
            }

            Connection.Open();
            dataAdapter.Update(dataset1, "Employees");
            Connection.Close();

            Console.ReadKey();
        }
    }
}
