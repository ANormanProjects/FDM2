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
        public PostLogic _postLogic;
        public CommentLogic _commentLogic;
        public UserAccountLogic _userLogic;

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

            if ( _userLogic == null ) _userLogic = new UserAccountLogic(new Repository<User>());

            try
            {
                user = _userLogic.ViewAccountInfo(User.Identity.Name);
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
                return PartialView("_EntityNotFound");
            }
            catch (EmptyInputException)
            {
                return PartialView("_FieldNotFilled");
            }


            return PartialView("_Success");
        }

        [HttpPost]
        public ActionResult LikePost(UserPostViewModel viewModel)
        {
            SocialNetworkDataModel context = new SocialNetworkDataModel();
            _postLogic = new PostLogic(context);

            try
            {
                Post post = _postLogic.GetPost(viewModel.post.postId);
                _postLogic.LikePost(post);
            }
            catch (EntityNotFoundException)
            {
                return PartialView("_EntityNotFound");
            }

            return PartialView("_Liked");
            //return RedirectToAction("Wall");
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
            _commentLogic = new CommentLogic(context);
            _postLogic = new PostLogic(context);
            _userLogic = new UserAccountLogic(context);

            try
            {
                User user = _userLogic.ViewAccountInfo(User.Identity.Name);
                Post post = _postLogic.GetPost(viewModel.post.postId);
                _commentLogic.AddComment(viewModel.comment.content, user, post);
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
            //return RedirectToAction("Wall");
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