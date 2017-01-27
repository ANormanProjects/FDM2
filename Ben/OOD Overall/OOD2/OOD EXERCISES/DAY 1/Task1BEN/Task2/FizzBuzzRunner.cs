using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class FizzBuzzRunner
    {   
        // BASIC CODE FROM TASK 1
        public void FizzBuzz(int number)
        {
            for (int i = 1; i <= 100; i++) //loop, i++ increments, i<=100 up to 100
            {
                if (IsFizzBuzz(i)) // PULLS METHOD FROM private Boolean IsFizzBuzz checking for % of 3 and 5
                {
                    Console.WriteLine(i + " FizzBuzz");
                }
                else if (IsBuzz(i))
                {
                    Console.WriteLine(i + " Buzz");
                }
                else if (IsFizz(i))
                {
                    Console.WriteLine(i + " Fizz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }

        // ADDING METHODS FOR MODULARITY
        private Boolean IsFizz (int num)
        {
            if (num % 3 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean IsBuzz (int num)
        {
            if (num % 5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean IsFizzBuzz (int num)
        {
            if (num % 3 == 0 && num % 5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
