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

        private string _myValue;
        public string myValue
        {
            get
            {
                return _myValue;
            }
            set
            {
                _myValue = value;
            }
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
            budgieUser = new ObservableCollection<BudgieUser>(budgieUserRepo.GetAllBudgieUsers());
            budgieUserLogic = new BudgieUserLogic(budgieUserRepo);
        }

        private void ListAllBudgieUser()
        {
            budgieUserRepo.GetAllBudgieUsers();
        }

        private void AddBudgieUser()
        {
            //budgieUserLogic.RegisterUser();
        }

        private void RemoveBudgieUser()
        {
            //budgieUserLogic.RemoveUser();
        }

        private void NavigateToListOfAllUsers()
        {
            //Access Navigation View Model
            NavigationViewModel navVM =
                App.Current.MainWindow.DataContext as NavigationViewModel;

            //Change the location to pagetwo.xaml
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
