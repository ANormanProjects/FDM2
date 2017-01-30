using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    public class SearchLogic : ISearchLogic
    {
        Repository<Post> postRepo;
        Repository<IUser> userRepo;

        public SearchLogic()
        {

        }

        public List<User> SearchForUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public User SearchForUserById(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> SearchForCode(string codeLanguage)
        {
            throw new NotImplementedException();
        }
    }
}
