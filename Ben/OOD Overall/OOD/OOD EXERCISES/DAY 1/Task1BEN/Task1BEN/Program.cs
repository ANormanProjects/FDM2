using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1BEN
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++) //loop, i++ increments, i<=100 up to 100
            {
                if (i % 3 == 0 && i % 5 == 0) // i is a multiple of 3 or 5 with 0 remainder
                {
                    Console.WriteLine(i + " FizzBuzz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine(i + " Buzz");
                }
                else if (i % 3 == 0)
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
    }
}
