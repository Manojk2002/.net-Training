using System;


namespace Assignment_1
{
    class Porgram2
    {
        static void Main()
        {
            /*fdsffd*/
            Console.Write("Input a number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num >= 0)
                Console.WriteLine($"{num} is a positive number.");
            else
                Console.WriteLine($"{num} is a negative number.");
            Console.ReadLine();
        }

    }
}
