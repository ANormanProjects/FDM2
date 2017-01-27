using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillars.Inheritance
{
    public class UserController // give access level
    {
        public bool Login(string username, string password)
        {
            Console.WriteLine("Attempting to log in: " + username);

            return true;
        }
    }

    public class AdminController : UserController
    {
        public void SetPermissions(string username)
        {
            Console.WriteLine("Setting permissions for user: " + username);
        }
    }

    public class SuperAdminController : AdminController
    {
        // Inherits from AdminController
    }
}
