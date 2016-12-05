using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.console
{
    class Checkout
    {
       public double CalculateTotalPrice(book[] books)
        {   // IF this bracket is illegal semi-colon might be the error
            double totalPrice = 0.0;
          //  for (int i = 0; i < books.Length; i++)
           // {
            //    return books[i].price;
           // }
            foreach (book mybook in books)
            {
                totalPrice += mybook.price;
            }
            
            return totalPrice;
        }
    }
}
