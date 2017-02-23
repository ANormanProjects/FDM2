using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeTest.Question5
{
    public class StringSorter
    {
        /// <summary>
        /// Sorts the characters in a string alphebetically using LINQ Expressions
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string AlphabeticalSortLinq(string message)
        {
            string result = new string(message.ToCharArray().OrderBy(c => c, new CharComparer()).ToArray());

            return result;
        }

        /// <summary>
        /// Sorts the characters in a string alphebetically using LINQ Expressions and returns a list of distinct values
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string DistinctAlphabeticalSortLinq(string message)
        {
            string result = new string(message.ToCharArray().OrderBy(c => c, new CharComparer()).Distinct().ToArray());

            return result;
        }

        /// <summary>
        /// Counts the number of times each character appears in the string using Linq expressions
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Dictionary<char, int> CountCharOccurencesLinq(string message)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();
            char[] distinctMessage = message.Distinct().ToArray();

            foreach ( char c in distinctMessage )
            {
                int count = message.ToCharArray().Count(ch => ch == c);
                result.Add(c, count);
            }            

            return result;
        }

        /// <summary>
        /// Sorts the characters in a string alphabetically
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string AlphabeticalSort(string message)
        {
            char[] result = message.ToCharArray();

            Array.Sort(result);

            return new string(result);
        }

        /// <summary>
        /// Sorts the characters in a string alphebetically and returns a list of distinct values
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string DistinctAlphabeticalSort(string message)
        {
            List<char> result = new List<char>();
            char[] array = message.ToCharArray();
            
            foreach( char c in array )
            {
                if ( !result.Contains(c) )
                {
                    result.Add(c);
                }
            }

            result.Sort();

            return new string(result.ToArray());
        }

        /// <summary>
        /// Counts the number of times each character appears in the string
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Dictionary<char, int> CountCharOccurences(string message)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();
            char[] distinctMessage = AlphabeticalSort(message).ToCharArray();

            foreach (char c in distinctMessage)
            {
                if ( result.ContainsKey(c) )
                {
                    result[c]++;
                }
                else
                {
                    result.Add(c, 1);
                }
            }

            return result;
        }
    }
}
