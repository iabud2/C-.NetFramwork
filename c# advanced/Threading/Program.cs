using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Net;


public class Program
{
    static int sharedCounter = 0;
    static object lockObject = new object();


    static void Method1()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Method1 executed : " + i.ToString());
            Thread.Sleep(200);
        }
    }

    static void Method2()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Method2 executed : " + i.ToString());
            Thread.Sleep(200);
        }
    }


    static void ParameterizedThread(string Message)
    {
        Console.WriteLine($"This Message From Parameterized Thread");
    }


    static void DownloadAndPrint(string url)
    {
        string Content;

        using (WebClient Client = new WebClient())
        {
            Content = Client.DownloadString(url);
        }

        Console.WriteLine($"{url} : {Content.Length} Characters Downloaded");
    }

    static void IncrementCounter()
    {
        for (int i = 0; i < 100000; i++)
        {

            lock (lockObject)
            {
                sharedCounter++;
            }
        }
    }


    static void Main(string[] args)
    {

        Thread th1 = new Thread(Method1);
        th1.Start();

        Thread th2 = new Thread(Method2);
        th2.Start();

        th1.Join();
        th2.Join();


        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Main executed : " + i.ToString());
            Thread.Sleep(200);
        }

        Thread th3 = new Thread(() => ParameterizedThread("Hello World"));
        th3.Start();
        th3.Join();

        Thread th4 = new Thread(() => DownloadAndPrint("https://programmingadvices.com/l/dashboard"));
        Thread.Sleep(100);
        th4.Start();



        Thread t5 = new Thread(IncrementCounter);
        Thread t6 = new Thread(IncrementCounter);


        t5.Start();
        t6.Start();



        t5.Join();
        t6.Join();


        Console.WriteLine("Final Counter Value: " + sharedCounter);
        Console.ReadLine();
    }

























}