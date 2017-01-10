using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopTDDv2
{
    public class Basket
    {
        public List<Book> booklist { get; set; }

        public Basket()  //Instance of an object
        {
            booklist = new List<Book>();
        }

        public List<Book> GetBooksInBasket()
        {
            return booklist;
            //return 0;
            //return null;
        }

        public void AddBook(Book bookToAdd)
        {
            booklist.Add(bookToAdd);
        }
    }
}
