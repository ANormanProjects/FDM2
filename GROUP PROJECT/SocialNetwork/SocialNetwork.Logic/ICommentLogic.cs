using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    public interface ICommentLogic
    {
        void addComment(string commentText, User user, Post post);
        void DeleteComment(Comment comment);
        void EditComment(Comment comment, string newText);
        void LikeComment(Comment comment);

    }
}
