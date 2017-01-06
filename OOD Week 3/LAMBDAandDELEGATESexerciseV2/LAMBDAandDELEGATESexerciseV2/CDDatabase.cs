using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMBDAandDELEGATESexerciseV2
{
    public class CDDatabase
    {
        public List<CD> cdList = new List<CD>();

        public IEnumerable<CD> SearchByTitle(string searchTitle)
        {
            return cdList.Where(a => a.title == searchTitle);
        }

        public IEnumerable<CD> SearchForMinsMoreThan60()
        {
            return cdList.Where(a => a.mins > 60);
        }

        public IEnumerable<CD> SearchForLessThan10Tracks()
        {
            return cdList.Where(a => a.numOfTracks < 10);
        }

        public IEnumerable<CD> OrderByTitle()
        {
            return cdList.OrderBy(a => a.title);
        }

        public bool CheckIfArtistExists(string searchArtist)
        {
            if (cdList.SingleOrDefault(c => c.artist == searchArtist) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
