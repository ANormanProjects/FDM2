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
    public class User : IUser
    {
        [DataMember]
        private int _userId;
        [DataMember]
        public virtual int userId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        [DataMember]
        private string _username;
        [DataMember]
        [DisplayName("User Name")]
        public virtual string username
        {
            get { return _username; }
            set { _username = value; }
        }

        [DataMember]
        private string _password;
        [DataMember]
        [DisplayName("Password")]
        public virtual string password
        {
            get { return _password; }
            set { _password = value; }
        }

        [DataMember]
        private string _fullName;
        [DataMember]
        [DisplayName("Full Name")]
        public virtual string fullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        [DataMember]
        private string _gender;
        [DataMember]
        [DisplayName("Gender")]
        public virtual string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        [DataMember]
        private string _role;
        [DataMember]
        [DisplayName("Role")]
        public virtual string role
        {
            get { return _role; }
            set { _role = value; }
        }

        [DataMember]
        private ICollection<Group> _groups;
        [DataMember]
        public virtual ICollection<Group> groups
        {
            get { return _groups; }
            set { _groups = value; }
        }

        [DataMember]
        private ICollection<UserPost> _posts;
        [DataMember]
        public virtual ICollection<UserPost> posts
        {
            get { return _posts; }
            set { _posts = value; }
        }

        [DataMember]
        private ICollection<User> _friends;
        [DataMember]
        public virtual ICollection<User> friends
        {
            get { return _friends; }
            set { _friends = value; }
        }

        [DataMember]
        private ICollection<string> _skills;
        [DataMember]
        public virtual ICollection<string> skills
        {
            get { return _skills; }
            set { _skills = value; }
        }


        public User()
        {
        }

        public override string ToString()
        {
            return userId + "-" + username + "-" + password + "-" + gender + "-[" + fullName + "]";
        }

    }
}
