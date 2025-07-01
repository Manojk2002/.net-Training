using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01
{
    internal class Program02
    {
        static void Main()
        {
            string input1 = "abcd";
            string result1 = ExchangeFirstAndLast(input1);
            Console.WriteLine($"Input: \"{input1}\"");
            Console.WriteLine($"Output: {result1}");

            string input2 = "a";
            string result2 = ExchangeFirstAndLast(input2);
            Console.WriteLine($"Input: \"{input2}\"");
            Console.WriteLine($"Output: {result2}");

            string input3 = "xy";
            string result3 = ExchangeFirstAndLast(input3);
            Console.WriteLine($"Input: \"{input3}\"");
            Console.WriteLine($"Output: {result3}");
            Console.ReadLine();
        }

        static string ExchangeFirstAndLast(string str)
        {
            if (str.Length <= 1)
            {
                return str;
            }

            char firstChar = str[0];
            char lastChar = str[str.Length - 1];

            return lastChar + str.Substring(1, str.Length - 2) + firstChar;
        }
    }
}