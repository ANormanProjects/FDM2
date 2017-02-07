using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    [DataContract]
    public class GroupPost : Post
    {
        [DataMember]
        public Group group { get; set; }
        
        public GroupPost() : base() { }

        public override string ToString()
        {
            return time.ToShortDateString() + "-" + postId + "-" + title + "-" +
                content + "-" + code + "-" + language + "[Group: " + group.ToString() + "]";
        }
    }
}
