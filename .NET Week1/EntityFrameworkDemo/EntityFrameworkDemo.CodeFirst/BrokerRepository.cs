using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.CodeFirst
{
    public class BrokerRepository
    {
        CodeFirstModel _context;

        public BrokerRepository(CodeFirstModel context)
        {
            _context = context;
        }
        public virtual List<Broker> GetAllBrokers()
        {
            return _context.brokers.ToList();
        }
    }
}
