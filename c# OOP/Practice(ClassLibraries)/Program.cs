using System;
using CarsClassLibrary;

namespace Practice_ClassLibraries_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cars Ford = new Cars("ford expedition", 2020, "Black", "New");
            Ford.CarInfo();
            Console.ReadKey();

        }
    }
}
