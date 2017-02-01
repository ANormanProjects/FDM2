using SocialNetwork.DataAccess;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Logic;

namespace Test_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            SocialNetworkDataModel context = new SocialNetworkDataModel();
            Repository<User> userRepo = new Repository<User>(context);
            Repository<Group> groupRepo = new Repository<Group>(context);
            Repository<Comment> commentRepo = new Repository<Comment>(context);
            Repository<Post> postRepo = new Repository<Post>(context);
            UserAccountLogic uAccLogic = new UserAccountLogic(userRepo);                    

            //userRepo.Insert(new User()
            //{
            //    fullName = "Princess Peach"
            //});           

            //Console.ReadKey();

            //userRepo.Save();

            //foreach (User user in userRepo.GetAll())
            //{
            //    System.Console.WriteLine(user.fullName);
            //}

            //List<Group> groups = new List<Group>();

            //foreach (Group group in groupRepo.GetAll())
            //{
            //    groups.Add(group);
            //    System.Console.WriteLine(groupRepo);
            //}

            //CommentLogic commentLogic = new CommentLogic(postRepo, commentRepo);

            //commentLogic.addComment("hello", userRepo.GetAll().ToList()[0], postRepo.GetAll().ToList()[0]);

            //List<Post> posts = postRepo.GetAll();

            ////commentRepo.Insert(new Comment("haha lmao Bishan is a player! rofl lol", userRepo.GetAll()[0], posts[0]));
            //User user = userRepo.First(u => true);
            //Post post = posts[0];
            //Comment test = new Comment("lol", user, post);
            //commentRepo.Insert(test);

            //CommentLogic commentLogic = new CommentLogic(postRepo, commentRepo, userRepo);

            //commentLogic.EditComment(commentRepo.GetAll()[1], "Lololol I'm glad you find that shh amusing");

            //foreach (Comment comment in posts[0].comments)
            //{
            //    System.Console.WriteLine(comment.content);
            //}

            //foreach (Comment comment in commentRepo.GetAll())
            //{
            //    System.Console.WriteLine(comment.content);
            //}


            //Console.ReadLine();

            bool val = uAccLogic.Login("mreid", "password");

            Console.WriteLine(val);

            Console.ReadLine();

        }
    }
}
