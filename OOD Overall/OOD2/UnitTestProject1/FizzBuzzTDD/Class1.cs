using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzTDD
{
    public class FizzBuzz
    {
        public bool IsDivisibleByThree(int input)
        {
            return (input % 3 == 0);
        }

        public bool IsDivisibleByFive(int input)
        {
            return (input % 5 == 0);
        }

        public bool IsDivisibleBy15(int input)
        {
            return (input % 15 == 0);
        }

        public string GetTextForNumber(int input)
        {
            if (input % 15 == 0)
            {
                return "FizzBuzz";
            }
            if (input % 5 == 0)
            {
                return "Buzz";
            }
            if (input % 3 == 0)
            {
                return "Fizz";
            }
            else
            {
                return input.ToString();
            }
        }

        public string DoTheFullFizzBuzz(int maxnum)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= maxnum; i++)
            {
                sb.AppendFormat("{0} ", GetTextForNumber(i));
            }
            return sb.ToString();
        }
    }
}
