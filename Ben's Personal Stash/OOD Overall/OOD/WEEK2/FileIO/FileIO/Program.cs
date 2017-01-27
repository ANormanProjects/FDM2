using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            //"C:\\Users\\benjamin.bowes\\Desktop\\myFile.txt";
            

            //Enter Pathname
            Console.WriteLine("Please enter the path for the text file: ");
            string path = Console.ReadLine();

            //Checking Path is Correct
            try
            {
                CheckPathValidity(path);
            }
            catch (InvalidPathException ex)
            {

                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }

            //Enter Message for File
            Console.WriteLine();
            Console.WriteLine("Please enter the message to go into the file: ");
            string message = Console.ReadLine();


            //Choosing Append or Overwrite Function
            Console.WriteLine();
            bool append = true;
            //bool overwrite = false;

            WriteToFile(path, message, append);

            string fileContents = ReadFromFile(path); //ReadFromFile Method link

            Console.WriteLine(fileContents);
            
        }

        private static void CheckPathValidity(string path) //CHECKING PATHNAME IS VALID
        {
            if (path != "C:\\Users\\benjamin.bowes\\Desktop\\myFile.txt") //REQUIRED PATHNAME
            {
                throw new InvalidPathException("Incorrect path for the file!");
            }
        }

        private static void WriteToFile(string path, string message, bool append) //WRITE TO FILE
        {
            StreamWriter writer = new StreamWriter(path); //IN SCOPE FOR ALL try, catch and finally.

                //True will append to the file
                //False will override the file
                writer.Write(message, append);

                writer.Close();

        }

        private static string ReadFromFile(string path) //READ FROM FILE
        {
            StreamReader reader = new StreamReader(path);

            StringBuilder stringBuilder = new StringBuilder();

            do
            {
                stringBuilder.Append(reader.ReadLine());
            }
            while (reader.Peek() != -1); //-1 is given back when there are no more lines to read. While will keep reading lines until it hits -1.

            return stringBuilder.ToString();
        }
    }
}
