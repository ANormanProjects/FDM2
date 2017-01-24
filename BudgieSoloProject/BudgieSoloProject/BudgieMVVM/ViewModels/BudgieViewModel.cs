using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgieMVVM.ViewModels
{
    public class BudgieViewModel : BaseViewModel
    {
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

        private ICommand _changeMessageCommand;
        public ICommand changeMessageCommand
        {
            get 
            {
                if(_changeMessageCommand == null)
                {
                    _changeMessageCommand = new Command(ChangeText, CanChangeText);
                }
                return _changeMessageCommand; }
            set { _changeMessageCommand = value; }
        }

        private bool CanChangeText()
        {
            //Put logic in here to test whether the button can be clicked.
            return true;
        }

        private void ChangeText()
        {
            message = "Today is Friday";
        }
        
        public BudgieViewModel()
        {
            message = "Today is Tuesday!";
        }
    }
}
