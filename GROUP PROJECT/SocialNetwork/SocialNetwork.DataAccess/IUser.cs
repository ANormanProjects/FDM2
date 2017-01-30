using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    public interface IUser
    {
        int userId { get; set; }

        string username { get; set; }

        string password { get; set; }

        string fullName { get; set; }

        string gender { get; set; }

        IEnumerable<Post> posts { get; set; }

        IEnumerable<User> friends { get; set; }

        IEnumerable<string> skills { get; set; }
    }
}
