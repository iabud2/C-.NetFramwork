﻿using System;

namespace syntax_3_C___Datatypes_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte b1 = 255;
            //byte b2 = -128; // this will raise a Compile error bcs out of range 0-255;
            sbyte sb1= -128;
            sbyte sb2 = 127;
            Console.WriteLine("Byte Range is : ");
            Console.WriteLine("Min = {0},  Max = {1}", Byte.MinValue, Byte.MaxValue);

            Console.WriteLine("signed Byte range is :");
            Console.WriteLine("Min = {0}, MAx = {1}", SByte.MinValue, SByte.MaxValue);

            short s1 = 32767;
            short s2 = -32768;
            //short s3 = 35000; // compile-time error, out of range;

            ushort us1 = 65535;
            //ushort us2 = -1; // also compile-time error, must positive value;

            Console.WriteLine("\nShort range :");
            Console.WriteLine("Min = {0}, Max = {1}", Int16.MinValue, Int16.MaxValue);

            Console.WriteLine("\nunSigned Short Range :");
            Console.WriteLine("Min = {0}, Max = {1}", UInt16.MinValue, UInt16.MaxValue);

            int i = -2147483648;
            int j = 2147483647;
            //  int k = 4294967295; //Compile-time error: Cannot implicitly convert type 'uint' to 'int'.

            uint ui1 = 4294967295;
            // uint ui2 = -1; //Compile-time error: Constant value '-1' cannot be converted to a 'uint'

            Console.WriteLine("Int range :");
            Console.WriteLine("Min = {0}, Max{1}", Int32.MinValue, Int32.MaxValue);

            Console.WriteLine("unsigned Int range :");
            Console.WriteLine("Min = {0}, Max = {1}", UInt32.MinValue, UInt32.MaxValue);

            long l1 = -9223372036854775808;
            long l2 = 9223372036854775807;

            ulong ul1 = 18223372036854775808ul;
            ulong ul2 = 18223372036854775808UL;

            Console.WriteLine("\nLong:");
            Console.WriteLine("Min={0} , Max={1}", Int64.MinValue, Int64.MaxValue);

            Console.WriteLine("\nULong:");
            Console.WriteLine("Min={0} , Max={1}", UInt64.MinValue, UInt64.MaxValue);


            //Float
            float f1 = 123456.5F;
            float f2 = 1.123456f;

            Console.WriteLine("\nFloat:");
            Console.WriteLine("Min={0} , Max={1}", float.MinValue, float.MaxValue);


            //double
            double d1 = 12345678912345.5d;
            double d2 = 1.123456789123456d;

            Console.WriteLine("\nDouble:");
            Console.WriteLine("Min={0} , Max={1}", double.MinValue, double.MaxValue);



            //Decimal
            //The decimal type has more precision and a smaller range
            //than both float and double,
            //and so it is appropriate for financial and monetary calculations.
            decimal d3 = 123456789123456789123456789.5m;
            decimal d4 = 1.1234567891345679123456789123m;

            Console.WriteLine("\nDecimal:");
            Console.WriteLine("Min={0} , Max={1}", decimal.MinValue, decimal.MaxValue);


            //Scientific Notation
            //Use e or E to indicate the power of 10 
            //as exponent part of scientific notation with float, double or decimal.

            double d = 0.12e2;
            Console.WriteLine(d);  // 12;

            float f = 123.45e-2f;
            Console.WriteLine(f);  // 1.2345

            decimal m = 1.2e6m;
            Console.WriteLine(m);// 1200000



            //hex & Binary
            int hex = 0x2F;
            int binary = 0b_0010_1111;

            Console.WriteLine(hex);
            Console.WriteLine(binary);

            Console.ReadKey();
        }
    }
}
