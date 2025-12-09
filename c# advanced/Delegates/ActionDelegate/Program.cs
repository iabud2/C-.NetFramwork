using System;




public class Program
{
    static Action <string, int> MyAcDelegate = PrintInfo;

    static void PrintInfo(string name, int age) => Console.WriteLine($"Name: {name}, Age: {age}");
    

    public static void Main()
    {
        MyAcDelegate("15", 30);
    }
}