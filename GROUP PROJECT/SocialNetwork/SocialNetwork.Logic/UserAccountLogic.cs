using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    public class UserAccountLogic : IUserAccountLogic
    {
        Repository<User> _userRepository;
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

            postLogic = new PostLogic(_postRepository, _userRepository, _commentRepository);
            groupAccLogic = new GroupAccountLogic(_groupRepository, _postRepository, _commentRepository, _userRepository);
        }

        public UserAccountLogic(Repository<User> userRepository)
        {
            _userRepository = userRepository;

        }

        public UserAccountLogic(PostLogic PostLogic)
        {
            postLogic = PostLogic;
        }

        public bool Login(string username, string password)
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

            return result;
        }

        public bool LoginDetailVerification(string username, string password)
        {
            User currentUser = new User();
                 
            currentUser = _userRepository.First(u => u.username == username);

            if (currentUser.username == username && currentUser.password == password)
            {
                return true;
            } return false;

        }

        public bool CheckForDuplicates(User user)
        {
            User newUser = new User();

            newUser = _userRepository.First(u => u.username == user.username);

            if (newUser.username == user.username)
            {
                return false;
        }
            else
	        {
                return true;
	        }
        }

        public void Logout(int id)
        {
            throw new NotImplementedException();
        }

        public void Register(User userToAdd)
        {   //defensive code
            _userRepository.Insert(userToAdd);
            _userRepository.Save();
        }

        public void ViewAccountInfo(int userId)
        {
           //find user
            User userToDisplay = _userRepository.First(u => u.userId == userId);
            //what to display
            
        }

        public void AddFriend(int userId, int friendId)
        {
            //probably wrong

            User currentUser = _userRepository.First(u => u.userId == userId);

            User userToAdd = _userRepository.First(u => u.userId == userId);
            currentUser.friends.Add(userToAdd);           

            userToAdd.friends.Add(currentUser);

            _userRepository.Save();

        }

        public void UpdateInfo(int id, string username, string password)
        {
            throw new NotImplementedException();
        }

        public virtual List<User> GetAllUserAccounts()
        {
            return _userRepository.GetAll();
        }

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

        public List<GroupPost> ViewAllPostByFollowedGroups(User user)
        {
            List<GroupPost> groupPosts = new List<GroupPost>();

            foreach (Group _group in user.groups)
            {
                groupPosts = groupAccLogic.GetAllPostsInGroup(_group);
            }

            return groupPosts;
            
        }

    }
}
