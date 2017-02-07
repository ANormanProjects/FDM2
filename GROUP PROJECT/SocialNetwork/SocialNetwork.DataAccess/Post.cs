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
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int postId { get; set; }

        [DataMember]
        [DisplayName("Time")]
        public DateTime time { get; set; }

        [DataMember]
        [DisplayName("Likes")]
        public int likes { get; set; }

        [DataMember]
        [DisplayName("Title")]
        public string title { get; set; }

        [DataMember]
        public virtual ICollection<Comment> comments { get; set; }

        [DataMember]
        [DisplayName("Language")]
        public string language { get; set; }

        [DataMember]
        [DisplayName("Content")]
        public string content { get; set; }

        [DataMember]
        [DisplayName("Code")]
        public string code { get; set; }

        public Post()
        {
        }

    }
}
