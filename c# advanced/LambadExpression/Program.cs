using System;


public class Program
{
    static Action<int, int> Sum = (x, y) => Console.WriteLine(x + y);
    static Func <int, int, int> Multiply = (x, y) => x * y;
    static Predicate<int> IsPositive = (x) => x > 0;
    public static void Main()
    {
        Sum(10, 10);
        Console.WriteLine(Multiply(10, 10));
        Console.WriteLine(IsPositive(-1));
    }
}