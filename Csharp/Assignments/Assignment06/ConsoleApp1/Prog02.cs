using System;
using System.IO;

class Prog02
{
    static void Main()
    {
        string[] lines = {
            "The Great Gatsby",
            "To Kill a Mockingbird",
            "1984",
            "Pride and Prejudice",
            "Moby Dick"
        };

        string filePath = "BooksList.txt";

        try
        {
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("File created and data written successfully.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Console.ReadLine();
        }
    }
}
