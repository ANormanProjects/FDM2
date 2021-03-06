﻿using BudgieDatabaseLayer;
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

        public BudgieUserController()
        {
            userRepo = new BudgieUserRepository(budgieDBCFModel);
            accountRepo = new AccountRepository(budgieDBCFModel);
            buLogic = new BudgieUserLogic(userRepo, accountRepo);
        }

        // GET: BudgieUser
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListOfAllBudgieUsers()
        {
            return View(userRepo.GetAllBudgieUsers());
        }

        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(BudgieUser budgieuser)
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
            return View();
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
            return View();
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
            return View();
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
