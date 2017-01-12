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

            context.SaveChanges();
        }

        public void updateNewAccount(int id, string lastNameUpdate, string dobUpdate)
        {
            context.accounts.Where(a => a.accountOwnerId == id).First().accountNumber = (lastNameUpdate + dobUpdate);

            context.SaveChanges();
        }

        public void removeAccount(int id) //Only use to remove accounts only, Accounts will be deleted automatically if User accounts linked to them are removed.
        {         
            context.accounts.Remove(context.accounts.Where(a => a.accountOwnerId == id).First());

            context.SaveChanges();

            //Account accountToRemove = context.accounts.Where(a => a.accountOwnerId == id).First();
            //context.accounts.Remove(accountToRemove);
        }
    }
}
