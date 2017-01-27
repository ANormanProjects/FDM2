using ADODemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDemo.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=TRNLON11661;Initial Catalog=DemoDatabase;Integrated Security=True";

            IAccountRepository _accountRepo = 
                new MicrosoftSqlServerAccountRepository(connectionString);

            //_accountRepo.AddNewAccount(new Accounts() { id = 9, firstName = "Elizabeth", lastName = "Low"});  //make if statement to prevent adding additional accounts
            
            //_accountRepo.UpdateAccount(9, new Accounts() { firstName = "Fadia", lastName = "AlAbbar" });

            //_accountRepo.RemoveAccount(9);

            //List<Accounts> allAccounts = _accountRepo.GetAllAccounts();

            IAccountRepository _accountRepoDisconnected = 
                new AccountRepositoryDisconnected(connectionString);

            //_accountRepoDisconnected.UpdateAccount(8, new Accounts() { firstName = "Bishan", lastName = "Meghani" });

            List<Accounts> allAccounts = _accountRepoDisconnected.GetAllAccounts();


            foreach (Accounts accounts in allAccounts)
            {
                Console.WriteLine(accounts.id + " " + accounts.firstName + " " + accounts.lastName);
            }

            Console.ReadLine();
        }
    }
}
