using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch=true)]

namespace LoggingExample
{
    class Program
    {
        private static readonly ILog logger = 
            LogManager.GetLogger("Program.cs");

        static void Main(string[] args)
        {
            DivideTwoNumbers();


        }
        private static void DivideTwoNumbers()
        {
            try
            {
                int num1 = 10;
                int num2 = 0;
                int result = num1 / num2; 
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message); //can use different settings (logger.Error etc (OFF, FATAL, ERROR, WARN, INFO, DEBUG, ALL)
                Console.WriteLine("You can't divide by zero!");
            }
        }
            

    }
}
