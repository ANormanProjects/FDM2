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

        public GroupAccountLogic(PostLogic PostLogic)
        {
            postLogic = PostLogic;
        }

        public void AddUserToGroup(Group group, User user)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserFromGroup(Group group, User User)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsersInGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public void WritePost(int id, string title, string language, string code, string content, Group group)
        {
            throw new NotImplementedException();
        }

        public List<GroupPost> GetAllPostsInGroup(Group group)
        {
            throw new NotImplementedException();
        }

    }
}
