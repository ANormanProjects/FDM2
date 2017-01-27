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
        public BudgieUserRepository budgieUserRepo { get; set; }
        public AccountRepository accountRepo { get; set; }
        public BudgieUserLogic budgieUserLogic { get; set; }

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

        //Real
        public BudgieViewModel()
        {
            budgieUserRepo = new BudgieUserRepository(budgieDBCFModel);
            accountRepo = new AccountRepository(budgieDBCFModel);          
            budgieUserLogic = new BudgieUserLogic(budgieUserRepo, accountRepo);
            budgieUser = new ObservableCollection<BudgieUser>(budgieUserLogic.GetAllBudgieUsers());
        }

        //Test
        public BudgieViewModel(BudgieUserLogic budgieUserLogic)
        {
            this.budgieUserLogic = budgieUserLogic;
        }

        public void ListAllBudgieUser()
        {
            budgieUserLogic.GetAllBudgieUsers();
        }

        public void AddBudgieUser()
        {
            BudgieUser newUser = new BudgieUser();
            newUser.firstName = firstName;
            newUser.lastName = lastName;
            newUser.emailAddress = emailAddress;
            newUser.dob = dob;
            newUser.password = password;

            budgieUserLogic.RegisterUser(newUser);            
        }

        public void RemoveBudgieUser()
        {
            BudgieUser removeUser = new BudgieUser();
            removeUser.emailAddress = emailAddress;

            budgieUserLogic.RemoveUser(removeUser);
        }

       
    }
}
