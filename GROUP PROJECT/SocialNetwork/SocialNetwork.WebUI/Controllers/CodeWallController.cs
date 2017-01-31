using SocialNetwork.DataAccess;
using SocialNetwork.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WebUI.Controllers
{
    public class CodeWallController : Controller
    {
        PostLogic _postLogic;

        public CodeWallController() { }

        public CodeWallController(PostLogic postLogic)
        {
            postLogic = _postLogic;
        }

        //GET: CodeWall
        [HttpGet]
        public ActionResult Wall()
        {
            return View("Wall");
        }

        

    }
}