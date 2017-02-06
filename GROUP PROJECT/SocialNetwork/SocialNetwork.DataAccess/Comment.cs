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

        private int _commentId;
        public int commentId
        {
            get { return _commentId; }
            set { _commentId = value; }
        }        

        private string _content;
        [DisplayName("Content")]
        public virtual string content
        {
            get { return _content; }
            set { _content = value; }
        }        

        private User _user;
        public virtual User user
        {
            get { return _user; }
            set { _user = value; }
        }


        private Post _post;
        public virtual Post post
        {
            get { return _post; }
            set { _post = value; }
        }

        private int _likes;
        [DisplayName("Likes")]
        public virtual int likes
        {
            get { return _likes; }
            set { _likes = value; }
        }
        
        
    }
}
