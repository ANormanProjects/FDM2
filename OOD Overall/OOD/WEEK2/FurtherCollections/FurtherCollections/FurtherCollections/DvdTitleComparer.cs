using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurtherCollections
{
    public class DvdTitleComparer : IComparer<Dvd> // Learn AlphabetSorting After christmas
    {
        public int Compare(Dvd dvd1, Dvd dvd2)
        {
            if (dvd1.title != dvd2.title)
            {
                return -1;
            }
            else if (dvd1.title == dvd2.title)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
