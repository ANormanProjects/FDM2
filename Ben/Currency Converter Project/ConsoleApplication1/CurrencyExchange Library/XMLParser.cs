using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CurrencyExchange_Library
{
    public class XMLParser
    {
        XmlReader reader = XmlReader.Create(@".\CurrencyRatesData.Xml");
        public Dictionary<string, double> currencyDatabase { get; set; }

        public XMLParser()
        {
            currencyDatabase = new Dictionary<string, double>();
        }

        public void getCurrencyList()
        {
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    if (reader.Name == "Cube")
                    {
                        string currencyName = reader["currency"];
                        if (currencyName == null)
                        {
                            continue;
                        }

                        string currencyRate = reader["rate"];
                        if (currencyRate == null)
                        {
                            continue;
                        }
                        double currencyRateValue;
                        currencyRateValue = Convert.ToDouble(currencyRate);

                        currencyDatabase.Add(currencyName, currencyRateValue);
                    }

                }

            }
        }
    }
}
