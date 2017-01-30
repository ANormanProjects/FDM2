using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    public class Post
    {
        public int postId { get; set; }

        public User user { get; set; }

        public DateTime time { get; set; }

        public int likes { get; set; }

        public string title { get; set; }

        public IEnumerable<Comment> comments { get; set; }

    }
}
