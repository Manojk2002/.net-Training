using System;


namespace Assignment_1
{
    class Program5
    {
        static int SumTriple(int a, int b)
        {
            return a == b ? (a + b) * 3 : a + b;
        }

        static void Main()
        {
            Console.Write("Input first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Result: {SumTriple(num1, num2)}");
            Console.ReadLine();
        }
        

    }
}
