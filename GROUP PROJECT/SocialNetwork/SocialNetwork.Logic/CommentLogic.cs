using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
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

        public CommentLogic(DbContext context)
        {
            postRepo = new Repository<Post>(context);
            commentRepo = new Repository<Comment>(context);
            userRepo = new Repository<User>(context);
        }

        /// <summary>
        /// Adds a comment to the database
        /// </summary>
        /// <param name="commentText"></param>
        /// <param name="user"></param>
        /// <param name="post"></param>
        public virtual void AddComment(string commentText, User user, Post post)
        {
            if (userRepo.GetAll().Contains(user, new GenericCompare<User>(u => u.userId)))
            {
                if (postRepo.GetAll().Contains(post, new GenericCompare<Post>(p => p.postId)))
                {
                    if(commentText.Length > 0 && commentText.Length < 255)
                    {
                        Comment comment = new Comment(commentText, user, post);

                        // Just have to put in in the comment repo, entity framework will link it together
                        //post.comments.Add(comment);
                        //postRepo.Save();

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

        /// <summary>
        /// Deletes a comment from the database
        /// </summary>
        /// <param name="comment"></param>
        public void DeleteComment(Comment comment)
        {
            if (commentRepo.GetAll().Contains(comment, new GenericCompare<Comment>(c => c.commentId)))
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

        /// <summary>
        /// Changes the content of the specified comment
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="newText"></param>
        public void EditComment(Comment comment, string newText)
        {
            if (commentRepo.GetAll().Contains(comment, new GenericCompare<Comment>(c => c.commentId)))
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
        
        /// <summary>
        /// Adds one like to the specified comment
        /// </summary>
        /// <param name="comment"></param>
        public void LikeComment(Comment comment)
        {
            if (commentRepo.GetAll().Contains(comment, new GenericCompare<Comment>(c => c.commentId)))
            {
                comment.likes = comment.likes + 1;
                commentRepo.Save();
            }
            else
            {
                throw new EntityNotFoundException();
            }
        
        }
    }
}
