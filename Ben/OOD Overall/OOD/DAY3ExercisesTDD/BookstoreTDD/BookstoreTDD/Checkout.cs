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
            double discount = 0;
            int numOfBooks =  myBasket.GetBooksInBasket().Count;
            //double totalprice = 0.0;

            //foreach (Book book in myBasket.books)
            //{
           //     totalprice += book.price;
           // }
            //if (basket.books.Count == 3)
            //{
            // totalprice *= 0.99
            //}
            // double discount = totalprice * 0.01;
            // totalprice -= discount;
            //return Math.Round(totalprice, 2);  // 2 DECIMAL POINTS USING MATH.ROUND


            for (int i = 0; i < numOfBooks; i++) //.Count is used for List(GetBooksInBasket)
            {
                cost = cost + myBasket.GetBooksInBasket()[i].price;
                
            }
            
            discount = numOfBooks / 3; // THIS INCREASES DISCOUNT BY 1% FOR EVERY 3 BOOKS


                if (numOfBooks == 10)
                {
                    discount = discount + 10;
                }


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

            return Math.Round(cost, 2);

               
        }
    }
}
