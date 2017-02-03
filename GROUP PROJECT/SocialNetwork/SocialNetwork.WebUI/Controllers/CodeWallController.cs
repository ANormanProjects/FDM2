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
    public class CodeWallController : Controller
    {
        PostLogic _postLogic;

        public CodeWallController() { }

        public CodeWallController(PostLogic postLogic)
        {
            _postLogic = postLogic;
        }

        //GET: CodeWall
        [HttpGet]
        [Authorize]
        public ActionResult Wall()
        {
            List<UserPostViewModel> viewModels;
            User user;
            UserAccountLogic logic = new UserAccountLogic(new Repository<User>());

            try
            {
                user = logic.ViewAccountInfo(User.Identity.Name);
                viewModels = CreateViewModelsForUserFriendsGroups(user);
                return View("Wall", viewModels);
            }
            catch (EntityNotFoundException)
            {
                return View("Wall");
            }       

            
        }

        [HttpPost]
        [Authorize]
        public ActionResult MakePost(UserPostViewModel viewModel)
        {
            return PartialView("_Success");
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


        public List<UserPostViewModel> CreateViewModelsForUserFriendsGroups(User user)
        {
            List<UserPostViewModel> posts = new List<UserPostViewModel>();

            foreach (UserPost p in user.posts)
            {
                posts.Add(new UserPostViewModel() { post = p });
            }

            foreach (User f in user.friends)
            {
                foreach (UserPost p in f.posts)
                {
                    posts.Add(new UserPostViewModel() { post = p });
                }
            }

            return posts;
        }        
    }
}