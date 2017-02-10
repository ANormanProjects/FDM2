using SocialNetwork.DataAccess;
using SocialNetwork.Logic;
using SocialNetwork.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SocialNetwork.MVVM
{
    public class GroupWPFViewModel : BaseViewModel
    {

        public Repository<Group> groupRepo { get; set; }
        public Repository<Post> postRepo { get; set; }
        public Repository<Comment> commentRepo { get; set; }
        public Repository<User> userRepo { get; set; }
        public GroupAccountLogic groupAccLogic { get; set; }
        public UserAccountLogic userAccLogic { get; set; }

        private ObservableCollection<Group> _group;

        public ObservableCollection<Group> group
        {
            get { return _group; }
            set
            {
                _group = value;
                OnPropertyChanged("group");
            }
        }

        private ObservableCollection<User> _user;

        public ObservableCollection<User> user
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("user");
            }
        }

        private int _groupID;
        public int groupID
        {
            get { return _groupID; }
            set 
            { 
                _groupID = value;
                OnPropertyChanged("groupID");
            }
        }

        private string _groupName;
        public string groupName
        {
            get { return _groupName; }
            set 
            { 
                _groupName = value;
                OnPropertyChanged("groupName");
            }
        }

        private User _owner;
        public User owner
        {
            get { return _owner; }
            set 
            { 
                _owner = value;
                OnPropertyChanged("owner");
            }
        }

        private ICommand _listAllGroupsCommand;
        public ICommand listAllGroupsCommand
        {
            get
            {
                if (_listAllGroupsCommand == null)
                {
                    _listAllGroupsCommand = new Command(ListAllGroups);
                }
                return _listAllGroupsCommand;
            }
            set { _listAllGroupsCommand = value; }
        }

        private ICommand _addGroupCommand;
        public ICommand addGroupCommand
        {
            get
            {
                if (_addGroupCommand == null)
                {
                    _addGroupCommand = new Command(AddGroup);
                }
                return _addGroupCommand;
            }
            set { _addGroupCommand = value; }
        }

        private ICommand _removeGroupCommand;
        public ICommand removeGroupCommand
        {
            get
            {
                if (_removeGroupCommand == null)
                {
                    _removeGroupCommand = new Command(RemoveGroup);
                }
                return _removeGroupCommand;
            }
            set { _removeGroupCommand = value; }
        }

        //Live
        public GroupWPFViewModel()
        {
            groupRepo = new Repository<Group>();
            postRepo = new Repository<Post>();
            commentRepo = new Repository<Comment>();
            userRepo = new Repository<User>();
            groupAccLogic = new GroupAccountLogic(groupRepo, postRepo, commentRepo, userRepo);
            userAccLogic = new UserAccountLogic(userRepo);
            group = new ObservableCollection<Group>(groupAccLogic.GetAllGroups());
            user = new ObservableCollection<User>(userAccLogic.GetAllUserAccounts());
        }

        public GroupWPFViewModel(GroupAccountLogic groupAccountLogic)
        {
            groupAccLogic = groupAccountLogic;
        }

        public void ListAllGroups()
        {
            List<Group> repoGroup = groupAccLogic.GetAllGroups();
            group = new ObservableCollection<Group>(repoGroup);
        }

        public void AddGroup()
        {
            try
            {
                Group newGroup = new Group();

                newGroup.groupName = groupName;

                groupAccLogic.CreateGroup(newGroup);

                return;
            }

            catch (EntityAlreadyExistsException)
            {
                return;
            }

        }

        public void RemoveGroup()
        {
            try
            {
                Group removeGroup = new Group();
                    
                removeGroup = groupAccLogic.ViewGroupInfo(groupName);

                groupAccLogic.RemoveGroup(removeGroup);

                return;
            }

            catch(EntityNotFoundException)
            {
                return;
            }
        }
    }
}
