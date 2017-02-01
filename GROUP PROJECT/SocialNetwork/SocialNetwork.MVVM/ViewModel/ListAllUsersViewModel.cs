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
