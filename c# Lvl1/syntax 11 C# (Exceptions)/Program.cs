using System;

namespace syntax_11_C___Exceptions_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                int[] arr = { 1, 2, 3, 4 };
                Console.WriteLine(arr[10]);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            Console.ReadKey();
        } 
    }
}
