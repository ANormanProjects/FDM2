using BudgieDatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgieLogic
{
    public class NewBudgieUser
    {
        BudgieUser budgieUser = new BudgieUser();
        BudgieUserRepository budgieUserDB = new BudgieUserRepository();
        List<BudgieUser> database = new List<BudgieUser>();

        public int MyProperty { get; set; }

        public NewBudgieUser()
        {

        }

        public bool CheckForDuplicateEmail(string emailAddress)
        {
            database = budgieUserDB.GetAllBudgieUsers();
            foreach (var info in database)
            {
                if (emailAddress == info.emailAddress)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
