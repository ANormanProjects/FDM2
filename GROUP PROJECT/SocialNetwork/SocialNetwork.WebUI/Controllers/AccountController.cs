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

        PostLogic postLogic;
        CommentLogic commentLogic;
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

        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(UserRegisterViewModel viewModel)
        {
            if (_userAccountLogic == null)
            {
                _userAccountLogic = new UserAccountLogic(new Repository<User>());
            }

            if ( viewModel.user.password != viewModel.confirmPassword )
            {
                return PartialView("_PasswordsDoNotMatch");
            }

            if (viewModel.user.fullName == null || viewModel.user.password == null || 
                viewModel.user.username == null || viewModel.user.gender == null)
            {
                return PartialView("_FieldNotFilled");
            }
            else
            {
                bool check = _userAccountLogic.CheckForDuplicates(viewModel.user);

                if (check == true)
                {
                    return PartialView("_UserAlreadyExists");
                }
                else
                {
                    viewModel.user.role = "User";
                    _userAccountLogic.Register(viewModel.user);
                        
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
                    bool userValid = false;

                    try
                    {
                       userValid = _userAccountLogic.Login(username, password);
                    }
                    catch (EmptyInputException)
                    {
                        ModelState.AddModelError("", "The email or password provided is incorrect.");
                    }
                    catch (InputExceedsSpecifiedLimitException)
                    {
                        ModelState.AddModelError("", "The email or password provided is incorrect.");
                    }

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
            return View("Login");
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
            ProfilePageViewModel viewModels = CreateViewModelsForUser(user);

            return View("ProfilePage", viewModels);
        }

        [Authorize]
        public ActionResult ProfilePage(string username)
        {
            Repository<User> userRepo = new Repository<User>();
            User user = userRepo.First(u => u.username == username);
            ProfilePageViewModel viewModels = CreateViewModelsForUser(user);

            return View("ProfilePage", viewModels);
        }

        /// <summary>
        /// Takes user input and sends it to be added to the database
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MakeComment(CommentViewModel viewModel)
        {
            SocialNetworkDataModel context = new SocialNetworkDataModel();
            commentLogic = new CommentLogic(context);
            postLogic = new PostLogic(context);
            userAccountLogic = new UserAccountLogic(context);

            try
            {
                User user = userAccountLogic.ViewAccountInfo(User.Identity.Name);
                Post post = postLogic.GetPost(viewModel.post.postId);
                commentLogic.AddComment(viewModel.comment.content, user, post);
            }
            catch (EntityNotFoundException)
            {
                return PartialView("_EntityNotFound");
            }
            catch (StringNotCorrectLengthException)
            {
                return PartialView("_FieldNotFilled");
            }

            return PartialView("_Success");
        }

        [HttpPost]
        public ActionResult LikePost(UserPostViewModel viewModel)
        {
            SocialNetworkDataModel context = new SocialNetworkDataModel();
            postLogic = new PostLogic(context);

            try
            {
                Post post = postLogic.GetPost(viewModel.post.postId);
                postLogic.LikePost(post);
            }
            catch (EntityNotFoundException)
            {
                return PartialView("_EntityNotFound");
            }

            return PartialView("_Liked");
        }

        public ProfilePageViewModel CreateViewModelsForUser(User user)
        {
            ProfilePageViewModel posts = new ProfilePageViewModel();

            List<UserPost> listposts = new List<UserPost>();

            foreach (UserPost p in user.posts)
            {
                listposts.Add(p);
            }

            posts.userpost = listposts;

            posts.user = user;

            return posts;
        }
    }
}