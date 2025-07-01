using System;


namespace Assignment_02
{
    internal class ArrayProg3
    {
        public static void Copy_string()
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

            int[] arr2 = new int[arr.Length];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = arr[i];
            }
            Console.WriteLine(string.Join(",", arr2));
        }
    }
}
