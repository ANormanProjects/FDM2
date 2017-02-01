using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SocialNetwork.MVVM.ViewModel
{
    public class RemoveViewModel : BaseViewModel
    {
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
        
        public RemoveViewModel()
        {

        }
        
        public void Remove()
        {

        }
    }
}
