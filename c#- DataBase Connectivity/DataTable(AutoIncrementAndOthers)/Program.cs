using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataTable_AutoIncrementAndOthers_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable Employees = new DataTable();

            DataColumn dtColumn;

            //Column1:
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "ID";
            dtColumn.AutoIncrement = true;
            dtColumn.AutoIncrementSeed = 1;
            dtColumn.AutoIncrementStep = 1;

            dtColumn.Caption = "EmployeeID";
            dtColumn.ReadOnly = true;
            dtColumn.Unique = true;
            Employees.Columns.Add(dtColumn);

            //Column2:
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Name";
            dtColumn.AutoIncrement = false;

            dtColumn.Caption = "Name";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            Employees.Columns.Add(dtColumn);

            //Column3:
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Country";
            dtColumn.AutoIncrement = false;
            dtColumn.Caption = "Country";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            Employees.Columns.Add(dtColumn);

            //Column4:
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Double);
            dtColumn.ColumnName = "Salary";
            dtColumn.AutoIncrement = false;
            dtColumn.Caption = "Salary";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            Employees.Columns.Add(dtColumn);

            //Column5:
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(DateTime);
            dtColumn.ColumnName = "Date";
            dtColumn.AutoIncrement = false;
            dtColumn.Caption = "Date";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            Employees.Columns.Add(dtColumn);

            //Make ID column as PrimaryKey:
            DataColumn[] PrimaryKeyEmployees = new DataColumn[1];
            PrimaryKeyEmployees[0] = Employees.Columns["ID"];
            Employees.PrimaryKey = PrimaryKeyEmployees;

            //Adding Records:
            Employees.Rows.Add(null, "Mohammed Ahmed", "Jordan", 5000, DateTime.Now);
            Employees.Rows.Add(null, "Ali Maher", "KSA", 525.5, DateTime.Now);
            Employees.Rows.Add(null, "Lina Kamal", "Jordan", 730.5, DateTime.Now);
            Employees.Rows.Add(null, "Fadi JAmeel", "Egypt", 800, DateTime.Now);
            Employees.Rows.Add(null, "Omar Mahmoud", "Lebanon", 7000, DateTime.Now);

            //Print Records:
            Console.WriteLine("Employees List:");
            foreach(DataRow RecordRow in Employees.Rows)
            {
                Console.WriteLine("ID: {0}\t Name : {1} \t Country: {2} \t Salary: {3}\t Date: {4} \t ",
                                              RecordRow["ID"], RecordRow["Name"], RecordRow["Country"], RecordRow["Salary"], RecordRow["Date"]);
            }

            Console.ReadKey();
        }
    }
}
