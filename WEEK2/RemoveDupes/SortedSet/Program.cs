using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedSet
{
    //7)	Write a method that uses a String method split to tokenize a line of text input by the user 
    //      and places each token in a SortedSet. It should return the SortedSet. 

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sorted numbers: ");
            foreach (int number in SortNumbers("9 1 2 3 4 5 6 9 8 7 1 2"))
            {
                Console.WriteLine(number);
            }
            Console.ReadKey();
        }
        
        private static SortedSet<int> SortNumbers(string numbersString)
        {
            SortedSet<int> realnumbers = new SortedSet<int>();

            string[] numbers = numbersString.Split(' ');

            foreach (string number in numbers)
            {
                realnumbers.Add(Convert.ToInt32(number));
            }

            return realnumbers;
        }
    }
}
