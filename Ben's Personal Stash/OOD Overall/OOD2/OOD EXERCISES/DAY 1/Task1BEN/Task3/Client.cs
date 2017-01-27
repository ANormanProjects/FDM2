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
            Person person1 = new Person("John", "Smith", "28 / 06 / 1993"); // INFORMATION FOR ARRAY
            Person person2 = new Person("Jane", "Doe", "05 / 01 / 1950");
            Person person3 = new Person("Fred", "Bloggs", "12 / 12 / 1930");


            PensionController controller = new PensionController(); // creating new instance of PensionController called controller with PensionController

            Person[] people = { person1, person2, person3 }; // ARRAY called people

            controller.HandlePensions(people); // ARRAY GIVEN to PensionController

            Console.ReadLine();


        }
    }
}
