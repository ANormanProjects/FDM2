using System.Windows.Input;

namespace dotNetworkMVVM.ViewModels
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


        //NAVIGATION COMMANDS

        private ICommand _navigateWelcomeCommand;
        public ICommand navigateWelcomeCommand
        {
            get
            {
                if (_navigateWelcomeCommand == null)
                {
                    _navigateWelcomeCommand = new Command(NavigateToWelcomePage);
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

        private ICommand _navigateEditUserCommand;
        public ICommand navigateEditUserCommand
        {
            get
            {
                if (_navigateEditUserCommand == null)
                {
                    _navigateEditUserCommand = new Command(NavigateToAddUser);
                }
                return _navigateEditUserCommand;
            }
            set { _navigateEditUserCommand = value; }
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

        private ICommand _navigateSettingsCommand;
        public ICommand navigateSettingsCommand
        {
            get
            {
                if (_navigateSettingsCommand == null)
                {
                    _navigateSettingsCommand = new Command(NavigateToSettings);
                }
                return _navigateSettingsCommand;
            }
            set { _navigateSettingsCommand = value; }
        }

        //APP NAVIGATION

        public void NavigateToWelcomePage()
        {
            NavigationViewModel navVM = 
                App.Current.MainWindow.DataContext as NavigationViewModel;

            navVM.location = "Pages/Welcome.xaml";
        }

        public void NavigateToListOfAllUsers()
        {
            NavigationViewModel navVM =
                App.Current.MainWindow.DataContext as NavigationViewModel;

            navVM.location = "Pages/ListAllUsers.xaml";
        }

        public void NavigateToAddUser()
        {
            NavigationViewModel navVM =
                App.Current.MainWindow.DataContext as NavigationViewModel;

            navVM.location = "Pages/Add.xaml";
        }

        public void NavigateToEditUser()
        {
            NavigationViewModel navVM =
                App.Current.MainWindow.DataContext as NavigationViewModel;

            navVM.location = "Pages/Edit.xaml";
        }

        public void NavigateToRemoveUser()
        {
            NavigationViewModel navVM =
                App.Current.MainWindow.DataContext as NavigationViewModel;

            navVM.location = "Pages/Remove.xaml";
        }

        public void NavigateToSettings()
        {
            NavigationViewModel navVM =
                App.Current.MainWindow.DataContext as NavigationViewModel;

            navVM.location = "Pages/Settings.xaml";
        }
    }
}
