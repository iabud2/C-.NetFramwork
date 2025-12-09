using System;

public class NewArticle : EventArgs
{
    public string Title { get; }
    public string Content { get; }

    public NewArticle(string title, string content)
    {
        this.Title = title;
        this.Content = content;
    }
}

public class NewPublisher
{
    public event EventHandler<NewArticle> NewsPublished;

    public void PublishNews(string title, string content)
    {
        NewArticle newArticle = new NewArticle(title, content);
        OnNewsPublished(newArticle);
    }
    protected virtual void OnNewsPublished(NewArticle e)
    {
        NewsPublished?.Invoke(this, e);
    }
}

public class NewSubscriber
{
    public string Name { get; }
    public NewSubscriber(string Name)
    {
        this.Name = Name;
    }

    public void Subscribe(NewPublisher publisher)
    {
        publisher.NewsPublished += HandleNewsPublished;
    }

    public void Unsubscribe(NewPublisher publisher)
    {
        publisher.NewsPublished -= HandleNewsPublished;
    }
    public void HandleNewsPublished(object sender, NewArticle e)
    {
        Console.WriteLine($"{Name} received a new news article:");
        Console.WriteLine($"Title: {e.Title}");
        Console.WriteLine($"Content: {e.Content}");
        Console.WriteLine();
    }
}

public class Program
{
    static void Main()
    {
        var Subscriber1 = new NewSubscriber("Ahmed");
        var Subscriber2 = new NewSubscriber("Ali");
        var new_Publisher = new NewPublisher();


        Subscriber1.Subscribe(new_Publisher);
        Subscriber2.Subscribe(new_Publisher);

        new_Publisher.PublishNews("Breaking News", "Goal!!!");
        new_Publisher.PublishNews("Crime", "Some One Killed");


        Subscriber1.Unsubscribe(new_Publisher);
        new_Publisher.PublishNews("Tech Update", "New gadgets are hitting the market.");



        Subscriber2.Unsubscribe(new_Publisher);
        new_Publisher.PublishNews("Final Edition", "Last news update for today.");

        Console.ReadLine();
    }
}