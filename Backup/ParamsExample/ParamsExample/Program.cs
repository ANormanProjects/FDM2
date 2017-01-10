using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsExample
{
    public class Params
    {
        public static void ParamsExample(params int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        public static void ParamsExample2(params object[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main()
        {
            ParamsExample(1, 2, 3, 4);          // You can send a comma-separated list of arguments of the specified type.
            
            ParamsExample2(1, 'a', "test");

            ParamsExample2();                   // The following calling statement displays only a blank line.

            // An array argument can be passed, as long as the array
            // type matches the parameter type of the method being called.
            int[] myIntArray = { 5, 6, 7, 8, 9 };
            ParamsExample(myIntArray);

            object[] myObjArray = { 2, 'b', "test", "again" };
            ParamsExample2(myObjArray);

            // The following call causes a compiler error because the object
            // array cannot be converted into an integer array.
            //UseParams(myObjArray);

            // The following call does not cause an error, but the entire 
            // integer array becomes the first element of the params array.
            ParamsExample2(myIntArray);
        }
    }
}
