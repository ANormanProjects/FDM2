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
    public class CurrencyRatesXML
    {
        private string _url;

        public CurrencyRatesXML(string url)
        {
            _url = url;
        }


        public XDocument CurrencyRatesLoader()
        {
            return XDocument.Load("C:\\Users\\benjamin.bowes\\Desktop\\Currency Converter Project\\C#Day13-CurrencyConverterData.xml");
        }
    }
}
