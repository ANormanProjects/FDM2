using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Question5v2
{
    public class StringSorterLINQ
    {
        public string AlphabeticalSortLinq(string message)
        {
            string newMessage = new string(message.ToCharArray().OrderBy(c => c).ToArray());

            return newMessage;
        }

        public string DistinctAlphabeticalSortLinq(string message)
        {

            string newMessage = new string(message.ToCharArray().OrderBy(c => c).Distinct().ToArray());

            return newMessage;
        }

        public Dictionary<char, int> CountCharOccurencesLinq(string message)
        {
            return message.GroupBy(c => c)
                          .ToDictionary(grp => grp.Key, grp => grp.Count());
                            
        }
    }
}
