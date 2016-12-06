using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Person
    {
        private string _firstname;   // PROPFULL WORK

        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        private string _lastname;

        public string lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        private string _dateOfBirth;

        public string dateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public Person (string fn, string ln, string dob)
        {
            _firstname = fn;
            _lastname = ln;
            _dateOfBirth = dob;
        }

        
    }
}
