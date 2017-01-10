using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.InterfaceSegregation
{
    //public interface Worker //Cannot be instantiated / Abstract // Helping Liskov, Dependency Conversion, and Open/Closed
    //{             
    //    void Work();
    //    void Eat();
    //}                     // Original interface does not follow interface segregation

    public interface Worker
    {
        void Work();
    }

    public interface Eater
    {
        void Eat();
    }

    public class EfficientWorker : Worker, Eater // INTERFACE SEGREGATION (EATER)
    {

        public void Work()
        {
            Console.WriteLine("I work as much as I can");
        }

        public void Eat()
        {
            Console.WriteLine("I only eat when I have to");
        }
    }

    public class LazyWorker : Worker, Eater
    {

        public void Work()
        {
            Console.WriteLine("I only work when I'm being watched");
        }

        public void Eat()
        {
            Console.WriteLine("I eat whenever I feel like it");
        }
    }

    public class RobotWorker : Worker //INTERFACE POLLUTION / ROBOT CLASS DOESNT NEED ALL INTERFACE METHODS (DOESNT EAT AS ITS A ROBOT)
    {

        public void Work()
        {
            Console.WriteLine("I work nonstop");
        }

        //public void Eat() //Interface Pollution
        //{
        //    Console.WriteLine("I don't eat")
        //}

    }
}
