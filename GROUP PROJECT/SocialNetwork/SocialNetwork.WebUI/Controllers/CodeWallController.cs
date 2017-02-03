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
            string username = User.Identity.Name;
            Repository<User> userRepo = new Repository<User>();
            User user = userRepo.First(u => u.username == (User.Identity.Name == "" ? "snewton" : User.Identity.Name));
            List<UserPostViewModel> viewModels = CreateViewModelsForUser(user);

            return View("Wall", viewModels);
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




        public List<UserPostViewModel> CreateTestViewModels()
        {
            UserPostViewModel viewModel1 = new UserPostViewModel()
            {
                post = new UserPost()
                {
                    user = new User() { fullName = "Spencer Newton" },
                    title = "My Repository Interface",
                    content = "Hey guys here is my code I hope you like it xoxo Spencer",
                    code = @"   /// <summary>
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

            return viewModels;
        }
    }
}