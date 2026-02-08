using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;


class Program
{
    static List<string> urls = new List<string>()
    {
        "https://www.cnn.com",
        "https://www.amazon.com",
        "https://programmingadvices.com/l/products?sortKey=recommended&sortDirection=asc&page=1"
    };

    static void DownloadContent(string url)
    {
        string content;
        using (WebClient client = new WebClient())
        {
            Thread.Sleep(1000);
            content = client.DownloadString(url);
        }


        Console.WriteLine($"{url}: {content.Length} characters downloaded");
    }

    static void Function1()
    {
        Console.WriteLine("Function 1 is starting.");
        Task.Delay(1000).Wait(); // Simulating work
        Console.WriteLine("Function 1 is completed.");
    }

    static void Function2()
    {
        Console.WriteLine("Function 2 is starting.");
        Task.Delay(1000).Wait(); // Simulating work
        Console.WriteLine("Function 2 is completed.");
    }

    static void Function3()
    {
        Console.WriteLine("Function 3 is starting.");
        Task.Delay(1000).Wait(); // Simulating work
        Console.WriteLine("Function 3 is completed.");
    } 
    static void Main()
    {            
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;


        TaskFactory taskFactory = new TaskFactory
            (
                token,
                TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default
            );



        Task t1 = taskFactory.StartNew(()
            =>
        {
            Console.WriteLine("This is the first run for t1");
            Thread.Sleep(1000);

            Console.WriteLine("This is the second run for t1");
        });


        Task t2 = taskFactory.StartNew(() =>
        {
            Console.WriteLine("This is the first run for t2");
            Thread.Sleep(1000);
            Console.WriteLine("This is the second run for t2");
        });


        try
        {
            Task.WaitAll(t1, t2);
            Console.WriteLine("All runs Complete");
        }
        catch (AggregateException ex)
        {
            foreach (var e in ex.InnerExceptions)
            Console.WriteLine($"Exception: {e.Message}");
        }
        cts.Dispose();



        Console.WriteLine("==========================================================");

        int NumberOfIterations = 5;

        Parallel.For(0, NumberOfIterations, i =>
        {
            Console.WriteLine($"Executing iteration {i} on thread {Task.CurrentId}");
            Thread.Sleep(1000);
        });
        Console.WriteLine("All Iterations Completed!");



        Console.WriteLine("==========================================================");

        Parallel.ForEach(urls, url =>
        {
            DownloadContent(url);
        });


        Console.WriteLine("==========================================================");


        Parallel.Invoke(
            () => Console.WriteLine("Invoke Number '1'"),
            () => Console.WriteLine("Invoke Number '2'"),
            () => Console.WriteLine("Invoke Number '3'"));


        Console.WriteLine("==========================================================");
        Console.WriteLine("Invoke 3 Functions:");

        Parallel.Invoke(Function1, Function2, Function3);




        Console.ReadKey();
    }
}