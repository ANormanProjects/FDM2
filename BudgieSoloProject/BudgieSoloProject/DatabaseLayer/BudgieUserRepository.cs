using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgieDatabaseLayer
{
    public class BudgieUserRepository
    {
        private static readonly ILog logger = LogManager.GetLogger("BudgieUserRepository.cs");

        BudgieDBCFModel context;

        List<BudgieUser> database = new List<BudgieUser>();

        public BudgieUserRepository ()
	    {
          
	    }

        public BudgieUserRepository(BudgieDBCFModel _context)
        {
            context = _context;
        }

        public virtual List<BudgieUser> GetAllBudgieUsers()
        {
            return context.budgieUsers.ToList();
        }

        public void addNewBudgieUser(BudgieUser newBudgieUser)
        {
            context.budgieUsers.Add(newBudgieUser);

            context.SaveChanges();
        }

        public void updateBudgieUser(int id, string firstNameUpdate, string lastNameUpdate, string dobUpdate)
        {

            context.budgieUsers.Find(id).firstName = firstNameUpdate;
            context.budgieUsers.Find(id).lastName = lastNameUpdate;
            context.budgieUsers.Find(id).dob = dobUpdate;

            context.SaveChanges();

            //context.budgieUsers.(newBudgieUser);
            //budgieUserToUpdate.firstName = firstNameUpdate;
            //budgieUserToUpdate.lastName = lastNameUpdate;
            //budgieUserToUpdate.dob = dobUpdate;
        }

        public void removeBudgieUser(int id)
        {
            context.budgieUsers.Remove(context.budgieUsers.Find(id));

            context.SaveChanges();
        }
        
    }
}
