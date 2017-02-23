using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeTest.Question3
{
    public class AccountUnsafe
    {
        List<Posting> Postings = new List<Posting>();

        /// <summary>
        /// Object to lock balance access
        /// </summary>
        private readonly object balanceLock = new Object();

        /// <summary>
        /// Object to lock postings access
        /// </summary>
        private readonly object postingLock = new Object();

        /// <summary>
        /// Returns sum of posting amounts in this account
        /// </summary>
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

        /// <summary>
        /// Add new posting to account
        /// </summary>
        /// <param name="amount"></param>
        public void Post(decimal amount)
        {
            lock (postingLock)
            {
                Postings.Add(new Posting { Amount = amount, CreatedOn = DateTime.Now });
            }
        }

    }
}
