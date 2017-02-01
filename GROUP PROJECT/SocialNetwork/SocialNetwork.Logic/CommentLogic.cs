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
        Repository<User> userRepo = new Repository<User>();

        public CommentLogic(Repository<Post> PostRepo, Repository<Comment> CommentRepo, Repository<User> UserRepo)
        {
            postRepo = PostRepo;
            commentRepo = CommentRepo;
            userRepo = UserRepo;
        }

        public virtual void AddComment(string commentText, User user, Post post)
        {
            if (userRepo.GetAll().Contains(user))
            {
                if (postRepo.GetAll().Contains(post))
                {
                    if(commentText.Length > 0 && commentText.Length < 255)
                    {
                        Comment comment = new Comment(commentText, user, post);

                        post.comments.Add(comment);
                        postRepo.Save();

                        commentRepo.Insert(comment);
                        commentRepo.Save();
                    }
                    else
                    {
                        throw new StringNotCorrectLengthException();
                    }
                }
                else
                {
                    throw new EntityNotFoundException();
                }
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        public void DeleteComment(Comment comment)
        {
            if (commentRepo.GetAll().Contains(comment))
            {
                Post post = comment.post;
                post.comments.Remove(comment);
                postRepo.Save();

                commentRepo.Remove(comment);
                commentRepo.Save();
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        public void EditComment(Comment comment, string newText)
        {
            if (commentRepo.GetAll().Contains(comment))
            {
                if (newText.Length > 0 && newText.Length < 255)
                {
                    comment.content = newText;
                    commentRepo.Save();
                }
                else
                {
                    throw new StringNotCorrectLengthException();
                }
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        public void LikeComment(Comment comment)
        {
            comment.likes = comment.likes + 1;
            commentRepo.Save();
        }
    }
}
