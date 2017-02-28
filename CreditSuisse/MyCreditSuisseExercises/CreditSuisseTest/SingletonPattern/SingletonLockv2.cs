using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public sealed class SingletonLockv2
    {
        //Single instance of class
        private static SingletonLockv2 instance;


        //Object to lock portion of code
        private static object instanceLock = new Object();


        //Private Constructor
        private SingletonLockv2() { }


        //Returns the single instance of this class. If it has not been created, then it will create it.
        public static SingletonLockv2 Instance()
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new SingletonLockv2();
                }
            }
            return instance;
        }
    }
}
