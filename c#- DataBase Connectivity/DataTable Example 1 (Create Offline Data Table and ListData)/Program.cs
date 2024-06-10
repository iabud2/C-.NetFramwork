using System;
using System.Data;
using System.Linq;

public class Example
{
    public static void Main()
    {
        DataTable EmployeesDataTable = new DataTable();
        EmployeesDataTable.Columns.Add("ID", typeof(int));
        EmployeesDataTable.Columns.Add("Name", typeof(string));
        EmployeesDataTable.Columns.Add("Country", typeof(string));
        EmployeesDataTable.Columns.Add("Salary", typeof(Double));
        EmployeesDataTable.Columns.Add("Date", typeof(DateTime));

        //Primary Key:
        DataColumn[] PrimaryKeyColumn = new DataColumn[1];
        PrimaryKeyColumn[0] = EmployeesDataTable.Columns["ID"];
        EmployeesDataTable.PrimaryKey = PrimaryKeyColumn;


        //Add rows 
        EmployeesDataTable.Rows.Add(1, "Mohammed Abu-Hadhoud", "Jordan",5000, DateTime.Now);
        EmployeesDataTable.Rows.Add(2, "Ali Maher", "KSA",525.5, DateTime.Now);
        EmployeesDataTable.Rows.Add(3, "Lina Kamal", "Jordan",730.5, DateTime.Now);
        EmployeesDataTable.Rows.Add(4, "Fadi JAmeel", "Egypt",800, DateTime.Now);
        EmployeesDataTable.Rows.Add(5, "Omar Mahmoud", "Lebanon",7000, DateTime.Now);

        int EmployeesCount = 0;
        double TotalSalary = 0;
        double AverageSalary = 0;
        double MinSalary = 0;
        double MaxSalary = 0;

        EmployeesCount = EmployeesDataTable.Rows.Count;
        TotalSalary = Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)", string.Empty));
        AverageSalary = Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", string.Empty));
        MinSalary = Convert.ToDouble(EmployeesDataTable.Compute("Min(Salary)", string.Empty));
        MaxSalary = Convert.ToDouble(EmployeesDataTable.Compute("Max(Salary)", string.Empty));



        Console.WriteLine("\nEmployees List:\n");
        foreach (DataRow RecordRow in EmployeesDataTable.Rows)
        {
            //Using Index
            // Console.WriteLine("ID: {0}\t Name : {1} \t Country: {2} \t Salary: {3} Date: {4} \t ", RecordRow[0], RecordRow[1], RecordRow[2], RecordRow[3], RecordRow[4]);

            //Using Field Name
            Console.WriteLine($"ID:{RecordRow["ID"]}, Name:{RecordRow["Name"]}, Country:{RecordRow["Country"]}, Salary:{RecordRow["Salary"]}, Date:{RecordRow["Date"]}");
       
        }

        Console.WriteLine($"\n\n\nTotal Employees: {EmployeesCount}");
        Console.WriteLine($"Total Salary: {TotalSalary}");
        Console.WriteLine($"Average Salary: {AverageSalary}");
        Console.WriteLine($"Min Salary: {MinSalary}");
        Console.WriteLine($"Max Salary: {MaxSalary}");


        //Filtering Data:

        int ResultCount = 0;
        DataRow[] ResultRow = EmployeesDataTable.Select("Country='Jordan'");
        Console.WriteLine("\n\nFilter 'Jordan' Emplopyees:");
        foreach (DataRow RecordRow in ResultRow)
        {
            Console.WriteLine($"ID:{RecordRow["ID"]}, Name:{RecordRow["Name"]}, Country:{RecordRow["Country"]}, Salary:{RecordRow["Salary"]}, Date:{RecordRow["Date"]}");
        }

        ResultCount = ResultRow.Count();
        TotalSalary = Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)", "Country='Jordan'"));
        AverageSalary = Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", "Country='Jordan'"));
        MinSalary = Convert.ToDouble(EmployeesDataTable.Compute("Min(Salary)", "Country='Jordan'"));
        MaxSalary = Convert.ToDouble(EmployeesDataTable.Compute("Max(Salary)", "Country='Jordan'"));

        Console.WriteLine($"\n\n\nTotal Employees: {ResultCount}");
        Console.WriteLine($"Total Salary: {TotalSalary}");
        Console.WriteLine($"Average Salary: {AverageSalary}");
        Console.WriteLine($"Min Salary: {MinSalary}");
        Console.WriteLine($"Max Salary: {MaxSalary}");


        //Sorting Data:


        EmployeesDataTable.DefaultView.Sort = "ID desc";
        EmployeesDataTable = EmployeesDataTable.DefaultView.ToTable();

        Console.WriteLine("\n\nSorting By ID desc:\n");
        foreach (DataRow RecordRow in EmployeesDataTable.Rows)
        {
            Console.WriteLine($"ID:{RecordRow["ID"]}, Name:{RecordRow["Name"]}, Country:{RecordRow["Country"]}, Salary:{RecordRow["Salary"]}, Date:{RecordRow["Date"]}");
        }



        //Delete Row

        DataRow[] Result = EmployeesDataTable.Select("ID=4");
        foreach(var RecordRow in Result)
        {
            RecordRow.Delete();
        }

        EmployeesDataTable.AcceptChanges();

        Console.WriteLine("\n\nTable After Deleting Records Having ID = 4");
        foreach (DataRow RecordRow in EmployeesDataTable.Rows)
        {
            Console.WriteLine($"ID:{RecordRow["ID"]}, Name:{RecordRow["Name"]}, Country:{RecordRow["Country"]}, Salary:{RecordRow["Salary"]}, Date:{RecordRow["Date"]}");
        }


        //Update Record

        DataRow[] Result1 = EmployeesDataTable.Select("ID = 1");
        foreach(var RecordRow in Result1)
        {
            RecordRow["Name"] = "Abdullah";
            RecordRow["Salary"] = "75321";
            RecordRow["Country"] = "Palestine";
        }

        Console.WriteLine("\n\nTable After Update:");
        foreach (DataRow RecordRow in EmployeesDataTable.Rows)
        {
            Console.WriteLine($"ID:{RecordRow["ID"]}, Name:{RecordRow["Name"]}, Country:{RecordRow["Country"]}, Salary:{RecordRow["Salary"]}, Date:{RecordRow["Date"]}");
        }




        //Clear
        EmployeesDataTable.Clear();

        Console.WriteLine("\n\nTable After Using Clear Method:");
        foreach (DataRow RecordRow in EmployeesDataTable.Rows)
        {
            Console.WriteLine($"ID:{RecordRow["ID"]}, Name:{RecordRow["Name"]}, Country:{RecordRow["Country"]}, Salary:{RecordRow["Salary"]}, Date:{RecordRow["Date"]}");
        }

        Console.ReadKey();

    }
}