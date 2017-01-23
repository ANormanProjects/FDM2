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
        private static readonly ILog logger = LogManager.GetLogger("BudgieUserLogic.cs");

        BudgieUser budgieUser = new BudgieUser();
        BudgieUserRepository budgieUserRepo;
        AccountRepository accountRepo;
        AccountLogic accountLogic;

        //private BudgieUserRepository budgieUserRepository;

        public BudgieUserLogic(BudgieUserRepository BudgieUserRepository, AccountRepository AccountRepository, AccountLogic AccountLogic)
        {
            budgieUserRepo = BudgieUserRepository;
            accountRepo = AccountRepository;
            accountLogic = AccountLogic;
        }

        public BudgieUserLogic(BudgieUserRepository userRepo, AccountRepository accountRepo)
        {
            // TODO: Complete member initialization
            this.budgieUserRepo = userRepo;
            this.accountRepo = accountRepo;
        }

        public BudgieUserLogic(BudgieUserRepository budgieUserRepository)
        {
            // TODO: Complete member initialization
            this.budgieUserRepo = budgieUserRepository;
        }


        public bool CheckForDuplicateEmail(string emailAddress)
        {
            foreach (var info in budgieUserRepo.GetAllBudgieUsers())
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

            budgieUserRepo.addNewBudgieUser(budgieuser);

            Account newAccount = new Account() { accountNumber = budgieuser.lastName + budgieuser.dob, balance = 0, budget = 0, accountOwnerId = budgieuser.id };

            accountRepo.addNewAccount(newAccount);
        }

        public void UpdateUser(BudgieUser budgieuser)
        {
            int idUpdate = 0;

            foreach (BudgieUser bu in budgieUserRepo.GetAllBudgieUsers())
            {
                if (bu.emailAddress == budgieuser.emailAddress)
                {
                    idUpdate = bu.id;
                }
            }

            budgieUserRepo.updateBudgieUser(idUpdate, budgieuser.firstName, budgieuser.lastName, budgieuser.dob);
            accountLogic.updateNewAccount(idUpdate, budgieuser.lastName, budgieuser.dob);
        }

        public void RemoveUser(BudgieUser budgieuser)
        {
            int id = 0;

            foreach (BudgieUser bu in budgieUserRepo.GetAllBudgieUsers())
            {
                if (bu.emailAddress == budgieuser.emailAddress)
                {
                    id = bu.id;
                }
            }
            budgieUserRepo.removeBudgieUser(id);
        }
    }
}
