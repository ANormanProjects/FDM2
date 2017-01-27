using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Menu
    {
        static void Main(string[] args)
        {
            string input;

            while (true) //LOOPING UNTIL OPTION C is selected
            {
                Console.WriteLine("Please select either Option A, B or C");
                input = Console.ReadLine().ToUpper();
                if (input == "A")
                {
                    Console.WriteLine("You have chosen Option A");
                }
                if (input == "B")
                {
                    Console.WriteLine("You have chosen Option B");
                }
                if (input == "C")
                {
                    Environment.Exit(0); // EXIT APPLICATION
                }
            }
        }
    }
}
