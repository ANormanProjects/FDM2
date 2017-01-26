using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgieMVVM.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        private string _location;

        public string location
        {
            get { return _location; }
            set
            {

                _location = value;
                OnPropertyChanged("location");
            }
        }

        public NavigationViewModel()
        {
            location = "Pages/Welcome.xaml";
        }

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

        //NAVIGATION

        public void NavigateToWelcome()
        {
            //Access Navigation View Model
            NavigationViewModel navVM =
                App.Current.MainWindow.DataContext as NavigationViewModel;

            //Change the location to pagetwo.xaml
            navVM.location = "Pages/Welcome.xaml";
        }

        public void NavigateToListOfAllUsers()
        {
            //Access Navigation View Model
            NavigationViewModel navVM =
                App.Current.MainWindow.DataContext as NavigationViewModel;

            //Change The Location
            navVM.location = "Pages/ListAllUsers.xaml";
        }

        public void NavigateToAddUser()
        {
            //Access Navigation View Model
            NavigationViewModel navVM =
                App.Current.MainWindow.DataContext as NavigationViewModel;

            //Change The Location
            navVM.location = "Pages/AddUser.xaml";
        }

        public void NavigateToRemoveUser()
        {
            //Access Navigation View Model
            NavigationViewModel navVM =
                App.Current.MainWindow.DataContext as NavigationViewModel;

            //Change The Location
            navVM.location = "Pages/RemoveUser.xaml";
        }
    }
}
