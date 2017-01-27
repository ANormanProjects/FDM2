using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Library
{
    public class CurrencyRateCalculator
    {
        CurrencyRatesDatabase rates;
        string ConvertedCurrency;
        double AmountOfCurrency;


        public CurrencyRateCalculator(CurrencyRatesDatabase Rates, string currencyToConvertTo, double amountOfMoneyToConvert)
        {
            rates = Rates;
            ConvertedCurrency = currencyToConvertTo;
            AmountOfCurrency = amountOfMoneyToConvert;
            
        }

        public double calculateConvertedAmount()
        {
            rates.calculateExchangeRate(ConvertedCurrency);
            double answer = AmountOfCurrency * rates.rate;
            return answer;
        }

    }
}
