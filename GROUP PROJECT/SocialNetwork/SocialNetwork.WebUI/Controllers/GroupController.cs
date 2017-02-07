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
            IEnumerable<GroupViewModels> viewModels;
            if (_groupAccountLogic == null)
            {
                _groupAccountLogic = new GroupAccountLogic(new PostLogic(new Repository<Post>(), new Repository<Comment>()), new Repository<Group>());
            }

            var groups = _groupAccountLogic.GetAllGroups();
            UserAccountLogic logic = new UserAccountLogic(new Repository<User>());
            User user;
            Group group = new Group();
            user = logic.ViewAccountInfo(User.Identity.Name);
            viewModels = CreateViewModels(group).Where(u => u.group.usersInGroup == user);
  
            return View("GroupList", viewModels);
        }

        //GET: GroupProfile
        public ActionResult GroupProfile()
        {
            return View("GroupProfile");
        }

        public List<GroupViewModels> CreateViewModels(Group group)
        {
            if (_groupAccountLogic == null)
            {
                _groupAccountLogic = new GroupAccountLogic(new PostLogic(new Repository<Post>(), new Repository<Comment>()), new Repository<Group>());
            }

            var groupList = _groupAccountLogic.GetAllGroups();

            List<GroupViewModels> groups = new List<GroupViewModels>();

            foreach (Group g in groupList)
            {
                groups.Add(new GroupViewModels() { group = g });
            }

            return groups;
        }
    }
}