using BudgieDatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.Budgie.Controllers
{
    public class BudgieUserController : Controller
    {
        BudgieUserRepository budb = new BudgieUserRepository();
        // GET: BudgieUser
        public ActionResult Index()
        {
            return View();
        }
    }
}