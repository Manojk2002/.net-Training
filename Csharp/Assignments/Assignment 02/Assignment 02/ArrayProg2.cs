using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    internal class ArrayProg2
    {
        public static void Marks_Op()
        {

            int[] arr = new int[10];
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
            Console.WriteLine("The sum is : {0}", sum);
            Console.WriteLine("The average is: {0} ", avg);

            int maxValue = arr.Max();
            int minValue = arr.Min();

            Console.WriteLine("The max value is {0} and min value is {1}", maxValue, minValue);

            Array.Sort(arr);
            Console.WriteLine("Ascending array: " + string.Join(",", arr));
            Array.Reverse(arr);
            Console.WriteLine("Descending array: " + string.Join(",", arr));
        }
    }
}
