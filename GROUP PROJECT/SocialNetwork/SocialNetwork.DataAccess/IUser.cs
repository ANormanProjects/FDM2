using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    
    public interface IUser
    {
        int userId { get; set; }
        [DisplayName("User Name")]
        string username { get; set; }
        [DisplayName("Password")]
        string password { get; set; }
        [DisplayName("Full Name")]
        string fullName { get; set; }
        [DisplayName("Gender")]
        string gender { get; set; }

        IEnumerable<Post> posts { get; set; }

        IEnumerable<User> friends { get; set; }

        IEnumerable<string> skills { get; set; }
    }
}
