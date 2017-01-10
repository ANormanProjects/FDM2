using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string spdlimit;
            string spd;

            //Name Query
            Console.WriteLine("Please enter name: ");
            name = Console.ReadLine(); //READING USER INPUT AND SETTING VALUE FROM INPUT
            
            //Speed LIMIT Check
            Console.WriteLine("Enter Speed Limit: ");
            spdlimit = Console.ReadLine();

            //Speed travelled check
            Console.WriteLine("Enter Speed Travelled: ");
            spd = Console.ReadLine();

            double spdlmt = Convert.ToDouble(spdlimit); // CONVERTING STRING into DOUBLE for numbers(speed)
            double speed = Convert.ToDouble(spd);

            if (speed - spdlmt >= 1 && speed - spdlmt <= 10) // SPEED IS 1mph up to 10mph over the limit
            {
                Console.WriteLine("$50 Fine for speeding up to 10mph over the limit.");
            }
            if (speed - spdlmt >= 11 && speed - spdlmt <=20)
            {
                Console.WriteLine("$75 Fine for speeding up to 20 mph over the limit.");
            }
            if (speed - spdlmt >= 21)
            {
                Console.WriteLine("$100 Fine for speeding over 20mph over the limit and your license is suspended for 3 months.");
            }
            Console.WriteLine("Your name is: " + name + " and your speed was " + speed + "mph and the speed limit was " + spdlmt + "mph.");
            Console.WriteLine("Press Enter to continue and exit the application.");
            Console.ReadLine();
        }
    }
}
