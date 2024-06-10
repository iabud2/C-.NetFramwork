using System;

namespace WorkingWithStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * In C#, a string is a series of characters that is used to represent text. 
             * It can be a character, 
             * a word or a long passage surrounded with the double quotes ".
             */
            string S1 = "Abdullah Abu-Amra";
            Console.WriteLine("MyString : " + S1);
            Console.WriteLine("Show 5 Characters Start at index 2 : " + S1.Substring(2, 5));
            Console.WriteLine("My String After Lower All : " + S1.ToLower());
            Console.WriteLine("My String After Upper All : " + S1.ToUpper());
            Console.WriteLine("Character At Index '3' : " + S1[3]);
            Console.WriteLine("String After Inserting 'XD' After Index '8' :" + S1.Insert(8, "XD"));
            Console.WriteLine("String After Replacing Character 'A' for '*' :" + S1.Replace('A', '*'));
            Console.WriteLine("Index of character 'b' : " + S1.IndexOf('b'));
            Console.WriteLine("Is the index containts charcter 'x'? :" + S1.Contains("x"));
            Console.WriteLine("Stirng Length until reach last 'u' :" + S1.LastIndexOf("u"));
            //-------------------
            string S2 = "Ali,Ahmed,Mohammed";
            string[] NameList = S2.Split(',');
            Console.WriteLine("NameList of '0' : "  + NameList[0]);
            Console.WriteLine("NameList of '1' : " + NameList[1]);
            Console.WriteLine("NameList of '2' : " + NameList[2]);
            //-------------------
            string S3 = "  PointBlank   ";
            Console.WriteLine("Trim S3 : " + S3.Trim());
            S3 = "        PointBlank";
            Console.WriteLine("Trim Start S3 : " + S3.TrimStart());
            S3 = "Point Blank         ";
            Console.WriteLine("Trim End S3 : " + S3.TrimEnd() + " Pi");
            //-------------------------------------------------------------

            //2-Stirng Interpolation:
            string F_Name = "Abdullah";
            string L_Name = "Abu-Amra";
            string Code = "107";
            //You should use  '$' to identify an Interpolation stirng.
            string FullName = $"{F_Name} {L_Name}";
            Console.WriteLine("Full Name :" + FullName);

            Console.ReadKey();

        }
    }
}
