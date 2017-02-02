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
    public class WPFViewModel : BaseViewModel
    {
        public Repository<User> _userRepository { get; set; }
        public UserAccountLogic userAccLogic { get; set; }

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
        private UserAccountLogic userAccountLogic;
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

        private ICommand _addUserCommand;
        public ICommand addUserCommand
        {
            get
            {
                if (_addUserCommand == null)
                {
                    _addUserCommand = new Command(Add);
                }
                return _addUserCommand;
            }
            set { _addUserCommand = value; }
        }

        private ICommand _editUserCommand;
        public ICommand editUserCommand
        {
            get
            {
                if (_editUserCommand == null)
                {
                    _editUserCommand = new Command(Edit);
                }
                return _editUserCommand;
            }
            set { _editUserCommand = value; }
        }

        private ICommand _removeUserCommand;
        public ICommand removeUserCommand
        {
            get
            {
                if (_removeUserCommand == null)
                {
                    _removeUserCommand = new Command(Remove);
                }
                return _removeUserCommand;
            }
            set { _removeUserCommand = value; }
        }

        //Live
        public WPFViewModel()
        {
            _userRepository = new Repository<User>();
            userAccLogic = new UserAccountLogic(_userRepository);
            user = new ObservableCollection<User>(userAccLogic.GetAllUserAccounts());
        }

        //Test
        public WPFViewModel(UserAccountLogic userAccountLogic)
        {
            this.userAccountLogic = userAccountLogic;
        }

        public void ListAllUsers()
        {
            userAccLogic.GetAllUserAccounts();
        }

        public void Add()
        {
            User newUser = new User();

            newUser.username = username;
            newUser.fullName = fullName;
            newUser.gender = gender;
            newUser.role = role;
            newUser.password = password;

            userAccLogic.Register(newUser);
        }

        public void Edit()
        {
            User editUser = new User();

            editUser.username = username;

            string newName = fullName;
            string newGender = gender;
            string newRole = role;
            string newPassword = password;

            userAccLogic.EditUser(editUser, newName, newGender, newRole, newPassword);
        }

        public void Remove()
        {

        }
       

    }
}
