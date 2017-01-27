using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    public class Conversion
    {
        Program prog = new Program();

        public string ConvCal(int miles) // Uses int miles for the string with yards and feet for calculations   
        {
            string conversionString = ""; // "" ensures that what is written in conversionString below will come out as text.
            int yards = 1760;
            int feet = 5280;
            conversionString = miles + "\t" + (miles * yards) + "\t" + (miles * feet); // Produces the string parameters

            return conversionString; // Returns the string for printing at line 19 at Program.Conversion (class.method)
        }
    }
}
