using BudgieDatabaseLayer;
using BudgieLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ASP.NET.Budgie.Controllers
{
    public class BudgieUserController : Controller
    {
        BudgieDBCFModel budgieDBCFModel = new BudgieDBCFModel();
        BudgieUserRepository userRepo;
        AccountRepository accountRepo;
        BudgieUserLogic buLogic;

        //REAL LIFE
        public BudgieUserController()
        {
            userRepo = new BudgieUserRepository(budgieDBCFModel);
            accountRepo = new AccountRepository(budgieDBCFModel);
            buLogic = new BudgieUserLogic(userRepo, accountRepo);
        }

        //FOR TESTS
        public BudgieUserController(BudgieUserLogic BuLogic)
        {
            buLogic = BuLogic;
        }

        // GET: BudgieUser
        public ActionResult Index()
        {
            return View("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListOfAllBudgieUsers()
        {
            return View("ListOfAllBudgieUsers", userRepo.GetAllBudgieUsers());
        }

        [HttpGet]
        public virtual ActionResult RegisterUser()
        {
            return View("RegisterUser");
        }

        [HttpPost]
        public virtual ActionResult RegisterUser(BudgieUser budgieuser)
        {
            if (buLogic.CheckForDuplicateEmail(budgieuser.emailAddress) == true)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_failure");
                }
            }
            else
            {
                buLogic.RegisterUser(budgieuser);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_success");
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult UpdateUser()
        {
            return View("UpdateUser");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult UpdateUser(BudgieUser budgieuser)
        {

            if (buLogic.CheckForDuplicateEmail(budgieuser.emailAddress) == false)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_failureUpdate");
                }
            }
            else
            {
                buLogic.UpdateUser(budgieuser);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_successUpdate");
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult RemoveUser()
        {
            return View("RemoveUser");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult RemoveUser(BudgieUser budgieuser)
        {
            if (buLogic.CheckForDuplicateEmail(budgieuser.emailAddress) == false)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_failureRemove");
                }
            }
            else
            {
                buLogic.RemoveUser(budgieuser);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_successRemove");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(BudgieUser budgieuser, string returnUrl)
        {
            // Lets first check if the Model is valid or not
            if (ModelState.IsValid)
            {
                using (budgieDBCFModel)
                {
                    string username = budgieuser.emailAddress;
                    string password = budgieuser.password;


                    bool userValid = budgieDBCFModel.budgieUsers.Any(user => user.emailAddress == username && user.password == password);

                    // User found in the database
                    if (userValid)
                    {

                        FormsAuthentication.SetAuthCookie(username, false);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The email or password provided is incorrect.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

    }
}
