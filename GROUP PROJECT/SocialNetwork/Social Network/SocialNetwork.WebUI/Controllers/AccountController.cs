using SocialNetwork.DataAccess;
using SocialNetwork.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SocialNetwork.WebUI.Controllers
{
    public class AccountController : Controller
    {
        SocialNetworkDataModel dataModel = new SocialNetworkDataModel();

        // GET: Profile
        public ActionResult ProfilePage()
        {
            return View("ProfilePage");
        }

        // GET: Register
        public ActionResult Register()
        {
            return View("Register");
        }

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(User checkUser, string returnUrl)
        {
            Repository<User> userRepository = new Repository<User>(dataModel);
            if (ModelState.IsValid)
            {
                UserAccountLogic al = new UserAccountLogic(userRepository);
                string username = checkUser.username;
                string password = checkUser.password;

                if (al.LoginDetailVerification(checkUser.username, checkUser.password) == true)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        if (Request.IsAjaxRequest())
                        {
                            return PartialView("_successful");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                else
                {
                    
                    return PartialView("_unsuccessful");
                }
            }
            return View(checkUser);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
    }
}