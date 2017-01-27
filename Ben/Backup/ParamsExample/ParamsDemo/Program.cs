using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsDemo
{
    public class Params
    {
        public static void ParamsExample(params int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main()
        {
            ParamsExample(1, 2, 3, 4, 5);

            Console.ReadLine();

        }
    }
}
