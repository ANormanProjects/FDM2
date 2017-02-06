using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    [DataContract]
    public class Group : IGroup
    {
        private int _groupID;
        public int groupID
        {
            get { return _groupID; }
            set { _groupID = value; }
        }

        private string _groupName;
        [DisplayName("Group Name")]
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

        private ICollection<User> _usersInGroup;
        public virtual ICollection<User> usersInGroup
        {
            get { return _usersInGroup; }
            set { _usersInGroup = value; }
        }

        private ICollection<GroupPost> _groupWall;
        public virtual ICollection<GroupPost> groupWall
        {
            get { return _groupWall; }
            set { _groupWall = value; }
        }


        public Group()
        {
        }

        public override string ToString()
        {
            return groupID + "-" + groupName + "[Owner: " + owner.ToString() + "]";
        }
    }
}
