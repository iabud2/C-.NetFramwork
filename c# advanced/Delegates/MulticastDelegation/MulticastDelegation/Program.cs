using System;

public delegate void Notify(string Message);


class MulticastDelegate
{
    public static void Notify1(string Message)
    {
        Console.WriteLine("Notify1: " + Message);
    }

    public static void Notify2(string Message)
    {
        Console.WriteLine("Notify2: " + Message);
    }

    public static void Main()
    {
        Notify Notifies = Notify1;
        Notifies += Notify2;

        Notifies("Hello, World!");

        Notifies -= Notify2;

        Notifies("Have a Nice Day!");

        Console.ReadLine();
    }



}