using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopv4
{
    public class Checkout
    {
        public double CalculatePrice(Basket myBasket)
        {
            double cost = 0.0;
            double discount = 0.0;

            int booklist = myBasket.GetBooksInBasket().Count;

            for (int i = 0; i < booklist; i++)
			{
			    cost = cost + myBasket.GetBooksInBasket()[i].price;
			}

            discount = discount + booklist / 3;

            if (booklist >= 10)
            {
                discount += 10;
            }

            cost = cost * (1 - discount / 100);

            return cost;
        }

    }
}
