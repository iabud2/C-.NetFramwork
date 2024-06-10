using System;

namespace defaultvalues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                Every data type has a default value. Numeric type is 0,
                boolean has false, and char has '\0' as default value.
                Use the default(typename) to assign a default value of the data type or C# 7.1 onward, 
               use default literal
            */
            int di = default(int); // 0
            float df = default(float);// 0
            decimal dd = default(decimal);// 0
            bool db = default(bool);// false
            char dc = default(char);// '\0'

            // C# 7.1 onwards
            //get default value using default
            int di2 = default; // 0
            float df2 = default;// 0
            decimal dd2 = default;// 0
            bool db2 = default;// false
            char dc2 = default;// '\0'
        }
    }
}
