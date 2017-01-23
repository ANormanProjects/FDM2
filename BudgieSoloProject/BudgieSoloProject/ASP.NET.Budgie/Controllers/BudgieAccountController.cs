using BudgieDatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.Budgie.Controllers
{
    public class BudgieAccountController : Controller
    {
        BudgieDBCFModel buc = new BudgieDBCFModel();
        BudgieUserRepository buRepo;
        AccountRepository accRepo;
        
        // GET: BudgieAccount
        public ActionResult Index()
        {
            accRepo = new AccountRepository(buc);
            return View(accRepo.GetAllAccounts());
        }

        public ActionResult Overview()
        {
            string emailAddress = User.Identity.Name;
            int _accountOwnerId = 0;
            int targetid = 0;

            foreach (BudgieUser budgie in buRepo.GetAllBudgieUsers())
            {
                if (emailAddress == budgie.emailAddress)
                {
                    _accountOwnerId = budgie.id;
                }
            }

            foreach (Account account in accRepo.GetAllAccounts())
            {
                if (_accountOwnerId == account.accountOwnerId)
                {
                    targetid = account.id;
                }
            }

            return View(accRepo.printBalance(targetid));
        }

    }
}