using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillars.Inheritance
{
   public abstract class User
    {
        public string name { get; set; }
        public int id { get; set; }

    }
    public class Buyer : User
    {

    }
    
    public class Seller : User
    {

    }

    public class Admin : User
    {
        public string password { get; set; }

    }
}
