using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgieDatabaseLayer
{
    public class AccountRepository
    {
        private static readonly ILog logger = LogManager.GetLogger("AccountRepository.cs");

        BudgieDBCFModel _context;

        public AccountRepository(BudgieDBCFModel context)
        {
            _context = context;
        }

        public List<Account> GetAllAccounts()
        {
            return _context.accounts.ToList();
        }
    }
}
