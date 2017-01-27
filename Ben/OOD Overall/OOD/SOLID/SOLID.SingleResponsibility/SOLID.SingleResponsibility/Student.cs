using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SingleResponsibility
{
    public class Student
    {
        // SINGLE RESPONSIBILITY (SRP) - Each Class should be responsible for one thing
        // Encapsulation

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int studentNumber { get; set; }

        public double debt { get; set; }


        // These properties and behaviours remove encapsulation, not relevant to a student

        // Breaks SRP - Class no longer has one responsibility

        //public int studentunionPhoneNumber { get; set; }

        //public DateTime happyHour { get; set; }


        //public void GoToLecture()
        //{

        //}


        //public void SignUpToNewCourse(string courseName)
        //{

        //}
    }
}
