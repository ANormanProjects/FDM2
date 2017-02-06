﻿using SocialNetwork.DataAccess;
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
        void AddUserToGroup(Group group, User user);
        void RemoveUserFromGroup(Group group, User user);
        List<User> GetAllUsersInGroup(Group group);
        void WritePost(int id, string title, string language, string code, string content, Group group);
        List<GroupPost> GetAllPostsInGroup(Group group);
        List<Group> GetAllGroups();

    }
}
