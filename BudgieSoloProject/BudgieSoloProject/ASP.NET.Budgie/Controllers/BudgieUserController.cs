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
        BudgieDBCFModel buc = new BudgieDBCFModel();
        BudgieUserRepository budb;

        // GET: BudgieUser
        public ActionResult Index()
        {
            budb = new BudgieUserRepository(buc);
            return View(budb.GetAllBudgieUsers());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(BudgieUser budgieuser)
        {
            buc.budgieUsers.Add(budgieuser);
            buc.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_success");
            }
            return RedirectToAction("Index");
        }
    }
}