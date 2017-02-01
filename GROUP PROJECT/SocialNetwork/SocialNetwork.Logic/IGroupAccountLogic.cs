using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    public interface IGroupAccountLogic
    {
        void addUserToGroup(User user);
        void RemoveUserFromGroup(User User);
        List<User> GetAllUsersInGroup();


    }
}
