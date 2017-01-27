using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string ben = "ben";
            string andrew = "andrew";
            string suleman = "suleman";

            RemoveDupesFromList rmdupes = new RemoveDupesFromList();
            string[] listofnames = rmdupes.removedupes(ben, andrew, ben, suleman, ben);

            foreach (string names in listofnames)
            {
                Console.WriteLine(names);
            }
            Console.ReadKey();

        }
    }

    public class RemoveDupesFromList
    {
        public string[] removedupes(params string[] args)
        {
            HashSet<string> names = new HashSet<string>(args);
            string[] nodupes = names.ToArray();
            return nodupes;
        }
    }

//    private static HashSet<string> RemoveDuplicates(string[] names)
//{
//    return new HashSet<string>(names);
//}
}
