using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    public interface IComment
    {
        void addComment(string commentText);
        void DeleteComment(Comment comment);
        void EditComment(Comment comment, string newText);
        void LikeComment(Comment comment);

    }
}
