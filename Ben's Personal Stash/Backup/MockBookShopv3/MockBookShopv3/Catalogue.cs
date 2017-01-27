using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockBookShopv3
{
    public class Catalogue
    {

        public IDatabaseReader dbreader { get; set; }
        DatabaseWriter dbwriter;


        public Catalogue(IDatabaseReader dbread, DatabaseWriter dbwrite)
        {
            dbreader = dbread;
            dbwriter = dbwrite;
        }
            
        public List<Book> GetAllBooks()
        {
            //return null; // Make fail first - task 1
            //return new List<Book>(); // Task1 - Call GetAllBooks method of catalogue and return list of books
            return dbreader.ReadDatabase();
        }

        public void AddBooks(Book addbook)
        {
            dbwriter.WriteDatabase(addbook);
        }
    }




}
