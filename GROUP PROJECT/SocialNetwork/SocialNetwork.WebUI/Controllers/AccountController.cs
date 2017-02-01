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
        SocialNetworkDataModel socNetDataModel = new SocialNetworkDataModel();

        public AccountController()
        {
           
        }

        UserAccountLogic _userAccountLogic;

        public AccountController(UserAccountLogic userAccountLogic)
        {
            _userAccountLogic = userAccountLogic;
        }

        // GET: Profile
        public ActionResult ProfilePage()
        {
            return View("ProfilePage");
        }

        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if(_userAccountLogic == null)
            {
                _userAccountLogic = new UserAccountLogic(new Repository<User>());
            }

            _userAccountLogic.Register(user);

            return PartialView("_AccountCreated");
        }

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(User _user, string returnUrl)
        {
            // Lets first check if the Model is valid or not
            if (ModelState.IsValid)
            {
                using (socNetDataModel)
                {
                    string username = _user.username;
                    string password = _user.password;


                    bool userValid = socNetDataModel.users.Any(user => user.username == username && user.password == password);

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