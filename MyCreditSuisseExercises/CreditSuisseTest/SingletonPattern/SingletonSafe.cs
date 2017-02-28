using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public sealed class SingletonSafe
    {
        private static readonly SingletonSafe instance = new SingletonSafe();

        private SingletonSafe()
        {

        }

        public static SingletonSafe Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
