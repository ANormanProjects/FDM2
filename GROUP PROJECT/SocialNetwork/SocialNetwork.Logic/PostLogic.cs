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
        private Repository<Comment> _commentRepository;
        CommentLogic commentLogic;

        // String Restrictions (number of characters)
        public int maxContentLength { get; set; }
        public int minContentLength { get; set; }
        public int maxTitleLength { get; set; }
        public int minTitleLength { get; set; }
        public int maxCodeLength { get; set; }
        public int minCodeLength { get; set; }


        public PostLogic(Repository<Post> postRepository, Repository<User> userRepository, Repository<Comment> commentRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            commentLogic = new CommentLogic(_postRepository, _commentRepository, _userRepository);

            maxContentLength = 255;
            minContentLength = 0;
            maxTitleLength = 100;
            minTitleLength = 0;
            maxCodeLength = 255;
            minCodeLength = 0;
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
        public void WriteGroupPost(int id, string title, string language, string code, string content)
        {

            GroupPost postToWrite = new GroupPost();
            postToWrite.title = title;
            postToWrite.language = language;
            postToWrite.code = code;
            postToWrite.content = content;

            _postRepository.Insert(postToWrite);
        }

        /// <summary>
        /// Adds a User Post object to the Repository after checking the arguments are valid
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="language"></param>
        /// <param name="code"></param>
        /// <param name="content"></param>
        public void WriteUserPost(int id, string title, string language, string code, string content)
        {

            UserPost postToWrite = new UserPost();
            postToWrite.title = title;
            postToWrite.language = language;
            postToWrite.code = code;
            postToWrite.content = content;

            _postRepository.Insert(postToWrite);

        }

        /// <summary>
        /// Returns a list of posts made by the User and the Users friends
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Post> ViewTimeline(User user)
        {
            List<Post> timelinePosts = new List<Post>();

            if (user != null)
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
            if (user == null) 
            {
                //exception to throw - might need to add new exception 
                throw new EntityNotFoundException();
            }

            //return the list
            return timelinePosts;
        }

        public void Reply(Post _post, string UserInput, User _user)
        {
            //Comment commentToAdd = new Comment();
            //commentToAdd.content = UserInput;

            //if (UserInput != null) 
            //{
            //    _post.comments.Add(commentToAdd);
            //}
            //if (UserInput == null) 
            //{
            //    //error message, throw empty input exception
            //    throw new EmptyInputException();
            //}
            //if (UserInput.Count<char>() > maxContentLength) 
            //{
            //    //error message, throw exceedspecifiedlimit exception
            //    throw new InputExceedsSpecifiedLimitException();                
            //} 
            

            commentLogic.addComment(UserInput, _user, _post);
        }

        public void LikePost(Post _post)
        {
            //post likes go up by 1
            _post.likes += 1;
        }

        public void SharePost(Post _post)
        {
            throw new NotImplementedException();
        }
    }

}
