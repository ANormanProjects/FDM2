using SocialNetwork.DataAccess;
using SocialNetwork.Logic;
using SocialNetwork.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WebUI.Controllers
{
    public class GroupController : Controller
    {
        GroupAccountLogic _groupAccountLogic;

        public GroupController() { }

        public GroupController(GroupAccountLogic groupAccountLogic)
        {
            _groupAccountLogic = groupAccountLogic;
        }

        // GET: Group
        [HttpGet]
        [Authorize]
        public ActionResult GroupPosts()
        {
            if (_groupAccountLogic == null)
            {
                _groupAccountLogic = new GroupAccountLogic(new PostLogic(new Repository<Post>(), new Repository<Comment>()), new Repository<Group>());
            }

            List<GroupPostViewModel> posts = new List<GroupPostViewModel>();
            User user;
            UserAccountLogic logic = new UserAccountLogic(new Repository<User>());
            user = logic.ViewAccountInfo(User.Identity.Name);
            List<Group> groups = _groupAccountLogic.GetAllGroups(); 
            var query = from u in groups
                        where u.usersInGroup.Contains(user)
                        select u; 

            
            

            return View("GroupPosts");
        }

           
        
    }
}