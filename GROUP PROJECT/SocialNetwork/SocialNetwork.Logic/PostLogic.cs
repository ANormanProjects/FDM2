using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    public interface IPostLogic
    {
        void WritePost(int id, string title, string language, string code, string content);
        List<Post> ViewTimeline(User user);
        void Reply(Post _post, string UserInput);
        void LikePost();
        void SharePost();
    }
    
    public class PostLogic : IPostLogic
    {
        Repository<Post> PostRepository; 
    
        public PostLogic()	
        {
            PostRepository = new Repository<Post>();
        }

        public void WritePost(int id, string title, string language, string code, string content)
        {
            Post postToWrite = new Post();
            postToWrite.user.userId = id;
            postToWrite.title = title;
            postToWrite.language = language;
            postToWrite.code = code;
            postToWrite.content = content;

            PostRepository.Insert(postToWrite);
           
        }

        public List<Post> ViewTimeline(User user)
        {
            throw new NotImplementedException();
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
