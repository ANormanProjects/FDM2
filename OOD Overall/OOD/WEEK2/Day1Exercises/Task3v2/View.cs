using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3v2
{
    class View
    {
        public void PrintEligible(Person person)
        {
            Console.WriteLine(string.Format("{0} {1} may qualify for a pension this year.", person.firstname, person.lastname));
        }

        public void PrintIneligible(Person person)
        {
            Console.WriteLine(string.Format("{0} {1} is not old enough yet.", person.firstname, person.lastname));
        }
    }
}
