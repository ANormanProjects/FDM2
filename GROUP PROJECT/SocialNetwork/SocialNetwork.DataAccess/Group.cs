﻿using System;
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

        private ICollection<User> _usersInGroup;
        public virtual ICollection<User> usersInGroup
        {
            get { return _usersInGroup; }
            set { _usersInGroup = value; }
        }

        private ICollection<Post> _groupWall;
        public ICollection<Post> groupWall
        {
            get { return _groupWall; }
            set { _groupWall = value; }
        }


        public Group()
        {
            usersInGroup = new List<User>();
            groupWall = new List<Post>();
        }

        public override string ToString()
        {
            return groupID + "-" + groupName + "[Owner: " + owner.ToString() + "]";
        }
    }
}
