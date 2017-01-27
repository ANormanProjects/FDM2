using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddBookshop
{
    public class Book // ENSURE ITS PUBLIC
    {
        public string title { get; set; } // RUN TEST and SHOULD PASS, BUT ITS IMPORTANT TO WATCH IT FAIL FIRST. REALLY IMPORTANT TO KNOW FAILURE FIRST
        // GO BACK TO Catalogue.cs and change end to (return new List<Books>();) TO ENSURE IT FAILS and change back to get indication we made test properly.
        
        public string isbn { get; set; }
    }
}                   // NO NEED TO REFACTOR, NO REPEATED CODE AND SIMPLE, BUT WE WILL REFACTOR 'name' to 'title'

                    // 'name' was REFACTOR > RENAME to change all links to title (ALWAYS DO THIS INSTEAD OF RENAMING)
