using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    internal class ArrayProg1
    {
        public static void Array_Calc()
        {
            Console.WriteLine("Give size of array");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("give element");
                int ele = Convert.ToInt32(Console.ReadLine());
                arr[i] = ele;
            }
            Console.WriteLine(string.Join(",", arr));

            int sum = 0;
            int avg = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                sum = sum + arr[j];
                avg = sum / arr.Length;
            }
            Console.WriteLine("The average is: {0} ", avg);

            int maxValue = arr.Max();
            int minValue = arr.Min();

            Console.WriteLine("The max value is {0} and min value is {1}", maxValue, minValue);

        }
    }
}
