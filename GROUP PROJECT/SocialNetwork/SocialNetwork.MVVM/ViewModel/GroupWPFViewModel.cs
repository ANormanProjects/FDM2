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

        //Live
        public GroupWPFViewModel()
        {
            groupRepo = new Repository<Group>();
            postRepo = new Repository<Post>();
            commentRepo = new Repository<Comment>();
            userRepo = new Repository<User>();
            groupAccLogic = new GroupAccountLogic(groupRepo, postRepo, commentRepo, userRepo);
            group = new ObservableCollection<Group>(groupAccLogic.GetAllGroups());
        }

        public GroupWPFViewModel(GroupAccountLogic groupAccountLogic)
        {
            this.groupAccLogic = groupAccountLogic;
        }

        public void ListAllGroups()
        {
            List<Group> repoGroup = groupAccLogic.GetAllGroups();
            group = new ObservableCollection<Group>(repoGroup);
        }

        public void AddGroup()
        {

        }
    }
}
