using SocialNetwork.DataAccess;
using SocialNetwork.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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

            return View("Index", viewModels);
        }
    }
}