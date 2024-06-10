using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataSets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Table1 'Employees':
            DataTable EmployeesDataTable = new DataTable("EmployeesDataTable");
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

            Console.WriteLine("\nEmployees List:\n");

            foreach (DataRow RecordRow in EmployeesDataTable.Rows)
            {
                //Using Field Name
                Console.WriteLine("ID: {0}\t Name : {1} \t Country: {2} \t Salary: {3} Date: {4} \t ",
                    RecordRow["ID"], RecordRow["Name"], RecordRow["Country"], RecordRow["Salary"],
                    RecordRow["Date"]);
            }

            //Table2 'Departments':

            DataTable DepartmentsDataTable = new DataTable("DepartmentsDataTable");
            DepartmentsDataTable.Columns.Add("DepartmentID", typeof(int));
            DepartmentsDataTable.Columns.Add("Name", typeof(string));

            //Add rows 
            DepartmentsDataTable.Rows.Add(1, "Marketing");
            DepartmentsDataTable.Rows.Add(2, "IT");
            DepartmentsDataTable.Rows.Add(3, "HR");


            Console.WriteLine("\nDepartments List:\n");

            foreach (DataRow RecordRow in DepartmentsDataTable.Rows)
            {
                Console.WriteLine("DepartmentID: {0}\t Name : {1} ",
                    RecordRow["DepartmentID"], RecordRow["Name"]);
            }

            //Now Create DataSet:
            DataSet dataSet1 = new DataSet();
            dataSet1.Tables.Add(EmployeesDataTable);
            dataSet1.Tables.Add(DepartmentsDataTable);

            Console.WriteLine("\n\nThis Data From DataSet:");
            Console.WriteLine("\n\nList All Records From Employees table:");
            foreach(DataRow row in dataSet1.Tables["EmployeesDataTable"].Rows)
            {
                Console.WriteLine("ID: {0}\t Name : {1} \t Country: {2} \t Salary: {3} Date: {4} \t ",
                                 row["ID"], row["Name"], row["Country"], row["Salary"],
                                     row["Date"]);
            }

            Console.WriteLine("\n\nList All Records From Departments Table:");
            foreach (DataRow row in dataSet1.Tables["DepartmentsDataTable"].Rows)
            {
                Console.WriteLine("DepartmentID: {0}\t Name : {1} ",
                    row["DepartmentID"], row["Name"]);
            }

            Console.ReadKey();

        }
    }
}
