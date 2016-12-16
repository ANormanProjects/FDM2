using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackHeapV3
{
    class Program
    {
        //int i = 10;   PUTTING VARIABLES IN MAIN CLASS LEVEL PUTS BOTH METHODS IN THE SAME SCOPE, REFS ARENT REQUIRED.
        //int j = 5;

        static void Main(string[] args)
        {
            int i = 10; // VARIABLES ON THE STACK
            int j = 5;

            Swap(i, j);   //SWAP CANNOT CHANGE THE VALUE OF ORIGINALS IN DIFFERENT SCOPES WITHOUT REF

            //Swap(ref i, ref j); // USE REF TO CHANGE THE VALUES OF THE ORIGINALS IN DIFFERENT SCOPES. NOT USED VERY OFTEN

            Console.WriteLine("i is: " + i);
            Console.WriteLine("j is: " + j);

            Console.ReadLine();

        }
        //private static void Swap(ref int i, ref int j)

        private static void Swap(int i, int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
    }
}
