using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreTDD
{
    public class Basket
    {
        public List<Book> books { get; set; }

        public Basket() //CONSTRUCTOR
        {
            books = new List<Book>();
        }

        public List<Book> GetBooksInBasket()
        {
            //return null;
            //return books;
            return new List<Book>();
        }
    }
}
