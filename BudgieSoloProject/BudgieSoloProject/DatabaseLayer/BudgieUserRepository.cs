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

        BudgieDBCFModel _context;

        List<BudgieUser> database = new List<BudgieUser>();

        public BudgieUserRepository ()
	    {

	    }

        public BudgieUserRepository(BudgieDBCFModel context)
        {
            _context = context;
        }

        public virtual List<BudgieUser> GetAllBudgieUsers()
        {
            return _context.budgieUsers.ToList();
        }


        
    }
}
