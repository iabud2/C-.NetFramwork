using System;


namespace syntax_9_C_C_Math_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Max of 5, 10 is : " + Math.Max(5, 10));
            Console.WriteLine("Min of 5, 10 is : " + Math.Min(5, 10));
            Console.WriteLine($"Square Root of 64 is : {Math.Sqrt(64)}");
            Console.WriteLine($"Absolute value of '-4.7' is : {Math.Abs(-4.7)}");
            Console.WriteLine($"Round Of '9.99' is : {Math.Round(9.99)}");
            Console.ReadKey();
        }
    }
}
