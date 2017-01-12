using log4net;
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
        private static readonly ILog logger = LogManager.GetLogger("LocalUI.cs");

        static void Main(string[] args)
        {
            UserInput();

            Console.ReadLine();
        }

        static void UserInput()
        {
            char input = '0';
            Console.Clear();

            while ( input != 'q' )
            {
                StartUpMenu();
                input = Console.ReadKey().KeyChar;

                switch (input)
                {
                    default:
                        System.Console.WriteLine("Invalid Input");
                        continue;

                    case 'q':
                        Environment.Exit(0);
                        continue;

                    case 'l':
                        Console.WriteLine();
                        ListAllUsers();
                        continue;

                    case 'a':
                        Console.WriteLine();
                        AddUser();
                        continue;

                    case 'u':
                        Console.WriteLine();
                        UpdateUser();
                        continue;

                    case 'r':
                        Console.WriteLine();
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
            string firstName, lastName, emailAddress, dob, password, confirmPassword;
            int newAccountId = 0;

            BudgieDBCFModel context = new BudgieDBCFModel();
            NewBudgieUser newUser = new NewBudgieUser(new BudgieUserRepository(new BudgieDBCFModel()));
            BudgieUserRepository bur = new BudgieUserRepository(context);
            AccountRepository ar = new AccountRepository(context);

            Console.WriteLine(); Console.WriteLine("--- Creating a new Budgie User ---"); Console.WriteLine();

            Console.WriteLine("Please enter your email address (e.g. benkentarobowes@gmail.com): ");
            emailAddress = (Console.ReadLine());
            bool isInDatabase = newUser.CheckForDuplicateEmail(emailAddress);

            if (isInDatabase == true)
            {
                Console.WriteLine("This email is already in use, please quit and log into your original account or restart the application and try again.");
            }
            else
            {
                
                Console.WriteLine();

                Console.WriteLine("Please enter your first name (e.g. Ben): ");
                firstName = (Console.ReadLine());

                Console.WriteLine();

                Console.WriteLine("Please enter your last name (e.g. Bowes): ");
                lastName = (Console.ReadLine());

                Console.WriteLine();

                Console.WriteLine("Please enter your date of birth (e.g. DDMMYY (040191)): ");
                dob = (Console.ReadLine());

                Console.WriteLine();

                Console.WriteLine("Please enter your new password: ");
                password = (Console.ReadLine());

                Console.WriteLine();

                Console.WriteLine("Please confirm your new password: ");
                confirmPassword = (Console.ReadLine());

                Console.WriteLine();

                if ( password != confirmPassword )
                {
                    Console.WriteLine("Your passwords do not match, please restart the application and try again.");
                    Console.WriteLine();
                    RestartApplication();
                }
                else
                {
                    //Add
                    BudgieUser newBudgieUser = new BudgieUser() { firstName = firstName, lastName = lastName, emailAddress = emailAddress, dob = dob, password = password };

                    bur.addNewBudgieUser(newBudgieUser);
                    //context.budgieUsers.Add(newBudgieUser);

                    //context.SaveChanges();

                    Console.WriteLine("New BudgieUser has been successfully registered: Name = " + newBudgieUser.firstName + " " + newBudgieUser.lastName);
                    Console.WriteLine();
                    Console.WriteLine("Automatically creating a new bank account...");
                    Console.WriteLine();

                    foreach (BudgieUser budgieUser in context.budgieUsers)
                    {
                        if (emailAddress == budgieUser.emailAddress)
                        {
                            newAccountId = budgieUser.id;
                        }
                    }

                    Account newAccount = new Account() { accountNumber = lastName + dob, balance = 0, budget = 0, accountOwnerId = newAccountId };

                    ar.addNewAccount(newAccount);
                    //context.accounts.Add(newAccount);

                    Console.WriteLine("Your new account has been successfully created: Account Number = " + newAccount.accountNumber);
                    Console.WriteLine();
                    Console.WriteLine("You may log in and start smart budgeting your finances today! Thank you for joining Budgie.");
                }
            }
            RestartApplication();
        }

        static void UpdateUser()
        {
            //Update
            string firstNameUpdate, lastNameUpdate, dobUpdate;
            int id;

            BudgieDBCFModel context = new BudgieDBCFModel();
            NewBudgieUser newUser = new NewBudgieUser(new BudgieUserRepository(new BudgieDBCFModel()));
            BudgieUserRepository bur = new BudgieUserRepository(context);
            AccountRepository ar = new AccountRepository(context);

            Console.WriteLine(); Console.WriteLine("--- Updating an existing Budgie User ---"); Console.WriteLine();

            UpdatedList();

            Console.WriteLine();

            Console.WriteLine("Please enter the id of the Budgie User you wish to update: ");
            id = Convert.ToInt32(Console.ReadLine());

            //BudgieUser budgieUserToUpdate = context.budgieUsers.Find(id);
            //Account accountToUpdate = context.accounts.Where(a => a.accountOwnerId == id).First();

            Console.WriteLine();

            Console.WriteLine("Updating first name (e.g. Ben): ");
            firstNameUpdate = (Console.ReadLine());
            //budgieUserToUpdate.firstName = firstNameUpdate;

            Console.WriteLine();

            Console.WriteLine("Updating last name (e.g. Bowes): ");
            lastNameUpdate = (Console.ReadLine());
            //budgieUserToUpdate.lastName = lastNameUpdate;

            Console.WriteLine();

            Console.WriteLine("Updating date of birth (e.g. DDMMYY (040191)): ");
            dobUpdate = (Console.ReadLine());
            //budgieUserToUpdate.dob = dobUpdate;

            bur.updateBudgieUser(id, firstNameUpdate, lastNameUpdate, dobUpdate);
            ar.updateNewAccount(id, lastNameUpdate, dobUpdate);
            //accountToUpdate.accountNumber = (lastNameUpdate + dobUpdate);

            Console.WriteLine("The following updates have been made: " + firstNameUpdate + " " + lastNameUpdate + " " + dobUpdate + " Account Number: " + (lastNameUpdate + dobUpdate));
            Console.WriteLine();

            Console.WriteLine("Press any key to save changes and continue: ");
            Console.ReadLine();
            context.SaveChanges();
            RestartApplication();
        }

        static void RemoveUser()
        {
            int id;

            BudgieDBCFModel context = new BudgieDBCFModel();
            BudgieUserRepository bur = new BudgieUserRepository(context);
            AccountRepository ar = new AccountRepository(context);

            Console.WriteLine(); Console.WriteLine("--- Removing an existing Budgie User ---"); Console.WriteLine();

            UpdatedList();

            Console.WriteLine();

            Console.WriteLine("Please enter the id of the Budgie User you wish to Remove: ");
            id = Convert.ToInt32(Console.ReadLine());           

            BudgieUser budgieUserToRemove = context.budgieUsers.Find(id);
            Account accountToRemove = context.accounts.Where(a => a.accountOwnerId == id).First();

            Console.WriteLine();

            Console.WriteLine("The Budgie User " + budgieUserToRemove.firstName + " " + budgieUserToRemove.lastName + " " + budgieUserToRemove.emailAddress + " has been successfully removed.");
            bur.removeBudgieUser(id);
            //context.budgieUsers.Remove(budgieUserToRemove);

            Console.WriteLine();

            Console.WriteLine("The Bank Account " + accountToRemove.accountNumber + " has also been successfully removed.");

            //ar.removeAccount(id);     NOT REQUIRED, context.budgieUsers.Remove(budgieUserToRemove); will remove Account as well due to the link between FK and PK (accountOwnerId)
            //context.accounts.Remove(accountToRemove);

            Console.WriteLine();

            Console.WriteLine("Press any key to continue: ");
            Console.ReadLine();
            
            RestartApplication();
        }

        static void UpdatedList()
        {
            BudgieDBCFModel context = new BudgieDBCFModel();

            Console.WriteLine();
            Console.WriteLine("List of all Budgie Users currently registered in the system: ");
            Console.WriteLine("ID | First Name | Last Name | Email Address | Date of Birth");
            Console.WriteLine();
            foreach (BudgieUser budgieUser in context.budgieUsers)
            {
                Console.WriteLine(budgieUser.id + " " + budgieUser.firstName + " " + budgieUser.lastName + " " + budgieUser.emailAddress + " " + budgieUser.dob);
            }
        }

        static void ListAllUsers()
        {
            BudgieDBCFModel context = new BudgieDBCFModel();

            Console.WriteLine();
            Console.WriteLine("List of all Budgie Users currently registered in the system: ");
            Console.WriteLine("ID | First Name | Last Name | Email Address | Date of Birth");
            Console.WriteLine();
            foreach (BudgieUser budgieUser in context.budgieUsers)
            {
                Console.WriteLine(budgieUser.id + " " + budgieUser.firstName + " " + budgieUser.lastName + " " + budgieUser.emailAddress + " " + budgieUser.dob);
            }

            RestartApplication();
        }

        static void RestartApplication()
        {
            Console.WriteLine();
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

        static void LegacyCode()
        {
            //LINQ SQL
            //var query = from b in context.budgieUsers
            //            where b.lastName == "Low"
            //            select b;

            //foreach (var budgie in query)
            //{
            //    Console.WriteLine(budgie.firstName + " " + budgie.lastName + " " + budgie.dob);
            //}

            //Remove
            //foreach (BudgieUser budgieUser in context.budgieUsers)
            //{
            //    if (budgieUser.id == id)
            //    {
            //        accountId = budgieUser.id;
            //        context.budgieUsers.Remove(budgieUser);
            //        Console.WriteLine("The Budgie User " + budgieUser.firstName + " " + budgieUser.lastName+ " " + budgieUser.emailAddress + " has been successfully removed.");
            //    }
            //}

            //foreach (Account account in context.accounts)
            //{
            //    if (account.accountOwnerId == accountId)
            //    {
            //        context.accounts.Remove(account);
            //        Console.WriteLine("The Account " + account.accountNumber + " has also been successfully removed.");
            //    }
            //}
        }    
    }
}
