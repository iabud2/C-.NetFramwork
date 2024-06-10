using System;

namespace syntax_5_C_DateTime_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             The default and the lowest value of a DateTime object is January 1, 
             0001 00:00:00 (midnight). 
             The maximum value can be December 31, 
             9999 11:59:59 P.M.
            */
            //assigns default value 01/01/0001 00:00:00
            DateTime Dt = new DateTime();

            //assigns year, month, day
            DateTime dt2 = new DateTime(2023, 12, 31);

            //assigns year, month, day, hour, min, seconds
            DateTime dt3 = new DateTime(2023, 12, 31, 5, 10, 20);

            //assigns year, month, day, hour, min, seconds, UTC timezone
            DateTime dt4 = new DateTime(2023, 12, 31, 5, 10, 20, DateTimeKind.Utc);

            Console.WriteLine(Dt);
            Console.WriteLine(dt2);
            Console.WriteLine(dt3);
            Console.WriteLine(dt4);

            //Date now:
            Dt = DateTime.Now;
            Console.WriteLine("Date Now : " + Dt);


            //Ticks:

            /*
             * Ticks is a date and time expressed in the number of 100-nanosecond intervals that have elapsed,
             * since January 1, 0001, at 00:00:00.000 in the Gregorian calendar.
             * A single tick represents one hundred nanoseconds or one ten-millionth of a second.
             * There are 10,000 ticks in a millisecond and 10 million ticks in a second.
             */
           
            //number of 100-nanosecond intervals that have elapsed
            //since January 1, 0001, at 00:00:00.000 in the Gregorian calendar. 

            Console.WriteLine(DateTime.MinValue.Ticks);  //min value of ticks
            Console.WriteLine(DateTime.MaxValue.Ticks); // max value of ticks

            //Datetime Static Fields:

            DateTime currentDateTime = DateTime.Now;  //returns current date and time
            DateTime todaysDate = DateTime.Today; // returns today's date
            DateTime currentDateTimeUTC = DateTime.UtcNow;// returns current UTC date and time
            DateTime maxDateTimeValue = DateTime.MaxValue; // returns max value of DateTime
            DateTime minDateTimeValue = DateTime.MinValue; // returns min value of DateTime

            Console.WriteLine("currentDateTime: " + currentDateTime);
            Console.WriteLine("Today: " + todaysDate);
            Console.WriteLine("currentDateTimeUTC: " + currentDateTimeUTC);
            Console.WriteLine("minDateTimeValue: " + minDateTimeValue);
            Console.WriteLine("maxDateTimeValue: " + maxDateTimeValue);

            //Time Span:
            // TimeSpan is a struct that is used to represent time in,
            // days, hour, minutes, seconds, and milliseconds.



            DateTime dtSpan = new DateTime(2023, 2, 21);

            // Hours, Minutes, Seconds
            TimeSpan ts = new TimeSpan(49, 25, 34);
            Console.WriteLine(ts);
            Console.WriteLine(ts.Days);
            Console.WriteLine(ts.Hours);
            Console.WriteLine(ts.Minutes);
            Console.WriteLine(ts.Seconds);

            //this will add time span to the date.
            DateTime newDate = dtSpan.Add(ts);

            Console.WriteLine(newDate);


            //subtration of two dates results in TimeSpan:
            DateTime T1 = new DateTime(2024, 1, 1);
            DateTime T2 = DateTime.Now;
            TimeSpan SubtractionResult = T2.Subtract(T1);

            Console.WriteLine(SubtractionResult.Days);

            //Operators:
            /*
             * The DateTime struct overloads +, -, ==, !=, >, <, <=, >= .
             * operators to ease out addition, subtraction, and comparison of dates. 
             * These make it easy to work with dates.
             */
            DateTime DT_1 = new DateTime(2015, 12, 20);
            DateTime DT_2 = new DateTime(2016, 12, 31, 5, 10, 20);
            TimeSpan Time_1 = new TimeSpan(10, 5, 25, 50);
            
            Console.WriteLine(DT_2 + Time_1);
            Console.WriteLine(DT_2 - DT_1);
            Console.WriteLine(DT_2 == DT_1);
            Console.WriteLine(DT_2 != DT_1);
            Console.WriteLine(DT_1 > DT_2);
            Console.WriteLine(DT_1 < DT_2);
            Console.WriteLine(DT_1 >= DT_2);
            Console.WriteLine(DT_1 <= DT_2);
            //--------------------------------

            //Convert String to DateTime:
            /*
             * A valid date and time string can be converted to a DateTime object using Parse(), ParseExact(), TryParse() and TryParseExact() methods.
             * The Parse() and ParseExact() methods will throw an exception if the specified string is not a valid representation of a date and time. 
             * So, it's recommended to use TryParse() or TryParseExact() method because they return false if a string is not valid.
             */

            //valid Date:
            var strDate = "1/1/2020";
            DateTime DT_3;
            var isvalidDate = DateTime.TryParse(strDate, out DT_3);
            if(isvalidDate)
            {
                Console.WriteLine(DT_3);
            }
            else
            {
                Console.WriteLine($"{strDate} is not a valid date.");
            }
            //Invalid Date:
            var strDate2 = "6/65/2023";
            DateTime DT_4;

            var isValidDate2 = DateTime.TryParse(strDate2, out DT_4);

            if (isValidDate2)
                Console.WriteLine(DT_4);
            else
                Console.WriteLine($"{strDate2} is not a valid date string");


            Console.ReadKey();
        }
    }
}
