using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.DataAccess
{
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

        public string content
        {
            get { return _content; }
            set { _content = value; }
        }        

        private User _user;

        public User user
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
        
    }
}
