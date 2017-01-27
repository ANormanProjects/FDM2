using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApps
{
    public class CurrencyRateDatabaseReader
    {
        XMLReader xmlReader = new XMLReader();
        Dictionary<string, decimal> database = new Dictionary<string, decimal>();

        

        public decimal DatabaseReader(string TargetCurrency)
        {
            database = xmlReader.GetCurrencyAndRates();
            foreach (var item in database)
            {
                if (TargetCurrency == item.Key)
                {
                    return item.Value;
                }
            }
            return 0;
        }

        public bool DatabaseChecker(string Currency)
        {
            database = xmlReader.GetCurrencyAndRates();
            foreach (var item in database)
            {
                if (Currency == item.Key)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
