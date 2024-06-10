using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInputs_Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1- User Inputs:
            //----
            Console.WriteLine("Enter your Name :");//as we know, this method used to 'Print'
            string MyName = Console.ReadLine();//Enter Your name then press Enert.
            Console.WriteLine("Name is : " + MyName);
            /*
             * The Console.ReadLine() method returns a string.
             * Therefore, you cannot get information from another data type, such as int.
             * therefore you should use casting when you read.
             */
            Console.WriteLine("Enter Your Age : ");
            //if you dont convert you will get an arror, and if you enter string you 
            //will get an error.
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Age is: {age}");

            //----
            //2-Operators:
            int number = 10, result;
            bool flag = true;

            result = +number;
            Console.WriteLine("+number = " + result);

            result = -number;
            Console.WriteLine("-number = " + result);

            result = ++number;
            Console.WriteLine("++number = " + result);

            result = --number;
            Console.WriteLine("--number = " + result);

            Console.WriteLine("!flag = " + (!flag));

            Console.WriteLine((number++));
            Console.WriteLine((number));

            Console.WriteLine((++number));
            Console.WriteLine((number));

            int number1 = 12;
            string result1;

            result1 = (number1 % 2 == 0) ? "Even Number" : "Odd Number";
            Console.WriteLine($"{number1} is {result1}");

            Console.ReadKey();

        }
    }
}
