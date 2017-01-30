using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    public class User : IUser
    {
        public int userId { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string fullName { get; set; }

        public string gender { get; set; }

        public IEnumerable<Post> posts { get; set; }

        public IEnumerable<User> friends { get; set; }

        public IEnumerable<string> skills { get; set; }
    }
}
