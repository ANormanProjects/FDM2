using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using CurrencyConverterLibrary;

namespace CurrencyConverterApplication


{
    class CurrencyConsole
    {
        static void Main(string[] args)
        {

            CurrencyRatesXML currencyRatesXML = new CurrencyRatesXML("C:\\Users\\benjamin.bowes\\Desktop\\Currency Converter Project\\C#Day13-CurrencyConverterData.xml");
            CurrencyRatesXMLParser currencyRatesParser = new CurrencyRatesXMLParser();
            var curRates = currencyRatesXML.CurrencyRatesLoader();
            var currencyRates = currencyRatesParser.ParseCurrencyRates(curRates).ToList();
            var currencyConverter = new CurrencyConverter(currencyRates);
            



            Console.WriteLine("Gamma EUR Currency Rate Converter");
            Console.WriteLine("This application will convert your EUR to any other currency of your choice that is available on the list: ");
            Console.WriteLine("USD, JPY, BGN, CZK, DKK, GBP, HUF, PLN, RON, SEK, CHF, NOK, HRK, RUB, TRY, AUD, BRL, CAD, CNY, HKD, IDR, ILS, INR, KRW, MXN, MYR, NZD, PHP, SGD, THB, ZAR");            
            Console.WriteLine("Please enter the amount of EUR currency you would like to convert: ");
            decimal amountToConvert = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Please enter the currency you would like to convert to: ");
            string convertToCurrency = Console.ReadLine();
            Console.WriteLine("Your currency has been converted to: " + convertToCurrency + " " + currencyConverter.Convert(convertToCurrency, amountToConvert));


            



            //var curRates = currencyRatesXML.CurrencyRatesLoader();
            //var currencyRates = currencyRateXMLParser.ParseCurrencyRates(curRates).ToList();
            




            // read currency codes and value from console with another module

            //var eurInUsd = currencyConverter.Convert("eur", "usd", 20);




            //XDocument curRates = XDocument.Load("C:\\Users\\benjamin.bowes\\Desktop\\Currency Converter Project\\C#Day13-CurrencyConverterData.xml");

            //Dictionary<string, double> CurrencyRatesList = new Dictionary<string, double>();
            //CurrencyRatesList = curRates.Descendants("Cubes")
            //    .ToDictionary(d => (string)d.Attribute("currency"));

            ////foreach (XElement element in curRates.Descendants().Where(c => c.HasElements == false))
            ////{
            ////    string rates = 
            ////}
           

            ////List<XElement> cubes = curRates.Elements("Cubes");

            ////foreach (XElement Cubes in cubes)
            ////{
            ////    string currency = Cubes.Attribute("currency").Value;
            ////    string rate = Cubes.Attribute("rate").Value;
            ////}

        }
    }
}
