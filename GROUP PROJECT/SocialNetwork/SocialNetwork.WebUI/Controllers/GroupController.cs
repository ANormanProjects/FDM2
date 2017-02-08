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
        User user;
        UserAccountLogic logic; 

        public GroupController()
        {
            commentRepo = new Repository<Comment>();
            postRepo = new Repository<Post>();
            userRepo = new Repository<User>();
            groupRepo = new Repository<Group>();
            _groupAccountLogic = new GroupAccountLogic(groupRepo, postRepo, commentRepo, userRepo);
            _userAccountLogic = new UserAccountLogic(userRepo, postRepo, commentRepo, groupRepo);
            logic = new UserAccountLogic(new Repository<User>());
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
            
            Group group = new Group();
            user = logic.ViewAccountInfo(User.Identity.Name);
            viewModels = CreateViewModels(user);

            return View("GroupList", viewModels);
        }

        //GET: GroupProfile
        [Authorize]
        public ActionResult GroupProfile(GroupViewModels model, int id)
        {
            GroupViewModels viewModel;
            user = logic.ViewAccountInfo(User.Identity.Name);
            viewModel = CreateGroupViewModel(user,id);
            return View("GroupProfile", viewModel);
        }

        //Create view models for groups
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

        //Create view model for one group
        public GroupViewModels CreateGroupViewModel(User user, int id)
        {
            GroupViewModels model = new GroupViewModels();
            var groupList = _userAccountLogic.ViewAllGroupsFollowedByUser(user).Where(u => u.groupID == id);

            List<GroupViewModels> groups = new List<GroupViewModels>();

            foreach (Group g in groupList)
            {
                groups.Add(new GroupViewModels() { group = g });
            }

            var group = groups.First();

            return group;
        }
    }
}