using SocialNetwork.DataAccess;
using SocialNetwork.Logic;
using SocialNetwork.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WebUI.Controllers
{
    public class SearchController : Controller
    {
        SearchLogic searchLogic;
        Repository<User> userRepo;
        Repository<Post> postRepo;
        List<UserPostViewModel> viewModels;
        List<UserViewModel> userModels;
        UserAccountLogic logic;


        public SearchController()
        {
           postRepo = new Repository<Post>();
           userRepo = new Repository<User>();
           searchLogic = new SearchLogic(postRepo,userRepo);
           viewModels = new List<UserPostViewModel>();
           userModels = new List<UserViewModel>();
           logic = new UserAccountLogic(new Repository<User>());
        }

        // GET: Search
        [HttpGet]
        [Authorize]
        public ActionResult Search()
        {
            return View("Results");
        }

        [HttpPost]
        [Authorize]
        public ActionResult SearchResults(string searchString)
        {
            User user = logic.ViewAccountInfo(User.Identity.Name);          

            try
            {
                if (searchLogic.CheckIfSearchTermInPostDataBase(searchString) == true)
                {
                    List<Post> results = searchLogic.SearchForCode(searchString);
                    foreach (var result in results)
                    {
                        if (result is UserPost) viewModels.Add(new UserPostViewModel() { post = (UserPost)result, user = user });
                    }

                    return View("Results", viewModels);
                }

                if (searchLogic.CheckIfSearchTermInUserDataBase(searchString) == true) 
                {
                    List<User> userResult = searchLogic.SearchForUserByName(searchString);
                    foreach (var result in userResult)
                    {
                        if (result is User) userModels.Add(new UserViewModel() { user = result });
                    }
                    return View("UserResults", userModels);                
                }
            }
            catch (EntityNotFoundException)
            {
                 return View("Error");
            }
            return View("Error");
        }
    }
}