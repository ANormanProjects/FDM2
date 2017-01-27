using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopv4
{
    public class Basket
    {
        public List<Book> booklist { get; set; }

        public Basket()
        {
            booklist = new List<Book>();
        }

        public List<Book> GetBooksInBasket()
        {
            return booklist;
        }

        public void AddBook(Book bookToAdd)
        {
            booklist.Add(bookToAdd);
        }
    }
}
