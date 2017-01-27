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
            CurrencyConverterApp();
        }


        public static void RestartApplication()
        {
            Console.WriteLine("Would you like to continue using the Gamma Converter? (Please enter y (yes) or n (no))");
            ConsoleKeyInfo input = Console.ReadKey();
            Console.WriteLine();

            if (input.KeyChar == 'y')
            {
                CurrencyConverterApp();
            }
            else
            {
                Environment.Exit(0);
            }
        }


        public static void CurrencyConverterApp()
        {
            string FromCurrency, ToCurrency;
            decimal amountToConvert;
            CurConverterStreamWriter writer = new CurConverterStreamWriter();
            CurrencyRateDatabaseReader database = new CurrencyRateDatabaseReader();

            Console.Clear();

            StartUpMenu();

            ApplicationMenu();

            //ORIGINAL CURRENCY
            Console.WriteLine("Please enter the original currency: ");
            FromCurrency = (Console.ReadLine()).ToUpper();
            bool isInDatabase = database.DatabaseChecker(FromCurrency);

            while (isInDatabase == false)
            {
                Console.WriteLine("Incorrect currency, please enter another currency: ");
                FromCurrency = (Console.ReadLine()).ToUpper();
            }

            


            Console.WriteLine();
            Console.WriteLine();

            //TARGET CURRENCY
            Console.WriteLine("Please enter the target currency you would like to convert to: ");
            ToCurrency = (Console.ReadLine()).ToUpper();

            Console.WriteLine();
            Console.WriteLine();

            //AMOUNT OF CURRENCY
            Console.WriteLine("Please enter the amount of the original currency you would like to convert: ");
            amountToConvert = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine();

            //CURRENCY CONVERSION
            CurrencyConverter currencyConverter = new CurrencyConverter(FromCurrency, ToCurrency, amountToConvert);

            decimal result = currencyConverter.ConvertFromCurrencyToCurrency();

            //CURRENCY RESULTS
            Console.WriteLine("Currency Conversion: " + result + " " + ToCurrency);
            Console.WriteLine();
            writer.WriteToFile(result, ToCurrency);
            Console.WriteLine("Conversion has been saved to C:\\Users\\benjamin.bowes\\Desktop\\CurrencyAppsV2\\ConversionLog.txt");

            Console.WriteLine();
            Console.WriteLine();

            RestartApplication();

            Console.ReadLine();
        }


        static void StartUpMenu()
        {
            Console.WriteLine("<= GAMMA CURRENCY RATE CONVERTER APPLICATION =>");
            Console.WriteLine();
            Console.WriteLine("Welcome to the GAMMA Currency Rate Converter.");
            Console.WriteLine();
            Console.WriteLine("Please press any key to continue my master.");
            Console.ReadLine();
            Console.WriteLine();
        }


        static void ApplicationMenu()
        {
            Console.WriteLine("This application will convert your current currency to any other currency of your choice that is available on the list: ");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("EUR, USD, JPY, BGN, CZK, DKK, GBP, HUF, PLN, RON, SEK, CHF, NOK, HRK, RUB, TRY, AUD, BRL, CAD, CNY, HKD, IDR, ILS, INR, KRW, MXN, MYR, NZD, PHP, SGD, THB, ZAR");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}
