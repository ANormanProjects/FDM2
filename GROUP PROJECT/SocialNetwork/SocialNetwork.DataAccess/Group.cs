using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    public class Group : IGroup
    {
        private int _groupID;
        public int groupID
        {
            get { return _groupID; }
            set { _groupID = value; }
        }

        private string _groupName;
        public string groupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

        private User _owner;
        public User owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        private List<User> _usersInGroup;
        public List<User> usersInGroup
        {
            get { return _usersInGroup; }
            set { _usersInGroup = value; }
        }

        private List<Post> _groupWall;
        public List<Post> groupWall
        {
            get { return _groupWall; }
            set { _groupWall = value; }
        }

    }
}
