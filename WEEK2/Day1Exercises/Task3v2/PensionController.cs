using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3v2
{
    public class PensionController
    {
        public void HandlePensions(Person[] people)
        {
            View view = new View();

            PensionLogic logic = new PensionLogic();

            foreach (Person person in people)
            {
                bool isPensionable = logic.IsPensionable(person, "2016");

                if(isPensionable == true)
                {
                    view.PrintEligible(person);

                }
                else
                {
                    view.PrintIneligible(person);
                }
            }
        }
    }
}
