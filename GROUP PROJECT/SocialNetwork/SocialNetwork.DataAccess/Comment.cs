using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.DataAccess
{
    public class Comment
    {
        public int commentId { get; set; }

        public string content { get; set; }

        public User user { get; set; }

        public Post post { get; set; }
    }
}
