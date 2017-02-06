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

    public interface IGroupAccountLogic
    {
        [OperationContract]
        void AddUserToGroup(Group group, User user);

        [OperationContract]
        void RemoveUserFromGroup(Group group, User user);

        [OperationContract]
        List<User> GetAllUsersInGroup(Group group);

        [OperationContract]
        void WritePost(int id, string title, string language, string code, string content, Group group);

        [OperationContract]
        List<GroupPost> GetAllPostsInGroup(Group group);

        [OperationContract]
        List<Group> GetAllGroups();

    }
}
