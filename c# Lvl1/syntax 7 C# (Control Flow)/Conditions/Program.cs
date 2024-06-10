using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Conditions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //if - then - else:
            int x = 10, y = 20;
            if (x == 10 && y <= 20)
            {
                Console.WriteLine("Yes x = 10, and y <= 20");
            }
            if(x == 11)
            {
                Console.WriteLine("yes x = 11");
            }
            else 
            {
                Console.WriteLine("No, x != 11");
            }
            //----
            int a = 12;
            if(a < 5)
            {
                Console.WriteLine("Yes, a less than 12.");
            }
            else if(a > 5)
            {
                Console.WriteLine("Yes, a Greater than 5");
            }
            else 
            {
                Console.WriteLine($"{a} equals to 5");
            }
            //----------------------------------------
            //2-Switch Case:
            //Example1:
            char ch;
            Console.WriteLine("Enter a character :");
            ch = Convert.ToChar(Console.ReadLine());
            switch (Char.ToLower(ch))
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    Console.WriteLine("Vowel");
                    break;
                default:
                    Console.WriteLine("Not a Vowel.");
                    break;
            }

            //Example2:
            char ch1;
            Console.WriteLine("Enter a Character: ");
            ch1 = Convert.ToChar(Console.ReadLine());
            switch (Char.ToLower(ch1))
            {
                case 'a':
                    Console.WriteLine("Vowel");
                    break;
                case 'e':
                    Console.WriteLine("Vowel");
                    break;
                case 'i':
                    Console.WriteLine("Vowel");
                    break;
                case 'o':
                    Console.WriteLine("Vowel");
                    break;
                case 'u':
                    Console.WriteLine("Vowel");
                    break;
                default:
                    Console.WriteLine("Not A Vowel");
                    break;
            }

            //Example3:
            char Operation;
            double first, Second, Result;
            Console.WriteLine("Enter First Number :");
            first = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Second Number :");
            Second = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the Operation (+, -, *, /)");
            Operation = Convert.ToChar(Console.ReadLine());

            switch (Operation)
            {
                case '+':
                    Result = first + Second;
                    Console.WriteLine($"{first} + {Second} = {Result}");
                    break;
                case '-':
                    Result = first - Second;
                    Console.WriteLine($"{first} - {Second} = {Result}");
                    break;
                case '*':
                    Result = first * Second;
                    Console.WriteLine($"{first} * {Second} = {Result}");
                    break;
                case '/':
                    Result = first / Second;
                    Console.WriteLine($"{first} / {Second} = {Result}");
                    break;
            }

            //Example4:
            string Name = "Mohammed";
            switch (Name.ToLower())
            {
                case "mohammed":

                    Console.WriteLine("Yes Mohammed");
                    break;

                case "ali":

                    Console.WriteLine("Yes ALi");
                    break;

                default:
                    Console.WriteLine("No Name Matched!");
                    break;

            }
            //----------------------------------------
            //3-Ternary Operator:
            int number = 4;
            bool isEven;
            if (number % 2 == 0)
            {
                isEven = true;
            }
            else
            {
                isEven = false;
            }

            //We can replace  the previous condition for this:
            isEven = (number % 2 == 0) ? true : false;

            Console.ReadKey();
        }
    }
}
