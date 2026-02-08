using System;
using System.Diagnostics;
using Microsoft.Data.SqlClient;


public class Program
{

    static public string ConnectionString = "Server=.;Database=C21_DB1;User Id=sa;Password=sa123456;TrustServerCertificate=True;";
   
    
    static public void test()
    {
        Stopwatch sw = new Stopwatch();
        SqlConnection conn = new SqlConnection(ConnectionString);
        string Query = @"SELECT PerformanceGategory, COUNT(*) AS NumberOfEmployees, AVG(salary) as AverageSalary
                            	FROM
	                                (SELECT Name, Salary,
	                                                    CASE 
                                                        		WHEN PerformanceRating >= 80 THEN 'High'
	                                                        	WHEN PerformanceRating >= 60 THEN 'Medium'
	                                                        	else 'Low'
		                                                        END AS PerformanceGategory
		                                                        FROM Employees) AS PerformanceTable
		                                                        GROUP BY PerformanceGategory;";
        SqlCommand cmd = new SqlCommand(Query, conn);

        try
        {

            sw.Start();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                Console.WriteLine("+-----------------------+----------------------+------------------+");
                Console.WriteLine("| Performance Category  | Number of Employees  | Average Salary  |");
                Console.WriteLine("+-----------------------+----------------------+------------------+");
            } 
            while (reader.Read())
            {
                Console.WriteLine("\t{0}\t\t|\t   {1}\t       | {2}",reader["PerformanceGategory"], reader["NumberOfEmployees"], reader["AverageSalary"]);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            conn.Close();
            sw.Stop();
            Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds} ms");
        }

    }
    public static void Main()
    {

        test();

    }
}
