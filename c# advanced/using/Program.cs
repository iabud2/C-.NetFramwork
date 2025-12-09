//using
//nullable
//serialization
using System;
using Koko = System.Console;
using static System.Math;



public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Country { get; set; }
}

public class Program
{
    public static void ReadFile()
    {
        using (var reader = new StreamReader("C:\\Users\\iabud\\Desktop\\Web Courses.txt"))
        {
            string Line;
            while ((Line = reader.ReadLine()) != null)
            {
                Koko.WriteLine(Line);
            }
        }
    }

    public static void Main()
    {
        double a = Sqrt(64);
        Koko.WriteLine("Square Root for 65 is = " + a);
        ReadFile();

        int? Age = null;
        string Name = "Abdullah Saeed";
        string FullName = Name ?? "No Name Provided";
        Age = 25;
        if (Age.HasValue)
            Koko.WriteLine("My Age is = " + Age);

        Console.WriteLine("My Full Name is = " + FullName);

        Person? person1 = new Person
        {
            Name = "Abdullah Saeed",
            Age = 25,
            Country = "Pakistan"
        };

        Console.WriteLine(person1?.Name);
            

    }
       
}