using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsKata
{
    public class RomanNumeralsCalculator
    {
        public String arabicToRoman(int arabic)
        {
            //StringBuilder result = new StringBuilder();
            //int remaining = arabic;

            //if (remaining >= 9)
            //{
            //    result.Append("IX");
            //    remaining -= 9;
            //}

            //if (remaining >= 5)
            //{
            //    result.Append("V");
            //    remaining -= 5;
            //}

            //if (remaining >= 4)
            //{
            //    result.Append("IV");
            //    remaining -= 4;
            //}

            //for (int i = 0; i < remaining; i++)
            //{
            //    result.Append("I");
            //}

            //return result.ToString();

            StringBuilder result = new StringBuilder();
            int remaining = arabic;
            remaining = appendRomanNumerals(remaining, 9, "IX", result);
            remaining = appendRomanNumerals(remaining, 5, "V", result);
            remaining = appendRomanNumerals(remaining, 4, "IV", result);
            for (int i = 0; i < remaining; i++)
            {
                result.Append("I");
            }
            return result.ToString();

        }

        private int appendRomanNumerals(int arabic, int value, string romanDigits, StringBuilder builder) //MATCHES ABOVE (remaining, 9, "IX", results);
        {
            int result = arabic;
            if (result >= value)
            {
                builder.Append(romanDigits);
                result -= value;
            }
            return result;
        }

            
    }
}
