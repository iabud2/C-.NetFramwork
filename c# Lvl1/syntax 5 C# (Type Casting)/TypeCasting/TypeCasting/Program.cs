using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeCasting
{
    internal class Program
    {
        enum WeekDays
        {
            Monday, 
            Tuesday, 
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        static void Main(string[] args)
        {
            //1-Implicit & Explicit Casting: 
            int MyInt = 10;
            double MyDouble = MyInt; //Automatic Casting : int to double.
            Console.WriteLine($"Value : {MyInt}, Type : {MyInt.GetType()}");
            Console.WriteLine($"Value : {MyDouble}, Type : {MyDouble.GetType()}");

            double MyDouble1 = 12.121;
            int MyInt1 = (int)MyDouble1;//Manual Casting : Double to Int.
            Console.WriteLine($"Value : {MyDouble1}, Type : {MyDouble1.GetType()}");
            Console.WriteLine($"Value : {MyInt1}, Type : {MyInt1.GetType()}");
            //-----------------
            //2-Using Convert Method:
            int MyInt3 = 23;
            double MyDouble3 = 2.22;
            bool MyBool = false;

            Console.WriteLine("Convert from int to string : " + Convert.ToString(MyInt3));
            Console.WriteLine("Convert from int to double : " + Convert.ToDouble(MyInt3));
            Console.WriteLine("Convert from double to int : " + Convert.ToInt32(MyDouble3));
            Console.WriteLine("Convert from bool to string :" + Convert.ToString(MyBool));
            //------------------
            //3-Casting Enums:
            Console.WriteLine(WeekDays.Friday);
            int Day = (int) WeekDays.Saturday;
            Console.WriteLine(Day);

            var wd = (WeekDays)5;
            Console.WriteLine(wd);
                    



            Console.ReadKey();
        }
    }
}
