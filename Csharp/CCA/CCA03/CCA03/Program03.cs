using System;
using System.IO;

public class Program03
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the file name to append to (e.g., mytext.txt, filename.txt): ");
        string fileName = Console.ReadLine();
        Console.Write("Enter the Text to append accordingly: ");
        string textToAppend = Console.ReadLine();

        try
        {
            using (StreamWriter fileWriter = new StreamWriter(fileName, true))
            {
                fileWriter.WriteLine(textToAppend);
            }
            Console.WriteLine($"Successfully appended text to '{fileName}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to exit----------------->.");
        Console.ReadKey();
    }
}