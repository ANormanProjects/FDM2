using log4net;
using BudgieDatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace BudgieLogic
{
    public class BudgieUserLogic
    {
        private static readonly ILog logger = LogManager.GetLogger("NewBudgieUser.cs");

        BudgieUser budgieUser = new BudgieUser();
        BudgieUserRepository budgieUserDB;
        AccountRepository accountDB;
        List<BudgieUser> bulist;
        private BudgieUserRepository budgieUserRepository;

        public BudgieUserLogic(BudgieUserRepository BudgieUserRepository, AccountRepository AccountRepository)
        {
            budgieUserDB = BudgieUserRepository;
            accountDB = AccountRepository;
            bulist = budgieUserDB.GetAllBudgieUsers();
        }

        public BudgieUserLogic(BudgieUserRepository budgieUserRepository)
        {
            // TODO: Complete member initialization
            this.budgieUserRepository = budgieUserRepository;
        }

        public bool CheckForDuplicateEmail(string emailAddress)
        {
            List<BudgieUser> budgieusers = budgieUserDB.GetAllBudgieUsers();

            foreach (var info in budgieusers)
            {
                if (info.emailAddress == emailAddress)
                {
                    return true;
                }
            }
            return false;
        }

        public void RegisterUser(BudgieUser budgieuser)
        {
            int newAccountId = 0;
            budgieuser.roles = "User";

            budgieUserDB.addNewBudgieUser(budgieuser);

            foreach (BudgieUser budgieUser in bulist)
            {
                if (budgieUser.emailAddress == budgieuser.emailAddress)
                {
                    newAccountId = budgieUser.id;
                }
            }

            Account newAccount = new Account() { accountNumber = budgieuser.lastName + budgieuser.dob, balance = 0, budget = 0, accountOwnerId = newAccountId };

            accountDB.addNewAccount(newAccount);
        }

        public void UpdateUser(BudgieUser budgieuser)
        {
            int idUpdate = 0;

            foreach (BudgieUser bu in bulist)
            {
                if (bu.emailAddress == budgieuser.emailAddress)
                {
                    idUpdate = bu.id;
                }
            }

            budgieUserDB.updateBudgieUser(idUpdate, budgieuser.firstName, budgieuser.lastName, budgieuser.dob);
            accountDB.updateNewAccount(idUpdate, budgieuser.lastName, budgieuser.dob);
        }

        public void RemoveUser(BudgieUser budgieuser)
        {
            int id = 0;
            foreach (BudgieUser bu in bulist)
            {
                if (bu.emailAddress == budgieuser.emailAddress)
                {
                    id = bu.id;
                }
            }
            budgieUserDB.removeBudgieUser(id);
        }
    }
}
