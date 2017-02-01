using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    public class GroupPost : Post
    {
        public Group group { get; set; }

        public GroupPost() : base() { }

        public override string ToString()
        {
            return time.ToShortDateString() + "-" + postId + "-" + title + "-" +
                content + "-" + code + "-" + language + "[Group: " + group.ToString() + "]";
        }
    }
}
