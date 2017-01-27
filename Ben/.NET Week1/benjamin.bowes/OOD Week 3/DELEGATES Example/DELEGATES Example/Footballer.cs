using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DELEGATES_Example
{
    public class Footballer
    {
        public string name { get; set; }
        public string team { get; set; }
        public double price { get; set; }
        public bool isInjured { get; set; }

        public Footballer(string Name, string Team, double Price, bool IsInjured)
        {
            name = Name;
            team = Team;
            price = Price;
            isInjured = IsInjured;
        }
    }
}
