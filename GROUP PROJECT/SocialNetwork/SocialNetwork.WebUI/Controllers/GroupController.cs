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
        Repository<Group> groupRepo;
        Repository<Post> postRepo;
        Repository<Comment> commentRepo;
        Repository<User> userRepo;
        GroupAccountLogic _groupAccountLogic;
        UserAccountLogic _userAccountLogic;
        public GroupController()
        {
            commentRepo = new Repository<Comment>();
            postRepo = new Repository<Post>();
            userRepo = new Repository<User>();
            groupRepo = new Repository<Group>();
            _groupAccountLogic = new GroupAccountLogic(groupRepo, postRepo, commentRepo, userRepo);
            _userAccountLogic = new UserAccountLogic(userRepo, postRepo, commentRepo, groupRepo);
        }

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

            var groups = _groupAccountLogic.GetAllGroups();
            UserAccountLogic logic = new UserAccountLogic(new Repository<User>());
            User user;
            Group group = new Group();
            user = logic.ViewAccountInfo(User.Identity.Name);
            viewModels = CreateViewModels(user);

            return View("GroupList", viewModels);
        }

        //GET: GroupProfile
        public ActionResult GroupProfile()
        {
            return View("GroupProfile");
        }

        public List<GroupViewModels> CreateViewModels(User user)
        {
            var groupList = _userAccountLogic.ViewAllGroupsFollowedByUser(user);

            List<GroupViewModels> groups = new List<GroupViewModels>();

            foreach (Group g in groupList)
            {
                groups.Add(new GroupViewModels() { group = g });
            }

            return groups;
        }
    }
}