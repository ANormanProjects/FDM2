﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace BudgieDatabaseLayer
{
    public class BudgieUser
    {
        private static readonly ILog logger = LogManager.GetLogger("BudgieUser.cs");

        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string emailAddress { get; set; }

        public string dob { get; set; }
    }
}
