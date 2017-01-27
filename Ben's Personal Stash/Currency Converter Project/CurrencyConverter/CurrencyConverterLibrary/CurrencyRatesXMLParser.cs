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
    public class CurrencyRatesXMLParser
    {
        public IEnumerable<CurrencyRates> ParseCurrencyRates(XDocument curRates)
        {
            return curRates.Root.Elements("Cube").Select(c => new CurrencyRates(c));
        }
    }
}
