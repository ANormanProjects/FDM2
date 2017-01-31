using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    public class UserPost : Post
    {
        public User user { get; set; }

        public override string ToString()
        {
            return time.ToShortDateString() + "-" + postId + "-" + title + "-" + 
                content + "-" + code + "-" + language + "[User: " + user.ToString() + "]";
        }
    }
}
