using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3  // MVC ARCHITECTURE
{
    class Client
    {
        public static void Main(string[] args)
        {
            Person person1 = new Person("John", "Smith", "28 / 06 / 1993");
            Person person2 = new Person("Jane", "Doe", "05 / 01 / 1950");
            Person person3 = new Person("Fred", "Bloggs", "12 / 12 / 1949");

            Person[] people = { person1, person2, person3 }; // used in array loop in pensioncontroller
            PensionController Control = new PensionController(); // creating new operator called control with PensionController
            Control.HandlePensions(people); // extension of Control operator for PensionController
            Console.ReadLine();


        }
    }
}
