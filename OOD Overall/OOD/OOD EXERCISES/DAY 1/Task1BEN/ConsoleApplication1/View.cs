using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class View
    {
        
        //Ctrl + K + D to auto format 

        public string UserInput()
        {
            Console.WriteLine("Enter the number of widgets you want to order: ");
            return Console.ReadLine();
        }

        public void OnetoTwelveWids()
        {
            Console.WriteLine("Ordering 1 to 12 Widgets cost $12.39 each");
        }

        public void Thirteento50Wids()
        {
            Console.WriteLine("Ordering 13 to 50 Widgets cost $11.99 each");
        }

        public void FiftyOnePlusWids()
        {
            Console.WriteLine("Ordering 51 or more Widgets cost $11.49 each");
        }

        public void Delivery30Less(string wids)
        {
            Console.WriteLine("You have ordered " + wids + " Widgets");
            Console.WriteLine("Delivery Charge will be $3.00 up to 30 Widgets");        
        }

        public void Delivery31Plus(string wids)
        {
            Console.WriteLine("You have ordered " + wids + " Widgets");
            Console.WriteLine("Delivery Charge will be $5.00 for orders over 30 Widgets");
        }
    }
}
