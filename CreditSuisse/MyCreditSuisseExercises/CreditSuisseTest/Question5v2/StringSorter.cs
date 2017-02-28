using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question5v2
{
    public class StringSorter
    {
        public string AlphabeticalSort(string message)
        {
            //Convert to char array
            char[] c = message.ToArray();

            //Sort letters
            Array.Sort(c);

            //Return modified string
            return new string(c);
        }

        public string DistinctAlphabeticalSort(string message)
        {
            //Convert to char array and only contain distincts
            char[] c = message.Distinct().ToArray();

            //Sort letters
            Array.Sort(c);

            //Return modified string
            return new string(c);         
        }

        public Dictionary<char, int> CountCharOccurences(string message)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();
            char[] occurences = message.ToCharArray();

            foreach (char c in occurences)
            {
                if (result.ContainsKey(c))
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
