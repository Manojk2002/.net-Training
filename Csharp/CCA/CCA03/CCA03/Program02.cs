using System;
class Box
{
    public int Length { get; set; }
    public int Breadth { get; set; }
    public Box(int length, int breadth)
    {
        Length = length;
        Breadth = breadth;
    }
    public Box() : this(0, 0) { }

    public static Box operator +(Box b1, Box b2)
    {
        return new Box(b1.Length + b2.Length, b1.Breadth + b2.Breadth);
    }

    public void Display()
    {
        Console.WriteLine($"Length: {Length}");
        Console.WriteLine($"Breadth: {Breadth}");
    }
}
class Program02
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the details for Box1 accordingly:");
        Console.Write("Length: ");
        int length1 = int.Parse(Console.ReadLine());
        Console.Write("Breadth: ");
        int breadth1 = int.Parse(Console.ReadLine());

        Console.WriteLine("\nEnter the details for Box2 accordingly:");
        Console.Write("Length: ");
        int length2 = int.Parse(Console.ReadLine());
        Console.Write("Breadth: ");
        int breadth2 = int.Parse(Console.ReadLine());

        Box box1 = new Box(length1, breadth1);
        Box box2 = new Box(length2, breadth2);
        Box box3 = box1 + box2;

        Console.WriteLine("\n Result of Box 3 (Sum of Box 1 & Box 2) ");
        box3.Display();

        Console.WriteLine("\nPress to exit...");
        Console.ReadKey();
    }
}