using System;


namespace CarsClassLibrary
{
    public class Cars
    {
        public string Name { get; set; }
        public int Model { get; set; }
        public string Color { get; set; }
        
        public string Status { get; set; }
        
        public Cars(string name, int model, string color, string status) 
        {
            Name = name;
            Model = model;
            Color = color;
            Status = status;

        }

        public void CarInfo()
        {
            Console.WriteLine($"Car {Name} Info:");
            Console.WriteLine($"Name : {Name},\nModel: {Model},\nColor: {Color},\nStatus : {Status}");
        }
    }
}
