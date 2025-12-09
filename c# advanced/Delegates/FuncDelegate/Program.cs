using System;
using System.Reflection.Metadata;


public class Program
{
    static Func<int, int, int> Adder = AddNumbers;
    static int AddNumbers(int a, int b)
    {
        return a + b;
    }

    static int DivideNumbers(int a, int b)
    {
        return a / b;
    }


    static void PrintOnScreen(Func<int, int, int> Action, int x, int y)
    {
        int result = Action(x, y);
        Console.WriteLine($"The result is: {result}");
    }

    static public void Main()
    {
        PrintOnScreen(AddNumbers, 1, 1);  
        PrintOnScreen(DivideNumbers, 10, 2);

        Console.ReadLine();
    }
}