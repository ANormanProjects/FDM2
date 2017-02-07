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

        public SearchLogic()
        {
            postRepo = new Repository<Post>();
            userRepo = new Repository<IUser>();
        }

        public List<IUser> SearchForUserByName(string name)
        {            
            List<IUser> userList = userRepo.Search(x => x.fullName.ToUpper() == name.ToUpper());

            if(userList.Count() > 0)
            {
                return userList.ToList();
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        public IUser SearchForUserById(int id)
        {           
            if (id > 0)
            {
                IUser searchedUser = userRepo.First(x => x.userId == id);
                if (searchedUser != null)
                {
                    return searchedUser;
                }
                else
                {
                    throw new EntityNotFoundException();
                }
            }
            else
            {
                throw new IntegerMustBeGreaterThanZeroException();
            }

        }

        public List<Post> SearchForCode(string codeLanguage)
        {
            List<Post> searchedPosts = postRepo.Search(x => x.language.ToUpper() == codeLanguage.ToUpper());

            if (searchedPosts.Count() > 0)
            {
                return searchedPosts.ToList();
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        //public void searchMachine(string searchString)
        //{
        //    List<Post> result = new List<Post>();

        //    if (_userRepository.GetAll().Contains(searchString))
        //    {
        //        result = SearchForUserByName(searchString);
        //    }

        //    return result;
        //}
    }
}
