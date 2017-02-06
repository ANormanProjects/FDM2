using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    [DataContract]
    public abstract class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int postId { get; set; }

        [DisplayName("Time")]
        public DateTime time { get; set; }

        [DisplayName("Likes")]
        public int likes { get; set; }

        [DisplayName("Title")]
        public string title { get; set; }

        public virtual ICollection<Comment> comments { get; set; }

        [DisplayName("Language")]
        public string language { get; set; }

        [DisplayName("Content")]
        public string content { get; set; }

        [DisplayName("Code")]
        public string code { get; set; }

        public Post()
        {
        }

    }
}
