using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class WidgetController
    {
        public void WidgetCalculations()
        {
            View view = new View(); //New instance of View

            double totalprice = 0; // += will be used later to add onto value

            string widgets = view.UserInput(); //Grabbing input value from View Class

            int wids = Convert.ToInt32(widgets);

            if (wids >= 1 && wids <= 12)
            {
                totalprice += wids * 12.39;
                view.OnetoTwelveWids(); //pulling method from view
            }
            if (wids >= 13 && wids <= 50)
            {
                totalprice += wids * 11.99;
                view.Thirteento50Wids();    
            }
            if (wids >= 51)
            {
                totalprice += wids * 11.49;
                view.FiftyOnePlusWids();
            }

            if (wids <= 30) //delivery charge of 3
            {
                totalprice += 3.00;
                view.Delivery30Less(widgets);
            }

            if (wids >= 31) //delivery charge of 5
            {
                totalprice += 5.00;
                view.Delivery31Plus(widgets);
            }

            Console.WriteLine("Total cost of Widgets is: $" + totalprice + ".");
        }
    }
}
