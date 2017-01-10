using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int uinput;

            Conversion con = new Conversion();  // SETTING UP A CONSTRUCTOR FROM ANOTHER CLASS (e.g. Conversion).

            Console.WriteLine("Miles \t Yards \t Feet ");
            Console.WriteLine("=======================");
            for (int i = 1; i <= 100; i++) // LOOPING TO 100
            {
                Console.WriteLine(con.ConvCal(i)); // LINKS WITH LINE 31 Conversion
            }
            while (true)
            {
                Console.Write("Enter Mile or type 0 to Exit: ");
                uinput = Convert.ToInt32(Console.ReadLine());    // CONVERTING USERINPUT TO INT
                Console.WriteLine("Miles \t \t Yards \t Feet ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Mile - " + con.ConvCal(uinput));
                Console.WriteLine("Press Enter to continue and do another conversion.");
                Console.ReadKey();                                                          //tryparse
            if (uinput == 0)  // EXITING APP
            {
                    Environment.Exit(0); // EXIT APPLICATION
            }
            }
        }
    }
}
