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
        List<Account> accounts;

        public AccountRepository(BudgieDBCFModel _context)
        {
            context = _context;
            accounts = GetAllAccounts();
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
            int actualUpdateId = 0;

            foreach (Account account in accounts)
            {
                if (account.accountOwnerId == idUpdate)
                {
                    actualUpdateId = account.id;
                }
            }

            context.accounts.Find(actualUpdateId).accountNumber = (lastNameUpdate + dobUpdate);     //context.accounts.Where(a => a.accountOwnerId == idUpdate).First().accountNumber = (lastNameUpdate + dobUpdate);

            context.SaveChanges();
        }

        public void removeAccount(int idToRemove) //Only use to remove accounts only, Accounts will be deleted automatically if User accounts linked to them are removed.
        {         

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

        public decimal printBalance(int idToPrintBalance)
        {
            int targetIdToPrintBalance = 0;
            decimal printCurrentBalance = 0;

            foreach (Account account in accounts)
            {
                if (account.accountOwnerId == idToPrintBalance)
                {
                    targetIdToPrintBalance = account.id;
                    break;
                }
            }

            printCurrentBalance += context.accounts.Find(targetIdToPrintBalance).balance;

            return printCurrentBalance;
        }

        public decimal printBudget(int idToPrintBudget)
        {
            int targetIdToPrintBudget = 0;
            decimal printCurrentBudget = 0;

            foreach (Account account in accounts)
            {
                if (account.accountOwnerId == idToPrintBudget)
                {
                    targetIdToPrintBudget = account.id;
                    break;
                }
            }

            printCurrentBudget += context.accounts.Find(targetIdToPrintBudget).budget;

            return printCurrentBudget;
        }

        public bool withdrawMoney(int idToWithdraw, decimal withdrawBalance)
        {
            int targetIdToWithdraw = 0; 

            foreach (Account account in accounts)
            {
                if (account.accountOwnerId == idToWithdraw)
                {
                    targetIdToWithdraw = account.id;
                    break;
                }
            }
            
            decimal balanceAfterWithdrawal = context.accounts.Find(targetIdToWithdraw).balance - withdrawBalance;
            decimal currentBalance = context.accounts.Find(targetIdToWithdraw).balance;

            if (balanceAfterWithdrawal >= 0)
            {
                context.accounts.Find(targetIdToWithdraw).balance -= withdrawBalance;
                context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public void depositMoney(int idToDeposit, decimal depositBalance)
        {
            int targetIdToDeposit = 0;

            foreach (Account account in accounts)
            {
                if (account.accountOwnerId == idToDeposit)
                {
                    targetIdToDeposit = account.id;
                    break;
                }
            }

            context.accounts.Find(targetIdToDeposit).balance += depositBalance;

            context.SaveChanges();
        }

        public bool transferMoney(int idToTransferFrom, int idToTransferTo, decimal amountToTransfer)
        {
            int targetIdToTransferFrom = 0;
            int targetIdToTransferTo = 0;
            decimal _amountToTransfer = 0;

            foreach (Account account in accounts)
            {
                if (account.accountOwnerId == idToTransferFrom)
                {
                    targetIdToTransferFrom = account.id;
                    break;
                }
            }

            foreach (Account account in accounts)
            {
                if (account.accountOwnerId == idToTransferTo)
                {
                    targetIdToTransferTo = account.id;
                    break;
                }
            }

            _amountToTransfer = amountToTransfer;
            decimal balanceAfterTransfer = context.accounts.Find(targetIdToTransferFrom).balance - amountToTransfer;

            if (balanceAfterTransfer >= 0)
            {
                context.accounts.Find(targetIdToTransferFrom).balance -= _amountToTransfer;
                context.accounts.Find(targetIdToTransferTo).balance += _amountToTransfer;
                context.SaveChanges();

                return true;
            }

            else
            {
                return false;
            }
        }

        public void setBudget(int idToSetBudget, decimal amountToBudget)
        {
            int targetIdToSetBudget = 0;
            decimal _amountToBudget = 0;

            foreach (Account account in accounts)
            {
                if (account.accountOwnerId == idToSetBudget)
                {
                    targetIdToSetBudget = account.id;
                    break;
                }
            }

            _amountToBudget = amountToBudget;

            context.accounts.Find(targetIdToSetBudget).budget += _amountToBudget;

            context.SaveChanges();
        }
    }

    //context.accounts.Remove(context.accounts.Where(a => a.accountOwnerId == idToRemove).First());

    //context.SaveChanges();

    //Account accountToRemove = context.accounts.Where(a => a.accountOwnerId == id).First();
    //context.accounts.Remove(accountToRemove);
}
