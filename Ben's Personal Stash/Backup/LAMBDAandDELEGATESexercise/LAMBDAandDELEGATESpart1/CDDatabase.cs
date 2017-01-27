using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMBDAandDELEGATESpart1
{
    public class CDDatabase
    {
        public List<CD> CDlist { get; set; }

        public CDDatabase()
        {
            CDlist = new List<CD>();
        }

        public List<CD> getCDsInList()
        {
            return CDlist;
        }

        public List<CD> SearchByTitle(string Title)
        {
            List<CD> searchByTitle = CDlist.Where<CD>(a => Title == a.title).ToList();
            return searchByTitle;
        }

        public List<CD> longerThanOneHour(double Mins)
        {
            List<CD> longerThan1HR = CDlist.Where<CD>(a => Mins > 60).ToList();
            return longerThan1HR;
        }
        
        //public List<CD> SearchByTitle()
        //{
        //    IEnumerable<CD> searchMatchingTitle = 

        //    return CDlist;
        //}

    }
}
