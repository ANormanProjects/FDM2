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
        Repository<User> userRepo;

        IPostLogic postLogic; 

        public GroupAccountLogic(Repository<Group> groupRepository, Repository<Post> PostRepo, Repository<Comment> CommentRepo, Repository<User> UserRepo)
        {
            groupRepo = groupRepository;
            postRepo = PostRepo;
            commentRepo = CommentRepo;
            userRepo = UserRepo;

            postLogic = new PostLogic(postRepo, commentRepo);
        }

        public GroupAccountLogic(PostLogic PostLogic, Repository<Group> groupRepository)
        {
            postLogic = PostLogic;
            groupRepo = groupRepository;
        }

        public virtual Group ViewGroupInfo(string groupName)
        {
            Group groupToDisplay = groupRepo.First(c => c.groupName == groupName);
            if (groupToDisplay != null)
            {
                return groupToDisplay;
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        public void CreateGroup(Group group)
        {
            if (groupRepo.GetAll().Contains(group))
            {
                throw new EntityAlreadyExistsException();
            }
            else
            {
                groupRepo.Insert(group);
            }
        }

        public void RemoveGroup(Group group)
        {
            if (groupRepo.GetAll().Contains(group))
            {
                groupRepo.Remove(group);
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        public void AddUserToGroup(Group group, User user)
        {
            if (groupRepo.GetAll().Contains(group))
            {
                if (userRepo.GetAll().Contains(user))
                {
                    if (group.usersInGroup.Contains(user))
                    {
                        throw new EntityAlreadyExistsException();
                    }
                    else
                    {
                        group.usersInGroup.Add(user);
                    }
                }
                else
                {
                    throw new EntityNotFoundException();
                }
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        public void RemoveUserFromGroup(Group group, User user)
        {
            if (groupRepo.GetAll().Contains(group))
            {
                if (userRepo.GetAll().Contains(user))
                {
                    group.usersInGroup.Remove(user);
                }
                else
                {
                    throw new EntityNotFoundException();
                }
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        public virtual List<User> GetAllUsersInGroup(Group group)
        {
            List<User> users = new List<User>();
            if (groupRepo.GetAll().Contains(group))
            {
                foreach (User user in group.usersInGroup)
                {
                    users.Add(user);
                }
                return users;
            }
            else
            {
                throw new EntityNotFoundException();
            } 
        }

        public void WritePost(int id, string title, string language, string code, string content, Group group)
        {
            if (groupRepo.GetAll().Contains(group))
            {
                postLogic.WriteGroupPost(id, title, language, code, content, group);
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        public virtual List<GroupPost> GetAllPostsInGroup(Group group)
        {
            List<GroupPost> groupPosts = new List<GroupPost>();
            if (groupRepo.GetAll().Contains(group))
            {
                foreach (GroupPost groupPost in group.groupWall)
                {
                    groupPosts.Add(groupPost);
                }
                return groupPosts;
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }        

        public virtual List<Group> GetAllGroups()
        {
            List<Group> groups = new List<Group>();
            groups = groupRepo.GetAll();

            return groups;
        }
    }
}
