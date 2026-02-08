using System;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;


public class CustomEventArgs : EventArgs
{
    public int  Value1 { get; set; }
    public string Value2 { get; set; }

    public CustomEventArgs(int value1, string value2)
    {
        Value1 = value1; 
        Value2 = value2;
    }
}
public class Program
{
    public delegate void CallBackEventHandler(object sender, CustomEventArgs eventArgs);
    public static event CallBackEventHandler CallBack;



    static async Task<int> PerformAsyncOperation()
    {
        await Task.Delay(1000);
        return 1;
    }

    static async Task DownloadAndPrintAsync(string url)
    {
        string Content;
        using (WebClient Client = new WebClient())
        {
            await Task.Delay(1000);
            Content = await Client.DownloadStringTaskAsync(url);
        }
        Console.WriteLine($"{url}: {Content.Length} characters downloaded");
    }

    static void OnCallBack(object sender, CustomEventArgs e)
    {
        Console.WriteLine($"This is a int value '{e.Value1}' and this is a string value '{e.Value2}'");
    }

    static async Task PerformEventUsingAsync(CallBackEventHandler callback)
    {
        await Task.Delay(2000);
        CustomEventArgs eventArgs = new CustomEventArgs(1, "Ahmed");
        callback.Invoke(null, eventArgs);
    }

    static void ClownDownload(string fileName)
    {
        Console.WriteLine($"Download : {fileName} started");
        Task.Delay(2000);
        Console.WriteLine($"{fileName} Downloaded Successfully!");
    }

    static async Task Main()
    {
        Task<int> GetNum = PerformAsyncOperation();

        Console.WriteLine("busy....");

        int Num = await GetNum;
        Console.WriteLine("Num = " + Num);

        string url1 = "https://www.amazon.com";
        string url2 = "https://www.cnn.com";

        Task t1 = DownloadAndPrintAsync(url1);
        Console.WriteLine($"Download from {url1} started\n");
        Task t2 = DownloadAndPrintAsync(url2);
        Console.WriteLine($"Download from {url2} started\n");

        await Task.WhenAll(t1, t2);

        Console.WriteLine("======================================");

        CallBack += OnCallBack;
        Task t3 = PerformEventUsingAsync(CallBack);
        Console.WriteLine("Busy...");
        await t3;
        Console.WriteLine("Done!!");

        Console.WriteLine("======================================");

        Task t4 = Task.Run(() => ClownDownload("fifa 17"));
        Task t5 = Task.Run(() => ClownDownload("fifa 2022"));

        await Task.WhenAll(t4, t5);
        Console.WriteLine($"Task 1 and 2 completed");






        Console.ReadLine();


    }







}