using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    public class User : IUser
    {
        private int _userId;
        public virtual int userId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        
        private string _username;
        [DisplayName("User Name")]
        public virtual string username
        {
            get { return _username; }
            set { _username = value; }
        }

        
        private string _password;
        [DisplayName("Password")]
        public virtual string password
        {
            get { return _password; }
            set { _password = value; }
        }

        
        private string _fullName;
        [DisplayName("Full Name")]
        public virtual string fullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        
        private string _gender;
        [DisplayName("Gender")]
        public virtual string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }       
        
        private string _role;
        public virtual string role
        {
            get { return _role; }
            set { _role = value; }
        }
        
        private ICollection<Group> _groups;
        public virtual ICollection<Group> groups
        {
            get { return _groups; }
            set { _groups = value; }
        }


        private ICollection<Post> _posts;
        public virtual ICollection<Post> posts
        {
            get { return _posts; }
            set { _posts = value; }
        }        

        private ICollection<User> _friends;
        public virtual ICollection<User> friends
        {
            get { return _friends; }
            set { _friends = value; }
        }

        private ICollection<string> _skills;
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
