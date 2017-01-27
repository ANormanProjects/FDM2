using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillars.Encapsulation
{
    class Student
    {
        // ENCAPSULATION - GROUPING DATA AND BEHAVIOUR TOGETHER
        // GROUPING RELEVANT THINGS ONLY
        public string name { get; set; } // PROP TAB TAB
        public string role { get; set; } // DOING PROP IS THE SAME AS PROPFULL
        public string course { get; set; }
        public string schedule { get; set; }
        public int id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal debt { get; set; }

        // These are not relevant for a student
        // public DateTime TermDates { get; set; } // not part of the student
        // public int StudentUnionPhoneNumber { get; set; } // not important

        // Variables encapsulates pieces of data
        // Methods encapsulates pieces of logic
        // Objects encapsulates variables and methods
        // Projects encapsulates classes/objects
        // Solution encapsulates Projects
        // Applications encapsulates Solutions and Projects

    }
}
