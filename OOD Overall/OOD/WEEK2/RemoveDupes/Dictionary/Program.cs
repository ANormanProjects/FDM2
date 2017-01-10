using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dictionary
{
    //3)	Use a Dictionary to create a reusable class for choosing one of the 13 
    //      predefined colors in class Color. The names of the colors should be 
    //      used as keys, and the predefined Color  objects should be used as values. It should return the Dictionary.


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Get all colors in the Dictionary: ");
            foreach (KeyValuePair<string,Color> color in GetDictionaryOfColors())
            {
                Console.WriteLine(color.Value);
            }
            Console.ReadKey();
        }

        private static Dictionary<string, Color> GetDictionaryOfColors()
        {
            return new Dictionary<string, Color>
            { //ARRAY START
                {"Red", Color.Red},
                {"Orange", Color.Orange},
                {"Blue", Color.Blue},
                {"Green", Color.Green},
                {"White", Color.White}
            }; //ARRAY END
        }
    }
}
