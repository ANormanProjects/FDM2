using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Profile
        public ActionResult ProfilePage()
        {
            return View();
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
    }
}