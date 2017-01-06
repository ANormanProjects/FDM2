using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DELEGATES_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            PriceTotaller priceTotaller = new PriceTotaller(); //New Instance/Default Constructor

            FootballerDatabase footballerDB = new FootballerDatabase(); //New Instance/Default Constructor

            Footballer footballer1 = new Footballer("Ben Bowes", "Middlesbrough", 10000.00, false);         //Making footballers
            Footballer footballer2 = new Footballer("Andrew Norman", "Middlesbrough", 1000.00, false);
            Footballer footballer3 = new Footballer("Spencer Newton", "Middlesbrough", 100.00, false);
            Footballer footballer4 = new Footballer("Bishan Meghani", "Middlesbrough", 10.00, true);

            footballerDB.AddFootballer(footballer1);        //Adding to database
            footballerDB.AddFootballer(footballer2);
            footballerDB.AddFootballer(footballer3);
            footballerDB.AddFootballer(footballer4);

            ProcessPlayerDelegate myDelegate =
                new ProcessPlayerDelegate(priceTotaller.AddFootballersPriceToTotal);        //Constructor for the Delegate

            footballerDB.ProcessInjuredPlayers(myDelegate);

            ProcessPlayerDelegate myPrintDelegate =
                new ProcessPlayerDelegate(priceTotaller.Print);

            footballerDB.ProcessInjuredPlayers(myPrintDelegate);

        }
    }
}
