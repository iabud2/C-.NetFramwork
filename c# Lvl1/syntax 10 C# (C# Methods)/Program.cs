using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_10_C___C__Methods_
{
    internal class Program
    {
        //Must type the method inside a class, bcs C# is a OOP Language Only.
        static void PrintMyName(string name)
        {
            Console.WriteLine($"Name is : {name}");
        }

        static void PrintMyInfo(string name, int age)
        {
            Console.WriteLine($"Name : {name}\nAge : {age}");
        }

        static void PrintEmplyeeInfo(string Name, byte Age, string Address = "No Address")
        {
            //you can keep or pass your address , scince we have a default value.
            Console.WriteLine($"Name= {Name} , Age= {Age}, Address= {Address}");
        }

        static string GetMyName()
        {
            return "Abdullah Abu-Amra";
        }

        static byte GetMyAge() 
        {
            return 25;
        }

        static void MyMethod(string child1, string child2, string child3)
        {
            Console.WriteLine("The youngest child is: " + child3);
        }

        static int Sum(int Num1, int Num2)

        {
            return Num1 + Num2;
        }

        static int Sum(int Num1, int Num2, int Num3)

        {
            return Num1 + Num2 + Num3;
        }

        static int Sum(int Num1, int Num2, int Num3, int Num4)

        {
            return Num1 + Num2 + Num3 + Num4;
        }

        static void Main(string[] args)
        {
            string Name = GetMyName();
            byte age = GetMyAge();
            string Address = "Makkah";
            PrintMyName(Name);
            PrintMyInfo(Name, age);
            PrintEmplyeeInfo(Name, age);
            PrintEmplyeeInfo(Name, age, Address);
            //-------------------------------
            //Named Arguments:
            //It is also possible to send arguments with the key: value syntax.
            MyMethod(child3: "Ahmed", child2: "Khaled", child1: "Ali");
            //-------------------------------
            //Method OverLoading:
            Console.WriteLine(Sum(10, 20));
            Console.WriteLine(Sum(10, 20, 30));
            Console.WriteLine(Sum(10, 20, 30, 40));
            Console.ReadKey();
        }
    }
}
