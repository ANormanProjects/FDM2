using BudgieDatabaseLayer;
using BudgieLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.Budgie.Controllers
{
    public class BudgieAccountController : Controller
    {
        BudgieDBCFModel budgieDBCFModel = new BudgieDBCFModel();
        public AccountLogic accLogic { get; set; }
        public BudgieUserLogic buLogic { get; set; }
        public BudgieUserRepository userRepo { get; set; }
        public AccountRepository accountRepo { get; set; }

        //REAL
        public BudgieAccountController()
        {
            userRepo = new BudgieUserRepository(budgieDBCFModel);
            accountRepo = new AccountRepository(budgieDBCFModel);
            accLogic = new AccountLogic(accountRepo);
            buLogic = new BudgieUserLogic(userRepo);
        }

        //TDD+MOQ
        public BudgieAccountController(AccountLogic AccLogic, BudgieUserLogic BuLogic)
        {

            accLogic = AccLogic;
            buLogic = BuLogic;
        }

        // GET: BudgieAccount
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View("Index", accLogic.GetAllAccounts());
        }

        public ActionResult Overview()
        {
            string emailAddress = HttpContext.User.Identity.Name;
            int _accountOwnerId = 0;
            Account targetid = null;

            foreach (BudgieUser budgie in buLogic.GetAllBudgieUsers())
            {
                if (emailAddress == budgie.emailAddress)
                {
                    _accountOwnerId = budgie.id;
                }
            }

            foreach (Account account in accLogic.GetAllAccounts())
            {
                if (_accountOwnerId == account.accountOwnerId)
                {
                    targetid = account;
                }
            }
            return View("Overview", targetid);
        }

        [HttpGet]
        public ActionResult Deposit()
        {
            return View("Deposit");
        }

        [HttpPost]
        public ActionResult Deposit(Account account)
        {
            string emailAddress = User.Identity.Name;
            int _accountOwnerId = 0;
            int targetid = 0;
            decimal depositAmount = 0;

            foreach (BudgieUser budgie in buLogic.GetAllBudgieUsers())
            {
                if (emailAddress == budgie.emailAddress)
                {
                    _accountOwnerId = budgie.id;
                }
            }

            foreach (Account accounts in accLogic.GetAllAccounts())
            {
                if (_accountOwnerId == accounts.accountOwnerId)
                {
                    targetid = accounts.id;
                }
            }

            depositAmount = account.balance;
            accLogic.depositMoney(targetid, depositAmount);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_successDeposit");
            }

            return RedirectToAction("Overview");
        }


        [HttpGet]
        public ActionResult Withdraw()
        {
            return View("Withdraw");
        }


        [HttpPost]
        public ActionResult Withdraw(Account account)
        {

            string emailAddress = HttpContext.User.Identity.Name;
            int _accountOwnerId = 0;
            int targetid = 0;
            decimal withdrawAmount = 0;

            foreach (BudgieUser budgie in buLogic.GetAllBudgieUsers())
            {
                if (emailAddress == budgie.emailAddress)
                {
                    _accountOwnerId = budgie.id;
                }
            }

            foreach (Account accounts in accLogic.GetAllAccounts())
            {
                if (_accountOwnerId == accounts.accountOwnerId)
                {
                    targetid = accounts.id;
                }
            }

            withdrawAmount = account.balance;
            if (accLogic.withdrawMoney(targetid, withdrawAmount) == true)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_successWithdraw");
                }
            }
            else
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_failureWithdraw");
                }
            }

            return RedirectToAction("Overview");
        }


        [HttpGet]
        public ActionResult Budget()
        {
            return View("Budget");
        }


        [HttpPost]
        public ActionResult Budget(Account account)     //REPAIR BUDGET CHANGING
        {
            string emailAddress = User.Identity.Name;
            int _accountOwnerId = 0;
            int targetid = 0;
            decimal setBudget = 0;

            foreach (BudgieUser budgie in buLogic.GetAllBudgieUsers())
            {
                if (emailAddress == budgie.emailAddress)
                {
                    _accountOwnerId = budgie.id;
                }
            }

            foreach (Account accounts in accLogic.GetAllAccounts())
            {
                if (_accountOwnerId == accounts.accountOwnerId)
                {
                    targetid = accounts.id;
                }
            }

            setBudget = account.budget;
            accLogic.setBudget(targetid, setBudget);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_successBudget");
            }

            return RedirectToAction("Overview");
        }

        [HttpGet]
        public ActionResult Transfer()
        {
            return View("Transfer");
        }

        [HttpPost]
        public ActionResult Transfer(Account account)
        {
            string emailAddress = User.Identity.Name;
            string targetAccountNumber = account.accountNumber;
            int _accountOwnerId = 0;
            int targetidFrom = 0;
            int idToTransferTo = 0;
            decimal amountToTransfer = 0;

            foreach (BudgieUser budgie in buLogic.GetAllBudgieUsers())
            {
                if (emailAddress == budgie.emailAddress)
                {
                    _accountOwnerId = budgie.id;
                }
            }

            foreach (Account accounts in accLogic.GetAllAccounts())
            {
                if (_accountOwnerId == accounts.accountOwnerId)
                {
                    targetidFrom = accounts.id;
                }
            }

            foreach (Account accounts in accLogic.GetAllAccounts())
            {
                if (targetAccountNumber == accounts.accountNumber)
                {
                    idToTransferTo = accounts.accountOwnerId;
                }
            }

            amountToTransfer = account.balance;

            if (accLogic.transferMoney(targetidFrom, idToTransferTo, amountToTransfer) == true)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_successTransfer");
                }
            }
            else
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_failureTransfer");
                }
            }
            return RedirectToAction("Overview");
        }


    }
}