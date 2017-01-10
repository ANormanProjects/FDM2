using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOExercise
{
    //1.	Write a method that counts the number of times a particular character, 
    //      such as e, appears in a file. The character and the filename can be 
    //      specified as method arguments. You can use any sample input file.

    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\benjamin.bowes\\Desktop\\myFile.txt";

            string character = Console.ReadLine();

            ReadFromFile(character, path);
        }

        private static void ReadFromFile(string character, string path)
        {
            StreamReader reader = new StreamReader(path);
            string line = reader.ReadToEnd();

            int counter = 0;
            
            foreach (char ch in line)
            {
                if (character == ch.ToString())
                {
                    counter = counter + 1;
                }

            }
            Console.WriteLine("The character appears " + counter + " times.");
            Console.ReadKey();
        }
    }
}
