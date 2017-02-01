using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SocialNetwork.MVVM.ViewModel
{
    public class EditViewModel : BaseViewModel
    {
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
        public EditViewModel()
        {

        }

        public void Edit()
        {

        }
    }
}
