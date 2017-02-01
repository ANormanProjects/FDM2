using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SocialNetwork.MVVM.ViewModel
{
    public class ListAllUsersViewModel : BaseViewModel
    {
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

        }

        public void ListAllUsers()
        {

        }
    }
}
