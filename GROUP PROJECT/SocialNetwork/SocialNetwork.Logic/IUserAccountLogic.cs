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
        SocialNetworkDataModel _dataModel;
        Repository<User> _userRepository;

        public UserAccountLogic(SocialNetworkDataModel dataModel, Repository<User> userRepository)
        {
            _dataModel = dataModel;
            _userRepository = userRepository;
        }

        public void Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool LoginDetailVerification(string username, string password)
        {
            var query = from b in _dataModel.users
                        where b.username == username && b.password == password
                        select b;

            foreach (var user in query)
            {
                if (username == user.username && password == user.password)
                {
                    return true;
                }
            }
            return false;
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
            var query = from b in _dataModel.users
                        where b.userId == userId
                        select b;

            var queryForFriend = from b in _dataModel.users
                                 where b.userId == friendId
                                 select b;

            foreach (User user in query)
            {
                foreach (User friend in queryForFriend)
                {
                    user.friends.ToList().Add(friend);
                }
            }
        }

        public void UpdateInfo(int id, string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
