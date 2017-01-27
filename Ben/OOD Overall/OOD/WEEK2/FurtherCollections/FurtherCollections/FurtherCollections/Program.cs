using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurtherCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<int, string> personDictionary =
            //    new Dictionary<int, string>();

            ////                   KEY   VALUE
            //personDictionary.Add(500, "Nana");
            //personDictionary.Add(400, "Ben");
            //personDictionary.Add(556, "Andrew");
            //personDictionary.Add(546, "Daniel");
            //personDictionary.Add(987, "Suleman");
            //personDictionary.Add(123, "Bishan");
            //personDictionary.Add(542, "Mario");

            //string value = personDictionary[556];

            //Console.WriteLine(value);
            //Console.ReadKey();

            ////Dvd dvd1 = new Dvd(1, "Bambi");
            //    //Dvd dvd2 = new Dvd(1, "Bambi");
            //            bool equals = dvd1.Equals(dvd2);

            //Console.WriteLine(equals); //equals = bool equals
            //Console.ReadLine();

            List<Dvd> dvds = new List<Dvd>()
            {
                    new Dvd(5, "Shrek", 5),
                    new Dvd(1, "Pulp Fiction", 6), //Use commas for List
                    new Dvd(3, "Lion King", 9),
                    new Dvd(2, "Bambi", 8),
                    new Dvd(4, "American History X", 10),
            };

            Console.WriteLine("Original List: ");
            foreach (Dvd dvd in dvds)
            {
                
                Console.WriteLine(dvd.id + " : " + dvd.title);
            }


            //This uses default comparison - IComparable on the DVD Class - OUTDATED FOR MULTIPLE SORTS BUT GOOD FOR ONE THING
            //dvds.Sort();

            Console.WriteLine();
            Console.WriteLine("Sorted by ID");

            dvds.Sort(new DvdIdComparer());             //This uses an external class to compare prices DvdIdComparer

            foreach (Dvd dvd in dvds)
            {
                Console.WriteLine(dvd.id + " : " + dvd.title);
            }

            
            Console.WriteLine();
            Console.WriteLine("Sorted By Price");

            dvds.Sort(new DvdPriceComparer()); //Will Change to the right order, and will go back to the top again to check again

            foreach (Dvd dvd in dvds)
            {
                Console.WriteLine(dvd.id + " : " + dvd.title + " : " + dvd.price);
            }
       

            Console.ReadLine();



        }
    }
}
