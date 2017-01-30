using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{    
    public class PostLogic : IPostLogic
    {
        Repository<Post> PostRepository; 
    
        public PostLogic()	
        {
            PostRepository = new Repository<Post>();
        }

        public void WriteGroupPost(int id, string title, string language, string code, string content)
        {
                       
            GroupPost postToWrite = new GroupPost();
            postToWrite.group.groupID = id;
            postToWrite.title = title;
            postToWrite.language = language;
            postToWrite.code = code;
            postToWrite.content = content;

            PostRepository.Insert(postToWrite);
           
        }
        
        public void WriteUserPost(int id, string title, string language, string code, string content)
        {

            UserPost postToWrite = new UserPost();
            postToWrite.user.userId = id;
            postToWrite.title = title;
            postToWrite.language = language;
            postToWrite.code = code;
            postToWrite.content = content;

            PostRepository.Insert(postToWrite);

        }

        public List<Post> ViewTimeline(User user)
        {
            
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
