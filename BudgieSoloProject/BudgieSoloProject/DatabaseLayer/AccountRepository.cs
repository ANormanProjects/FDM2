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

        public void updateNewAccount(int actualUpdateId, string lastNameUpdate, string dobUpdate)
        {
            context.accounts.Find(actualUpdateId).accountNumber = (lastNameUpdate + dobUpdate);     //context.accounts.Where(a => a.accountOwnerId == idUpdate).First().accountNumber = (lastNameUpdate + dobUpdate);
            context.SaveChanges();
        }

        public void removeAccount(int actualRemoveId) //Only use to remove accounts only, Accounts will be deleted automatically if User accounts linked to them are removed.
        {

            context.accounts.Remove(context.accounts.Find(actualRemoveId));
            context.SaveChanges();
        }

        public decimal printBalance(int targetIdToPrintBalance)
        {
            return context.accounts.Find(targetIdToPrintBalance).balance;
        }

        public decimal printBudget(int targetIdToPrintBudget)
        {
            return context.accounts.Find(targetIdToPrintBudget).budget;
        }

        public void withdrawMoney(int targetIdToWithdraw, decimal withdrawBalance)
        {
            context.accounts.Find(targetIdToWithdraw).balance -= withdrawBalance;
            context.SaveChanges();
        }

        public void depositMoney(int targetIdToDeposit, decimal depositAmount)
        {
            context.accounts.Find(targetIdToDeposit).balance += depositAmount;
            context.SaveChanges();
        }

        public void transferMoney(int targetIdToTransferFrom, int targetIdToTransferTo, decimal amountToTransfer)
        {
                context.accounts.Find(targetIdToTransferFrom).balance -= amountToTransfer;
                context.accounts.Find(targetIdToTransferTo).balance += amountToTransfer;
                context.SaveChanges();
        }

        public void setBudget(int targetIdToSetBudget, decimal amountToBudget)
        {
            context.accounts.Find(targetIdToSetBudget).budget += amountToBudget;
            context.SaveChanges();
        }
    }

    //context.accounts.Remove(context.accounts.Where(a => a.accountOwnerId == idToRemove).First());

    //context.SaveChanges();

    //Account accountToRemove = context.accounts.Where(a => a.accountOwnerId == id).First();
    //context.accounts.Remove(accountToRemove);
}
