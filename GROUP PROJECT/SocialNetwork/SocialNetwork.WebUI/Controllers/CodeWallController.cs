using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WebUI.Controllers
{
    public class CodeWallController : Controller
    {
        // GET: CodeWall
        public ActionResult Wall()
        {
            return View();
        }
    }
}