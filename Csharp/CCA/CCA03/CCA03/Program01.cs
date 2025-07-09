using System;
using System.Collections.Generic;
class Cricket
{
    private List<int> Scores { get; set; }

    public Cricket()
    {
        Scores = new List<int>();
    }

    public void AddScores(int no_of_matches)
    {
        Console.WriteLine($"Enter the points scored in {no_of_matches} matches:");
        for (int i = 0; i < no_of_matches; i++)
        {
            Console.Write($"Match {i + 1}: ");
            int score = int.Parse(Console.ReadLine());
            Scores.Add(score);
        }
    }

    public int GetSum()
    {
        int total = 0;
        foreach (int score in Scores)
        {
            total += score;
        }
        return total;
    }

    public double GetAverage()
    {
        if (Scores.Count == 0) return 0;
        return (double)GetSum() / Scores.Count;
    }

    public void DisplayResults()
    {
        Console.WriteLine("\n--- Results ---");
        Console.WriteLine($"Total Matches Played: {Scores.Count}");
        Console.WriteLine($"Sum of Scores: {GetSum()}");
        Console.WriteLine($"Average Score: {GetAverage():F2}");
    }
}

class Program01
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of matches played: ");
        int matches = int.Parse(Console.ReadLine());
        Cricket team = new Cricket();
        team.AddScores(matches);
        team.DisplayResults();
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}