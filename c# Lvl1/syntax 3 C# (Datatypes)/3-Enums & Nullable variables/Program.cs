using System;


namespace Enums
{
    internal class Program
    {
        enum enWeekDays
        {
            Monday,     // 0
            Tuesday,    // 1
            Wednesday,  // 2
            Thursday,   // 3
            Friday,     // 4
            Saturday,   // 5
            Sunday      // 6
        }

        //if you set a value , it will auto number everything after it.
        enum enCategories
        {
            Electronics,    // 0
            Food,           // 1
            Automotive = 6, // 6
            Arts,           // 7
            BeautyCare,     // 8
            Fashion         // 9
        }


        //Enum can have any numarical data type byte, sbyte, short, ushort, int, uint, long, or ulong
        //but not string

        enum enCategories2 : byte
        {
            Electronics = 1,
            Food = 5,
            Automotive = 6,
            Arts = 10,
            BeautyCare = 11,
            Fashion = 15
        }
        static void Main(string[] args)
        {
            enWeekDays WeekDays;

            WeekDays = enWeekDays.Friday;

            Console.WriteLine(WeekDays);




            /*
                As you know, a value type cannot be assigned a null value. For example, 
                int i = null will give you a compile time error.
                C# 2.0 introduced nullable types that allow you to assign null to value type variables. 
                You can declare nullable types using Nullable<t> where T is a type.
            */

            Nullable <int> i = null;

            Console.ReadKey();
        }



    }
}
