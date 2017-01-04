using CurrencyExchange_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterApplication
{
    public class Program
    {
        static void Main(string[] args)
        {   
            XMLParser parser = new XMLParser();
            parser.getCurrencyList();
            CurrencyRatesDatabase database = new CurrencyRatesDatabase(parser);
            CurrencyRateCalculator calculator;          
            

            Console.WriteLine("Hello, this is our currency exchange rate calculator");
            Console.WriteLine("My name's Andrew, and this guy is Suleman");
            Console.WriteLine("We will convert your Euros into another currency for you");
            Console.WriteLine("How many Euros would you like to convert?");
            double amountToConvert = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("What currency would you like to change it to?");
            string currencyToConvertTo = Console.ReadLine();
            database.calculateExchangeRate(currencyToConvertTo);
            double rate = database.rate;
            calculator = new CurrencyRateCalculator(database, currencyToConvertTo, amountToConvert);
            double answer = calculator.calculateConvertedAmount();
            Console.WriteLine("Your given amount has been converted into- " + answer + " " + currencyToConvertTo);
            Console.ReadLine();
        }
    }
}
