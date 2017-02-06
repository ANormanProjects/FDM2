using SocialNetwork.DataAccess;
using SocialNetwork.Logic;
using SocialNetwork.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SocialNetwork.WebUI.Controllers
{
    public class AccountController : Controller
    {
        SocialNetworkDataModel socNetDataModel = new SocialNetworkDataModel();

        UserAccountLogic userAccountLogic;
        Repository<User> userRepository;

        public AccountController()
        {
            userRepository = new Repository<User>();
            userAccountLogic = new UserAccountLogic(userRepository);            
        }

        UserAccountLogic _userAccountLogic;

        public AccountController(UserAccountLogic userAccountLogic)
        {
            _userAccountLogic = userAccountLogic;
        }

        //// GET: Profile
        //[Authorize]
        //public ActionResult ProfilePage()
        //{
        //    return View("ProfilePage");
        //}

        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (_userAccountLogic == null)
            {
                _userAccountLogic = new UserAccountLogic(new Repository<User>());
            }
            if (user.fullName == null || user.password == null || user.username == null || user.gender == null)
            {
                return PartialView("_FieldNotFilled");
            }
            else
            {
                bool check = _userAccountLogic.CheckForDuplicates(user);

                if (check == true)
                {
                    return PartialView("_UserAlreadyExists");
                }
                else
                {
                    user.role = "User";
                    _userAccountLogic.Register(user);
                        
                    return PartialView("_AccountCreated");
                }
            }  
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
            if (_userAccountLogic == null)
            {
                _userAccountLogic = new UserAccountLogic(new Repository<User>());
            }

            // Lets first check if the Model is valid or not
            if (ModelState.IsValid)
            {
                using (socNetDataModel)
                {
                    string username = _user.username;
                    string password = _user.password;

                    bool userValid = _userAccountLogic.Login(username, password);
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
                            return RedirectToAction("ProfilePage");
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

        [Authorize]
        public ActionResult ProfilePage()
        {
            string username = User.Identity.Name;
            Repository<User> userRepo = new Repository<User>();
            User user = userRepo.First(u => u.username == (User.Identity.Name == "" ? "snewton" : User.Identity.Name));
            List<UserPostViewModel> viewModels = CreateViewModelsForUser(user);

            return View("ProfilePage", viewModels);
        }

        public List<UserPostViewModel> CreateViewModelsForUser(User user)
        {
            List<UserPostViewModel> posts = new List<UserPostViewModel>();

            foreach (UserPost p in user.posts)
            {
                posts.Add(new UserPostViewModel() { post = p });
            }

            return posts;
        }
    }
}