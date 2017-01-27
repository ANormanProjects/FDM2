using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgieDatabaseLayer
{
    public interface IBudgieUserRepository
    {
        List<BudgieUser> GetAllBudgieUsers();

        void addNewBudgieUser(BudgieUser newBudgieUser);

        void updateBudgieUser(int idUpdate, string firstNameUpdate, string lastNameUpdate, string dobUpdate);

        void removeBudgieUser(int idToRemove);
    }
}
