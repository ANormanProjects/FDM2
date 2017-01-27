using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class PensionLogic
    {
        public Boolean IsPensionable(Person person, string year) // boolean is used for true/false
        {
            int retirement = Convert.ToInt32(year); // connects y with year2 (y-year2)

            int dob = Convert.ToInt32(person.dateOfBirth.Substring(person.dateOfBirth.Length - 4)); // getting the year

            int age = retirement - dob;
                       
            if (age >= 65)
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
