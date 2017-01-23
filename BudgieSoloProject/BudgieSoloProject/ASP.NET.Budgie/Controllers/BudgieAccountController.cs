using BudgieDatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.Budgie.Controllers
{
    public class BudgieAccountController : Controller
    {
        BudgieDBCFModel buc = new BudgieDBCFModel();
        AccountRepository ardb;
        
        // GET: BudgieAccount
        public ActionResult Index()
        {
            ardb = new AccountRepository(buc);
            return View(ardb.GetAllAccounts());
        }

        public ActionResult Overview()
        {
            return View();
        }

        public ActionResult Budgets()
        {
            return View();
        }
    }
}