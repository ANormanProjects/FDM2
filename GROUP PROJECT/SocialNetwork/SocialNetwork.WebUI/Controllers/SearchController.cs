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
        Repository<IUser> userRepo;
        Repository<Post> postRepo;
        List<UserPostViewModel> viewModels;
        List<UserViewModel> userModels;
        UserAccountLogic logic;


        public SearchController()
        {
           postRepo = new Repository<Post>();
           userRepo = new Repository<IUser>();
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
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult SearchResults(string searchString)
        {
            User user = logic.ViewAccountInfo(User.Identity.Name);
           
            try
            {
                List<Post> results = searchLogic.SearchForCode(searchString);
                foreach (var result in results)
                {
                    if (result is UserPost) viewModels.Add(new UserPostViewModel() { post = (UserPost)result });
                }

                return View("Results", viewModels);
            }
            catch (EntityNotFoundException)
            {
                 return View("Error");
            }
        }
    }
}