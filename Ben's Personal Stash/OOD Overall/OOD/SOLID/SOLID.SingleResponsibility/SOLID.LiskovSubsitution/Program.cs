using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.LiskovSubsitution
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlFileWriter writer = new XmlFileWriter();
            writer.Write("Hello");

            Console.ReadLine();

        }
    }
}
