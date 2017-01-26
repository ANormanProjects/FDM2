using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.Budgie.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult About()     //TEST TOMORROW!!!
        {
            return View("About");
        }

        public ActionResult Contact()
        {
            return View("Contact");
        }

        public ActionResult FAQ()
        {
            return View("FAQ");
        }

        public ActionResult Careers()
        {
            return View("Careers");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminIndex()
        {
            ViewBag.Message = "This can be viewed only by users in Admin role only";
            return View("AdminIndex");
        }


    }
}