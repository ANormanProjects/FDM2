using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question5v2
{
    public class Program
    {
        static void Main(string[] args)
        {
            StringSorter sorter = new StringSorter();
            StringSorterLINQ sorterLinq = new StringSorterLINQ();
            string message = "kdfjhglksdfjhglkfdhsgkjfhdsgkhjdfg";

            Console.WriteLine("--------------------");
            Console.WriteLine("Sorting without LINQ");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine("Test Message is: " + message);
            Console.WriteLine();
            Console.WriteLine("Alphabetical Sort: " + sorter.AlphabeticalSort(message));
            Console.WriteLine();
            Console.WriteLine("Alphabetical Distinct Sort: " + sorter.DistinctAlphabeticalSort(message));
            Console.WriteLine();
            Console.WriteLine("Counting Character Occurences: ");   
            foreach (KeyValuePair<char, int> pair in sorter.CountCharOccurences(message))
            {
                Console.WriteLine(pair.Key + " - " + pair.Value);
            }
            Console.WriteLine();

            Console.WriteLine("------------------");
            Console.WriteLine("Sorting using LINQ");
            Console.WriteLine("------------------");
            Console.WriteLine();
            Console.WriteLine("Test Message is: " + message);
            Console.WriteLine();
            Console.WriteLine("Alphabetical Sort: " + sorterLinq.AlphabeticalSortLinq(message));
            Console.WriteLine();
            Console.WriteLine("Alphabetical Distinct Sort: " + sorterLinq.DistinctAlphabeticalSortLinq(message));
            Console.WriteLine();
            Console.WriteLine("Counting Character Occurences: ");            
            foreach (KeyValuePair<char, int> pair in sorterLinq.CountCharOccurencesLinq(message))
            {
                Console.WriteLine(pair.Key + " - " + pair.Value);
            }

            Console.ReadKey();






            

        }
    }
}
