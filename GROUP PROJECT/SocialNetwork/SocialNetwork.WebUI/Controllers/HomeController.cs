using SocialNetwork.DataAccess;
using SocialNetwork.Logic;
using SocialNetwork.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SocialNetwork.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {       
            return View("Index");
        }
        
    }
}