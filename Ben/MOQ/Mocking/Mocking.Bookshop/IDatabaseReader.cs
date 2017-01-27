using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocking.Bookshop
{
    public interface IDatabaseReader //ADD ACCESS LEVEL PUBLIC
    {
        int ReadQuantity(string isbn); //INTERFACE INHERTIANCE FOR OTHER CLASSES

    }

    public class DatabaseReader : IDatabaseReader   //INHERIT FROM CLASS ABOVE (IDATABASEREADER)
    {
        public int ReadQuantity(string isbn)
        {
            //Write code to connect to the database
            //Return whatever the database gives back
            return 0;
        }
    }
}
