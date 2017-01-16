using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NET.Budgie.Models
{

    public class Account
    {
        public int id { get; set; }

        [DisplayName("Account Number")]
        public string accountNumber { get; set; }

        [DisplayName("Current Balance")]
        public decimal balance { get; set; }

        [DisplayName("Budget")]
        public decimal budget { get; set; }

        public virtual int accountOwnerId { get; set; }

        public BudgieUser accountOwner { get; set; }
    }
}