using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterLib
{
    public class CurrencyNameRatesDB
    {
        Dictionary<string, decimal> RatesDB = new Dictionary<string, decimal>();
        public decimal currencyRate { get; set; }
        XMLREADER xmlreader { get; set; }

        public CurrencyNameRatesDB(XMLREADER xmlReader)
        {
            currencyRate = 0;
            xmlreader = xmlReader;
            RatesDB = xmlReader.
        }
    }
}
