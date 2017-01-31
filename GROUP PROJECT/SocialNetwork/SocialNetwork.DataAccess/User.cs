using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    public class User : IUser
    {
        private int _userId;

        public int userId
        {
            get { return _userId; }
            set { _userId = value; }
        }        

        private string _username;
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }        

        private string _password;

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }        

        private string _fullName;

        public string fullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }        

        private string _gender;
        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }       
        
        private IEnumerable<Post> _posts;
        public IEnumerable<Post> posts
        {
            get { return _posts; }
            set { _posts = value; }
        }        

        private IEnumerable<User> _friends;
        public IEnumerable<User> friends
        {
            get { return _friends; }
            set { _friends = value; }
        }

        private IEnumerable<string> _skills;
        public IEnumerable<string> skills
        {
            get { return _skills; }
            set { _skills = value; }
        }

        public override string ToString()
        {
            return userId + "-" + username + "-" + password + "-" + gender + "-[" + fullName + "]";
        }

    }
}
