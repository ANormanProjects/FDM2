using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackHeapV4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dvd dvd1 = new Dvd();
            dvd1.title = "The Matrix";
            Dvd dvd2 = new Dvd();
            dvd2.title = "Dumbo";

            SwapObjects(dvd1, dvd2); //THIS WILL NOT WORK DUE TO THE LACK OF REFS

            Console.WriteLine("dvd1 is: " + dvd1.title);
            Console.WriteLine("dvd2 is: " + dvd2.title);

            Console.ReadLine();
        }

        private static void SwapObjects(Dvd dvd1, Dvd dvd2) //THESE ARE REMOVED WHEN THE METHOD IS FINISHED AND IS OUT OF SCOPE, RESULTING WITH NO SWAP
        {
            //Dvd temp = dvd1;          // THESE WONT SWAP DUE TO NO REFS
            //dvd1 = dvd2;
            //dvd2 = temp;

            string temp = dvd1.title;   //THESE WILL SWAP AS THEY NOW HAVE SPECIFIC REFS ".title" which is property. 
                                            //So swap is now changing the property of the objects.
            dvd1.title = dvd2.title;
            dvd2.title = temp;
        }
    }
}
