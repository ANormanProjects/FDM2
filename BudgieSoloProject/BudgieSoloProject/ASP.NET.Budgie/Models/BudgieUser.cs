using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NET.Budgie.Models
{    
    public class BudgieUser
    {
        public int id { get; set; }

        [DisplayName("First Name")]
        public string firstName { get; set; }

        [DisplayName("Last Name")]
        public string lastName { get; set; }

        [DisplayName("Email Address")]
        public string emailAddress { get; set; }

        [DisplayName("Date of Birth")]
        public string dob { get; set; }

        public string password { get; set; }
    }
}