using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace CurrencyConverterLibrary
{
    public class CurrencyRates
    {
        public CurrencyRates(XElement curRate)
        {
            CurrencyName = curRate.Element("currency").Value;
            CurrencyRate = decimal.Parse(curRate.Element("rate").Value);
        }

        public string CurrencyName { get; set; }

        public decimal CurrencyRate { get; set; }

    }
}
