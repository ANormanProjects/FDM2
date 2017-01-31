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
        bool Login(string username, string password);
        bool LoginDetailVerification(string username, string password);
        void Logout(int id);
        void Register(User userToAdd);
        void ViewAccountInfo(int id);
        void AddFriend(int userId, int friendToAdd);
        void UpdateInfo(int id, string username, string password);
    }

    
}
