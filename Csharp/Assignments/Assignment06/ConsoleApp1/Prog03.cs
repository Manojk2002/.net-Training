using System;
using System.IO;

class Prog03
{
    static void Main()
    {
        string filePath = "BooksList.txt";

        try
        {
            int lineCount = File.ReadAllLines(filePath).Length;
            Console.WriteLine($"The file '{filePath}' contains {lineCount} lines.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Console.ReadLine();
        }
    }
}
