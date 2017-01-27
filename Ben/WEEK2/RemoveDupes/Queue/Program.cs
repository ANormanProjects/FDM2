using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    //8)	Create a method that takes in a variable argument of type double and returns
    //      a Queue that orders the doubles in descending order
    //      (i.e., 14.8 should be the highest-priority element rather than 2.2)

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ordered Doubles By Descending: ");
            foreach (double number in OrderDoublesInQueue(new double[] { 2.1, 2.2, 1.2, 1.1, 1.6, 8.1, 9.3, 9.9 }))
            {
                Console.WriteLine(number);
            }
            Console.ReadKey();
        }

        private static Queue<double> OrderDoublesInQueue(double[] doubles)
        {
            Queue<double> queue = new Queue<double>(doubles);

            return new Queue<double>(queue.OrderByDescending(d => d));
        }
    }
}
