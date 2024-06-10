using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataView1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable  EmployeesDataTable = new DataTable();
            EmployeesDataTable.Columns.Add("ID", typeof(int));
            EmployeesDataTable.Columns.Add("Name", typeof(string));
            EmployeesDataTable.Columns.Add("Country", typeof(string));
            EmployeesDataTable.Columns.Add("Salary", typeof(Double));
            EmployeesDataTable.Columns.Add("Date", typeof(DateTime));

            //Add rows 
            EmployeesDataTable.Rows.Add(1, "Mohammed Abu-Hadhoud", "Jordan", 5000, DateTime.Now);
            EmployeesDataTable.Rows.Add(2, "Ali Maher", "KSA", 525.5, DateTime.Now);
            EmployeesDataTable.Rows.Add(3, "Lina Kamal", "Jordan", 730.5, DateTime.Now);
            EmployeesDataTable.Rows.Add(4, "Fadi JAmeel", "Egypt", 800, DateTime.Now);
            EmployeesDataTable.Rows.Add(5, "Omar Mahmoud", "Lebanon", 7000, DateTime.Now);

            Console.WriteLine("Employees List:");
            foreach(DataRow RecordRow in EmployeesDataTable.Rows)
            {
                //Using Field Name
                Console.WriteLine($" ID: {RecordRow["ID"]}\t Name : {RecordRow["Name"]} \t Country: {RecordRow["Country"]} \t Salary: {RecordRow["Salary"]} Date: {RecordRow["Date"]} \t ");            
            }

            DataView EmployeesDataView1 = EmployeesDataTable.DefaultView;
            Console.WriteLine("\n\nEmployees View1:");
            for(int i = 0; i < EmployeesDataView1.Count; i++)
            {
                Console.WriteLine($"ID:{EmployeesDataView1[i][0]}, Name:{EmployeesDataView1[i][1]}, Country {EmployeesDataView1[i][2]}");
            }

            EmployeesDataView1.Sort = "Name asc";
            Console.WriteLine("\n\nEmployees After Sorting:");
            for (int i = 0; i < EmployeesDataView1.Count; i++)
            {
                Console.WriteLine($"ID:{EmployeesDataView1[i][0]}, Name:{EmployeesDataView1[i][1]}, Country {EmployeesDataView1[i][2]}");
            }

            EmployeesDataView1.RowFilter = "Country = 'Jordan' and ID > 1";
            Console.WriteLine("\n\nJordan Employees And Id greater than 1:");
            for (int i = 0; i < EmployeesDataView1.Count; i++)
            {
                Console.WriteLine($"ID:{EmployeesDataView1[i][0]}, Name:{EmployeesDataView1[i][1]}, Country {EmployeesDataView1[i][2]}");
            }

            Console.ReadKey();
        }
    }
}
