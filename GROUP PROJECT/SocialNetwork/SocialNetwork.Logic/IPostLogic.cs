using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    [ServiceContract]

    public interface IPostLogic
    {
        [OperationContract]
        void WriteUserPost(int id, string title, string language, string code, string content, User user);

        [OperationContract]
        void WriteGroupPost(int id, string title, string language, string code, string content, Group group);

        [OperationContract]
        List<Post> ViewTimeline(User user);

        [OperationContract]
        void Reply(Post _post, string UserInput, User _user);

        [OperationContract]
        void LikePost(Post _post);
        
    }
}
