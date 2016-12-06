using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            string miles;

            Console.WriteLine("Input no. of Miles for Yds and Feet conversion: ");
            miles = Console.ReadLine();

            double mls = Convert.ToDouble(miles);

            for (double i = 0; i <= mls; i++)
            {
                double yds = 1760 * mls;
                double feet = 5280 * mls;
                Console.WriteLine("You travelled " + mls + "miles and this is converted to: " + yds + " yards and " + feet + " feet.");
            }
            Console.ReadLine();
        }
    }
}
