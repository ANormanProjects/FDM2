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
        Repository<Post> postRepo = new Repository<Post>();
        Repository<Comment> commentRepo = new Repository<Comment>();

        public void addComment(string commentText, User user, Post post)
        {
            Comment comment = new Comment(commentText, user, post);

            post.comments.Concat(new[] { comment });
            postRepo.Save();

            commentRepo.Insert(comment);
            commentRepo.Save();
        }

        public void DeleteComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void EditComment(Comment comment, string newText)
        {
            throw new NotImplementedException();
        }

        public void LikeComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
