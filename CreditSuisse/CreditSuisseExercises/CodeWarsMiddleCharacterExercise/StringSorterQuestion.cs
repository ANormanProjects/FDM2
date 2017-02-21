using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisseExercises
{
    public class StringSorterQuestion
    {
        public string alphabeticalSort(string stringToBeSorted)
        {
            List<Char> charList = stringToBeSorted.ToCharArray().ToList();

            charList.Sort();

            return string.Join("", charList.ToArray());
        }

        public string distinctAlphabeticalSort(string stringToBeSorted)
        {
            List<Char> charList = stringToBeSorted.ToCharArray().ToList();
            
            charList = charList.Distinct().ToList();

            charList.Sort();

            return string.Join("", charList.ToArray());
        }

        public Dictionary<char, int> characterCount(string stringToBeCounted)
        {
            List<Char> charList = stringToBeCounted.ToCharArray().ToList();
            Dictionary<char, int> countDictionary = new Dictionary<char, int>();

            List<Char> distinctCharList = charList.Distinct().ToList();

            foreach (var character in distinctCharList)
            {
                int count = 0;

                foreach (var _character in charList)
                {
                    if (character == _character)
                    {
                        count++;
                    }
                }
                countDictionary.Add(character, count);
            }
            return countDictionary;
        }

        public string alphabeticalSortLinq(string stringToBeSorted)
        {
            List<Char> charList = stringToBeSorted.ToCharArray().ToList();

            var sortedCharList = charList.OrderBy(x => x).ToList();

            return string.Join("", sortedCharList.ToArray());
        }

        public string distinctAlphabeticalSortLinq(string stringToBeSorted)
        {
            List<Char> charList = stringToBeSorted.ToCharArray().ToList();

            var distinctCharList = charList.GroupBy(c => c).Select(x => x.First()).ToList();

            var sortedDistinctCharList = distinctCharList.OrderBy(x => x).ToList();

            return string.Join("", sortedDistinctCharList.ToArray());
        }

        public Dictionary<char, int> characterCountLinq(string stringToBeCounted)
        {
            List<Char> charList = stringToBeCounted.ToCharArray().ToList();
            Dictionary<char, int> countDictionary = new Dictionary<char, int>();

            var distinctCharList = charList.GroupBy(c => c).Select(x => x.First()).ToList();

            foreach (var character in distinctCharList)
            {
                var count = charList.Count(x => x == character);
                countDictionary.Add(character, count);
            }
            return countDictionary;
        }
    }
}
