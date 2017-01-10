using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            WidgetController wc = new WidgetController();

            wc.WidgetCalculations();

            Console.WriteLine("Press any key to exit the application");
            
            Console.ReadLine();
        }
    }
}
