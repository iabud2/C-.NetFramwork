using System;
using System.Data;



public class Point
{
    public int x { get; set; }
    public int y { get; set; }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static Point operator +(Point a, Point b) => new Point(a.x + b.x, a.y + b.y);

    public static Point operator -(Point a, Point b) => new Point(a.x - b.x, a.y - b.y);

    public static bool operator ==(Point a, Point b) => a.x == b.x && a.y == b.y;

    public static bool operator !=(Point a, Point b) => a.x != b.x || a.y != b.y;

    public override string ToString()
    {
        return $"({x}, {y})";
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Point p1 = new Point(3, 4);
        Point p2 = new Point(1, 2);
        Point sum = p1 + p2;
        Point difference = p1 - p2;
        Console.WriteLine($"Point 1: {p1}");
        Console.WriteLine($"Point 2: {p2}");
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Difference: {difference}");
        Console.WriteLine($"Point 1 == Point 2: {p1 == p2}");
        Console.WriteLine($"Point 1 != Point 2: {p1 != p2}");
        Console.WriteLine("Using 'ToString' override : " + p1.ToString());
    }
}