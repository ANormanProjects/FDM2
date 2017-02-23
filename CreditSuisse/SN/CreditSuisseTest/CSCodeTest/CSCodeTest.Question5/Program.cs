using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeTest.Question5
{
    public class Program
    {
        static void Main(string[] args)
        {
            StringSorter sorter = new StringSorter();

            string message = "kdfjhglksdfjhglkfdhsgkjfhdsgkhjdfg";

            Console.WriteLine("========== USING LINQ ==========");
            Console.WriteLine("Message = " + message);
            Console.WriteLine(sorter.AlphabeticalSortLinq(message));
            Console.WriteLine(sorter.DistinctAlphabeticalSortLinq(message));
            foreach( KeyValuePair<char, int> pair in sorter.CountCharOccurencesLinq(message))
            {
                Console.WriteLine(pair.Key + " - " + pair.Value);
            }
            Console.WriteLine();

            Console.WriteLine("========== WITHOUT USING LINQ ==========");
            Console.WriteLine("Message = " + message);
            Console.WriteLine(sorter.AlphabeticalSort(message));
            Console.WriteLine(sorter.DistinctAlphabeticalSort(message));
            foreach (KeyValuePair<char, int> pair in sorter.CountCharOccurences(message))
            {
                Console.WriteLine(pair.Key + " - " + pair.Value);
            }
            Console.WriteLine();

            Console.ReadLine();
        }

    }
}
