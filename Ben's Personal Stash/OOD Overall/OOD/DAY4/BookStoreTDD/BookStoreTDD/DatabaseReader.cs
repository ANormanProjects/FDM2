using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreTDD
{
    
    public interface DatabaseReader
    {
       List<Book> ReadDatabase(); // TASK 2 // MOCKING A LIST OF BOOK OBJECTS
    }
}
