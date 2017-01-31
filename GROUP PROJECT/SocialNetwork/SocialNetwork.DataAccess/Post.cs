using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    public abstract class Post
    {
        public int postId { get; set; }

        public DateTime time { get; set; }

        public int likes { get; set; }

        public string title { get; set; }

        public List<IComment> comments { get; set; }

        public string language { get; set; }

        public string content { get; set; }

        public string code { get; set; }

    }
}
