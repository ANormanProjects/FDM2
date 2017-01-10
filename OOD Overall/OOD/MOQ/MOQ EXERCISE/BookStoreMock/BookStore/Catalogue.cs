using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class Catalogue
    {
        public DatabaseReader databasereader { get; set; }
        DatabaseWriter databasewriter;

        
        public Catalogue(DatabaseReader databaseread, DatabaseWriter databasewrite)
        {
            databasereader = databaseread;
            databasewriter = databasewrite;

        }


        public List<Book> GetAllBooks()
        {
            return databasereader.ReadDatabase();

            //return new List<Book>();

            //return null;  -- to fail the test // TASK 1
        }

        public void AddBook(Book bookToAdd)
        {
            //databasewriter.WriteDatabase(new Book());
            databasewriter.WriteDatabase(bookToAdd);
        }
    }
}
