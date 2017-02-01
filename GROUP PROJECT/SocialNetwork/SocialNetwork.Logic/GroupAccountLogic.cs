using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    public class GroupAccountLogic : IGroupAccountLogic
    {
        Repository<Group> groupRepo;
        Repository<Post> postRepo;
        Repository<Comment> commentRepo;

        IPostLogic postLogic; 

        public GroupAccountLogic(Repository<Group> groupRepository, Repository<Post> PostRepo, Repository<Comment> CommentRepo)
        {
            groupRepo = groupRepository;
            postRepo = PostRepo;
            commentRepo = CommentRepo;

            postLogic = new PostLogic(postRepo, commentRepo);
        }
    
        public void addUserToGroup(DataAccess.User user)
        {
 	        throw new NotImplementedException();
        }

        public void RemoveUserFromGroup(DataAccess.User User)
        {
    	    throw new NotImplementedException();
        }

        public List<DataAccess.User> GetAllUsersInGroup()
        {
            throw new NotImplementedException();
        }
    }
}
