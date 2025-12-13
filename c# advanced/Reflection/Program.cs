using System;
using System.Linq;
using System.Reflection;


//this is a custom attribute storing a description about the class or method it decorates
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class MyCustomAttribute : Attribute
{
    public string Description { get; }
    public MyCustomAttribute(string description)
    {
        Description = description;
    }
}

//custom attributes for validation.
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class RangeAttribute : Attribute
{
    public int Max { get; }
    public int Min { get; }
    public string ErrorMessage { get; set; }

    public RangeAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }
}

public class Person
{
    [Range(18, 65, ErrorMessage = "Age Must Be 18-65 Year Old")]
    public int Age { get; set; }

    [Range(3, 5, ErrorMessage = "Experience Must Be 3-5 years")]
    public int Experience { get; set; }

}


//method decorated with the custom attribute
[MyCustom("This class demonstrates custom attributes.")]
public class DemoClass
{
    [MyCustom("This method demonstrates custom attributes.")]
    public void ImportantMethod()
    {
        Console.WriteLine("Doing something important...");
    }
}

public class  Program
{
    /// <summary>
    /// Validate any member in object 'personObj' that inherit attribute 'range'
    /// </summary>
    /// <param name="personObj">the object that contains information about person</param>
    static public void ValidatePerson(Person personObj)
    {
        Type type = typeof(Person);

        foreach(var property in type.GetProperties())
        {
            if(Attribute.IsDefined(property, typeof(RangeAttribute)))
            {
                var rangeAttribute = (RangeAttribute)Attribute.GetCustomAttribute(property, typeof(RangeAttribute));
                int Value = (int)property.GetValue(personObj);

                if ((Value < rangeAttribute.Min || Value > rangeAttribute.Max))
                {
                    Console.WriteLine($"Validation failed for property '{property.Name} : {Value}',   '{rangeAttribute.ErrorMessage}'.");
                }
            }
        }
    }








    public static void Main()
    {
        Type myType = typeof(String);

        Console.WriteLine("Full Name: " + myType.FullName);
        Console.WriteLine("Namespace: " + myType.Namespace);
        Console.WriteLine("Assembly: " + myType.IsClass);

        Console.WriteLine("\n==================================================\n");


        Assembly mscorlib = typeof(string).Assembly;
        Type stringType = mscorlib.GetType("System.String");


        if(stringType != null)
        {
            Console.WriteLine("Methods Of The System.String Class:\n");
            var stringMethods = stringType.GetMethods(BindingFlags.Public | BindingFlags.Instance).OrderBy(method => method.Name); ;
        
            foreach (var method in stringMethods)
            {
                Console.WriteLine(method.Name + "  " + method.ReturnType);
            }

        }
        else
        {
            Console.WriteLine("Type not found.");
        }

        Console.WriteLine("\n==================================================\n");

        Type demoType = typeof(DemoClass);
        object[] classAttributes = demoType.GetCustomAttributes(typeof(MyCustomAttribute), false);
        foreach(MyCustomAttribute attr in classAttributes)
        {
            Console.WriteLine($"Class Attribute Description: {attr.Description}");
        }

        Console.WriteLine("\n==================================================\n");

        MethodInfo methodInfo = demoType.GetMethod("ImportantMethod");
        object[] methodAttributes = methodInfo.GetCustomAttributes(typeof(MyCustomAttribute), false);
        foreach(MyCustomAttribute attr in methodAttributes)
        {
            Console.WriteLine($"Method Attribute Description: {attr.Description}");
        }

        Console.WriteLine("\n==================================================\n");

        Person person = new Person();
        person.Age = 10;
        person.Experience = 20;
        ValidatePerson(person);






            Console.ReadLine();
    }
}
