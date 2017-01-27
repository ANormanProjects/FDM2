using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountNumOfChars
{
    class Program
    {
        //4)	Write a method to count the number of occurrences of each letter in a string. 
        //      For example, the string "HELLO THERE" contains two Hs, three Es, two Ls, one O, 
        //      one T and one R. It should return an object that contains the results 
        //      – what kind of class is best suited for this?

        static void Main(string[] args)
        {
            foreach (KeyValuePair<char, int> entry in CountNumOfChars("HelloWorld"))
            {
                Console.WriteLine("There are: " + entry.Value + " " + entry.Key);
            }
            Console.ReadKey();
        }

        private static Dictionary<char, int> CountNumOfChars(string sentence)
        {
            string capsSentence = sentence.ToUpper();

            Dictionary<char, int> numOfOccurances = new Dictionary<char, int>();

            foreach (char character in capsSentence)
            if (numOfOccurances.ContainsKey(character))
            {
                numOfOccurances[character]++;
            }
            else
            {
                numOfOccurances.Add(character, 1);
            }
            return numOfOccurances;
        }
        
    }
}
