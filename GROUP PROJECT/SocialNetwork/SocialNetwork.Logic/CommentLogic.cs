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

        public CommentLogic(Repository<Post> PostRepo, Repository<Comment> CommentRepo)
        {
            postRepo = PostRepo;
            commentRepo = CommentRepo;
        }

        public void addComment(string commentText, User user, Post post)
        {
            Comment comment = new Comment(commentText, user, post);

            post.comments.Add(comment);
            postRepo.Save();

            commentRepo.Insert(comment);
            commentRepo.Save();
        }

        public void DeleteComment(Comment comment)
        {
            Post post = comment.post;
            post.comments.Remove(comment);
            postRepo.Save();

            commentRepo.Remove(comment);
            commentRepo.Save();
        }

        public void EditComment(Comment comment, string newText)
        {
            comment.content = newText;
            commentRepo.Save();
        }

        public void LikeComment(Comment comment)
        {
            
        }
    }
}
