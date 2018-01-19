using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LolApp.ViewModel
{
    // Code based on code written by Josh Smith in an article from the Febuary 2009 issue of the MSDN Magazine, Volume 24 No. 2
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute) : this(execute, null) { }       // constructor when command is always able to execute
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)   // constructor if condition is needed for command to execute
        {
            if (execute == null) { throw new ArgumentNullException("execute"); }
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);             // always returns true if there is no canExecute predicate
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter) { _execute(parameter); }
    }
}
