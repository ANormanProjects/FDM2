using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OpenClosedDependencyInversion
{
    public abstract class Stock
    {
        public int value { get; set; }
    }

    public class Share : Stock
    {
        int share = 10;
    }

    public class Bond : Stock
    {
        int bond = 20;
    }

    //Broken Open/Closed because we modified a finished class. Chance of breaking is very high.
    //Adding new methods and rewriting code is difficult.

    public class ForeignEx : Stock
    {
        int fx = 30;
    }

    public class Gilt : Stock
    {
        int gilt = 40;
    }

    public class Exchange : Stock
    {
        int ex = 50;
    }


}
