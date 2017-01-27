using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Divide(10, 0));
            Console.ReadKey();
        }

        static int Divide(int number1, int number2)
        {

            try
            {
                return number1 / number2;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                //throw;
                return 0;
            }
            finally
            {
                //Will Always Run. Good for disconnecting from databases.
            }
            
            //catch (NullReferenceException e2)
            //{
            //    Console.WriteLine(e2.Message);
            //    return 0;
            //}


            //THIS IS Defensive Coding

            //if (number2 == 0)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return number1 / number2;
            //}
            
        }
    }
}
