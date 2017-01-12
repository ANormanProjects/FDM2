﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgieDatabaseLayer
{
    public class Account
    {
        private static readonly ILog logger = LogManager.GetLogger("Account.cs");

        public int id { get; set; }

        public string accountNumber { get; set; }

        public decimal balance { get; set; }

        public decimal budget { get; set; }

        public int accountOwnerId { get; set; }

        public BudgieUser accountOwner { get; set; }
    }
}
