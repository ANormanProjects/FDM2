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

        public PostLogic(Repository<Post> postRepository, Repository<User> userRepository, Repository<Group> groupRepository ,Repository<Comment> commentRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _commentRepository = commentRepository;
            commentLogic = new CommentLogic(_postRepository, _commentRepository, _userRepository);
        }

        public PostLogic(CommentLogic CommentLogic, Repository<Post> postRepository, Repository<User> userRepository)
        {
            _postRepository = postRepository;
            commentLogic = CommentLogic;
            _userRepository = userRepository;
        }

        public PostLogic(Repository<Post> postRepository, Repository<Comment> commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            commentLogic = new CommentLogic(_postRepository, _commentRepository, _userRepository);
        }      

        public PostLogic(SocialNetworkDataModel context)
        {
            _postRepository = new Repository<Post>(context);
            _userRepository = new Repository<User>(context);
        }


        /// <summary>
        /// Adds a Group Post object to the Repository after checking the arguments are valid
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="language"></param>
        /// <param name="code"></param>
        /// <param name="content"></param>
        public virtual void WriteGroupPost(int id, string title, string language, string code, string content, Group group)
        {
            if (title != null && language != null && code != null && content != null)
            {
                if (_groupRepository.GetAll().Contains(group, new GenericCompare<Group>(u => u.groupID)))
                {
                    GroupPost postToWrite = new GroupPost();
                    postToWrite.title = title;
                    postToWrite.language = language;
                    postToWrite.code = code;
                    postToWrite.content = content;
                    postToWrite.group = group;
                    postToWrite.time = DateTime.Now;

                    _postRepository.Insert(postToWrite);
                    _postRepository.Save();
                }
                else
                {
                    throw new EntityNotFoundException();
                }      
            }
            else
            {
                throw new EmptyInputException();
            }
        }

        /// <summary>
        /// Adds a User Post object to the Repository after checking the arguments are valid
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="language"></param>
        /// <param name="code"></param>
        /// <param name="content"></param>
        public virtual void WriteUserPost(int id, string title, string language, string code, string content, User user)
        {
            if (title != null && language != null && code != null && content != null)
            {
                if (_userRepository.GetAll().Contains(user, new GenericCompare<User>(u => u.username)))
                {
                    UserPost postToWrite = new UserPost();
                    postToWrite.title = title;
                    postToWrite.language = language;
                    postToWrite.code = code;
                    postToWrite.content = content;
                    postToWrite.user = user;
                    postToWrite.time = DateTime.Now;

                    _postRepository.Insert(postToWrite);
                    _postRepository.Save();
                }
                else
                {
                    throw new EntityNotFoundException();
                } 
            }
            else
            {
                throw new EmptyInputException();
            }

            
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
                ICollection<UserPost> userPToAdd = user.posts;

                foreach (Post pToAdd in userPToAdd)
                {
                    timelinePosts.Add(pToAdd);
                }

                //for each friend, get all posts, add to list,
                foreach (User friend in user.friends)
                {
                    ICollection<UserPost> pToAdd = friend.posts;

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

        /// <summary>
        /// Add a new comment to a specified post
        /// </summary>
        /// <param name="_post"></param>
        /// <param name="UserInput"></param>
        /// <param name="_user"></param>
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

        /// <summary>
        /// A a like to a specific post
        /// </summary>
        /// <param name="_post"></param>
        public void LikePost(Post _post)
        {
            if (_postRepository.GetAll().Contains(_post, new GenericCompare<Post>(p => p.postId)))
            {
                //post likes go up by 1
                _post.likes = _post.likes + 1;
                _postRepository.Save();
            }
            else
            {
                throw new EntityNotFoundException();
            }                
        }

        public Post GetPost(int postId)
        {
            Post post = _postRepository.First(p => p.postId == postId);

            if ( post == null )
            {
                throw new EntityNotFoundException();
            }
            else
            {
                return post;
            }

        }

    }

}
