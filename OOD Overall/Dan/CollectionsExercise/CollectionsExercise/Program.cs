using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //List - Default collection
            //Dictionary - KeyValuePairs
            //Hashset - Removes duplicate values
            //LinkedList - Allows fast insert and removes (InsertLast/ InsertFirst)
            //Queue - FIFO collection
            //SortedList - Good for storing values in order
            //Stack - LIFO collection

            //KeyValuePair - Holds a key and an associated value - used in dictionaries
            //Tuple - Holds three items together

            Console.WriteLine("Removed duplicates from list:");
            foreach (string name in RemoveDuplicates(new string[] { "Dan", "Dan", "Dan" }))
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            Console.WriteLine("Get all colors in the dictionary:");
            foreach (KeyValuePair<int, Color> color in GetDictionaryOfColours())
            {
                Console.WriteLine(color.Value);
            }
            Console.WriteLine();

            foreach (KeyValuePair<char, int> dictionaryEntry in CountNumberOfChars("HelloH"))
            {
                Console.WriteLine("There are: " + dictionaryEntry.Value + " " + dictionaryEntry.Key);
            }
            Console.WriteLine();

            Console.WriteLine("Number of duplicate words is: " + CountDuplicateWords("Hello hello Hello Goodbye goodbye"));
            Console.WriteLine();

            Console.WriteLine("LinkedList reversed: ");
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddLast(5);

            foreach (int number in ReverseLinkedList(linkedList))
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            Console.WriteLine("Sorted Numbers: ");
            foreach (int number in SortNumbers("9 1 8 2 6 4 7 5 3"))
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            Console.WriteLine("Ordered doubles: ");
            foreach (double number in OrderDoublesInQueue(new double[] {2.1, 1.0, 6.7, 9.8, 5.4, 5.3, 5.5}))
            {
                Console.WriteLine(number);
            }

            Console.ReadLine();
        }

        private static HashSet<string> RemoveDuplicates(string[] names)
        {
            return new HashSet<string>(names);
        }

        private static Dictionary<int, Color> GetDictionaryOfColours()
        {
            return new Dictionary<int, Color>
            {
                {1, Color.Red},
                {2, Color.Orange},
                {3, Color.Yellow},
                {4, Color.Green},
                {5, Color.Blue},
                {6, Color.Indigo},
                {7, Color.Violet}
            };
        }

        private static Dictionary<char, int> CountNumberOfChars(string sentence)
        {
            string capsSentence = sentence.ToUpper();

            Dictionary<char, int> numberOfOccurances = new Dictionary<char, int>();

            foreach (char character in capsSentence)
            {
                if (numberOfOccurances.ContainsKey(character))
                {
                    numberOfOccurances[character]++;
                }
                else
                {
                    numberOfOccurances.Add(character, 1);
                }
            }

            return numberOfOccurances;
        }

        private static int CountDuplicateWords(string sentence)
        {
            int numberOfDuplicates = 0;
            List<string> uniqueWords = new List<string>();

            string[] words = sentence.Split(' ');

            foreach (string word in words)
            {
                string wordToCompare = word.ToUpper();

                if (uniqueWords.Contains(wordToCompare))
                {
                    numberOfDuplicates++;
                }
                else
                {
                    uniqueWords.Add(wordToCompare);
                }
            }

            return numberOfDuplicates;
        }

        private static LinkedList<int> ReverseLinkedList(LinkedList<int> list)
        {
            return new LinkedList<int>(list.Reverse());
        }

        private static SortedSet<int> SortNumbers(string numbersString)
        {
            SortedSet<int> realNumbers = new SortedSet<int>();

            string[] numbers = numbersString.Split(' ');

            foreach (string number in numbers)
            {
                realNumbers.Add(Convert.ToInt32(number));
            }

            return realNumbers;
        }

        private static Queue<double> OrderDoublesInQueue(double[] doubles)
        {
            Queue<double> queue = new Queue<double>(doubles);
            return new Queue<double>(queue.OrderByDescending(d => d));
        }
    }
}
