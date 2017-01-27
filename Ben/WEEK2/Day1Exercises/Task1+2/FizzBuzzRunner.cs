using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2
{
    public class FizzBuzzRunner
    {
        public void FizzBuzzRun(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                if (IsFizzBuzz(i))
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (IsBuzz(i))
                {
                    Console.WriteLine("Buzz");
                }
                else if (IsFizz(i))
                {
                    Console.WriteLine("Fizz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
        private Boolean IsFizz(int num)
        {
            if(num % 3 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean IsBuzz(int num)
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

        private Boolean IsFizzBuzz(int num)
        {
            if (num % 15 == 0)
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
