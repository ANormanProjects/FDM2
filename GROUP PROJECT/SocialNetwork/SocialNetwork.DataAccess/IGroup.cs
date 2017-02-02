using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    public interface IGroup
    {
        int groupID { get; set; }

        ICollection<User> usersInGroup { get; set; }

        ICollection<GroupPost> groupWall { get; set; }

        string groupName { get; set; }

        User owner { get; set; }
    }
}
