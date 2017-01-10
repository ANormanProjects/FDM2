using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillars.Inheritance // Allows one class to receive all attributes and methods from any class it inherits from.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // BASE CLASS
            UserController usercontroller = new UserController();
            usercontroller.Login("Benjamin Bowes", "password123");

            // INHERITS FROM USERCONTROLLER AND OBTAINS ALL METHODS FROM UC
            AdminController admincontroller = new AdminController();
            admincontroller.Login("Bishan Meghani", "pass123");
            admincontroller.SetPermissions("Bishan Meghani");
            
            // INHERITS FROM ADMINCONTROLLER SO GETS ALL UC METHODS AND AC METHODS
            SuperAdminController superadmincontroller = new SuperAdminController();
            superadmincontroller.Login("Spencer Newton", "hello123");
            superadmincontroller.SetPermissions("Spencer Newton");

            //ADMIN inherits name and id from User
            Admin admin = new Admin();
            admin.id = 123;
            admin.name = "Andrew";
            admin.password = "Normam";

            //BUYER inherits name and id from User
            Buyer buyer = new Buyer();
            buyer.id = 456;
            buyer.name = "Nana";

            MicrosoftDbConnection microdbCon = new MicrosoftDbConnection();
            microdbCon.OpenConnectionToDatabase("Address");

            // Although these are abstract and interfaces we can still construct any object that inherits from
            User user = new Admin();
            DatabaseConnection dbConnection = new OracleDbConnection();

            //DatabaseConnection connection = new DatabaseConnection();
            MicrosoftDbConnection connection = new MicrosoftDbConnection();

            Console.ReadLine();
        }
    }
}
