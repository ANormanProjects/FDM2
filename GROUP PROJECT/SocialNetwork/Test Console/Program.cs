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
            Repository<User> userRepo = new Repository<User>(new SocialNetworkDataModel());
            Repository<Group> groupRepo = new Repository<Group>(new SocialNetworkDataModel());
            Repository<Comment> commentRepo = new Repository<Comment>(new SocialNetworkDataModel());
            Repository<Post> postRepo = new Repository<Post>(new SocialNetworkDataModel());

            userRepo.Insert(new User()
            {
                fullName = "Princess Peach"
            });           

            Console.ReadKey();

            userRepo.Save();

            foreach (User user in userRepo.GetAll())
            {
                System.Console.WriteLine(user.fullName);
            }

            List<Group> groups = new List<Group>();

            foreach (Group group in groupRepo.GetAll())
            {
                groups.Add(group);
                System.Console.WriteLine(groupRepo);
            }

            CommentLogic commentLogic = new CommentLogic(postRepo, commentRepo);

            commentLogic.addComment("hello", userRepo.GetAll().ToList()[0], postRepo.GetAll().ToList()[0]);

            Console.ReadLine();

            
        }
    }
}
