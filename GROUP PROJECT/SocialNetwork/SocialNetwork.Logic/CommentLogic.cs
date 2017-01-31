using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    public class CommentLogic : ICommentLogic
    {
        public void addComment(string commentText, User user, Post post)
        {
            IComment comment = new Comment(commentText, user, post);
        }

        public void DeleteComment(CommentLogic comment)
        {
            throw new NotImplementedException();
        }

        public void EditComment(CommentLogic comment, string newText)
        {
            throw new NotImplementedException();
        }

        public void LikeComment(CommentLogic comment)
        {
            throw new NotImplementedException();
        }
    }
}
