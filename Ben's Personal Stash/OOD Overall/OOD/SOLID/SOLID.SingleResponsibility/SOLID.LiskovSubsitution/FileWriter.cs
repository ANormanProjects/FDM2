using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.LiskovSubsitution
{
    public class FileWriter 
    {
        public virtual void Write(string text) //VIRTUAL CLASSES METHODS CAN BE OVERRIDDEN
        {
            Console.WriteLine("Writing to file...");

        }
    }

    public class XmlFileWriter : FileWriter
    {
        public override void Write(string text)
        {
            //Breaks Liskov
            //Because the method now does something that we don't expect it to do
            
            //Console.WriteLine("Deleting to XML file...");
            Console.WriteLine("Writing to xml...");

        }
        
    }


}
