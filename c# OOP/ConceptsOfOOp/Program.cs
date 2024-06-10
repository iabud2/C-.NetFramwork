using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptsOfOOp
{
    class clsPerson
    {
        //auto implement set/get properties:
        public string Name { set; get; }
        public int Age { set; get; }

        //Parameterized Constructor:
        public clsPerson(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public clsPerson()
        { 
        }

        //OverRideMethod using 'virtual-override
        public virtual void Info()
        {
            Console.WriteLine($"Hi, Here is A Virtual Method");
            Console.WriteLine($"Name : {Name}, Age: {Age}");
        }

        public virtual void MoreInfo()
        {
            Console.WriteLine($"Hi, Here is A Virtual Method 'MoreInfo'");
        }
    }

    class clsEmployee: clsPerson
    {
        public int ID { get; set; }
        public string Department {  set; get; }
        
        public clsEmployee(int id, string department, string name, int age)
            : base(name, age)
        {
            ID = id;
            Department = department;
        }

        public override void Info()
        {
            Console.WriteLine("Hi, This is We Override a Derived Method.");
            Console.WriteLine($"ID :{ID}, Department : {Department}.");
            Console.WriteLine($"Name : {Name}, Age{Age}");
        }

        static public clsEmployee Find(int id)
        {
            if(id != 10)
            {
                return null;
            }

            clsEmployee Employee = new clsEmployee(10, "IT", "Omar", 30);
            return Employee;
        }

        public new void MoreInfo()
        {
            Console.WriteLine("Hi, Derived Class Implementation Override using 'new' keyword.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            clsPerson Perosn1 = new clsPerson("Ahmed", 22);
            Perosn1.Info();
            Console.WriteLine("---------------------------------");
            
            Perosn1 = new clsEmployee(1, "IT", "Khaled", 22);
            Perosn1.Info();
            Console.WriteLine("---------------------------------");
            
            clsEmployee Employee1 = new clsEmployee(2, "Marketing", "Mona", 25);
            Employee1.Info();
            Console.WriteLine("---------------------------------");

            clsEmployee Employee2 = clsEmployee.Find(10);
            if(Employee2 != null) 
            {
                Employee2.Info();
            }
            else
            {
                Console.WriteLine("Employee Not Found!");
            }
            Console.WriteLine("---------------------------------");

            //UpCasting:
            clsPerson Person2 = Employee2;
            Employee2.Info();
            Console.WriteLine("---------------------------------");

            //DownCasting With Full Data:
            //if Any Data is Missing it will raise an Error.
            clsEmployee Employee3 =(clsEmployee) Person2;
            Employee3.Info();
            Console.WriteLine("---------------------------------");

            //Override Using 'new' Keyword:
            clsEmployee Person3 = new clsEmployee(3, "Driving", "Ali", 19);
            Employee3.MoreInfo();
            clsPerson Person4 =(clsPerson) Person3;
            Person4.MoreInfo();
            //Overriding by using 'new' keyword allows u to back to virtual Original Method After UpCasting.  
            Console.ReadKey();
        }
    }
}
