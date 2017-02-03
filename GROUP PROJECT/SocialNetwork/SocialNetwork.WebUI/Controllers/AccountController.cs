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


                    //bool userValid = socNetDataModel.users.Any(user => user.username == username && user.password == password);
                    bool userValid = userAccountLogic.Login(username, password);
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
            UserPostViewModel viewModel1 = new UserPostViewModel()
            {
                post = new UserPost()
                {
                    user = new User() { fullName = "Spencer Newton" },
                    title = "My Repository Interface",
                    content = "Hey guys here is my code I hope you like it xoxo Spencer",
                    code = @"/// <summary>
    /// Generic Interface for Implementing a Data Repository
    /// </summary>
    public interface IRepository<T>
    {
        void Save();
        void Insert(T entity);
        void Remove(T entity);
        //void Update(T entity, Func<T, bool> lambdaExpression);
        T First(Func<T, bool> lambdaExpression);
        List<T> Search(Func<T, bool> lambdaExpression);        
        List<T> GetAll();
    }",
                    time = DateTime.Now,
                    language = "C#",
                    likes = 214,
                    comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            content = "This code is great! Can I use it in my own program?",
                            user = new User() { fullName = "Bishan Meghani" }                            
                        }, 
                        new Comment()
                        {
                            content = "This was copied from my program!!!",
                            user = new User() { fullName = "Andrew Norman" }                            
                        }
                    }
                }
            };

            UserPostViewModel viewModel2 = new UserPostViewModel()
            {
                post = new UserPost()
                {
                    user = new User() { fullName = "Marvin Martian" },
                    title = "My Hello Mars App",
                    content = "Hey guys here is my code I hope you like it xoxo Marvin",
                    code = "Console.WriteLine(\"Hello Mars!\"); // Earth Sux LUL",
                    time = DateTime.Now,
                    language = "C#",
                    likes = 76,
                    comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            content = "This Offends Me.",
                            user = new User() { fullName = "Suleman Khan" }                            
                        }, 
                        new Comment()
                        {
                            content = "Earth Rules.",
                            user = new User() { fullName = "Mario Reid" }                            
                        }
                    }
                }
            };

            List<UserPostViewModel> viewModels = new List<UserPostViewModel>()
            {
                viewModel1, viewModel2
            };

            return View("ProfilePage", viewModels);
        }
    }
}