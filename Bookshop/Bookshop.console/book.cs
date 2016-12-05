using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.console
{
    class book  // added to project through add > new item
    {           // ACCESS MODIFIERS - PRIVATE, PUBLIC
        private string _title;   //private - Invisible to everyone but you (security door) | public - everyone can see
        public string title
        {
            get { return _title; }    //  RETREIVING THE NAME OF THE TITLE
            set { _title = value; }    //  UPDATING THE NAME OF THE TITLE
        }
        
        
        
        
        
        private string author;
        private string isbn;
        private double price;   // double - decimal point
        private int numberOfPages;
        
    }
}
