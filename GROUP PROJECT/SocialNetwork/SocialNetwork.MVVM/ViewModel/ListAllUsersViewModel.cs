using SocialNetwork.DataAccess;
using SocialNetwork.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SocialNetwork.MVVM.ViewModel
{
    public class ListAllUsersViewModel : BaseViewModel
    {
        Repository<User> _userRepository;
        UserAccountLogic userAccLogic;

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

        private int _userId;
        public virtual int userId
        {
            get { return _userId; }
            set 
            { 
                _userId = value;
                OnPropertyChanged("userId");
            }
        }

        private string _username;
        public string username
        {
            get { return _username; }
            set 
            {
                _username = value;
                OnPropertyChanged("username");
            }
        }

        private string _password;
        public string password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                OnPropertyChanged("password");
            }
        }

        private string _fullName;
        public string fullName
        {
            get { return _fullName; }
            set 
            { 
                _fullName = value;
                OnPropertyChanged("fullname");
            }
        }

        private string _gender;
        public string gender
        {
            get { return _gender; }
            set 
            { 
                _gender = value;
                OnPropertyChanged("gender");
            }
        }

        private string _role;
        public string role
        {
            get { return _role; }
            set 
            { 
                _role = value;
                OnPropertyChanged("role");
            }
        }

        private ICommand _ListAllUsersCommand;
        public ICommand ListAllUsersCommand
        {
            get
            {
                if (_ListAllUsersCommand == null)
                {
                    _ListAllUsersCommand = new Command(ListAllUsers);
                }
                return _ListAllUsersCommand;
            }
            set { _ListAllUsersCommand = value; }
        }

        public ListAllUsersViewModel()
        {
            _userRepository = new Repository<User>();
            userAccLogic = new UserAccountLogic(_userRepository);
            user = new ObservableCollection<User>(userAccLogic.GetAllUserAccounts());
        }

        public void ListAllUsers()
        {
            userAccLogic.GetAllUserAccounts();
        }
    }
}
