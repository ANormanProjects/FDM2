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
        [DataMember]
        private int _groupID;
        [DataMember]
        public int groupID
        {
            get { return _groupID; }
            set { _groupID = value; }
        }

        [DataMember]
        private string _groupName;
        [DataMember]
        [DisplayName("Group Name")]
        public virtual string groupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

        [DataMember]
        private User _owner;
        [DataMember]
        public User owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        [DataMember]
        private ICollection<User> _usersInGroup;
        [DataMember]
        public virtual ICollection<User> usersInGroup
        {
            get { return _usersInGroup; }
            set { _usersInGroup = value; }
        }

        [DataMember]
        private ICollection<GroupPost> _groupWall;
        [DataMember]
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
