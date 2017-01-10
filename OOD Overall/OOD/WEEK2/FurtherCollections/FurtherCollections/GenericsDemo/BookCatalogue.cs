using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    public class BookCatalogue
    {

        //BAD APPROACH

        List<Book> books = new List<Book>(); //New LIST Object

        public List<Book> GetAllBooks() //GETS ALL BOOKS IN THE LIST
        {
            return books;
        }

        public void AddBook(Book bookToAdd) //ADD BOOK TO LIST      //VOID - RETURN, USE VOID IF METHOD RETURNS NO VALUE, AND DONT USE VOID IF METHOD WILL  USE 'RETURN'
        {
            books.Add(bookToAdd);
        }
    }
}
