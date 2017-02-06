using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    [ServiceContract]

    public interface ICommentLogic
    {
        [OperationContract]
        void AddComment(string commentText, User user, Post post);

        [OperationContract]
        void DeleteComment(Comment comment);

        [OperationContract]
        void EditComment(Comment comment, string newText);

        [OperationContract]
        void LikeComment(Comment comment);

    }
}
