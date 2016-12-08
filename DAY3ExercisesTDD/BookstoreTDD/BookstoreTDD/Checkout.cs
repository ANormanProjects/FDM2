using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreTDD
{
    public class Checkout
    {

        public double CalculatePrice(Basket myBasket)
        {
            double cost = 0.0;
            int discount = 0;
            int numOfBooks =  myBasket.GetBooksInBasket().Count;


            for (int i = 0; i < numOfBooks; i++) //.Count is used for List(GetBooksInBasket)
            {
                cost = cost + myBasket.GetBooksInBasket()[i].price;
                
            }
            if (numOfBooks >= 10)
            {
                discount = discount + 10; // THIS ADDS 10% DISCOUNT TO 10BOOKS OR MORE TO THE CURRENT DISCOUNT.
            }
            
            discount = myBasket.GetBooksInBasket().Count / 3; // THIS INCREASES DISCOUNT BY 1% FOR EVERY 3 BOOKS
            cost = cost * (1 - discount / 100.00);

            
            
            //if (numOfBooks >= 3 && numOfBooks < 6)
           // {
           //     cost = cost * 0.99;
            //}
            //if (numOfBooks >= 6 && numOfBooks < 9)
            //{
            //    cost = cost * 0.98;
            //}
           // if (numOfBooks >= 10)
           // //{
            //    cost = cost * 0.90 * 0.97;
            //}

            return cost;

               
        }
    }
}
