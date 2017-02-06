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
        [OperationContract]
        bool Login(string username, string password);
        
        [OperationContract]
        bool LoginDetailVerification(string username, string password);

        [OperationContract]
        void Register(User userToAdd);

        [OperationContract]
        User ViewAccountInfo(string username);

        [OperationContract]
        void AddFriend(User currentUser, User userToAdd);

        [OperationContract]
        void WritePost(int id, string title, string language, string code, string content, User user);
    }

    
}
