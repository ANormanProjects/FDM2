﻿using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace BudgieDatabaseLayer
{
    public class BudgieUser
    {
        private static readonly ILog logger = LogManager.GetLogger("BudgieUser.cs");

        public virtual int id { get; set; }

        [DisplayName("First Name")]
        public virtual string firstName { get; set; }

        [DisplayName("Last Name")]
        public virtual string lastName { get; set; }

        [DisplayName("Email Address")]
        public string emailAddress { get; set; }

        [DisplayName("Date of Birth")]
        public virtual string dob { get; set; }

        [DisplayName("Password")]
        public string password { get; set; }
    }
}
