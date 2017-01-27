using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Ben", "Bowes", "28 / 06 / 1993");
            Person person2 = new Person("Jane", "Doe", "28 / 06 / 1950");
            Person person3 = new Person("Fred", "Bowes", "28 / 06 / 1930");


            PensionController controller = new PensionController();

            Person[] people = { person1, person2, person3 };

            controller.HandlePensions(people);

            Console.ReadLine();
        }
    }
}
