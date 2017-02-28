using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisseTest
{
    public class Singleton
    {
        private Singleton()
        {

        }

        private volatile static Singleton singletonObject;

        public static Singleton InstanceCreation()
        {
            
            return singletonObject;
        }

        public void DisplayMessage()
        {
            Console.WriteLine("My First Singleton Program");
        }



    }
}
