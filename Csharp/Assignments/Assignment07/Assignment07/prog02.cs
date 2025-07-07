using System;
using System.Linq;

class prog02
{
    static void Main()
    {
        string[] words = { "mum", "amsterdam", "bloom" };

        var result = words
            .Where(word => word.StartsWith("a", StringComparison.OrdinalIgnoreCase) &&
                           word.EndsWith("m", StringComparison.OrdinalIgnoreCase));

        foreach (var word in result)
        {
            Console.WriteLine(word);
            Console.ReadLine();
        }
    }
}
