using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    public interface IUserAccountLogic
    {
        void Login(string username, string password);
        bool LoginDetailVerification(string username, string password);
        void Logout(int id);
        void Register(User userToAdd);
        void ViewAccountInfo(int id);
        void AddFriend(int userId, int friendToAdd);
        void UpdateInfo(int id, string username, string password);
    }

    public class UserAccountLogic : IUserAccountLogic
    {
        Repository<User> _userRepository;

        public UserAccountLogic(Repository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Login(string username, string password)
        {

            //if(username.Count<char>() > 255) 
            //{
            //    throw new InputExceedsSpecifiedLimitException();
            //}
            //if (password.Count<char>() > 255) 
            //{
            //    throw new InputExceedsSpecifiedLimitException();
            //}
        }

        public bool LoginDetailVerification(string username, string password)
        {
            User currentUser = _userRepository.First(u => u.username == username);

            if (currentUser.username == username && currentUser.password == password)
            {
                return true;
            } return false;
          
        }

        public void Logout(int id)
        {
            throw new NotImplementedException();
        }

        public void Register(User userToAdd)
        {
            throw new NotImplementedException();
        }

        public void ViewAccountInfo(int id)
        {
            throw new NotImplementedException();
        }

        public void AddFriend(int userId, int friendId)
        {
            //probably wrong

            User currentUser = _userRepository.First(u => u.userId == userId);

            User userToAdd = _userRepository.First(u => u.userId == userId);

            currentUser.friends.ToList().Add(userToAdd);
            
        }

        public void UpdateInfo(int id, string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
