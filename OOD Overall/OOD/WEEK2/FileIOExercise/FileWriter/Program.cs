using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWriter
{
    class Program
    {

        //2.	Write a small program to register a new user of a system.   Your program should prompt the user
        //      for pertinent information (e.g. name, address, email etc).  Then this information should be appended 
        //      to a text file.  Fields should be separated by commas. Each line in the file should be a record for a different user. 

        static void Main(string[] args)
        {
            string path = "C:\\Users\\benjamin.bowes\\Desktop\\myFile.txt";

            //Name
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine();

            //Address
            Console.WriteLine("Please enter your address: ");
            string address = Console.ReadLine();
            Console.WriteLine();


            //Email
            Console.WriteLine("Please enter your email address: ");
            string email = Console.ReadLine();
            Console.WriteLine();

            bool append = true;

            WriteToFile(path, name, address, email, append);

            string fileContents = ReadFromFile(path);

            Console.WriteLine("Thank you for entering your details, this is what you have entered: ");
            Console.WriteLine(fileContents);
            Console.ReadKey();

        }

        private static void WriteToFile(string path, string name, string address, string email, bool append)
        {
            StreamWriter Writer = new StreamWriter(path);
            Writer.Write(name + " , " + address + " , " + email + ".", append);

            Writer.Close();
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
