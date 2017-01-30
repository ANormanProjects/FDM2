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
        Repository<Post> postRepository;
        Repository<User> userRepository;
    
        public PostLogic()	
        {
            postRepository = new Repository<Post>();
            userRepository = new Repository<User>();
        }

        public void WriteGroupPost(int id, string title, string language, string code, string content)
        {
                       
            GroupPost postToWrite = new GroupPost();
            postToWrite.group.groupID = id;
            postToWrite.title = title;
            postToWrite.language = language;
            postToWrite.code = code;
            postToWrite.content = content;

            postRepository.Insert(postToWrite);
           
        }
        
        public void WriteUserPost(int id, string title, string language, string code, string content)
        {

            UserPost postToWrite = new UserPost();
            postToWrite.user.userId = id;
            postToWrite.title = title;
            postToWrite.language = language;
            postToWrite.code = code;
            postToWrite.content = content;

            postRepository.Insert(postToWrite);

        }

        public List<Post> ViewTimeline(User user)
        {
            IEnumerable<Post> timelinePosts;

            //Find user in database use first
            User userFound = userRepository.First(u => u.username == user.username);
            //if not null, getallposts
            if (userFound != null)
            {
                timelinePosts = postRepository.GetAll();
            }
                        
            //for each friend, get all posts, add to list,
            foreach (User user in collection)
            {
                
            }

            //return the list
            return new List<Post>();
        }

        public void Reply(Post _post, string UserInput)
        {
            throw new NotImplementedException();
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
