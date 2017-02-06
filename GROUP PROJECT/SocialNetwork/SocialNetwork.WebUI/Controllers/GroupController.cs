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

        // GET: GroupList
        [HttpGet]
        [Authorize]
        public ActionResult GroupList()
        {
            if (_groupAccountLogic == null)
            {
                _groupAccountLogic = new GroupAccountLogic(new PostLogic(new Repository<Post>(), new Repository<Comment>()), new Repository<Group>());
            }

            var groups = _groupAccountLogic.GetAllGroups();
            UserAccountLogic logic = new UserAccountLogic(new Repository<User>());
            User user;
            user = logic.ViewAccountInfo(User.Identity.Name);

            var query = from s in groups
                        where s.usersInGroup == user
                        select s;

            return View("GroupList", query);
        }

        //GET: GroupProfile
        public ActionResult GroupProfile()
        {
            return View("GroupProfile");
        }

        public List<GroupViewModels> CreateViewModels(Group group)
        {
            List<GroupViewModels> groups = new List<GroupViewModels>();

            //foreach (Group g in group.group)
            //{
            //    groups.Add(new GroupViewModels() { group = g });
            //}

            return groups;
        }
    }
}