using log4net;
using BudgieDatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgieLogic
{
    public class AccountLogic
    {
        private static readonly ILog logger = LogManager.GetLogger("AccountLogic.cs");

        Account account = new Account();
        AccountRepository accountRepo;
        List<Account> accountList;

        public AccountLogic(AccountRepository AccountRepository)
        {
            accountRepo = AccountRepository;
            accountList = accountRepo.GetAllAccounts();
        }

        public AccountLogic()
        {

        }

        public void updateNewAccount(int idUpdate, string lastNameUpdate, string dobUpdate)
        {
            int actualUpdateId = 0;

            foreach (Account account in accountList)
            {
                if (account.accountOwnerId == idUpdate)
                {
                    actualUpdateId = account.id;
                }
            }
            accountRepo.updateNewAccount(actualUpdateId, lastNameUpdate, dobUpdate);
        }

        public void removeAccount(int idToRemove)
        {
            int actualRemoveId = 0;

            foreach (Account account in accountList)
            {
                if (account.accountOwnerId == idToRemove)
                {
                    actualRemoveId = account.id;
                }
            }
            accountRepo.removeAccount(actualRemoveId);
        }

        public decimal printBalance(int idToPrintBalance)
        {
            int targetIdToPrintBalance = 0;
            decimal printCurrentBalance = 0;

            foreach (Account account in accountList)
            {
                if (account.accountOwnerId == idToPrintBalance)
                {
                    targetIdToPrintBalance = account.id;
                }
            }
            printCurrentBalance += accountRepo.printBalance(targetIdToPrintBalance);
            return printCurrentBalance;
        }

        public decimal printBudget(int idToPrintBudget)
        {
            int targetIdToPrintBudget = 0;
            decimal printCurrentBudget = 0;

            foreach (Account account in accountList)
            {
                if (account.accountOwnerId == idToPrintBudget)
                {
                    targetIdToPrintBudget = account.id;
                }
            }
            printCurrentBudget = accountRepo.printBudget(targetIdToPrintBudget);
            return printCurrentBudget;
        }

        public bool withdrawMoney(int idToWithdraw, decimal withdrawBalance)
        {
            int targetIdToWithdraw = 0;

            foreach (Account account in accountList)
            {
                if (account.accountOwnerId == idToWithdraw)
                {
                    targetIdToWithdraw = account.id;
                }
            }

            decimal currentBalance = accountRepo.printBalance(targetIdToWithdraw);
            decimal balanceAfterWithdrawal = currentBalance - withdrawBalance;

            if (balanceAfterWithdrawal >= 0)
            {
                accountRepo.withdrawMoney(targetIdToWithdraw, withdrawBalance);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void depositMoney(int idToDeposit, decimal depositAmount)
        {
            int targetIdToDeposit = 0;

            foreach (Account account in accountList)
            {
                if (account.accountOwnerId == idToDeposit)
                {
                    targetIdToDeposit = account.id;
                }
            }
            accountRepo.depositMoney(targetIdToDeposit, depositAmount);
        }

        public bool transferMoney(int idToTransferFrom, int idToTransferTo, decimal amountToTransfer)
        {
            int targetIdToTransferFrom = 0;
            int targetIdToTransferTo = 0;
            decimal _amountToTransfer = 0;

            foreach (Account account in accountList)
            {
                if (account.accountOwnerId == idToTransferFrom)
                {
                    targetIdToTransferFrom = account.id;
                }
            }

            foreach (Account account in accountList)
            {
                if (account.accountOwnerId == idToTransferTo)
                {
                    targetIdToTransferTo = account.id;
                }
            }

            _amountToTransfer = amountToTransfer;
            decimal currentBalance = accountRepo.printBalance(targetIdToTransferFrom);
            decimal balanceAfterTransfer = currentBalance - amountToTransfer;

            if (balanceAfterTransfer >= 0)
            {
                accountRepo.transferMoney(targetIdToTransferFrom, targetIdToTransferTo, _amountToTransfer);
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

            foreach (Account account in accountList)
            {
                if (account.accountOwnerId == idToSetBudget)
                {
                    targetIdToSetBudget = account.id;
                }
            }
            _amountToBudget = amountToBudget;
            accountRepo.setBudget(targetIdToSetBudget, _amountToBudget);
        }
    }


}
