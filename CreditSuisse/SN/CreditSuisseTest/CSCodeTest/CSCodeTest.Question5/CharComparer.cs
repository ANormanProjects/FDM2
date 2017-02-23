using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeTest.Question5
{
    public class CharComparer : IComparer<char>
    {

        public int Compare(char x, char y)
        {
            if ( x < y )
            {
                return -1;
            }
            else if ( x > y )
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
