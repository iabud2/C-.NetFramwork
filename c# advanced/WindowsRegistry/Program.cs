using System;
using Microsoft.Win32;


class Program
{
    static void Main()
    {
        string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\MyFirstRegistry";
        string ValueName = "MyFirstValue";
        string ValueData = "Hello, Registry!";

        try
        {
            Registry.SetValue(KeyPath, ValueName, ValueData, RegistryValueKind.String);
            Console.WriteLine("Registry key and value created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error creating registry key: " + ex.Message);
        }


        try
        {
            string reg = Registry.GetValue(KeyPath, ValueName, null) as string;
            if (reg != null)
            {
                Console.WriteLine($"Registry '{ValueName}' Value: " + reg);
            }
            else
            {
                Console.WriteLine("Registry value not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading registry key: " + ex.Message);
        }

        Console.ReadLine();


        // Open the registry key for reading
    }
}