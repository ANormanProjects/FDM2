using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Library
{
    public class CurrencyRatesDatabase
    {
        Dictionary<string, double> rateHolder = new Dictionary<string, double>();
        public double rate { get; set; }
        XMLParser parser { get; set; }


        public CurrencyRatesDatabase(XMLParser Parser)
        {
            rate = 0;
            parser = Parser;
            rateHolder = parser.currencyDatabase;
        }


        public void calculateExchangeRate(string currencyName)
        {
            rate = rateHolder[currencyName];
        }
    }
}
