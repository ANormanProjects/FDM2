using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApps
{
    public class CurConverterStreamWriter
    {

        public void WriteToFile(decimal result, string ToCurrency)
        {
            StreamWriter Writer = new StreamWriter("C:\\Users\\benjamin.bowes\\Desktop\\CurrencyAppsV2\\ConversionLog.txt", true);

            Writer.WriteLine("Currency Conversion: " + result + " " + ToCurrency + Environment.NewLine);

            Writer.Close();
        }

        

    }
}
