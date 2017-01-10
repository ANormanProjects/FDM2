using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreTDD
{
    public class Catalogue
    {
        public List<Book> books { get; set; }

        public DatabaseReader databaseread { get; set; } //SET BOX of databaseread = databasereader; in method catalogue

        public Catalogue(DatabaseReader databasereader) //TASK 2
        {
            books = new List<Book>();
            databaseread = databasereader; //TASK 2
        }

        public List<Book> GetAllBooks()
    {
        books = new List<Book>();
        return databaseread.ReadDatabase();
        
    }
        

    }
}
