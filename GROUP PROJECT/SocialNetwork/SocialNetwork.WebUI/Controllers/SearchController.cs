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


        public SearchController()
        {
           postRepo = new Repository<Post>();
           userRepo = new Repository<IUser>();
           searchLogic = new SearchLogic(postRepo,userRepo);
            
        }

        // GET: Search
        public ActionResult Search()
        {
            return View();
        }


        public ActionResult SearchResults(string searchString)
        {
            List<UserPostViewModel> viewModels = new List<UserPostViewModel>();
         
            UserAccountLogic logic = new UserAccountLogic(new Repository<User>());
            User user = logic.ViewAccountInfo(User.Identity.Name);
            List<Post> results = searchLogic.SearchForCode(searchString);

          
            foreach (var result in results)
            {
                viewModels.Add(new UserPostViewModel() { post = (UserPost)result });
            }
                     
            return View("Results", viewModels);
        }
       
    }
}