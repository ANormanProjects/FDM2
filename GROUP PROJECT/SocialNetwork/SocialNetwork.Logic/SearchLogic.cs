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

        public SearchLogic(Repository<Post> PostRepo, Repository<IUser> UserRepo)
        {
            postRepo = PostRepo;
            userRepo = UserRepo;
        }

        public List<IUser> SearchForUserByName(string name)
        {
            IEnumerable<IUser> userList = userRepo.Search(x => x.fullName.ToUpper() == name.ToUpper());

            return userList.ToList();
        }

        public IUser SearchForUserById(int id)
        {
            IUser searchedUser = userRepo.First(x => x.userId == id);

            return searchedUser;
        }

        public List<string> SearchForCode(string codeLanguage)
        {
            throw new NotImplementedException();
        }
    }
}
