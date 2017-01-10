using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.InterfaceSegregation
{
    class Program
    {
        static void Main(string[] args)
        {
            LazyWorker worker1 = new LazyWorker();                  // DEPENDECY INVERSION CONTROLLER
            EfficientWorker worker2 = new EfficientWorker();
            RobotWorker worker3 = new RobotWorker();

            Console.WriteLine("I am a lazy worker");
            worker1.Eat();
            worker1.Work();
            Console.WriteLine();
            Console.WriteLine("I am an efficient worker");
            worker2.Eat();
            worker2.Work();
            Console.WriteLine();
            Console.WriteLine("I am a Robot");
            worker3.Work(); // ONLY INHERITS EAT

            Console.ReadKey();


        }
    }
}
