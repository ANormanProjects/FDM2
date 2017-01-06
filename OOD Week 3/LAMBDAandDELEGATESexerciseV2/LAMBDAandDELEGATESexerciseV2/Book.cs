using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMBDAandDELEGATESexerciseV2
{
    public class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public int numOfPages { get; set; }

        public Book(string Title, string Author, int NumOfPages)
        {
            title = Title;
            author = Author;
            numOfPages = NumOfPages;
        }
    }
}
