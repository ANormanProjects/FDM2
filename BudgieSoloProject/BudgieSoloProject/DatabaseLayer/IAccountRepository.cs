using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgieDatabaseLayer
{
    public interface IAccountRepository
    {
        List<Account> GetAllAccounts();

        void addNewAccount(Account newAccount);

        void updateNewAccount(int idUpdate, string lastNameUpdate, string dobUpdate);

        void removeAccount(int idToRemove);

        decimal printBalance(int idToPrintBalance);

        decimal printBudget(int idToPrintBudget);

        bool withdrawMoney(int idToWithdraw, decimal withdrawBalance);

        void depositMoney(int idToDeposit, decimal depositBalance);

        bool transferMoney(int idToTransferFrom, int idToTransferTo, decimal amountToTransfer);

        void setBudget(int idToSetBudget, decimal amountToBudget);
    }
}
