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

            User suleman = userRepo.First(u => u.username == "skhan");
            User spencer = userRepo.First(u => u.username == "snewton");

            foreach(User u in userRepo.GetAll())
            {
                Console.WriteLine("\n" + u.fullName + " has friends: ");

                foreach (User f in u.friends)
                {
                    Console.WriteLine(f.fullName);
                }
            }

            foreach(Post p in spencer.posts)
            {
                Console.WriteLine(p.title);

                foreach( Comment c in p.comments )
                {
                    Console.WriteLine(c.content);
                }
            }

            Console.ReadLine();            
        }
    }
}
