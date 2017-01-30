using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    public interface ISearchLogic
    {
        List<IUser> SearchForUserByName(string name);
        IUser SearchForUserById(int id);
        List<string> SearchForCode(string codeLanguage);
    }
}
