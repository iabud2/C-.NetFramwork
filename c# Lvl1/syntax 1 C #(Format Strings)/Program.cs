using System;

namespace syntax_1_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello This is My First Project in .net FrameWork");
            Console.WriteLine("My Name is Abdullah AbuAmra.");
            Console.WriteLine("10 + 20 = " + (10 + 20) );//you must type the operation inside the brackets.
            Console.WriteLine("Write Line method make a newline automatically");
            Console.Write("Here I am Using 'Write' method u must add new line by hand ");
            Console.Write(" As you can see :) \n");
            Console.WriteLine("Hi, {0} i am learning from {1} Platform.", "everyone", "Programming Advices");

            Console.WriteLine("We have many usefull enscape characters:\n");
            Console.WriteLine("New Line:");
            Console.WriteLine("Welcome to my \nGithub Account.");
            Console.WriteLine("Tab:");
            Console.WriteLine("Hi,\tWelcome to my Github Account.");
            Console.WriteLine("Single Quote:");
            Console.WriteLine("Hi, \'Welcome to my C# repository.");
            Console.WriteLine("Double Quote:");
            Console.WriteLine("Hi, \"Welcome to my C# repository.");
            Console.WriteLine("Backspace:");
            Console.WriteLine("Hi,  \bWelcome to my C# repository.");
            Console.WriteLine("backslash:");
            Console.WriteLine("Hi, \\Welcome to my C# repository.");
            Console.WriteLine("Alert:");
            Console.WriteLine("\a\a");
            //this a single line comment.
            /*
            this is a 
            multible
            line
            coment.
            */ 
            Console.ReadKey();
        }
    }
}
