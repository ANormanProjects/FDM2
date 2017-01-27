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
        AccountLogic accountLogic;
        List<BudgieUser> bulist;
        private BudgieUserRepository userRepo;
        private AccountRepository accountRepo;
        private BudgieUserRepository budgieUserRepository;
        //private BudgieUserRepository budgieUserRepository;

        public BudgieUserLogic(BudgieUserRepository BudgieUserRepository, AccountRepository AccountRepository, AccountLogic AccountLogic)
        {
            budgieUserDB = BudgieUserRepository;
            accountDB = AccountRepository;
            accountLogic = AccountLogic;
            bulist = budgieUserDB.GetAllBudgieUsers();
        }

        public BudgieUserLogic(BudgieUserRepository userRepo, AccountRepository accountRepo)
        {
            // TODO: Complete member initialization
            this.userRepo = userRepo;
            this.accountRepo = accountRepo;
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
            budgieuser.roles = "User";

            budgieUserDB.addNewBudgieUser(budgieuser);

            Account newAccount = new Account() { accountNumber = budgieuser.lastName + budgieuser.dob, balance = 0, budget = 0, accountOwnerId = budgieuser.id };

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
            accountLogic.updateNewAccount(idUpdate, budgieuser.lastName, budgieuser.dob);
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
