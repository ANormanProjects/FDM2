using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;


namespace CurrencyConverterLib
{
    public class XMLREADER
    {
        Dictionary<string, decimal> CurrencyRateDB { get; set; }

        public XMLREADER()
        {
            CurrencyRateDB = new Dictionary<string, decimal>();
        }

        public void GetCurrencyAndRates()
        {
            string path = "C:\\Users\\nana.li\\Desktop\\OOD3\\CurrencyApps\\C#Day13-CurrencyConverterData.xml";
            XDocument doc = XDocument.Load(path);

            XNamespace gesmes = "http://www.gesmes.org/xml/2002-08-01";
            XNamespace ns = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref";

            var cubes = doc.Descendants(ns + "Cubes").Descendants(ns + "Cube").Descendants(ns + "Cube")
                .Where(x => x.Attribute("currency") != null)
                .Select(x => new
                {
                    Currency = (string)x.Attribute("currency"),
                    Rate = (decimal)x.Attribute("rate")
                });

            foreach (var item in cubes)
            {
                CurrencyRateDB.Add(item.Currency, item.Rate);
            }
            return CurrencyRateDB;
        }

    }
}
