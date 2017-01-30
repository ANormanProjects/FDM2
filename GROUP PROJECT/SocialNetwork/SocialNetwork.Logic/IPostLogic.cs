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
}
