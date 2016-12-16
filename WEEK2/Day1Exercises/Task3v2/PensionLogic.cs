using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3v2
{
    public class PensionLogic
    {
        public Boolean IsPensionable(Person person, string year)
        {
            int retirement = Convert.ToInt32(year);

            int dob = Convert.ToInt32(person.dateOfBirth.Substring(person.dateOfBirth.Length - 4));

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
