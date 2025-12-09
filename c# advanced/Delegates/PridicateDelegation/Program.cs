using System;



public class Program
{
    static Predicate<int> isEven = IsEven;
    static Predicate<string> isNullOrEmpty = IsNullOrEmpty;
    static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    static bool IsNullOrEmpty(string str)
    { 
        return str.Trim().Length == 0;
    }
    public static void Main()
    {
        bool Result = IsEven(7);
        bool Result2 = IsNullOrEmpty("  ");

        Console.WriteLine($"Is 7 even? {Result}");
        Console.WriteLine($"Is the string null or empty? {Result2}");
    }
}   