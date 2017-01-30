using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    public class Group : IGroup
    {
        public int groupID { get; set; }
        public List<User> usersInGroup { get; set; }
        public string groupName;
        public List<Post> groupWall;
        public User owner;
    }
}
