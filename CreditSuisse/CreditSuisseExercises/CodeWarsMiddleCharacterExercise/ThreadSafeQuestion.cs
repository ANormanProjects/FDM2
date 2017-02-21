using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisseExercises
{
    class Posting
    {
        private static object createdOnLock = new Object();
        private static object amountLock = new Object();

        private decimal _Amount;

        public decimal Amount
        {
            get 
            {
                lock (amountLock)
                {
                    return _Amount;
                }
            }
            set
            {
                lock (amountLock)
                {
                    _Amount = value;
                }
            }
        }

        private DateTime _CreatedOn;

        public DateTime CreatedOn
        {
            get 
            { 
                lock (createdOnLock)
                { 
                    return _CreatedOn; 
                } 
            }
            set 
            {
                lock (createdOnLock)
                {
                    _CreatedOn = value;
                }
            }
        }

    }

    class AccountUnsafe
    {
        private static object balanceLock = new Object();
        private static object postLock = new Object();

        List<Posting> Postings = new List<Posting>();

        public decimal Balance
        {
            get
            {
                lock (balanceLock)
                {
                    decimal balance = 0;
                    foreach (var p in this.Postings)
                    {
                        balance += p.Amount;
                    }
                    return balance;
                }
            }
        }

        public void Post(decimal amount)
        {
            lock (postLock)
            {
                Postings.Add(new Posting { Amount = amount, CreatedOn = DateTime.Now });
            }
        }
    }

}
