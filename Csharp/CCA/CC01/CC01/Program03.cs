using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01
{
    internal class Program03
    {
        static void Main(string[] args)
        {
            int result1 = LargestNumber(1, 2, 3);
            Console.WriteLine($"Input: 1, 2, 3");
            Console.WriteLine($"Output: {result1}");

            int result2 = LargestNumber(1, 3, 2);
            Console.WriteLine($"Input: 1, 3, 2");
            Console.WriteLine($"Output: {result2}");

            int result3 = LargestNumber(1, 1, 1);
            Console.WriteLine($"Input: 1, 1, 1");
            Console.WriteLine($"Output: {result3}");

            int result4 = LargestNumber(1, 2, 2);
            Console.WriteLine($"Input: 1, 2, 2");
            Console.WriteLine($"Output: {result4}");
            Console.ReadLine();
        }

        static int LargestNumber(int num1, int num2, int num3)
        {
            int largest = (num1 >= num2 && num1 >= num3) ? num1 :
                          (num2 >= num1 && num2 >= num3) ? num2 :
                          num3;

            return largest;
        }
    }
}