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

        private string _author;         //propfull  -  auto set code out - change the values after
        public string author
        {
            get { return _author; }
            set { _title = value; }
        }

        private string _isbn;
        public string isbn
        {
            get { return _isbn; }
            set { _isbn = value; }
        }

        private double _price;      // double - decimal point
        public double price
        {
            get { return _price; }
            set { _price = value; }
        }

        private int _numberOfPages;
        public int numberOfPages
        {
            get { return _numberOfPages; }
            set { _numberOfPages = value; }
        }
    }
}
