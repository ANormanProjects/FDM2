using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DELEGATES_Example
{
    public class PriceTotaller
    {
        double totalPrice = 0;
        int numOfPlayers = 0;
        double average = 0;

        public void AddFootballersPriceToTotal(Footballer footballer) //Performs what the delegate wants (returns void and uses footballer)
        {
            totalPrice += footballer.price;
        }

        public void AveragePrice(Footballer footballer)
        {
            numOfPlayers++;
            totalPrice += footballer.price;

            average = totalPrice / numOfPlayers;
        }

        public void Print(Footballer footballer)
        {
            Console.WriteLine(footballer.name);
        }


    }
}
