using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocking.Bookshop
{
    public class StockChecker
    {
        IDatabaseReader _databaseReader;  //SETS MOCKDATABASEREADER AS _databaseReader

        public StockChecker(IDatabaseReader databaseReader) // GIVES IDatabaseReader to stockchecker forever.
            //MOCK DATABASE READER WAS CONSTRUCTED USING ^
        {
            _databaseReader = databaseReader;
        }

        public int NumberInStock(string isbn)
        {

            int stock = _databaseReader.ReadQuantity(isbn); //MOCKDATABASE READER IS AVAILABLE FOR STOCKCHECKER.

            return stock;
        }



            //return 0; // WILL ALWAYS RETURN 0

    }
}
