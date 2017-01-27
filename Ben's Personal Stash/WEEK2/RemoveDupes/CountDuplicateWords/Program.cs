using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountDuplicateWords
{
    class Program
    {

        //5)	Write a method that returns the number of duplicate words in a sentence.
        //      Treat uppercase and lowercase letters the same. Ignore punctuation.

        static void Main(string[] args)
        {
            Console.WriteLine("Number of duplicate words is: " + CountDuplicateWords("Hello hello hello goodbye goodbye"));
            Console.ReadKey();
        }
        
        private static int CountDuplicateWords(string sentence)
        {
            int numOfDupes = 0;
            List<string> uniquewords = new List<string>();

            string[] words = sentence.Split(' ');

            foreach (string word in words)
            {
                string wordToCompare = word.ToUpper();

                if (uniquewords.Contains(wordToCompare))
                {
                    numOfDupes++;
                }
                else
                {
                    uniquewords.Add(wordToCompare);
                }
                
            }
            return numOfDupes;
        }
    }
}
