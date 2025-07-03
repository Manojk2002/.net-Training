// 3. Write a C# program to implement a method that takes an integer as input and throws an exception if the number is negative. Handle the exception in the calling code.

using System;
class ExceptionHandling
{
    static void CheckNumber(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Number cannot be negative.");
        }
        Console.WriteLine($"Number {number} is valid.");
    }

    static void Main(string[] args)
    {
        Console.Write("Enter an integer: ");
        try
        {
            int input = int.Parse(Console.ReadLine());
            CheckNumber(input);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
        Console.ReadLine();
    }
}
