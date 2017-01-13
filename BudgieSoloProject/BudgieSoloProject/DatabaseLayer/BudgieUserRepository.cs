using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgieDatabaseLayer
{
    public class BudgieUserRepository : IBudgieUserRepository
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

        public List<BudgieUser> GetAllBudgieUsers()
        {
            return context.budgieUsers.ToList();
        }

        public void addNewBudgieUser(BudgieUser newBudgieUser)
        {
            context.budgieUsers.Add(newBudgieUser);

            context.SaveChanges();
        }

        public void updateBudgieUser(int idUpdate, string firstNameUpdate, string lastNameUpdate, string dobUpdate)
        {

            context.budgieUsers.Find(idUpdate).firstName = firstNameUpdate;
            context.budgieUsers.Find(idUpdate).lastName = lastNameUpdate;
            context.budgieUsers.Find(idUpdate).dob = dobUpdate;

            context.SaveChanges();

            //context.budgieUsers.(newBudgieUser);
            //budgieUserToUpdate.firstName = firstNameUpdate;
            //budgieUserToUpdate.lastName = lastNameUpdate;
            //budgieUserToUpdate.dob = dobUpdate;
        }

        public void removeBudgieUser(int idToRemove)
        {
            context.budgieUsers.Remove(context.budgieUsers.Find(idToRemove));

            context.SaveChanges();
        }
        
    }
}
