using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillars.Polymorphism
{
    class LoginController
    {
        public virtual void Login(string username) //Call method and pass as string
        {
            Console.WriteLine("Logging in with username: " + username);
        }

        //OVERLOADED with different argument/parameter types
        public virtual void Login(int id) //Call method and pass as int
        {
            Console.WriteLine("Logging in with id: " + id);
        }

        //OVERLOADED with extra arguments/parameters
        public void Login(string email, string password) //Call method and pass as string, string
        {
            Console.WriteLine("Logging in with email: " + email + " and password: " + password);
        }

    }

    class AdminLoginController : LoginController
    {
        public override void Login(string username)
        {
 	        Console.WriteLine("Logging in admin with username: " + username);
        }
    }
}
