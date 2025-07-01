using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01
{
    class Program01
    {
        static void Main()
        {
            string input1 = "Python";
            int position1 = 1;
            string result1 = RemoveCharAtIndex(input1, position1);
            Console.WriteLine(result1);
           

            string input2 = "Python";
            int position2 = 0;
            string result2 = RemoveCharAtIndex(input2, position2);
            Console.WriteLine(result2);
          
            string input3 = "Python";
            int position3 = 4;
            string result3 = RemoveCharAtIndex(input3, position3);
            Console.WriteLine(result3);

            Console.ReadLine();
        }

        static string RemoveCharAtIndex(string str, int index)
        {
            if (index < 0 || index >= str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            return str.Remove(index, 1);
        }
    }
}