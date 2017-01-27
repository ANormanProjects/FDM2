using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionExercise
{
    public class Program
    {
        public class RemoveDuplicatesFromList
        {
            public string[] removedupes(params string[] args)
            {
                HashSet<string> name = new HashSet<string>(args); //HASHSET generates a list that only contains unique elements
                string[] NoDupes = name.ToArray();
                return NoDupes;
            }

        }
        
        static void Main(string[] args)
        {
            //TASK 2
            string ben = "Ben";
            string bill = "Bill";
            string bob = "Bob";
            string andrew = "Andrew";

            RemoveDuplicatesFromList rmdupes = new RemoveDuplicatesFromList();

            string[] ListOfNames = rmdupes.removedupes(bill, bill, andrew, ben, bob, andrew, ben, ben);

            foreach (string name in ListOfNames)
            {
                Console.WriteLine(name);
            }
            Console.ReadKey();


        }
    }
}
