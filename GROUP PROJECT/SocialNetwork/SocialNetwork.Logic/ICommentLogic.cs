using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    public interface ICommentLogic
    {
        void addComment(string commentText);
        void DeleteComment(CommentLogic comment);
        void EditComment(CommentLogic comment, string newText);
        void LikeComment(CommentLogic comment);

    }
}
