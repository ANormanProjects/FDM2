using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisseExercises
{
    class Program
    {
        static void Main(string[] args)
        {

            StringSorterQuestion ssq = new StringSorterQuestion();

            Dictionary<char, int> dictionary = ssq.characterCount("kdfjhglksdfjhglkfdhsgkjfhdsgkhjdfg");

            foreach (var element in dictionary)
            {
                Console.WriteLine(element.Key + " " + element.Value);
            }

            Console.ReadLine();
        }
    }
}
