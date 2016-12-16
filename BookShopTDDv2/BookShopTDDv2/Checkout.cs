using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopTDDv2
{
    public class Checkout
    {
       
        public double calculatePrice(Basket myBasket)
        {
            double cost = 0.0;
            int NumOfBooks = myBasket.booklist.Count;
            double discount = 0.0;

            for (int i = 0; i < NumOfBooks; i++)
            {
                cost = cost + myBasket.GetBooksInBasket()[i].price;
            }

            discount = myBasket.booklist.Count / 3;

            for (int i = 1; i <= NumOfBooks; i++)
            {
                if (i % 10 == 0) discount += 10;
            }

            cost = cost * (1 - discount / 100);

            return Math.Round(cost, 2);
        }
    }
}
