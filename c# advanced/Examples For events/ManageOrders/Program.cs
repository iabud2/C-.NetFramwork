using System;

public class OrderEventArgs : EventArgs
{
    public int OrderID { get; }
    public int OrderTotalPriced { get; }
    public string ClientEmail { get; }
    
    public OrderEventArgs(int orderID, int orderTotalPriced,string clientEmail)
    {
        this.OrderID = orderID;
        this.OrderTotalPriced = orderTotalPriced;
        this.ClientEmail = clientEmail;
    }
}

public class Order
{
    public EventHandler<OrderEventArgs> OnOrderCreated;

    public void CreateOrder(int orderID, int totalPrice, string clientEmail)
    {
        if(OnOrderCreated != null)
        {
            Console.WriteLine("Order created successfully.");
            OnOrderCreated(this, new OrderEventArgs(orderID, totalPrice, clientEmail));
        }
    }
}

public class EmailService
{
    public void Subscribe(Order order)
    {
        order.OnOrderCreated += SendEmail;
    }

    public void Unsubscribe(Order order)
    {
        order.OnOrderCreated -= SendEmail;
    }

    public void SendEmail(object sender, OrderEventArgs e)
    {
        Console.WriteLine($"\n\n----------Email Service--------");
        Console.WriteLine($"Email Service Object Received a new order event");
        Console.WriteLine($"Order ID: {e.OrderID}");
        Console.WriteLine($"Order Price: {e.OrderTotalPriced}");
        Console.WriteLine($"Email: {e.ClientEmail}");
        Console.WriteLine($"\nSend an email");
        Console.WriteLine($"--------------------------------");
        Console.WriteLine("We will notify you for your order progress");
    }
}

public class SMS_Service
{
    public void Subscribe(Order order)
    {
        order.OnOrderCreated += SendSMS;
    }

    public void Unsubscribe(Order order)
    {
        order.OnOrderCreated -= SendSMS;
    }

    public void SendSMS(object sender, OrderEventArgs e)
    {
        Console.WriteLine($"\n\n----------SMS Service--------");
        Console.WriteLine($"SMS Service Object Received a new order event");
        Console.WriteLine($"Order ID: {e.OrderID}");
        Console.WriteLine($"Order Price: {e.OrderTotalPriced}");
        Console.WriteLine($"Email: {e.ClientEmail}");
        Console.WriteLine($"\nSend an SMS");
        Console.WriteLine($"--------------------------------");
        Console.WriteLine("We will notify you for your order progress");
    }
}

public class ShipmentService
{
    public void Subscribe(Order order)
    {
        order.OnOrderCreated += ShipOrder;
    }

    public void Unsubscribe(Order order)
    {
        order.OnOrderCreated -= ShipOrder;
    }

    public void ShipOrder(object sender, OrderEventArgs e)
    {
        Console.WriteLine($"\n\n----------Shipment Service--------");
        Console.WriteLine($"Shipment Service Object Received a new order event");
        Console.WriteLine($"Order ID: {e.OrderID}");
        Console.WriteLine($"Order Price: {e.OrderTotalPriced}");
        Console.WriteLine($"Email: {e.ClientEmail}");
        Console.WriteLine($"\nShip the order");
        Console.WriteLine($"--------------------------------");
        Console.WriteLine("We will notify you for your order progress");
    }
}

public class Program
{
    static void Main()
    {
        var order = new Order();
        EmailService emailService = new EmailService();
        SMS_Service smsService = new SMS_Service();
        ShipmentService shipmentService = new ShipmentService();

        emailService.Subscribe(order); 
        smsService.Subscribe(order);
        shipmentService.Subscribe(order);

        order.CreateOrder(1, 101, "Ahmed@gmail.com");
        Console.ReadLine();
    }
}