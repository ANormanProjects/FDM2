using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisseExercises
{
    public sealed class SingletonImplementationQuestion
    {

        private static SingletonImplementationQuestion singleton;
        private static object threadSafeLock = new object();

        private SingletonImplementationQuestion()
        {

        }

        public static SingletonImplementationQuestion Singleton
        {
            get
            {
                lock (threadSafeLock)
                {
                    if (singleton == null)
                    {
                        singleton = new SingletonImplementationQuestion();
                    }
                    return singleton;
                }
            }
        }
    }
}
