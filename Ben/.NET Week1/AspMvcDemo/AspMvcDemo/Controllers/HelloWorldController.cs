using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMvcDemo.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }

        public string England()
        {
            return "Hello World!";
        }

        public string France()
        {
            return "Bonjour tout le monde!";
        }
    }
}