using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdasExcercise
{
    public class CdStock
    {
        public List<Cd> cds = new List<Cd>();

        public IEnumerable<Cd> SearchByTitle(string searchTerm)
        {
            return cds.Where(c => c.title == searchTerm);
        }

        public IEnumerable<Cd> SearchForLengthOfMoreThan60()
        {
            return cds.Where(c => c.length > 60);
        }

        public IEnumerable<Cd> SearchForTracksOfLessThan10()
        {
            return cds.Where(c => c.numberOfTracks < 10);
        }

        public IEnumerable<Cd> OrderByTitle()
        {
            return cds.OrderBy(c => c.title);
        }

        public bool CheckIfArtistExists(string searchTerm)
        {
            if (cds.SingleOrDefault(c => c.artist == searchTerm) == null)
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
