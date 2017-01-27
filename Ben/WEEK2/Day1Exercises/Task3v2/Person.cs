using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3v2
{
    public class Person
    {
        public string firstname { get; set; }

        public string lastname { get; set; }

        public string dateOfBirth { get; set; }

        public Person(string fn, string ln, string dob)
        {

            firstname = fn;
            lastname = ln;
            dateOfBirth = dob;
        }
    }
}
