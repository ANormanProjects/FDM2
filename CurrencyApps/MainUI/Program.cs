using CurrencyApps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainUI
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Gamma EUR Currency Rate Converter");
            Console.WriteLine();

            Console.WriteLine("This application will convert your EUR to any other currency of your choice that is available on the list: ");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("USD, JPY, BGN, CZK, DKK, GBP, HUF, PLN, RON, SEK, CHF, NOK, HRK, RUB, TRY, AUD, BRL, CAD, CNY, HKD, IDR, ILS, INR, KRW, MXN, MYR, NZD, PHP, SGD, THB, ZAR");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Please enter the amount of currency you would like to convert: ");
            decimal amountToConvert = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Please enter the target currency: ");
            string FromCurrency = Console.ReadLine();
            Console.WriteLine("Please enter the currency you would like to convert to: ");
            string ToCurrency = Console.ReadLine();
            CurrencyConverter currencyConverter = new CurrencyConverter(FromCurrency, ToCurrency, amountToConvert); 
            decimal result = currencyConverter.ConvertFromCurrencyToCurrency();
            Console.WriteLine(result);

            Console.ReadLine();
          
        }
    }
}
