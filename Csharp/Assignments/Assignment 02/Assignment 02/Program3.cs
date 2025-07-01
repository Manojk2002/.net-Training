using System;

namespace Assignment_02
{
    internal class Program3
    {
        public static void Weekdays_Count()
        {
            Console.WriteLine("Enter the number");
            int a = Convert.ToInt32(Console.ReadLine());

            switch (a)
            {
                case 1:
                    Console.Write("Monday");
                    //Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Invalid number");
                    break;
            }
            Console.ReadLine();
        }
    }
}
