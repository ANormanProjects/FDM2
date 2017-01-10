using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class PensionController
    {
        public void HandlePensions(Person[] people) //used with Control. in client
        {
            View view = new View(); // sets operator newview

            PensionLogic logic = new PensionLogic(); // sets operator logic, creates a new instance of PensionLogic in PensionController

            foreach (Person person in people) // for loop with people in client, Person 'person' = creating new instance of Person in the class for running below.
            {
                bool isPensionable = logic.IsPensionable(person, "2014"); // uses PensionLogic to calculate eligibility

                if(isPensionable == true) // equality ==
                {
                    view.PrintEligible(person); // use operator newview
                }
                else
                {
                    view.PrintIneligible(person);
                }
            }
        }

    }
}
