using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SocialNetwork.MVVM.ViewModel
{
    public class AddViewModel : BaseViewModel
    {
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

        public AddViewModel()
        {

        }

        public void Add()
        {

        }
    }

}
