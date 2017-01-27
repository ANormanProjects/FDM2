using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurtherCollections
{
    public class DvdPriceComparer : IComparer<Dvd>
    {   //Highest to Lowest price (swap 1 and -1 for low)
        public int Compare(Dvd dvd1, Dvd dvd2)
        {
            if (dvd1.price < dvd2.price)
            {
                return 1;
            }

            else if (dvd1.price > dvd2.price)
            {
                return -1;
            }

            else
            {
                return 0;
            }
        }
    }
}
