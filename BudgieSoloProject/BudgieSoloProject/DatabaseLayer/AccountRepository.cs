using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgieDatabaseLayer
{
    public class AccountRepository
    {
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
