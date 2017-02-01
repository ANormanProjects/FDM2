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
        void WriteUserPost(int id, string title, string language, string code, string content, User user);
        void WriteGroupPost(int id, string title, string language, string code, string content, Group group);
        List<Post> ViewTimeline(User user);
        void Reply(Post _post, string UserInput, User _user);
        void LikePost(Post _post);
        void SharePost(Post _post);
    }
}
