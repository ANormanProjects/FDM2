using BudgieDatabaseLayer;
using BudgieLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgieMVVM.ViewModels
{
    public class BudgieViewModel : BaseViewModel
    {
        BudgieDBCFModel budgieDBCFModel = new BudgieDBCFModel();
        BudgieUserRepository budgieUserRepo;
        AccountRepository accountRepo;
        BudgieUserLogic budgieUserLogic;

        private ObservableCollection<BudgieUser> _budgieUser;

        public ObservableCollection<BudgieUser> budgieUser
        {
            get { return _budgieUser; }
            set
            {
                _budgieUser = value;
                OnPropertyChanged("budgieUser");
            }
        }

        private string _message;
        public string message
        {
            get { return _message; }
            set 
            {
                _message = value;
                OnPropertyChanged("message");
            }
        }

        private string _firstName;
        public string firstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged("firstName");
            }
        }

        private string _lastName;
        public string lastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged("lastName");
            }
        }

        private string _emailAddress;
        public string emailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                _emailAddress = value;
                OnPropertyChanged("emailAddress");
            }
        }

        private string _dob;
        public string dob
        {
            get
            {
                return _dob;
            }
            set
            {
                _dob = value;
                OnPropertyChanged("dob");
            }
        }

        private string _password;
        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("password");
            }
        }

        //Make one more for each property

        private ICommand _navigateWelcomeCommand;
        public ICommand navigateWelcomeCommand
        {
            get
            {
                if (_navigateWelcomeCommand == null)
                {
                    _navigateWelcomeCommand = new Command(NavigateToWelcome);
                }
                return _navigateWelcomeCommand;
            }
            set { _navigateWelcomeCommand = value; }
        }



        private ICommand _navigateListOfAllUsersCommand;
        public ICommand navigateListOfAllUsersCommand
        {
            get
            {
                if (_navigateListOfAllUsersCommand == null)
                {
                    _navigateListOfAllUsersCommand = new Command(NavigateToListOfAllUsers);
                }
                return _navigateListOfAllUsersCommand;
            }
            set { _navigateListOfAllUsersCommand = value; }
        }

        private ICommand _navigateAddUserCommand;
        public ICommand navigateAddUserCommand
        {
            get
            {
                if (_navigateAddUserCommand == null)
                {
                    _navigateAddUserCommand = new Command(NavigateToAddUser);
                }
                return _navigateAddUserCommand;
            }
            set { _navigateAddUserCommand = value; }
        }

        private ICommand _navigateRemoveUserCommand;
        public ICommand navigateRemoveUserCommand
        {
            get
            {
                if (_navigateRemoveUserCommand == null)
                {
                    _navigateRemoveUserCommand = new Command(NavigateToRemoveUser);
                }
                return _navigateRemoveUserCommand;
            }
            set { _navigateRemoveUserCommand = value; }
        }

        private ICommand _ListAllBudgieUserCommand;
        public ICommand ListAllBudgieUserCommand
        {
            get
            {
                if (_ListAllBudgieUserCommand == null)
                {
                    _ListAllBudgieUserCommand = new Command(ListAllBudgieUser);
                }
                return _ListAllBudgieUserCommand;
            }
            set { _ListAllBudgieUserCommand = value; }
        }

        private ICommand _addBudgieUserCommand;
        public ICommand addBudgieUserCommand
        {
            get
            {
                if (_addBudgieUserCommand == null)
                {
                    _addBudgieUserCommand = new Command(AddBudgieUser);
                }
                return _addBudgieUserCommand;
            }
            set { _addBudgieUserCommand = value; }
        }

        private ICommand _removeBudgieUserCommand;
        public ICommand removeBudgieUserCommand
        {
            get
            {
                if (_removeBudgieUserCommand == null)
                {
                    _removeBudgieUserCommand = new Command(RemoveBudgieUser);
                }
                return _removeBudgieUserCommand;
            }
            set { _removeBudgieUserCommand = value; }
        }

        public BudgieViewModel()
        {
            budgieUserRepo = new BudgieUserRepository(budgieDBCFModel);
            accountRepo = new AccountRepository(budgieDBCFModel);
            budgieUser = new ObservableCollection<BudgieUser>(budgieUserRepo.GetAllBudgieUsers());
            budgieUserLogic = new BudgieUserLogic(budgieUserRepo, accountRepo);
        }

        private void ListAllBudgieUser()
        {
            budgieUserRepo.GetAllBudgieUsers();
        }

        private void AddBudgieUser()
        {
            BudgieUser newUser = new BudgieUser();
            newUser.firstName = firstName;
            newUser.lastName = lastName;
            newUser.emailAddress = emailAddress;
            newUser.dob = dob;
            newUser.password = password;

            budgieUserLogic.RegisterUser(newUser);
            
        }

        private void RemoveBudgieUser()
        {
            BudgieUser removeUser = new BudgieUser();
            removeUser.emailAddress = emailAddress;

            budgieUserLogic.RemoveUser(removeUser);
        }

        private void NavigateToWelcome()
        {
            //Access Navigation View Model
            NavigationViewModel navVM =
                App.Current.MainWindow.DataContext as NavigationViewModel;

            //Change the location to pagetwo.xaml
            navVM.location = "Pages/Welcome.xaml";
        }

        private void NavigateToListOfAllUsers()
        {
            //Access Navigation View Model
            NavigationViewModel navVM =
                App.Current.MainWindow.DataContext as NavigationViewModel;

            //Change The Location
            navVM.location = "Pages/ListAllUsers.xaml";
        }

        private void NavigateToAddUser()
        {
            //Access Navigation View Model
            NavigationViewModel navVM =
                App.Current.MainWindow.DataContext as NavigationViewModel;

            //Change The Location
            navVM.location = "Pages/AddUser.xaml";
        }

        private void NavigateToRemoveUser()
        {
            //Access Navigation View Model
            NavigationViewModel navVM =
                App.Current.MainWindow.DataContext as NavigationViewModel;

            //Change The Location
            navVM.location = "Pages/RemoveUser.xaml";
        }
    }
}
