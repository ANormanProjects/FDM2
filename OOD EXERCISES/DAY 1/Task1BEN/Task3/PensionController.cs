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
            View newview = new View(); // sets operator newview
            PensionLogic logic = new PensionLogic(); // sets operator logic
            bool truefalse;
            foreach (Person myperson in people) // for loop with people in client
            {
                truefalse = logic.IsPensionable(myperson, "2014"); // uses PensionLogic to calculate eligibility
                if(truefalse == true)
                {
                    newview.PrintEligible(myperson); // use operator newview
                }
                else
                {
                    newview.PrintIneligible(myperson);
                }
            }
        }

    }
}
