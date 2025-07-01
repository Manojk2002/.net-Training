using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    internal class Program1
    {

        public static void Swap_numbers()
        {
            Console.WriteLine("Enter the 1st number");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the 2nd number");
            int n2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Before swapping 1st value is {0} and second value is {1}", n1, n2);

            int temp = n1;
            n1 = n2;
            n2 = temp;

            Console.WriteLine("After swapping 1st value is {0} and second value is {1}", n1, n2);
            Console.ReadLine();

        }
        static void Main(string[] args)
        {
            Swap_numbers();
            Program2.Four_Times();
            Program3.Weekdays_Count();
            ArrayProg1.Array_Calc();
            ArrayProg2.Marks_Op();
            ArrayProg3.Copy_string();
            StringProg1.Length_of_string();
            StringProg2.Reverse_of_string();
            StringProg3.Equal_String();




        }
    }
}
