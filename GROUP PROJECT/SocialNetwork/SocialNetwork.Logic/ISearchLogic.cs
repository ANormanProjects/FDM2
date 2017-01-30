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
        List<User> SearchForUserByName(string name);
        User SearchForUserById(int id);
        List<string> SearchForCode(string codeLanguage);
    }
}
