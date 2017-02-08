using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Web;

namespace SocialNetwork.Logic
{
    [ServiceContract]

    public interface ISearchLogic
    {
        [OperationContract]
        List<User> SearchForUserByName(string name);

        [OperationContract]
        IUser SearchForUserById(int id);

        [OperationContract]
        List<Post> SearchForCode(string codeLanguage);
    }
}
