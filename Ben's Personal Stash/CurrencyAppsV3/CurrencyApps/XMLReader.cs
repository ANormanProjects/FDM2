using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace CurrencyApps
{
    public class XMLReader
    {

        Dictionary<string, decimal> currencyRateDB = new Dictionary<string, decimal>();

        public Dictionary<string,decimal> GetCurrencyAndRates()
        {
            string path = "C:\\Users\\benjamin.bowes\\Desktop\\CurrencyAppsV2\\C#Day13-CurrencyConverterData.xml";
            
            XDocument doc = XDocument.Load(path);

            //XNamespace gesmes = "http://www.gesmes.org/xml/2002-08-01";
            XNamespace ns = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref";

            var cubes = doc.Descendants(ns + "Cube")
                .Where(x => x.Attribute("currency") != null)
                .Select(x => new
                {
                    Currency = (string)x.Attribute("currency"),
                    Rate = (decimal)x.Attribute("rate")
                });

            foreach (var item in cubes)
            {
                if (!currencyRateDB.ContainsKey(item.Currency))
                {
                    currencyRateDB.Add(item.Currency, item.Rate);
                }
                
            }
            return currencyRateDB;
        }
        
    }
}
