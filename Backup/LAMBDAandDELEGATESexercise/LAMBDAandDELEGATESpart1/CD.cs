using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMBDAandDELEGATESpart1
{
    public class CD
    {
        public string title { get; set; }
        public string artist { get; set; }
        public double mins { get; set; }
        public int numOfTracks { get; set; }

        public CD(string Title, string Artist, double Mins, int NumOfTracks)
        {
            title = Title;
            artist = Artist;
            mins = Mins;
            numOfTracks = NumOfTracks;
        }
    }
}
