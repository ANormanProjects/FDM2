using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Params
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
            ParamsExample(1, 2, 3, 4);          

            ParamsExample2(1, 'a', "FDM", "GROUP");

            ParamsExample2();            
       


            int[] myIntArray = { 5, 6, 7, 8, 9 };
            ParamsExample(myIntArray);

            object[] myObjArray = { 2, 'b', "FDM", "GROUP" };
            ParamsExample2(myObjArray);



            ParamsExample2(myIntArray);

            Console.ReadLine();
        }
       
    }
}
