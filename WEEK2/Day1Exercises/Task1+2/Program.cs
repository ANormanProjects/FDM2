using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzzRunner fizzbuzz = new FizzBuzzRunner();

            Console.WriteLine("Please enter your value to fizzbuzz: ");
            int input = Convert.ToInt32(Console.ReadLine());
            fizzbuzz.FizzBuzzRun(input);
            Console.ReadKey();

        }

    }
}

