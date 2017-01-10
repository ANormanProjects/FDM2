using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillars.Polymorphism //  Admin morphs it into a user
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginController logincontroller = new LoginController();
            logincontroller.Login(123);
            logincontroller.Login("123");
            logincontroller.Login("123@123.com", "123");

            AdminLoginController adminlogincontroller = new AdminLoginController();
            adminlogincontroller.Login("123");

            Console.ReadLine();

        }
    }
}
