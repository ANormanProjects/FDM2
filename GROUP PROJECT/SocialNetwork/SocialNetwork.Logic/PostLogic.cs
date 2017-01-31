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

        // String Restrictions
        public int maxContentLength { get; set; }
        public int minContentLength { get; set; }
        public int maxTitleLength { get; set; }
        public int minTitleLength { get; set; }
        public int maxCodeLength { get; set; }
        public int minCodeLength { get; set; }


        public PostLogic(Repository<Post> postRepository, Repository<User> userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public void WriteGroupPost(int id, string title, string language, string code, string content)
        {

            GroupPost postToWrite = new GroupPost();
            postToWrite.title = title;
            postToWrite.language = language;
            postToWrite.code = code;
            postToWrite.content = content;

            _postRepository.Insert(postToWrite);

        }

        public void WriteUserPost(int id, string title, string language, string code, string content)
        {

            UserPost postToWrite = new UserPost();
            postToWrite.title = title;
            postToWrite.language = language;
            postToWrite.code = code;
            postToWrite.content = content;

            _postRepository.Insert(postToWrite);

        }

        public List<Post> ViewTimeline(User user)
        {
            List<Post> timelinePosts = new List<Post>();

            //Find user in database use first
            User userFound = _userRepository.First(u => u.username == user.username);
            //if not null, getallposts
            if (userFound != null)
            {
                List<Post> userPToAdd = _postRepository.GetAll().ToList();

                foreach (Post pToAdd in userPToAdd)
                {
                    timelinePosts.Add(pToAdd);
                }

                //for each friend, get all posts, add to list,
                foreach (User friend in userFound.friends)
                {
                    List<Post> pToAdd = _postRepository.GetAll().ToList();

                    foreach (Post friendPToAdd in pToAdd)
                    {
                        timelinePosts.Add(friendPToAdd);
                    }
                }
            }

            //return the list
            return timelinePosts;
        }

        public void Reply(Post _post, string UserInput)
        {

            
            
        }

        public void LikePost()
        {
            throw new NotImplementedException();
        }

        public void SharePost()
        {
            throw new NotImplementedException();
        }
    }
}
