using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.CodeFirst
{
    public class Broker
    {
        public int id { get; set; }
        public string name { get; set; }
        public int companyId { get; set; }
        public Company company { get; set; }
    }
}
