using System;
using System.Security.Cryptography.X509Certificates;

public class Logger
{
    public delegate void LogHandler(string message);
    
    private LogHandler logHandler;

    public Logger(LogHandler handler)
    {
        logHandler = handler;
    }

    public void Log(string message)
    {
        logHandler(message);
    }
}

public class LoggerDelegate
{
    public static void LogToConsole(string message)
    {
        Console.WriteLine(message);
    }

    public static void LogToFile(string message)
    {
        string File = "logLine.txt";
        using (StreamWriter writer = new StreamWriter(File, append: true))
        {
            writer.WriteLine(message);
        }
    }
    static void Main()
    {
        Logger logToConsole = new Logger(LogToConsole);
        Logger logToFile = new Logger(LogToFile);

        logToConsole.Log("Logging to console.");
        logToFile.Log("Logging to file.");

        Console.ReadLine();

    }
}