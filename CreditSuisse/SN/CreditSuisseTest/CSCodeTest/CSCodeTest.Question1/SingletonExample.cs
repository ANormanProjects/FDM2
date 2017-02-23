using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeTest.Question1
{
    public sealed class SingletonExample
    {
        /// <summary>
        /// Single instance of class
        /// </summary>
        private static SingletonExample instance;

        /// <summary>
        /// Object to lock portion of code
        /// </summary>
        private static object instanceLock = new Object();

        /// <summary>
        /// Private constructor
        /// </summary>
        private SingletonExample() { }

        /// <summary>
        /// Returns the single instance of this class. If it has not been created, then it will create it.
        /// </summary>
        /// <returns></returns>
        public static SingletonExample Instance()
        {
            lock (instanceLock)
            { 
                if (instance == null)
                {
                    instance = new SingletonExample();
                }
            }

            return instance;
        }
    }
}
