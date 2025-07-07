using System;
using System.Linq;

class prog01
{
    static void Main()
    {
        int[] numbers = { 7, 2, 30 };

        var result = numbers
            .Select(n => new { Number = n, Square = n * n })
            .Where(x => x.Square > 20);

        foreach (var item in result)
        {
            Console.WriteLine($"{item.Number} - {item.Square}");
            Console.ReadLine();
        }
    }
}
