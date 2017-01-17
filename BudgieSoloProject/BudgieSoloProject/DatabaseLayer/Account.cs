using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgieDatabaseLayer
{
    public class Account
    {
        private static readonly ILog logger = LogManager.GetLogger("Account.cs");

        public virtual int id { get; set; }

        [DisplayName("Account Number")]
        public virtual string accountNumber { get; set; }

        [DisplayName("Balance")]
        public virtual decimal balance { get; set; }

        [DisplayName("Budget")]
        public virtual decimal budget { get; set; }

        public virtual int accountOwnerId { get; set; }

        public BudgieUser accountOwner { get; set; }
    }
}
