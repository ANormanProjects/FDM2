using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgieDatabaseLayer
{
    public class AccountRepository : IAccountRepository
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

        public void updateNewAccount(int idUpdate, string lastNameUpdate, string dobUpdate)
        {

            List<Account> accounts = GetAllAccounts();
            int actualUpdateId = 0;

            foreach (Account account in accounts)
            {
                if (account.accountOwnerId == idUpdate)
                {
                    actualUpdateId = account.id;
                    break;
                }
            }

            context.accounts.Find(actualUpdateId).accountNumber = (lastNameUpdate + dobUpdate);
            
            //context.accounts.Where(a => a.accountOwnerId == idUpdate).First().accountNumber = (lastNameUpdate + dobUpdate);

            context.SaveChanges();
        }

        public void removeAccount(int idToRemove) //Only use to remove accounts only, Accounts will be deleted automatically if User accounts linked to them are removed.
        {         
            //context.accounts.Remove(context.accounts.Where(a => a.accountOwnerId == idToRemove).First());

            //context.SaveChanges();

            //Account accountToRemove = context.accounts.Where(a => a.accountOwnerId == id).First();
            //context.accounts.Remove(accountToRemove);

            List<Account> accounts = GetAllAccounts();
            int actualRemoveId = 0;

            foreach (Account account in accounts)
            {
                if(account.accountOwnerId == idToRemove)
                {
                    actualRemoveId = account.id;
                    break;
                }                 
            }

            context.accounts.Remove(context.accounts.Find(actualRemoveId));

            context.SaveChanges();
        }
    }
}
