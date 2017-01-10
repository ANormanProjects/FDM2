using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumOfDuplicateWords
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Removing Duplicate Words from the List: ");
            foreach (string name in RemoveDuplicates(new string[] {"ben", "ben", "ben", "spencer", "ben", "andrew"}))
            {
                Console.WriteLine(name);
            }
            Console.ReadKey();
        }
        
        private static HashSet<string> RemoveDuplicates(string[] names)
        {
            return new HashSet<string>(names);
        }
    }
}
