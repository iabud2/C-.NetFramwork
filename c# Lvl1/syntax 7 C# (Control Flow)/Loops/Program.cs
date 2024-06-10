using System;

namespace Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1-For Loops:
            //forward loop:
            Console.WriteLine("\nForward Loop:\n");
            for(int i = 1; i<= 10; i++)
            {
                Console.WriteLine(i);
            }

            //backword loop:
            for (int i = 10; i >= 1; i--)

            {

                Console.WriteLine(i);

            }


            Console.WriteLine("\nNested Loops:");
            //forward loop
            for (int i = 1; i <= 10; i++)

            {

                for (int j = 0; j < 10; j++)

                {

                    Console.WriteLine("i={0} and j={1}", i, j);

                }

            }


            //2-While Loop:
            int q = 1;
            while (q <= 5)
            {
                Console.WriteLine("C# while Loop: Iteration {0}", q);
                q++;
            }

            //3-Do While Loops:
            int C = 1;
            do
            {
                Console.WriteLine($"C# do.. while Loop: Iterations {C}");
                C++;
            } while (C <= 5);

            int W = 1;
            do
            {

                Console.WriteLine($"C# do while Loop: Iteration {W}");

                if (W == 3)
                {
                    Console.WriteLine("Break here because W == 3");
                    break;
                }

                W++;

            } while (W <= 5);

            for (int Z = 1; Z <= 5; Z++)
            {
                if(Z == 3)
                {
                    Console.WriteLine("Continue here because Z == 3");
                    continue;
                }
                Console.WriteLine(Z);
            }

            Console.ReadKey();
        }
    }
}
