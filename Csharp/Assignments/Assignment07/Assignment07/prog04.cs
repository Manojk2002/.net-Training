using System;

class ConcessionCalculator
{
    public static void CalculateConcession(string name, int age, double totalFare)
    {
        if (age <= 5)
        {
            Console.WriteLine($"{name}: Little Champs - Free Ticket");
            Console.ReadLine();
        }
        else if (age > 60)
        {
            double concessionFare = totalFare * 0.7; // 30% discount
            Console.WriteLine($"{name}: Senior Citizen - Fare after concession: {concessionFare}");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine($"{name}: Ticket Booked - Fare: {totalFare}");
            Console.ReadLine();
        }
    }
}

class prog04
{
    const double TotalFare = 500;

    static void Main()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your age: ");
        int age;

        while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
        {
            Console.Write("Invalid input. Please enter a valid age: ");
        }
        ConcessionCalculator.CalculateConcession(name, age, TotalFare);
        Console.ReadLine();
    }
}
