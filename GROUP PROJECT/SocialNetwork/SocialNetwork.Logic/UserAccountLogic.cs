using log4net;
using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SocialNetwork.Logic
{
    public class UserAccountLogic : IUserAccountLogic
    {
        private static readonly ILog logger = LogManager.GetLogger("UserLogic.cs");

        Repository<User> _userRepository = new Repository<User>();
        Repository<Post> _postRepository;
        Repository<Comment> _commentRepository;
        Repository<Group> _groupRepository;
        IPostLogic postLogic; 
        GroupAccountLogic groupAccLogic;


        public UserAccountLogic(Repository<User> userRepository, Repository<Post> postRepo, Repository<Comment> commentRepo, Repository<Group> groupRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepo;
            _commentRepository = commentRepo;
            _groupRepository = groupRepository;

            postLogic = new PostLogic(_postRepository, _userRepository, _groupRepository, _commentRepository);
            groupAccLogic = new GroupAccountLogic(_groupRepository, _postRepository, _commentRepository, _userRepository);
        }

        public UserAccountLogic(Repository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public UserAccountLogic(PostLogic PostLogic, Repository<User> userRepository)
        {
            postLogic = PostLogic;
            _userRepository = userRepository;
        }

        public UserAccountLogic(GroupAccountLogic groupLogic, Repository<User> userRepository)
        {
            groupAccLogic = groupLogic;
            _userRepository = userRepository;
        }

        public UserAccountLogic(SocialNetworkDataModel context)
        {
            _userRepository = new Repository<User>(context);
            _postRepository = new Repository<Post>(context);
            _commentRepository = new Repository<Comment>(context);
            _groupRepository = new Repository<Group>(context);
        }

        /// <summary>
        /// Checks login details against database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual bool Login(string username, string password)
        {
            bool result = false;

            if ((username == null) || (password == null))
            {
                throw new EmptyInputException();
            }

            if ((username.Count<char>() > 25) || (password.Count<char>() > 25))
            {
                throw new InputExceedsSpecifiedLimitException();
            }

            if ((password.Count<char>() < 25) && (username.Count<char>() < 25))
            {
                result = LoginDetailVerification(username, password);
            }

            logger.Info("Attempted Login: " + username + "-" + password);

            return result;
        }

        /// <summary>
        /// Checks whether the password matches the username in the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LoginDetailVerification(string username, string password)
        {
            User currentUser = new User();
                 
            currentUser = _userRepository.First(u => u.username == username);

            if ( currentUser != null && currentUser.username == username && currentUser.password == password)
            {
                return true;
            } 

            return false;
        }

        /// <summary>
        /// Checks database for users with the same username
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public virtual bool CheckForDuplicates(User user)
        {

            var userList = _userRepository.GetAll();

            var query = from b in userList
                        where b.username == user.username
                        select b;

            foreach (var item in query)
            {
                if (user.username == item.username)
                {
                    return true;
                }
            }
            return false;

        }
               
        /// <summary>
        /// Adds new user to the database
        /// </summary>
        /// <param name="userToAdd"></param>
        public virtual void Register(User userToAdd)
        { 
            _userRepository.Insert(userToAdd);
            _userRepository.Save();
        }

        /// <summary>
        /// Changes the values of the user and saves it to the database
        /// </summary>
        /// <param name="userToEdit"></param>
        /// <param name="newName"></param>
        /// <param name="newGender"></param>
        /// <param name="newRole"></param>
        /// <param name="newPassword"></param>
        public virtual void EditUser(User userToEdit, string newName, string newGender, string newRole, string newPassword)
        {
            if(_userRepository.GetAll().Contains(userToEdit))
            {
                userToEdit.fullName = newName;
                userToEdit.gender = newGender;
                userToEdit.role = newRole;
                userToEdit.password = newPassword;
                _userRepository.Save();
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        /// <summary>
        /// Removes a user from the database
        /// </summary>
        /// <param name="userToRemove"></param>
        public virtual void RemoveUser(User userToRemove)
        {
            if(_userRepository.GetAll().Contains(userToRemove))
            {

                _userRepository.Remove(userToRemove);
                _userRepository.Save();
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        /// <summary>
        /// Retrieves a user from the database
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public virtual User ViewAccountInfo(string username)
        {
            User userToDisplay = _userRepository.First(u => u.username == username);
            if (userToDisplay != null)
            {
                return userToDisplay;
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        /// <summary>
        /// Adds a friend to a user
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="userToAdd"></param>
        public void AddFriend(User currentUser, User userToAdd)
        {            
            
            if (currentUser.friends.Contains(userToAdd))
            {
                //exception to be added
                throw new EntityAlreadyExistsException();
            }
            else 
            {
                userToAdd.friends.Add(currentUser);
                currentUser.friends.Add(userToAdd);                
            }
            _userRepository.Save();

        }
               
        /// <summary>
        /// Returns a list of all user accounts
        /// </summary>
        /// <returns></returns>
        public virtual List<User> GetAllUserAccounts()
        {
            return _userRepository.GetAll();
        }

        /// <summary>
        /// Adds a post to the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="language"></param>
        /// <param name="code"></param>
        /// <param name="content"></param>
        /// <param name="user"></param>
        public void WritePost(int id, string title, string language, string code, string content, User user)
        {
            if (_userRepository.GetAll().Contains(user))
            {
                postLogic.WriteUserPost(id, title, language, code, content, user);
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        /// <summary>
        /// Returns a list of posts from the groups a user follows
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<GroupPost> ViewAllPostByFollowedGroups(User user)
        {
            if (_userRepository.GetAll().Contains(user))
            {
                List<GroupPost> groupPosts = new List<GroupPost>();

                foreach (Group _group in user.groups)
                {
                    groupPosts = groupAccLogic.GetAllPostsInGroup(_group);
                }

                return groupPosts;
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        /// <summary>
        /// Returns a list of groups followed by a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Group> ViewAllGroupsFollowedByUser(User user)
        {
            bool test = false;

            foreach (User userTest in _userRepository.GetAll())
            {
                if (user.userId == userTest.userId)
                {
                    test = true;
                }
            }
            if (test == true)
            {
                List<Group> groups = new List<Group>();

                groups = user.groups.ToList();

                return groups;
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

    }
}
