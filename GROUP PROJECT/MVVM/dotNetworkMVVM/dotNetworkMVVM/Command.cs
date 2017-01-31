using System;
using System.Diagnostics;
using System.Windows.Input;

namespace dotNetworkMVVM
{
    public class Command : ICommand
    {
        private readonly Action _execute;               //DELEGATE storing a method
        private readonly Func<bool> _canExecute;        //Storing a Func
        public event EventHandler CanExecuteChanged;    //Check CanExecute

        public Command(Action execute, Func<bool> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentException("Execute was null");
            }

            _execute = execute;
            _canExecute = canExecute ?? (() => true); //?? short hand if statement
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            try { return _canExecute(); }
            catch { return false; }
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
            {
                return;
            }

            try { _execute(); }
            catch { Debugger.Break(); }
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged.Invoke(this, EventArgs.Empty);
        }
    }
}
