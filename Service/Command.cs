using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service
{
    public class DelegateCommand<T> : ICommand where T : class
    {
        public event EventHandler CanExecuteChanged;
        private Action<T> callCack;
        public DelegateCommand(Action<T> canExecute)
        {
            callCack = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            callCack.Invoke(parameter as T);
        }
    }
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action callCack;
        public DelegateCommand(Action canExecute)
        {
            callCack = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            callCack.Invoke();
        }
    }
}
