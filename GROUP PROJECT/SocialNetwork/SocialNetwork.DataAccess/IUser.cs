using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    public interface IUser
    {
        int userId { get; set; }
        [DisplayName("Username")]
        string username { get; set; }
        [DisplayName("Password")]
        string password { get; set; }
        [DisplayName("Full Name")]
        string fullName { get; set; }
        [DisplayName("Gender")]
        string gender { get; set; }
        string role { get; set; }

        ICollection<Group> groups { get; set; }

        ICollection<UserPost> posts { get; set; }

        ICollection<User> friends { get; set; }

        ICollection<string> skills { get; set; }
    }
}
