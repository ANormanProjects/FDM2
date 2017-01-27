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
        
        public Catalogue(DatabaseReader databaseread)
        {
            databasereader = databaseread;

        }


        public List<Book> GetAllBooks()
        {
            return databasereader.ReadDatabase();

            //return new List<Book>();

            //return null;  -- to fail the test // TASK 1
        }
    }
}
