using BudgieDatabaseLayer;
using BudgieLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace BudgieEFUI
{
    class LocalUI
    {

        static void Main(string[] args)
        {
            UserInput();

            //LINQ SQL
            //var query = from b in context.budgieUsers
            //            where b.lastName == "Low"
            //            select b;

            //foreach (var budgie in query)
            //{
            //    Console.WriteLine(budgie.firstName + " " + budgie.lastName + " " + budgie.dob);
            //}


            Console.ReadLine();
        }

        static void UserInput()
        {
            char input = '0';
            Console.Clear();

            while (input != 'Q')
            {
                StartUpMenu();
                input = System.Console.ReadKey().KeyChar;

                switch (input)
                {
                    default:
                        System.Console.WriteLine("Invalid Input");
                        continue;

                    case 'Q':
                        continue;

                    case 'M':
                        ListAllUsers();
                        continue;

                    case 'A':
                        AddUser();
                        continue;

                    case 'U':
                        UpdateUser();
                        continue;

                    case 'R':
                        RemoveUser();
                        continue;
                }
            }
        }

        static void StartUpMenu()
        {
            Console.WriteLine("Welcome to Budgie, your best banking application for budgeting your finances.");
            Console.WriteLine();
            Console.WriteLine("Please select the following options continue:");
            System.Console.WriteLine("-----------------------");
            System.Console.WriteLine("A - Create a new Budgie User");
            System.Console.WriteLine("U - Update details of an existing Budgie User");
            System.Console.WriteLine("R - Remove Budgie User");
            System.Console.WriteLine("L - List of all Budgie Users");
            System.Console.WriteLine("Q - Quit");
            System.Console.WriteLine("-----------------------");
        }

        static void AddUser()
        {
            string firstName, lastName, emailAddress;
            int dob;

            BudgieDBCFModel context = new BudgieDBCFModel();
            NewBudgieUser newUser = new NewBudgieUser();

            Console.WriteLine("Please enter your email address (e.g. benkentarobowes@gmail.com): ");
            emailAddress = (Console.ReadLine());
            bool isInDatabase = newUser.CheckForDuplicateEmail(emailAddress);

            while (isInDatabase == true)
            {
                Console.WriteLine("This email is already in use, please log into your original account or create a new account using a different email address: ");
                emailAddress = (Console.ReadLine());
            }

            Console.WriteLine("Please enter your first name (e.g. Ben): ");
            firstName = (Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Please enter your last name (e.g. Bowes): ");
            lastName = (Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Please enter your date of birth (e.g. DDMMYY (040191)): ");
            dob = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine();

            //Add
            BudgieUser newBudgieUser = new BudgieUser() { firstName = firstName, lastName = lastName, emailAddress = emailAddress, dob = dob };
            context.budgieUsers.Add(newBudgieUser);

            context.SaveChanges();
            Console.ReadLine();
            RestartApplication();
        }

        static void UpdateUser()
        {
            //Update
            string firstNameUpdate, lastNameUpdate;
            int dobUpdate, id;

            BudgieDBCFModel context = new BudgieDBCFModel();
            NewBudgieUser newUser = new NewBudgieUser();

            Console.WriteLine("List of all Budgie Users currently registered in the system: ");
            Console.WriteLine("BudgieUser ID | First Name | Last Name | Email Address | Date of Birth");
            foreach (BudgieUser budgieUser in context.budgieUsers)
            {
                Console.WriteLine(budgieUser.id + " " + budgieUser.firstName + " " + budgieUser.lastName + " " + budgieUser.emailAddress + " " + budgieUser.dob);
            }

            Console.WriteLine();

            Console.WriteLine("Please enter the id of the Budgie User you wish to update: ");
            id = Convert.ToInt32(Console.ReadLine());

            BudgieUser budgieUserToUpdate = context.budgieUsers.Find(id);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Updating first name (e.g. Ben): ");
            firstNameUpdate = (Console.ReadLine());
            budgieUserToUpdate.firstName = firstNameUpdate;

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Updating last name (e.g. Bowes): ");
            lastNameUpdate = (Console.ReadLine());
            budgieUserToUpdate.lastName = lastNameUpdate;

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Updating date of birth (e.g. DDMMYY (040191)): ");
            dobUpdate = Convert.ToInt32(Console.ReadLine());
            budgieUserToUpdate.dob = dobUpdate;

            context.SaveChanges();
            Console.ReadLine();
            RestartApplication();
        }

        static void RemoveUser()
        {
            string emailAddress;

            BudgieDBCFModel context = new BudgieDBCFModel();

            Console.WriteLine("Please enter the email address of the account you wish to remove (e.g. benkentarobowes@gmail.com): ");
            emailAddress = (Console.ReadLine());
            
            //Remove
            foreach (BudgieUser budgieUser in context.budgieUsers)
            {
                if (budgieUser.emailAddress == emailAddress)
                {
                    context.budgieUsers.Remove(budgieUser);
                    Console.WriteLine("The Account for " + budgieUser.firstName + " " + budgieUser.lastName+ " " + budgieUser.emailAddress + " has been successfully removed.");
                }
            }
            
            context.SaveChanges();
            Console.ReadLine();
            RestartApplication();
        }

        static void ListAllUsers()
        {
            BudgieDBCFModel context = new BudgieDBCFModel();
            Console.WriteLine("List of all Budgie Users currently registered in the system: ");
            Console.WriteLine("BudgieUser ID | First Name | Last Name | Email Address | Date of Birth");
            foreach (BudgieUser budgieUser in context.budgieUsers)
            {
                Console.WriteLine(budgieUser.id + " " + budgieUser.firstName + " " + budgieUser.lastName + " " + budgieUser.emailAddress + " " + budgieUser.dob);
            }

            Console.ReadLine();
            RestartApplication();
        }

        static void RestartApplication()
        {
            Console.WriteLine("Would you like to continue? (Please enter y (yes) or n (no))");
            ConsoleKeyInfo input = Console.ReadKey();
            Console.WriteLine();

            if (input.KeyChar == 'y')
            {
                UserInput();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        
    }
}
