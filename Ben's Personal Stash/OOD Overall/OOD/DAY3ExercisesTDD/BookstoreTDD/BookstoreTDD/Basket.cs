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
            books = new List<Book>();  //CONTAINS ALL THE BOOKS THAT HAVE BEEN ADDED
        }

        public List<Book> GetBooksInBasket() //GETTING VALUE OF THE LIST
        {
            //return null;
            //return books;
            return books; //RETURNS THE VALUE OF THE LIST books (List<Book> = books)
        }

        public void addBook(Book bookToAdd) //Book becomes bookToAdd
        {
            books.Add(bookToAdd); // bookToAdd is Book // books.Add - .Add adds an item to the list.

        }

    }
}
