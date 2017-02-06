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
        private PostLogic _postLogic;
        private UserAccountLogic _userLogic;

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
            SocialNetworkDataModel context = new SocialNetworkDataModel();
            _postLogic = new PostLogic(context);
            _userLogic = new UserAccountLogic(context);

            try
            {
                User user = _userLogic.ViewAccountInfo(User.Identity.Name);
                _postLogic.WriteUserPost(0, viewModel.post.title, viewModel.post.language, viewModel.post.code, viewModel.post.content, user);
            }
            catch (EntityNotFoundException)
            {
                return PartialView("_FieldNotFilled");
            }


            return PartialView("_Success");
        }

        /// <summary>
        /// Returns a list of posts that the user has made themselves, encapsulated into a view model
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<UserPostViewModel> CreateViewModelsForUser(User user)
        {
            List<UserPostViewModel> posts = new List<UserPostViewModel>();

            foreach (UserPost p in user.posts)
            {
                posts.Add(new UserPostViewModel() { post = p, user = user });
            }

            return posts;
        }

        /// <summary>
        /// Returns a list of posts that the user has made, their friends have made, and that groups they are a part of have made,
        /// encapsulated into a view model
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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