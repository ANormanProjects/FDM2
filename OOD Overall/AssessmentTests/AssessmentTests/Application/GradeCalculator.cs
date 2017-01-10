using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GradeCalculator
    {
        public string getClassification(double mark)
        {
            string distinction = "distinction";
            string merit = "merit";
            string pass = "pass";
            string fail = "fail";

            if(mark >= 90)
            {
                return distinction;
            }
            else if (mark < 90 && mark >= 80)
            {
                return merit;
            }
            else if (mark < 80 && mark >= 75)
            {
                return pass;
            }

            return fail;
        }
        
    }
}
