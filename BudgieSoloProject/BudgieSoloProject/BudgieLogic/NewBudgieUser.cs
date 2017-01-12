using log4net;
using BudgieDatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace BudgieLogic
{
    public class NewBudgieUser
    {
        private static readonly ILog logger = LogManager.GetLogger("NewBudgieUser.cs");

        BudgieUser budgieUser = new BudgieUser();
        BudgieUserRepository budgieUserDB;
        List<BudgieUser> database = new List<BudgieUser>();

        public int MyProperty { get; set; }

        public NewBudgieUser(BudgieUserRepository BudgieUserRepository)
        {
            budgieUserDB = BudgieUserRepository;
        }

        public bool CheckForDuplicateEmail(string emailAddress)
        {
            database = budgieUserDB.GetAllBudgieUsers();
            foreach (var info in database)
            {
                if (info.emailAddress == emailAddress)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
