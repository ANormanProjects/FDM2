using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApps
{
    public class CurrencyConverter
    {
       
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Value { get; set; }
        public decimal ConvertedValue { get; set; }


        CurrencyRateDatabaseReader currencyRateDBreader = new CurrencyRateDatabaseReader();


        public CurrencyConverter(string fromCurrency, string toCurrency, decimal value)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            Value = value;
        }


        public decimal ConvertFromCurrencyToCurrency()
        {
            if (FromCurrency == "EUR")
            {
                decimal RATE = currencyRateDBreader.databaseReader(ToCurrency);
                ConvertedValue = Value * RATE;
                return ConvertedValue;
            }
            else
            {
                decimal fromCurrencyRate = currencyRateDBreader.databaseReader(FromCurrency);
                decimal toCurrencyRate = currencyRateDBreader.databaseReader(ToCurrency);
                decimal transferValue = Value / fromCurrencyRate;
                ConvertedValue = transferValue * toCurrencyRate;
                
                return Math.Round(ConvertedValue, 2);
            }

        }

    }
}
