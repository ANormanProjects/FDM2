using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMBDAandDELEGATESexerciseV2
{
    public class BookCalculator
    {
        public int TotalNumOfPages { get; set; }
        public int NumOfPages { get; set; }

        public void addPagesInBookToCount(Book book)
        {
            TotalNumOfPages += book.numOfPages;
        }

        public void 
    }
}
