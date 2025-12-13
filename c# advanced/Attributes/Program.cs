#define CONDITION
using System;
using System.Diagnostics;

public class Program
{
    [Obsolete("this is the old Methos, use the Newer  version")]
    static public void OldMethod()
    {
        Console.WriteLine("This Message From Old Method");
    }

    static public void NewMethod()
    {
        Console.WriteLine("This Message From New Method");
    }

    [Conditional("DEBUG")]
    static public void DebugMethod()
    {
        Console.WriteLine("This Message From Debug Method");
    }

    [Conditional("RELEASE")]
    static public void ReleaseMethod()
    {
        Console.WriteLine("This Message From Release Method");
    }

    [Conditional("CONDITION")]
    static public void conditionalMethod()
    {
        Console.WriteLine("This Message From Conditional 'CONDITION' Method");
    }

    public static void Main()
    {
        OldMethod();
        NewMethod();
        DebugMethod();
        ReleaseMethod();
        conditionalMethod();
    }


}