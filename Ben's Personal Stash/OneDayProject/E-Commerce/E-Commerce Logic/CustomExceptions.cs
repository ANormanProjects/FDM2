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
}
