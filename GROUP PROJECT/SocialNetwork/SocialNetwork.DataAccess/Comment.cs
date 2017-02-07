using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SocialNetwork.DataAccess
{
    [DataContract]
    public class Comment : IComment
    {
        public Comment()
        {

        }
        
        public Comment(string Content, User User, Post Post)
        {
            content = Content;
            user = User;
            post = Post; 
        }

        [DataMember]
        private int _commentId;
        [DataMember]
        public int commentId
        {
            get { return _commentId; }
            set { _commentId = value; }
        }

        [DataMember]
        private string _content;
        [DataMember]
        [DisplayName("Content")]
        public virtual string content
        {
            get { return _content; }
            set { _content = value; }
        }

        [DataMember]
        private User _user;
        [DataMember]
        public virtual User user
        {
            get { return _user; }
            set { _user = value; }
        }

        [DataMember]
        private Post _post;
        [DataMember]
        public virtual Post post
        {
            get { return _post; }
            set { _post = value; }
        }

        [DataMember]
        private int _likes;
        [DataMember]
        [DisplayName("Likes")]
        public virtual int likes
        {
            get { return _likes; }
            set { _likes = value; }
        }
        
        
    }
}
