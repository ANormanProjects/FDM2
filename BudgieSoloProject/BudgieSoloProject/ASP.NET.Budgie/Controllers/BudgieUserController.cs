using BudgieDatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.Budgie.Controllers
{
    public class BudgieUserController : Controller
    {
        BudgieDBCFModel buc = new BudgieDBCFModel();
        BudgieUserRepository budb;
        AccountRepository ardb;

        // GET: BudgieUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListOfAllBudgieUsers()
        {
            budb = new BudgieUserRepository(buc);
            return View(budb.GetAllBudgieUsers());
        }

        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(BudgieUser budgieuser)
        {
            string firstName, lastName, emailAddress, dob;
            int newAccountId = 0;

            firstName = budgieuser.firstName;
            lastName = budgieuser.lastName;
            emailAddress = budgieuser.emailAddress;
            dob = budgieuser.dob;

            bool emailCheck = budb.CheckForDuplicateEmail(emailAddress);

            if (emailCheck == true)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_failure");
                }
            }
            else
            {
                budb.addNewBudgieUser(budgieuser);

                List<BudgieUser> bulist = budb.GetAllBudgieUsers();

                foreach (BudgieUser budgieUser in bulist)
                {
                    if (budgieUser.emailAddress == emailAddress)
                    {
                        newAccountId = budgieUser.id;
                    }
                }

                Account newAccount = new Account() { accountNumber = lastName + dob, balance = 0, budget = 0, accountOwnerId = newAccountId };

                ardb.addNewAccount(newAccount);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_success");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUser(BudgieUser budgieuser)
        {
            string firstNameUpdate, lastNameUpdate, dobUpdate, emailAddress;
            int idUpdate = 0;

            emailAddress = budgieuser.emailAddress;

            bool emailCheck = budb.CheckForDuplicateEmail(emailAddress);

            if (emailCheck == false)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_failureUpdate");
                }
            }
            else
            {
                List<BudgieUser> bulist = budb.GetAllBudgieUsers();

                foreach (BudgieUser bu in bulist)
                {
                    if (bu.emailAddress == emailAddress)
                    {
                        idUpdate = bu.id;
                    }
                }

                firstNameUpdate = budgieuser.firstName;
                lastNameUpdate = budgieuser.lastName;
                dobUpdate = budgieuser.dob;

                budb.updateBudgieUser(idUpdate, firstNameUpdate, lastNameUpdate, dobUpdate);
                ardb.updateNewAccount(idUpdate, lastNameUpdate, dobUpdate);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_successUpdate");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult RemoveUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RemoveUser(BudgieUser budgieuser)
        {
            string emailAddress;
            int id = 0;
            emailAddress = budgieuser.emailAddress;

            bool emailCheck = budb.CheckForDuplicateEmail(emailAddress);

            if (emailCheck == false)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_failureRemove");
                }
            }
            else
            {
                List<BudgieUser> bulist = budb.GetAllBudgieUsers();

                foreach (BudgieUser bu in bulist)
                {
                    if (bu.emailAddress == emailAddress)
                    {
                        id = bu.id;
                    }
                }

                budb.removeBudgieUser(id);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_successUpdate");
                }
            }
            return RedirectToAction("Index");
        }

    }
}
