using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Logic
{
    public class BasketAlreadyExistsException : Exception
    {
        public BasketAlreadyExistsException() : base("Basket Already Exists In Database")
        {

        }
    }

    public class BasketDoesNotExistException : Exception
    {
        public BasketDoesNotExistException() : base("Basket Does Not Exist In Database")
        {

        }
    }

    public class ItemDoesNotExistException : Exception
    {
        public ItemDoesNotExistException() : base("Item Does Not Exist In Database")
        {

        }
    }
}
