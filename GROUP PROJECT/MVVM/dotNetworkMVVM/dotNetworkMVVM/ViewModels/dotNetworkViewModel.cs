using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace dotNetworkMVVM.ViewModels
{
    public class dotNetworkViewModel : BaseViewModel
    {
        //PROPS + MODEL/REPO/LOGIC

        //private ObservableCollection<Sample> _sample;

        //public ObservableCollection<Sample> sample
        //{
        //    get { return _sample; }
        //    set
        //    {
        //        _sample = value;
        //        OnPropertyChanged("sample");
        //    }
        //}

        //COMMANDS FOR METHODS

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

        //LIVE CTOR
        public dotNetworkViewModel()
        {

        }

        //TEST CTOR
        //public dotNetworkViewModel()
        //{

        //}


        //METHODS - Logic

        public void ListAllUsers()
        {

        }

        public void Add()
        {

        }

        public void Edit()
        {

        }

        public void Remove()
        {

        }

    }
}
