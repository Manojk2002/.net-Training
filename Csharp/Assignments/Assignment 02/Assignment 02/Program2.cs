using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    internal class Program2
    {
        public static void Four_Times()
        {
            Console.WriteLine("Enter the number");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("{0} {0} {0} {0}", num);
            Console.WriteLine("{0}{0}{0}{0}", num);
            Console.WriteLine("{0} {0} {0} {0}", num);
            Console.Write("{0}{0}{0}{0}", num);

            Console.ReadLine();
        }
    }
}
