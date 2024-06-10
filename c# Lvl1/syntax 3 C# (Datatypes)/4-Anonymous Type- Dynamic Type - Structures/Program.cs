using System;


namespace Anonymous_Type_Dynamic_Type__Structures
{
    internal class Program
    {
        struct stStudent
        {
            public string FirstName;
            public string LastName;
        }
        static void Main(string[] args)
        {

            //1- Anonymous Date Type:
            //you dont have to specify and data type here,
            //it will specified automatically.

            var Employee = new { Id = 1, FirstName = "Abdllah", LastName = "Abu-Amra" };
            Console.WriteLine("Employee:\n");
            Console.WriteLine("ID : " + Employee.Id);
            Console.WriteLine("First Name : " + Employee.FirstName);
            Console.WriteLine("Last Name  : " + Employee.LastName);
            Console.WriteLine("Full Name : {0} {1}", Employee.FirstName, Employee.LastName);

            //Also i can print it like this:
            Console.WriteLine(Employee);

            //anonymous types are read-only
            //you cannot change the values of properties as they are read-only.
            // Employee.Id = 2;//Error: cannot chage value
            // Employee.FirstName = "Ali";//Error: cannot chage value.
            //An anonymous type's property can include another anonymous type.
           
            var Employee1 = new
            {
                Id = 20,
                FirstName = "Khalid",
                LastName = "Ahmed",
                Address = new { Street = 101, City = "Riyadh", Country = "KSA" }
            };

            Console.WriteLine("\nEmployee {0} {1} Address:", Employee1.FirstName, Employee1.LastName);
          
            Console.WriteLine("Country : " + Employee1.Address.Country);
          
            Console.WriteLine("City : " + Employee1.Address.City);
           
            Console.WriteLine("Street : " + Employee1.Address.Street);
            //----------------------------------------------

            //2- Structures:
            //A struct object can be created with or without the new operator,
            //same as primitive type variables.
            stStudent Student1;
            stStudent Student2 = new stStudent();

            Student1.FirstName = "Mohammed";
            Student1.LastName = "Ahmed";

            Console.WriteLine("\n\nStudent1 name : {0} {1}", Student1.FirstName, Student1.LastName);
          
            Student2.FirstName = "Khalid";
            Student2.LastName = "Ali";
           
            Console.WriteLine("\n\nStudent2 name : {0} {1}", Student2.FirstName, Student2.LastName);

            //----------------------------------------------
            //3-Dynamic Types:
            /*
             * C# 4.0 (.NET 4.5) introduced a new type called dynamic that avoids compile-time type checking. 
             * A dynamic type escapes type checking at compile-time; instead, it resolves type at run time.
             * A dynamic type variables are defined using the 'dynamic' keyword.
             */

            dynamic MyDynamicvar = 100;
            Console.WriteLine("Value : {0}, Type : {1}", MyDynamicvar, MyDynamicvar.GetType());

            MyDynamicvar = "This is string";
            Console.WriteLine("Value : {0}, Type : {1}", MyDynamicvar, MyDynamicvar.GetType());

            MyDynamicvar = false;
            Console.WriteLine("Value : {0}, Type : {1}", MyDynamicvar, MyDynamicvar.GetType());

            MyDynamicvar = DateTime.Now;
            Console.WriteLine("Value : {0}, Type : {1}", MyDynamicvar, MyDynamicvar.GetType());


            Console.ReadKey();
        
        }

    }
}
