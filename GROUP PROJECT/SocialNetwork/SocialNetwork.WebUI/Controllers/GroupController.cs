using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WebUI.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult GroupPosts()
        {
            return View("GroupPosts");
        }
    }
}