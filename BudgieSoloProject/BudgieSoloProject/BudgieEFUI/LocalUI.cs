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
        }

        static void UpdateUser()
        {
            //Update
            //Broker brokerToUpdate = context.brokers.Find(1);
            //brokerToUpdate.name = "Ben";
        }

        static void RemoveUser()
        {

            //Remove
            //foreach (Broker broker in context.brokers)
            //{
            //    if (broker.id == 3)
            //    {
            //        context.brokers.Remove(broker);
            //    }
            //}
        }

        static void ListAllUsers()
        {
            BudgieDBCFModel context = new BudgieDBCFModel();

            Console.WriteLine("BudgieUser ID | First Name | Last Name | Email Address | Date of Birth");
            foreach (BudgieUser budgieUser in context.budgieUsers)
            {
                Console.WriteLine(budgieUser.id + " " + budgieUser.firstName + " " + budgieUser.lastName + " " + budgieUser.emailAddress + " " + budgieUser.dob);
            }

            Console.ReadLine();
        }

        
    }
}
