using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApps
{
    public class CurrencyConverter
    {
       
        public string fromCurrency { get; set; }
        public string toCurrency { get; set; }
        public decimal value { get; set; }
        public decimal convertedValue { get; set; }


        CurrencyRateDatabaseReader currencyRateDBreader = new CurrencyRateDatabaseReader();


        public CurrencyConverter(string FromCurrency, string ToCurrency, decimal Value)
        {
            fromCurrency = FromCurrency;
            toCurrency = ToCurrency;
            value = Value;
        }


        public decimal ConvertFromCurrencyToCurrency()
        {
                     
            if (fromCurrency == toCurrency)
            {
                return value;
            }

            if (fromCurrency == "EUR")
            {
                decimal rate = currencyRateDBreader.DatabaseReader(toCurrency);
                convertedValue = value * rate;
                return convertedValue;
            }
            else
            {
                decimal fromCurrencyRate = currencyRateDBreader.DatabaseReader(fromCurrency);
                decimal toCurrencyRate = currencyRateDBreader.DatabaseReader(toCurrency);
                decimal transferValue = value / fromCurrencyRate;
                convertedValue = transferValue * toCurrencyRate;
                
                return Math.Round(convertedValue, 2);
            }

        }

    }
}
