using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountUnsafeQuestion3
{
    public class AccountUnsafe
    {
        List<Posting> postings = new List<Posting>();

        private static object syncLock = new Object();

        // Object to lock balance access
        private readonly object balancelock = new Object();

        // Object to lock posting access
        private readonly object postingLock = new Object();

        public decimal Balance
        {
            get
            {
                lock (balancelock)
                {
                    decimal balance = 0;
                    foreach (var p in this.postings)
                    {
                        balance += p.Amount;
                    }
                    return balance;
                }
            }
        }

        public void Post(decimal amount)
        {
            lock (postingLock)
            {
                postings.Add(new Posting { Amount = amount, CreatedOn = DateTime.Now });
            }
        }
    }


}
