using SocialNetwork.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    public class PostLogic : IPostLogic
    {
        private Repository<Post> _postRepository;
        private Repository<User> _userRepository;
        private Repository<Group> _groupRepository;
        private Repository<Comment> _commentRepository;
        CommentLogic commentLogic;

        // String Restrictions (number of characters)

        public PostLogic(Repository<Post> postRepository, Repository<User> userRepository, Repository<Group> groupRepository ,Repository<Comment> commentRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _commentRepository = commentRepository;
            commentLogic = new CommentLogic(_postRepository, _commentRepository, _userRepository);
        }

        public PostLogic(Repository<Post> postRepository, Repository<Comment> commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            commentLogic = new CommentLogic(_postRepository, _commentRepository, _userRepository);
        }

        public PostLogic(CommentLogic CommentLogic)
        {
            commentLogic = CommentLogic;
        }

        /// <summary>
        /// Adds a Group Post object to the Repository after checking the arguments are valid
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="language"></param>
        /// <param name="code"></param>
        /// <param name="content"></param>
        public void WriteGroupPost(int id, string title, string language, string code, string content, Group group)
        {
            if (_groupRepository.GetAll().Contains(group))
            {
                GroupPost postToWrite = new GroupPost();
                postToWrite.title = title;
                postToWrite.language = language;
                postToWrite.code = code;
                postToWrite.content = content;
                postToWrite.group = group;

                _postRepository.Insert(postToWrite);
            }
            else
            {
                //exception to throw - might need to add new exception 
                throw new EntityNotFoundException();
            }

            _postRepository.Save();
        }

        /// <summary>
        /// Adds a User Post object to the Repository after checking the arguments are valid
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="language"></param>
        /// <param name="code"></param>
        /// <param name="content"></param>
        public void WriteUserPost(int id, string title, string language, string code, string content, User user)
        {
            if (_userRepository.GetAll().Contains(user))
            {
                UserPost postToWrite = new UserPost();
                postToWrite.title = title;
                postToWrite.language = language;
                postToWrite.code = code;
                postToWrite.content = content;
                postToWrite.user = user;

                _postRepository.Insert(postToWrite);
            }
            else
            {
                //exception to throw - might need to add new exception 
                throw new EntityNotFoundException();
            }

            _postRepository.Save();
        }

        /// <summary>
        /// Returns a list of posts made by the User and the Users friends
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Post> ViewTimeline(User user)
        {
            List<Post> timelinePosts = new List<Post>();

            if (_userRepository.GetAll().Contains(user))
            {
                ICollection<Post> userPToAdd = user.posts;

                foreach (Post pToAdd in userPToAdd)
                {
                    timelinePosts.Add(pToAdd);
                }

                //for each friend, get all posts, add to list,
                foreach (User friend in user.friends)
                {
                    ICollection<Post> pToAdd = friend.posts;

                    foreach (Post friendPToAdd in pToAdd)
                    {
                        timelinePosts.Add(friendPToAdd);
                    }
                }
            }
            else
            {
                //exception to throw - might need to add new exception 
                throw new EntityNotFoundException();
            }

            //return the list
            return timelinePosts;
        }

        public void Reply(Post _post, string UserInput, User _user)
        {
            if (_postRepository.GetAll().Contains(_post))
            {
                if (_userRepository.GetAll().Contains(_user))
                {
                    commentLogic.AddComment(UserInput, _user, _post);
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

        public void LikePost(Post _post)
        {
            //post likes go up by 1
            _post.likes = _post.likes + 1;
            _postRepository.Save();
        }

        //public void SharePost(Post _post, User user)
        //{
        //    WriteUserPost(_post.postId, _post.title, _post.language, _post.code, _post.content, user);
        //}
    }

}
