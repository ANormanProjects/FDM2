using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterLibrary
{
    public class CurrencyConverter
    {
        public IDictionary<string, CurrencyRates> _currencyRates;

        public CurrencyConverter(IList<CurrencyRates> CurrencyRates)
        {
            _currencyRates = CurrencyRates.ToDictionary(x => x.CurrencyName, StringComparer.OrdinalIgnoreCase);

        }

        public decimal Convert(string toCurrency, decimal value)
        {

            var tocurrency = _currencyRates[toCurrency];
            var Conversion = tocurrency.CurrencyRate * value;
            
            return Conversion;

        }
    }
}
