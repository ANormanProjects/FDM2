using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockBookShopv3
{
    public class Catalogue 
    {
        public IDatabaseReader dbreader;
        public IDatabaseWriter dbwriter;
        public Catalogue(IDatabaseReader dbread, IDatabaseWriter dbwrite)
        {
            dbreader = dbread;
            dbwriter = dbwrite;
        }

        public List<Book> GetAllBooks()
        {
            return dbreader.ReadDatabase();
        }

        public void AddBook(Book bookToAdd)
        {
            dbwriter.WriteDatabase(bookToAdd);
        }
    }
}
