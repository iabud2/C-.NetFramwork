using System;
using System.Linq;

namespace syntax_8_C___Arrays_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1-Arrays:
            //Create an array.
            //Arrays are bound, you cannot exceed their limits as you do in C++.
            int[] myarr = { 1, 2, 3 };
            myarr[0] = 15;
            //myarr[3] = 4; //Exception Unhandled. 
            Console.WriteLine("The First Item in the array is : " + myarr[0]);
            //---------------
           
            //To define the number of elements that an array can hold,
            //we have to allocate memory for the array in C#.
            int[] Grades;
            Grades = new int[5];
            //or
            int[] ages = new int[5];
            //---------------------------------------

            int[] numbers = { 1, 2, 3, 4, 5 };
            for(int i = 0; i < numbers.Length; i++) 
            {
                Console.WriteLine($"Elements In Index {i} is {numbers[i]}");
            }
            //---------------------------------------
            //2-Two-Dimensional Arrays:
            
            int[ , ] mynumbers = { { 1, 2 ,3}, { 3, 4, 5 } };
            Console.WriteLine("Element at index [0, 0] : " + mynumbers[0, 0]);
            Console.WriteLine("Element at index [1, 0] : " + mynumbers[1, 0]);
            //----------------------------------------
            //3-foreach loops:
            char[] CharArray = { 'a', 'b', 'c', 'd', 'e' };
            foreach(char ch in CharArray)
            {
                Console.WriteLine(ch);
            }
            //----------------------------------------
            //4-Array Operations using System.Linq:
            int[] IntegerArray = { 124, 3231, 65, 870, 876 };
            Console.WriteLine("Smallest Element: " + IntegerArray.Min());
            Console.WriteLine("Largest Element: " + IntegerArray.Max());
            Console.WriteLine("Count :" + IntegerArray.Count());
            Console.WriteLine("Sum :" + IntegerArray.Sum());
            Console.WriteLine("Average : " + IntegerArray.Average());
            //----------------------------------------
            Console.ReadKey();
        }
    }
}
