using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Console
{
    class Checkout
    {
        public double CalculateTotalPrice(Book[] books)
        {
            double totalPrice = 0.0;

            // ---- FOR LOOP ----
            //for (int i = 0; i < books.Length; i++)
            //{
            //    totalPrice += books[i].price;
            //}

            // ---- FOREACH LOOP ----
            foreach (Book myBook in books)
            {
                totalPrice += myBook.price;
            }

            return totalPrice;
        }
    }
}
