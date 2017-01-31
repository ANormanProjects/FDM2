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
        void WriteUserPost(int id, string title, string language, string code, string content);
        void WriteGroupPost(int id, string title, string language, string code, string content);
        List<Post> ViewTimeline(User user);
        void Reply(Post _post, string UserInput);
        void LikePost(Post _post);
        void SharePost(Post _post);
    }
}
