using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class PensionLogic
    {
        public Boolean IsPensionable(Person person, String year) // boolean is used for true/false
        {
            int y = Convert.ToInt32(year); // connects y with year2 (y-year2)
            string dob = person.dateOfBirth; //
            string year1 = dob.Substring(dob.Length - 4); // uses the last 4 characters of the DOB to calculate
            int year2 = Convert.ToInt32(year1); // creating year2 from year1 value converted
            if (y-year2 >= 65)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
