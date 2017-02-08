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
        Repository<User> userRepo;

        public SearchLogic(Repository<Post> PostRepo, Repository<User> UserRepo)
        {
            postRepo = PostRepo;
            userRepo = UserRepo;
        }

        public SearchLogic()
        {
            postRepo = new Repository<Post>();
            userRepo = new Repository<User>();
        }

        public List<User> SearchForUserByName(string name)
        {            
            List<User> userList = userRepo.Search(x => x.fullName.ToUpper().Contains(name.ToUpper()));

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
            List<Post> searchedPosts = postRepo.Search(x => x.language.ToUpper().Contains(codeLanguage.ToUpper()));

            if (searchedPosts.Count() > 0)
            {
                return searchedPosts.ToList();
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        //public List<T> searchEngine(string searchString)
        //{
        //    List<IUser> uResult = new List<IUser>();

        //    List<Post> pResult = new List<Post>();

        //    if (_userRepository.GetAll().Contains(searchString))
        //    {
        //        result = SearchForUserByName(searchString);
        //    }

        //    return result;
        //}

        public bool CheckIfSearchTermInUserDataBase(string searchTerm)
        {
            foreach (User user in userRepo.GetAll())
            {
                if (user.fullName.ToUpper().Contains(searchTerm.ToUpper()))
                {
                    return true;
                }
                
            }
            return false;

        }

        public bool CheckIfSearchTermInPostDataBase(string searchTerm)
        {
            foreach (Post post in postRepo.GetAll())
            {
                if (post.language.ToUpper().Contains(searchTerm.ToUpper()))
                {
                    return true;
                }

            }
            return false;

        }
    }
}
