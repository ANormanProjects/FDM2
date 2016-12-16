using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurtherCollections
{
    public class DvdIdComparer : IComparer<Dvd>
    {

        public int Compare(Dvd dvd1, Dvd dvd2)
        {
            if (dvd1.id < dvd2.id)
            {
                return -1;
            }

           //else if (this.id > otherdvd.id) return 1;      Can be done like this without {} if it will return one thing

            else if (dvd1.id > dvd2.id)
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
