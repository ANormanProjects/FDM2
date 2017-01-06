using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Examples
{
    public class Book
    {
        public string title { get; set; }
        public int numOfPages { get; set; }

        public Book(string Title, int NumOfPages)  //Constructor
        {
            title = Title;
            numOfPages = NumOfPages;
        }
    }
}
