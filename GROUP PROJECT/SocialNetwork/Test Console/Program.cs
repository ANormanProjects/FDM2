using SocialNetwork.DataAccess;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Repository<User> userRepo = new Repository<User>(new SocialNetworkDataModel());

            userRepo.Insert(new User()
            {
                fullName = "Princess Peach"
            });           

            Console.ReadKey();
        }
    }
}
