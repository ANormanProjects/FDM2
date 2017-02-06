using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    [ServiceContract]

    public interface IUserAccountLogic
    {
        bool Login(string username, string password);
        bool LoginDetailVerification(string username, string password);        
        void Register(User userToAdd);
        User ViewAccountInfo(string username);
        void AddFriend(User currentUser, User userToAdd);        
        void WritePost(int id, string title, string language, string code, string content, User user);
    }

    
}
