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

        BudgieDBCFModel context;

        public AccountRepository(BudgieDBCFModel _context)
        {
            context = _context;
        }

        public List<Account> GetAllAccounts()
        {
            return context.accounts.ToList();
        }

        public void addNewAccount(Account newAccount)
        {
            context.accounts.Add(newAccount);
            //flr.addNewAccount(new Account { accountNumber, balance, budget, accountOwnerId })
            context.SaveChanges();
        }

        public void updateNewAccount(int id, string lastNameUpdate, string dobUpdate)
        {
            context.accounts.Find(context.accounts.Where(a => a.accountOwnerId == id).First()).accountNumber = lastNameUpdate + dobUpdate;

            context.SaveChanges();
        }

        public void removeAccount(int id)
        {
            context.accounts.Remove(context.accounts.Where(a => a.accountOwnerId == id).First());

            //Account accountToRemove = context.accounts.Where(a => a.accountOwnerId == id).First();
            //context.accounts.Remove(accountToRemove);
            context.SaveChanges();
        }
    }
}
