using System;


namespace Assignment_1
{
    class Program3
    {
        static void Main()
        {
            Console.WriteLine("Enter 1st number");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the operator (+,-,/,*)");
            char o = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter 2nd number");
            int b = Convert.ToInt32(Console.ReadLine());

            int output = 0;

            switch (o)
            {
                case '+':
                    output = a + b;
                    break;
                case '-':
                    output = a - b;
                    break;
                case '/':
                    output = a / b;
                    break;
                case '*':
                    output = a * b;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
            Console.WriteLine("{0} {1} {2} = {3}", a, o, b, output);
            Console.ReadLine();
        }

    }
}
