using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview1
{
    public class Item
    {
        public int id { get; set; }

        public string description { get; set; }

        public double cost { get; set; }

        public Item(int ID, string D, double Cost)
        {
            id = ID;
            description = D;
            cost = Cost;
        }
    }
}
